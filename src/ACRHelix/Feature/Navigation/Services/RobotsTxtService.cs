using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Sites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Navigation.Services
{
  public class RobotsTxtService : SiteHostResolverService
  {

    private const string DefaultContent = "User-agent: *\r\nDisallow: \r\n";
    private const string DisallowAll = "User-agent: *\r\nDisallow: /\r\n";

    private const string RobotsTxtTemplateID = "{506A3534-354E-44F6-BEB0-F57D0CC7A641}";
    private const string RobotsTxtFieldID = "{02EDC660-3F2D-496E-B96E-86D1B3A1FBDA}";

    public RobotsTxtService(string host) : base(host)
    {

    }

    public string GetRobotsContent()
    {
      var robotsDisallow = bool.Parse(Sitecore.Configuration.Settings.GetSetting("RobotsTxtDisallowAll", "true"));
      if (robotsDisallow)
      {
        return DisallowAll;
      }
      else
      {
        var startItem = GetCurrentSiteRoot();
        if (startItem != null)
        {
          string robots = GetSitecoreRobotsContent(startItem);
          if (!string.IsNullOrWhiteSpace(robots))
          {
            return robots;
          }
        }
      }
      return DefaultContent;
    }

    private string GetSitecoreRobotsContent(Item startItem)
    {
      string robotsContent = string.Empty;

      string query = $"fast:{startItem.Paths.FullPath}//*[@@templateid='{RobotsTxtTemplateID}']";

      var items = Database.SelectItems(query);
      if (items != null)
      {
        if (items.Length > 0)
        {
          string robot = items[0].Fields[RobotsTxtFieldID].Value;
          if (!string.IsNullOrWhiteSpace(robot))
          {
            if (robot.Contains("{DefaultSitemap}"))
            {
              var Url = HttpContext.Current.Request.Url;
              string sitemapXml = $"{Url.Scheme}://{Url.Host}/sitemap.xml";
              robot = robot.Replace("{DefaultSitemap}", sitemapXml);
            }
            robotsContent = robot;
          }
        }
      }
      return robotsContent;
    }
  }
}
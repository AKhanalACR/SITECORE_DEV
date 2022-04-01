using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Foundation.SitecoreExtensions.Extensions;
using Sitecore.Links;
using Sitecore.Sites;
using Sitecore.Web;
using System;
using System.Linq;

namespace ACRHelix.Foundation.CustomLinkProvider
{
  public class ACRHelixLinkProvider : LinkProvider
  {
    public override string GetItemUrl(Item item, UrlOptions options)
    {
      if (item.TemplateName == "ExternalLink")
      {
        LinkField link = item.Fields["Link"];
        return link != null ? link.Url : String.Empty;
      }
      if (item.Paths.IsMediaItem)
      {
        return RemoveSslPort(Sitecore.Resources.Media.MediaManager.GetMediaUrl(item));
      }

      //options.AlwaysIncludeServerUrl = false;
      //var matchedSite = GetSiteContext(item);
      //if (matchedSite != null)
      //{
      //  options.Site = matchedSite;
      //}
      //options.SiteResolving = true;

      return RemoveSslPort(base.GetItemUrl(item, options));
    }

    public static string RemoveSslPort(string url)
    {
      if (!string.IsNullOrWhiteSpace(url))
      {
        if (url.Contains(":443"))
        {
          url = url.Replace(":443", string.Empty);
        }
      }
      return url;
    }

    private SiteContext GetSiteContext(Item item)
    {
      var allSites = Sitecore.Configuration.Factory.GetSiteInfoList();

      int website = allSites.FindIndex(x => x.Name == "website");
      int lastSite = allSites.FindIndex(x => x.Name == "scheduler");

      if (website > 0 && lastSite > 0 && lastSite > website)
      {
        allSites = allSites.Skip(website).Take(lastSite - website).ToList();

        SiteInfo currSite = null;
        if (item.Paths.IsMediaItem)
        {
          //media can just default to website, all media urls are the same
          return new SiteContext(allSites.First(x => x.Name == "website"));
        }
        else
        {
          foreach (var site in allSites)
          {
            //match site by rootpath
            if (item.Paths.FullPath.StartsWith(site.RootPath))
            {
              currSite = site;
            }
          }
        }
        if (currSite != null)
        {
          //return correct SiteContext
          return new SiteContext(currSite);
        }
        else
        {
          return new SiteContext(allSites.First(x => x.Name == "website"));
        }
      }
      return null;
    }
  }
}
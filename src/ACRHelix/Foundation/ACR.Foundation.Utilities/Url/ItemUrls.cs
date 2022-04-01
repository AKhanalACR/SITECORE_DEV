using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Sitecore.Foundation.SitecoreExtensions.Extensions;

namespace ACR.Foundation.Utilities.Url
{
  public static class ItemUrls
  {
    private static readonly ID DashboardTemplateID = new ID("{27EE47CE-DD24-4572-84C8-94FBBC2E3EF8}");
    private static readonly ID LoginTemplateID = new ID("{F212EE88-6B77-4EC0-8734-56C760B28DDA}");
    
    //site name login page template id pair
    private static readonly List<KeyValuePair<string, ID>> SiteLoginTemplateIDList = new List<KeyValuePair<string, ID>>()
    {
        new KeyValuePair<string, ID>("RADPAC", new ID("{05E6DD0A-37EF-404C-BD56-B3FC593E6D84}"))
    };

    public static string GetDashboardUrl()
    {
        return GetFirstItemUrlWithTemplate(DashboardTemplateID);
    }

    public static string GetLoginPageUrl()
    {
      return GetFirstItemUrlWithTemplate(LoginTemplateID);
    }

    //Gets login page url for specifice site
    public static string GetLoginPageUrl(string sitename)
    {
      if(!string.IsNullOrWhiteSpace(SiteLoginTemplateIDList.Single(x => x.Key.ToLower() == sitename.ToLower()).Key))
      {
          var tempID = SiteLoginTemplateIDList.Single(x => x.Key.ToLower() == sitename.ToLower()).Value;
          return GetFirstItemUrlWithTemplate(tempID);
      }
      return null;
    }

    public static string GetFirstItemUrlWithTemplate(ID templateID)
    {
      var db = Sitecore.Context.Database;
      if (db == null)
      {
        db = Sitecore.Configuration.Factory.GetDatabase("web");
      }
      var item = db.SelectItems(string.Format("fast:/sitecore/content//*[@@templateid='{0}']", templateID.ToString())).FirstOrDefault();
      if (item != null)
      {
        return item.GetCanonicalUrl();
      }
      return "/ACR-Dashboard";
    }


  }
}
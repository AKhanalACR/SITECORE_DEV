using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Sites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Navigation.Services
{
  public class SiteHostResolverService
  {
    protected Database Database { get; set; }
    private string Host { get; set; }
    protected Site Site { get; set; }

    public SiteHostResolverService(string host)
    {
      Host = host;
      Database = Sitecore.Configuration.Factory.GetDatabase("web");
      Site = GetCurrentSite();
    }




    public Site GetCurrentSite()
    {
      foreach (var site in Sitecore.Sites.SiteManager.GetSites())
      {
        string hostName = site.Properties["hostName"];
        if (hostName != null)
        {
          if (Host.Equals(hostName, StringComparison.OrdinalIgnoreCase))
          {
            return site;
          }
        }
      }
      return null;
    }

    public Item GetCurrentSiteRoot()
    {
      if (Site != null)
      {
        string rootPath = Site.Properties["rootPath"];
        return Database.GetItem(rootPath);
      }
      return null;
    }
  }
}
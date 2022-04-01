using Sitecore.Data.Items;
using Sitecore.Foundation.SitecoreExtensions.Extensions;
using Sitecore.Links;
using Sitecore.SharedSource.ItemUrlHelper.Model;
using Sitecore.Sites;
using Sitecore.Web;
using System;

namespace Sitecore.SharedSource.ItemUrlHelper.ProcessUrl
{
  public class GetUrl : AProcessUrl
  {
    public GetUrl(UrlContext urlContext) : base(urlContext)
    {
    }

    public override void Process()
    {
      SiteInfo site = ResolveSite(UrlContext.Item);
      SiteContext siteContext = new SiteContext(site);

      UrlOptions options = LinkManager.GetDefaultUrlOptions();
      options.Site = siteContext;
      options.LanguageEmbedding = LanguageEmbedding.Never;
      options.AlwaysIncludeServerUrl = false;
      options.SiteResolving = true;

      //if (UrlContext.Item.Languages.Count() > 1)
      //{
      //  options.LanguageEmbedding = LanguageEmbedding.AsNeeded;
      //}

      SiteUrl siteUrlItem = SiteUrl.GetSiteInfo_ByName(site.Name);
      if (siteUrlItem == null)
      {
        UrlContext.Messages.Add("Unable to find mapping of site to url.");
        return;
      }

      string host = siteUrlItem.Url;
      UrlContext.Url = LinkManager.GetItemUrl(UrlContext.Item, options);

      if (options.Site.Name == "shell")
      {
        string url = UrlContext.Url;
        //string shellReplace = "/sitecore/shell/";
        //url = url.Replace("/sitecore/shell", "").ToLower();

        url = url.ReplaceStringIgnoreCase("/sitecore/shell/", "", StringComparison.OrdinalIgnoreCase, false);

        var trimRootPath = siteContext.RootPath.ReplaceStringIgnoreCase("/sitecore/content/", "", StringComparison.OrdinalIgnoreCase, false) + "/";

        url = url.ReplaceStringIgnoreCase(trimRootPath, "", StringComparison.OrdinalIgnoreCase, false);

        UrlContext.Url = "/" + url;
      }


      if (string.IsNullOrEmpty(UrlContext.Url))
      {
        UrlContext.Messages.Add("No Url was returned from Sitecore.");
        return;
      }

      if (UrlContext.Url.Contains("http"))
      {
        Uri uriContext = new Uri(UrlContext.Url);
        // get only the item path
        UrlContext.Url = uriContext.AbsolutePath;
      }

      //remove the 443 port for secured Sitecore instance (if any)
      UrlContext.Url = UrlContext.Url.Replace(":443", "");

      //verify we are not adding the host to a url that already contains a host
      if (!UrlContext.Url.ToLower().Contains(host.ToLower()))
      {
        UrlContext.Url = string.Format("{0}{1}", host, UrlContext.Url);
      }

      //get device item
      if (UrlContext.Device != null && !string.IsNullOrEmpty(UrlContext.Device.QueryString))
      {
        char appender = UrlContext.Url.Contains("?") ? '&' : '?';
        UrlContext.Url = string.Format("{0}{1}{2}", UrlContext.Url, appender, UrlContext.Device.QueryString);
      }
    }



    /// <summary>
    /// Find proper site based on the passed item and fall back to default website
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    private SiteInfo ResolveSite(Item item)
    {
      SiteInfo siteInfo = GetSite(item);
      if (siteInfo != null)
      {
        return siteInfo;
      }

      //fall back to default
      siteInfo = SiteContextFactory.GetSiteInfo("website");
      if (siteInfo != null)
      {
        return siteInfo;
      }

      return null;
    }

    public static SiteInfo GetSite(Item item)
    {
      string str = item.Paths.FullPath.ToLower();
      foreach (SiteInfo info in SiteContextFactory.Sites)
      {
        if (!string.IsNullOrEmpty(info.HostName) && (info.StartItem != null))
        {
          //string str2 = info.RootPath + info.StartItem + "/";
          string str2 = info.RootPath + "/";
          if (str.Contains(str2.ToLower()))
          {
            return info;
          }
        }
      }
      return null;
    }


  }
}

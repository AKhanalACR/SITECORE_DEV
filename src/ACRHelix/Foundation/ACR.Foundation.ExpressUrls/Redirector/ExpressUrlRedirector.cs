using ACR.Foundation.ExpressUrls.Cache;
using ACR.Foundation.ExpressUrls.Data;
using ACR.Foundation.ExpressUrls.Logger;
using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ACR.Foundation.ExpressUrls.Redirector
{
  public class ExpressUrlRedirector
  {

    private const string MapCacheKey = "ExpressUrlMaps";
    private const string DictionaryCacheKey = "ExpressUrlDictionary";

    private ExpressUrlCache _cache;

    private ExpressUrlCache ExpressUrlCache
    {
      get
      {
        if (_cache == null)
        {
          _cache = new ExpressUrlCache(StringUtil.ParseSizeString("10MB"));
        }
        return _cache;
      }
    }



    public Dictionary<string, string> GetUrlDictionaryFromCache()
    {
      var dictionary = ExpressUrlCache.Get(DictionaryCacheKey) as Dictionary<string, string>;
      if (dictionary != null)
      {
        return dictionary;
      }
      else
      {
        var dict = new Dictionary<string, string>();
        ExpressUrlCache.Set(DictionaryCacheKey, dict);
        //HttpContext.Current.Cache.Add(DictionaryCacheKey, dict, null, DateTime.UtcNow.AddMinutes(60), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Default, null);
        return dict;
      }
    }

    public string GetUrlRedirectFromCache(string url, string site)
    {
      var dictionary = GetUrlDictionaryFromCache();

      if (dictionary.ContainsKey(url + site))
      {
        return dictionary[url + site];
      }
      return null;
    }

    public void UpdateDictionaryCache(string url, string site, string targetUrl)
    {
      var dict = GetUrlDictionaryFromCache();
      string key = url + site;
      if (dict.ContainsKey(key))
      {
        dict[key] = targetUrl;
      }
      else
      {
        dict.Add(key, targetUrl);
      }
      ExpressUrlCache.Set(DictionaryCacheKey, dict);
      //HttpContext.Current.Cache.Add(DictionaryCacheKey, dict, null, DateTime.UtcNow.AddMinutes(60), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Default, null);
    }


   

    public bool TryPerformRedirect(HttpContext myContext)
    {
      string rawUrl = myContext.Request.RawUrl;
      if (rawUrl.LastIndexOf(';') > 0)
      {
        Uri uri = new Uri(rawUrl.Substring(rawUrl.LastIndexOf(';') + 1));
        rawUrl = uri.AbsolutePath;
      }
      try
      {
        string str = FindRedirectUrl(rawUrl);

        if (!string.IsNullOrEmpty(str))
        {
          //if (ExpressUrlResolver.ServerRedirect)
          //{
          //  myContext.Server.TransferRequest(str);
          //}
          //else if (!ExpressUrlResolver.UseTemporaryRedirect)
          //{
          //  myContext.Response.Status = "301 Moved Permanently";
          //  myContext.Response.AddHeader("Location", str);
          //  myContext.Response.End();
          //}
          //else
          //{
          myContext.Response.Redirect(str);
          //}
          return true;
        }
      }
      catch (Exception exception1)
      {

        string[] message = new string[] { "Url Redirect failed for page: ", rawUrl, ": \r\n", exception1.Message, "\r\n", exception1.StackTrace };
        ExpressUrlLogger.Logger.Error(string.Concat(message), exception1);
      }
      return false;
    }

    public List<UrlMap> GetUrlMaps()
    {
      var cacheMaps = ExpressUrlCache.Get(MapCacheKey) as List<UrlMap>;
        // HttpContext.Current.Cache[MapCacheKey] as List<UrlMap>;
      if (cacheMaps != null)
      {
        return cacheMaps;
      }
      else
      {
        using (ExpressUrlDatabase db = new ExpressUrlDatabase())
        {
          var urlMaps = db.UrlMaps.ToList();
          ExpressUrlCache.Set(MapCacheKey, urlMaps);
          //HttpContext.Current.Cache.Add(MapCacheKey, urlMaps, null, DateTime.UtcNow.AddMinutes(60), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Default, null);
          return urlMaps;
        }
      }
    }

    public string FindRedirectUrl(string sUrl)
    {
      if (Context.Site == null)
      {
        return null;
      }
      var fromCache = GetUrlRedirectFromCache(sUrl, Context.Site.Name);

      if (fromCache == null)
      {

        List<string> urls = new List<string>();
        urls.Add(sUrl);

        var url2 = sUrl.Replace(" ", "%20");
        urls.Add(url2);



        using (ExpressUrlDatabase db = new ExpressUrlDatabase())
        {
          foreach (var url in urls)
          {
            var url1 = url.Contains("?") ? url.Substring(0, url.IndexOf('?')) : url;
            var urlMaps = db.UrlMaps.Where(x => x.sourceUrl == url1 && (x.siteName == Context.Site.Name || x.siteName == "" || x.siteName == null));

            foreach (var map in urlMaps)
            {
              Item redirectItem = Sitecore.Context.Database.GetItem(map.destSitecoreId);

              var queryString = !string.IsNullOrEmpty(map.queryString) ? map.queryString : "";
              if (redirectItem != null)
              {
                string finalRedirect = LinkManager.GetItemUrl(redirectItem) + queryString;
                if (!string.IsNullOrWhiteSpace(map.destUrl))
                {
                    finalRedirect = map.destUrl + LinkManager.GetItemUrl(redirectItem) + queryString;
                }
                UpdateDictionaryCache(url, Context.Site.Name, finalRedirect);
                return finalRedirect;
              }
            }
          }
        }
      }
      else
      {
        return fromCache;
      }
      return null;
    }

    private static string WildcardStringToRegex(string pattern)
    {
      return string.Concat("^", Regex.Escape(pattern).Replace("\\*", ".*"), "$");
    }
  }
}
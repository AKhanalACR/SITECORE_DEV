using ACR.Foundation.ExpressUrls.Cache;
using ACR.Foundation.ExpressUrls.Data;
using Sitecore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACR.Foundation.ExpressUrls.Redirector
{
  public class PageNotFoundRedirector
  {
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

    public const string PageNotFoundCacheKey = "PageNotFoundUrls";


    public bool PageNotFoundRedirect(HttpContext context)
    {
      var notFoundUrls = ExpressUrlCache.Get(PageNotFoundCacheKey) as List<PageNotFoundRedirect>;

      if (notFoundUrls == null)
      {
        notFoundUrls = GetRedirects();
      }

      var url = context.Request.Url.LocalPath.ToLower();
      var query = context.Request.Url.Query;

      var fullUrl = context.Request.Url.PathAndQuery.ToLower();

      
      //try exact match

      var redirect = notFoundUrls.FirstOrDefault(x => x.NotFoundUrl == fullUrl);

      if (redirect != null) {
        string rdir = redirect.NewUrl;
        if (!string.IsNullOrWhiteSpace(query))
        {
          if (!rdir.Contains("?"))
          {
            rdir = rdir + query;
          }
        }
        context.Response.RedirectPermanent(rdir);
        return true;
      }

      url = url.TrimEnd(new char[] { '/' });

      redirect = notFoundUrls.FirstOrDefault(x => x.NotFoundUrl == url);
      if (redirect != null)
      {
        context.Response.RedirectPermanent(redirect.NewUrl + query);
        return true;
      }

      if (url.Contains("news-publications"))
      {
        context.Response.RedirectPermanent("/Media-Center");
      }

      if (url.Contains("residents-and-fellows"))
      {
        context.Response.RedirectPermanent("/Member-Resources/rfs");
        return true;
      }
      if (url.Contains("coding-source-list"))
      {
        context.Response.RedirectPermanent("/Advocacy-and-Economics/Coding-Source");
      }


      return false;
    }

    private List<PageNotFoundRedirect> GetRedirects()
    {
      List<PageNotFoundRedirect> redirects = new List<PageNotFoundRedirect>();

      using (ExpressUrlDatabase db = new ExpressUrlDatabase())
      {
        redirects = db.PageNotFoundRedirects.ToList();
      }
      ExpressUrlCache.Set(PageNotFoundRedirector.PageNotFoundCacheKey, redirects);
      return redirects;
    }

  }
}
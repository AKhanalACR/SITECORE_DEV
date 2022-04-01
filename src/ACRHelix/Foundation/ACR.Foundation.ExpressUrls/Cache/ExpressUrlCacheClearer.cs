using Sitecore.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACR.Foundation.ExpressUrls.Cache
{
  public class ExpressUrlCacheClearer
  {
    public void ClearCache(object sender, EventArgs args)
    {
      var cache = CacheManager.FindCacheByName(ExpressUrlCache.CacheName);
      if (cache != null)
      {
        cache.Clear();
      }

      
    }
  }
}
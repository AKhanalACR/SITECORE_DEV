using Sitecore.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACR.Foundation.ExpressUrls.Cache
{
  public class ExpressUrlCache : CustomCache
  {
    public const string CacheName = "ExpressUrlCache";

    public ExpressUrlCache(long size) : base(CacheName, size)
    {

    }
    public object Get(string key)
    {
      return GetObject(key);
    }

    public void Set(string key, object value)
    {
      SetObject(key, value);
    }
  }
}
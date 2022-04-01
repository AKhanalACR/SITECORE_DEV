using Glass.Mapper.Sc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Foundation.CustomCoveo.Services
{
  public sealed class CoveoSitecoreService
  {
    private static SitecoreService service = null;

    private static readonly object slock = new object();

    public static SitecoreService Service
    {
      get
      {
        lock (slock)
        {
          if (service == null)
          {
            service = new SitecoreService("web");
          }
          return service;
        }
      }
    }
  }
}
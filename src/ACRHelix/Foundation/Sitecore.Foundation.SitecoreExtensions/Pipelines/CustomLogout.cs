using Sitecore.Diagnostics;
using Sitecore.Pipelines.Logout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Foundation.SitecoreExtensions.Pipelines
{
  public class CustomLogout
  {
      // Methods
      public void Process(LogoutArgs args)
      {
      if (HttpContext.Current != null)
      {
        var cookie = HttpContext.Current.Response.Cookies["website#sc_mode"];
        if (cookie != null)
        {
          cookie.Expires = DateTime.Now.AddDays(-1);
        }
      }
      }
    





  }
}
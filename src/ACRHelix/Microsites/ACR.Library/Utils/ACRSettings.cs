using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.Library.Utils
{
  public static class ACRSettings
  {
    public static string AcrGoogleAnalyticsAccount
    {
      get { return ConfigurationManager.AppSettings["Acr.GoogleAnalytics.Account"]; }
    }

    public static string AcrGoogleTagManagerAccount
    {
      get { return ConfigurationManager.AppSettings["Acr.GoogleTagManager.Account"]; }
    }

    public static string AirpGoogleAnalyticsAccount
    {
      get { return ConfigurationManager.AppSettings["Airp.GoogleAnalytics.Account"]; }
    }
  }
}

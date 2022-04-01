using ACR.Foundation.CookieBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace ACR.Foundation.CookieBot.CookieBotModule
{
  public class CookieBotHttpModule : IHttpModule
  {



    //probably want to move this to a config file or sitecore item
    private static string[] PreferenceCookiesToRemove = new string[] { "test_pref" };
    private static string[] StatisticCookiesToRemove = new string[] { "SC_ANALYTICS_GLOBAL_COOKIE", "SC_ANALYTICS_SESSION_COOKIE" };
    private static string[] MarketingCookiesToRemove = new string[] { "__sharethis_cookie_test__" };



    public void Init(HttpApplication context)
    {
      context.EndRequest += new EventHandler(ProcessCookiesEndRequest);
    }



    public void Dispose()
    {
      //throw new NotImplementedException();
    }

    public static CookieBotSettings CookiesAllowed()
    {
      CookieBotSettings settings = new CookieBotSettings();

      var context = HttpContext.Current;
      if (context != null)
      {
        HttpRequest request = context.Request;
        if (request != null)
        {
          HttpCookie CurrentUserConsent = request.Cookies["CookieConsent"];

          if (CurrentUserConsent != null)
          {
            if (!string.IsNullOrWhiteSpace(CurrentUserConsent.Value))
            {
              switch (CurrentUserConsent.Value)
              {
                case "0":
                  //The user has not accepted cookies - set strictly necessary cookies only
                  break;

                case "-1":
                  //The user is not within a region that requires consent - all cookies are accepted
                  settings.MarketingCookiesAllowed = settings.PreferenceCookiesAllowed = settings.StatisticCookiesAllowed = true;
                  break;

                default: //The user has accepted one or more type of cookies

                  //Read current user consent in encoded JavaScript format
                  JavaScriptSerializer CookieConsentSerializer = new JavaScriptSerializer();
                  dynamic CookieConsent = CookieConsentSerializer.Deserialize<object>(HttpUtility.UrlDecode(CurrentUserConsent.Value));

                  if (CookieConsent["preferences"])
                  {
                    //Current user accepts all cookies
                    settings.PreferenceCookiesAllowed = true;
                  }
                  if (CookieConsent["statistics"])
                  {
                    settings.StatisticCookiesAllowed = true;
                  }
                  if (CookieConsent["marketing"])
                  {
                    settings.PreferenceCookiesAllowed = true;
                  }
                  break;
              }
            }
          }
        }
      }
      return settings;
    }

    private void RemoveCookies(IEnumerable<string> cookieNames, HttpResponse response, HttpRequest request)
    {
      List<string> cookies = new List<string>();

      //add cookies already in response
      for (int i = 0; i < response.Cookies.Count; i++)
      {
        string name = response.Cookies[i].Name;
        if (cookieNames.Contains(name))
        {
          cookies.Add(name);
        }
      }

      //add cookies from request
      for (int i = 0; i < request.Cookies.Count; i++)
      {
        string name = request.Cookies[i].Name;
        if (cookieNames.Contains(name))
        {
          cookies.Add(name);
        }
      }
      //remove cookies from response
      foreach (var cook in cookies.Distinct())
      {
        HttpCookie cookie = new HttpCookie(cook);
        cookie.Expires = DateTime.Now.AddYears(-1);
        response.Cookies.Add(cookie);
      }
    }

    private void ProcessCookiesEndRequest(object s, EventArgs e)
    {
      HttpApplication app = (HttpApplication)s;
      var response = app.Response;
      var request = app.Request;

      if (response != null)
      {

        if (request != null)
        {
          if (request.Cookies != null)
          {

            var settings = CookiesAllowed();
            if (!settings.MarketingCookiesAllowed)
            {
              RemoveCookies(MarketingCookiesToRemove, response, request);
            }
            if (!settings.PreferenceCookiesAllowed)
            {
              RemoveCookies(PreferenceCookiesToRemove, response, request);
            }
            if (!settings.StatisticCookiesAllowed)
            {
              RemoveCookies(StatisticCookiesToRemove, response, request);
            }

          }
        }
      }
    }


  }
}
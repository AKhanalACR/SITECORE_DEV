using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Diagnostics;

namespace ACR.Foundation.Utilities.Cookies
{
  public static class CookieUtil
  {

    public const string LoggerName = "CookieUtil";

    public static HttpCookie GetCookie(string cookieName)
    {
      //Anonymous users "cart" is stored in a cookie
      if (HttpContext.Current == null)
      {
        Log.Error("CookieUtil.GetCookie: Could not execute method because HttpContext.Current was null. CookieName: " + cookieName, LoggerName);
        return null;
      }
      HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
      return cookie;
    }

    public static HttpCookie CreateCookie(string cookieName, string value, string domain)
    {
      //Anonymous users "cart" is stored in a cookie
      if (HttpContext.Current == null)
      {
        Log.Error("CookieUtil.CreateCookie: Could not execute method because HttpContext.Current was null. CookieName: " + cookieName, LoggerName);
        return null;
      }
      HttpCookie cookie = new HttpCookie(cookieName);
      cookie.Path = "/";
      cookie.HttpOnly = false;
      cookie.Value = value;
      if (!String.IsNullOrEmpty(domain))
        cookie.Domain = domain;
      HttpContext.Current.Response.Cookies.Add(cookie);

      return cookie;
    }

    public static HttpCookie CreateCookie(string cookieName, string value, string domain, DateTime expires)
    {
      //Anonymous users "cart" is stored in a cookie
      if (HttpContext.Current == null)
      {
        Log.Error("CookieUtil.CreateCookie: Could not execute method because HttpContext.Current was null. CookieName: " + cookieName, LoggerName);
        return null;
      }
      HttpCookie cookie = new HttpCookie(cookieName);
      cookie.Value = value;
      if (!String.IsNullOrEmpty(domain))
        cookie.Domain = domain;
      cookie.Expires = expires;
      HttpContext.Current.Response.Cookies.Add(cookie);

      return cookie;
    }

    public static void DeleteCookie(string cookieName)
    {
      if (HttpContext.Current == null)
      {
        Log.Error("CookieUtil.DeleteCookie: Could not execute method because HttpContext.Current was null. CookieName: " + cookieName, LoggerName);
        return;
      }

      HttpCookie cookie = new HttpCookie(cookieName);
      cookie.Value = string.Empty;
      cookie.Expires = DateTime.Now.AddDays(-1);
      HttpContext.Current.Response.Cookies.Add(cookie);
    }
  }
}
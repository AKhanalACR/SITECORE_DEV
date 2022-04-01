using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACR.Foundation.Utilities.Session
{
  public class SessionManager : ISessionManager
  {
    public T GetValue<T>(string key)
    {
      if (HttpContext.Current != null && HttpContext.Current.Session != null)
      {
        object o = HttpContext.Current.Session[key];
        if (o != null)
        {
          return (T)o;
        }
      }
      return default(T);
    }

    public object GetValue(string key)
    {
      if (HttpContext.Current != null && HttpContext.Current.Session != null)
      {
        return HttpContext.Current.Session[key];
      }
      return null;
    }

    public void SetValue(string key, object obj)
    {
      //We are storing the session in the database, so need to make sure it is serializable
      if (obj == null || obj.GetType().IsSerializable)
      {
        if (HttpContext.Current != null && HttpContext.Current.Session != null)
        {
          if (obj == null)
          {
            HttpContext.Current.Session.Remove(key);
          }
          else
          {
            HttpContext.Current.Session.Add(key, obj);
          }
        }
      }
      else
      {
        throw new Exception("Cannot store object in session because it is not serializable.");
      }
    }

    public static T GetSessionValue<T>(string key)
    {
      SessionManager manager = new SessionManager();
      return manager.GetValue<T>(key);
    }

    public static void SetSessionValue(string key, object obj)
    {
      SessionManager manager = new SessionManager();
      manager.SetValue(key, obj);
    }
  }
}
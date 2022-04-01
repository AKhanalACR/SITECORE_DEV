using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace ACR.Foundation.Utilities.Url
{
  public class UrlUtil
  {

    public static string RemoveParameterFromUrl(string url, string parameter)
    {
      try
      {
        Uri uri = new Uri(url);
        NameValueCollection parameters = HttpUtility.ParseQueryString(uri.Query);
        parameters.Remove(parameter);

        UriBuilder uriBuilder = new UriBuilder(uri.Scheme, uri.Host);
        uriBuilder.Path = uri.AbsolutePath;
        uriBuilder.Query = parameters.ToString();
        return uriBuilder.ToString();
      }
      catch
      {
        Sitecore.Diagnostics.Log.Error("Cannot remove parameter from URL: " + url, "UrlUtil");
        return url;
      }
    }

    public static string AddParameterToUrl(string url, string parameterName, string parameterValue)
    {
      try
      {
        Uri uri = new Uri(url);
        NameValueCollection parameters = HttpUtility.ParseQueryString(uri.Query);
        if (parameters[parameterName] == null)
        {
          parameters.Add(parameterName, parameterValue);
        }
        UriBuilder uriBuilder = new UriBuilder(uri.Scheme, uri.Host);
        uriBuilder.Path = uri.AbsolutePath;
        uriBuilder.Query = parameters.ToString();
        return uriBuilder.ToString();
      }
      catch
      {
        if (url.Contains("?"))
        {
          NameValueCollection parameters = HttpUtility.ParseQueryString(url.Substring(url.IndexOf('?') + 1));
          if (parameters[parameterName] == null)
          {
            parameters.Add(parameterName, parameterValue);
          }
          url = url.Substring(0, url.IndexOf('?')) + parameters.ToString();
        }
        else
        {
          NameValueCollection parameters = HttpUtility.ParseQueryString("");
          parameters.Add(parameterName, parameterValue);
          url = url + "?" + parameters.ToString();
        }
        return url;
      }
    }

    public static string CreateUrl(string baseUrl, NameValueCollection queryParams)
    {
      if ((string.IsNullOrEmpty(baseUrl) || (queryParams == null)) || (queryParams.Count == 0))
      {
        return baseUrl;
      }
      string url = baseUrl;
      if (baseUrl.Contains("?"))
      {
        url += "&";
      }
      else
      {
        url += "?";
      }
      url += queryParams.ToString();
      return url;
    }
  }
}
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Sitecore.Configuration;
using Sitecore.WordOCX.HtmlDocument;

namespace ACR.Library.Utils
{
    public class HttpUtils
    {
        /// <summary>
        /// Adds/Updates the parameter to current URL and returns the result
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="parameterValue">The parameter value.</param>
        /// <returns></returns>
        public static string AddParameterToUrl(HttpRequest request, string parameterName, string parameterValue)
        {
            string fullUrl = "http://" + request.Url.Host + request.RawUrl;
            return AddParameterToUrl(fullUrl, parameterName, parameterValue);
        }

        /// <summary>
        /// Adds/Updates the parameter to passed in URL and returns the result
        /// </summary>
        /// <param name="fullUrl">The full URL.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="parameterValue">The parameter value.</param>
        /// <returns></returns>
        public static string AddParameterToUrl(string fullUrl, string parameterName, string parameterValue)
        {
            try
            {
                Uri fullUri = new Uri(fullUrl);
                NameValueCollection queryString = HttpUtility.ParseQueryString(fullUri.Query);
                //If it already exists, replace it
                if (!string.IsNullOrEmpty(queryString[parameterName]))
                {
                    queryString[parameterName] = parameterValue;
                }
                else
                {
                    queryString.Add(parameterName, parameterValue);
                }

                UriBuilder returnUri = new UriBuilder(fullUri.Scheme, fullUri.Host);
                returnUri.Path = fullUri.AbsolutePath;
                returnUri.Query = ConstructQueryString(queryString);
                return returnUri.ToString();
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// Removes a parameter from the current URL and returns the result
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <returns></returns>
        public static string RemoveParameterFromUrl(HttpRequest request, string parameterName)
        {
            string fullUrl = "http://" + request.Url.Host + request.RawUrl;
            return RemoveParameterFromUrl(fullUrl, parameterName);
        }

        /// <summary>
        /// Adds/Updates the parameter to passed in URL and returns the result
        /// </summary>
        /// <param name="fullUrl">The full URL.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <returns></returns>
        public static string RemoveParameterFromUrl(string fullUrl, string parameterName)
        {
            try
            {
                Uri fullUri = new Uri(fullUrl);
                NameValueCollection queryString = HttpUtility.ParseQueryString(fullUri.Query);

                queryString.Remove(parameterName);

                UriBuilder returnUri = new UriBuilder(fullUri.Scheme, fullUri.Host);
                returnUri.Path = fullUri.AbsolutePath;
                returnUri.Query = ConstructQueryString(queryString);
                return returnUri.ToString();
            }
            catch
            {
                return "";
            }
        }

        public static string ClearUrlParameters(HttpRequest request)
        {
            string fullUrl = "http://" + request.Url.Host + request.RawUrl;
            return ClearUrlParameters(fullUrl);
        }

        public static string ClearUrlParameters(string fullUrl)
        {
            //This is a special case where we dont want to clear some params in preview mode
            if (State.Previewing || State.WebEditing)
            {
                List<string> keysToSkip = new List<string>();
                keysToSkip.Add("sc_itemid");
                keysToSkip.Add("sc_mode");
                keysToSkip.Add("sc_lang");
                try
                {
                    Uri fullUri = new Uri(fullUrl);
                    NameValueCollection queryString = HttpUtility.ParseQueryString(fullUri.Query);
                    NameValueCollection newQueryString = new NameValueCollection();

                    foreach (string s in queryString.Keys)
                    {
                        if (keysToSkip.Contains(s))
                        {
                            newQueryString.Add(s, queryString[s]);
                        }
                    }
                    UriBuilder returnUri = new UriBuilder(fullUri.Scheme, fullUri.Host);
                    returnUri.Path = fullUri.AbsolutePath;
                    returnUri.Query = ConstructQueryString(newQueryString);
                    return returnUri.ToString();
                }
                catch
                {
                    return "";
                }
            }
            else
            {
                try
                {
                    Uri fullUri = new Uri(fullUrl);
                    UriBuilder returnUri = new UriBuilder(fullUri.Scheme, fullUri.Host);
                    returnUri.Path = fullUri.AbsolutePath;
                    returnUri.Query = string.Empty;
                    return returnUri.ToString();
                }
                catch
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// This function takes a NameValueCollection and returns a formatted query string
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public static String ConstructQueryString(NameValueCollection parameters)
        {
            List<String> items = new List<String>();

            foreach (String name in parameters)
                items.Add(String.Concat(name, "=", System.Web.HttpUtility.UrlEncode(parameters[name])));

            return String.Join("&", items.ToArray());
        }

        /// <summary>
        /// This is a wrapper for getting url parameters.  This makes it easy to do things like cleaning 
        /// HTML tags from them to prevent cross site scripting.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public static string GetParameterValue(string parameterName, HttpRequest request)
        {
            string value = request[parameterName];
            if (!string.IsNullOrEmpty(value))
            {
                value = StripHTMLTags(value);
                return value;
            }
            else
            {
                return string.Empty;
            }
        }

        public static string StripHTMLTags(string input)
        {
            string output = Regex.Replace(input, "<.*?>", string.Empty);
            return output;
        }

    }
}


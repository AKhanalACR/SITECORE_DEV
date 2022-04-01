using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace Sitecore.Feature.XBlog.Areas.XBlog.Helpers
{
    public static class Helper
    {
        #region extensions
        /// <summary>
        /// gets a slice of a list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="startIndex"></param>
        /// <param name="maxCount"></param>
        /// <returns></returns>
        public static IEnumerable<T> Slice<T>(this IEnumerable<T> list, int startIndex, int maxCount)
        {
            return list.Skip(startIndex).Take(maxCount);
        }

        /// <summary>
        /// gets a safe substring. 
        /// ensures that the max length is not greater than the string
        /// also ensures that the string is trimmed at the end of a word
        /// </summary>
        /// <param name="text"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static string SafeSubstring(this string text, int maxLength)
        {
            return SafeSubstring(text, maxLength, false);
        }
        /// <summary>
        ///  gets a safe substring. 
        ///  ensures that the max length is not greater than the string       
        ///  also ensures that the string is trimmed at the end of a word
        /// </summary>
        /// <param name="text"></param>
        /// <param name="maxLength"></param>
        /// <param name="dots"></param>
        /// <returns></returns>
        public static string SafeSubstring(this string text, int maxLength, bool dots)
        {
            if (string.IsNullOrEmpty(text) || text.Length < maxLength)
                return text;
            int length = Math.Min(text.LastIndexOf(' ', maxLength), maxLength);
            string substring = length <= 0 ? text.Substring(0, maxLength) : text.Substring(0, length);
            return string.Format("{0}{1}", substring, dots ? "..." : string.Empty);
        }
    public static string SubstringHtml(string stringValue, int length, bool dots)
    {
      var regexAllTags = new Regex(@"<[^>]*>");
      var regexIsTag = new Regex(@"<|>");
      var regexOpen = new Regex(@"<[^/][^>]*>");
      var regexClose = new Regex(@"</[^>]*>");
      var regexAttribute = new Regex(@"<[^ ]*");

      int necessaryCount = 0;
      var stringLength = regexAllTags.Replace(stringValue, "").Length;
      if (stringLength <= length)
      {
        return stringValue;
      }
      string[] split = regexAllTags.Split(stringValue);
      string counter = "";
      foreach (string item in split)
      {
        if (counter.Length < length && counter.Length + item.Length >= length)
        {
          necessaryCount = stringValue.IndexOf(item, counter.Length) + item.Substring(0, length - counter.Length).Length;
          break;
        }
        counter += item;
      }
      var x = regexIsTag.Match(stringValue, necessaryCount);
      if (x.Value == ">")
      {
        necessaryCount = x.Index + 1;
      }
      string subs = stringValue.Substring(0, necessaryCount);
      var openTags = regexOpen.Matches(subs);
      var closeTags = regexClose.Matches(subs);
      List<string> OpenTags = new List<string>();
      foreach (var item in openTags)
      {
        string trans = regexAttribute.Match(item.ToString()).Value;

        if (trans.Last() == '>')
        {
          trans = "</" + trans.Substring(1, trans.Length - 1);
        }
        else
        {
          trans = "</" + trans.Substring(1, trans.Length - 1) + ">";
        }

        OpenTags.Add(trans);
      }
      foreach (System.Text.RegularExpressions.Match close in closeTags)
      {
        OpenTags.Remove(close.Value);
      }
      subs= string.Format("{0}{1}", subs, dots ? "..." : string.Empty); ;
      for (int i = OpenTags.Count - 1; i >= 0; i--)
      {
        subs += OpenTags[i];
      }
      return subs;
    }

    public static IHtmlString GoogleCaptcha(this HtmlHelper helper)
    {
      //var publicSiteKey = WebConfigurationManager.AppSettings["GoogleRecaptchaSiteKey"];
      var publicSiteKey = Sitecore.Configuration.Settings.GetSetting("GoogleRecaptchaSiteKey");

      var mvcHtmlString = new TagBuilder("div")
      {
        Attributes =
                {
                    new KeyValuePair<string, string>("class", "g-recaptcha"),
                    new KeyValuePair<string, string>("data-sitekey", publicSiteKey),
                    new KeyValuePair<string, string>("data-callback", "recaptcha_callback")
                }
      };

      var googleCaptchaScript = "<script src='https://www.google.com/recaptcha/api.js'></script>";
      var renderedCaptcha = mvcHtmlString.ToString(TagRenderMode.Normal);

      return MvcHtmlString.Create(string.Format("{0}{1}", googleCaptchaScript, renderedCaptcha));
    }
    public static bool ValidateCaptcha(string captchaResponse)
    {
      var urlToPost = "https://www.google.com/recaptcha/api/siteverify";
      //var secretKey = WebConfigurationManager.AppSettings["GoogleRecaptchaPrivateKey"];
      var secretKey = Sitecore.Configuration.Settings.GetSetting("GoogleRecaptchaPrivateKey");

      //var captchaResponse = filterContext.HttpContext.Request.Form["g-recaptcha-response"];

      if (string.IsNullOrWhiteSpace(captchaResponse)) //AddErrorAndRedirectToGetAction(filterContext);
        return false;

      var validateResult = ValidateFromGoogle(urlToPost, secretKey, captchaResponse);
      if (!validateResult.Success)
        return false;

      return true;
    }

    //private static void AddErrorAndRedirectToGetAction(ActionExecutingContext filterContext)
    //{

    //    filterContext.Result = new RedirectToRouteResult(filterContext.RouteData.Values);
    //}

    private static ReCaptchaResponse ValidateFromGoogle(string urlToPost, string secretKey, string captchaResponse)
    {
      var postData = "secret=" + secretKey + "&response=" + captchaResponse;

      var request = (HttpWebRequest)WebRequest.Create(urlToPost);
      request.Method = "POST";
      request.ContentLength = postData.Length;
      request.ContentType = "application/x-www-form-urlencoded";

      using (var streamWriter = new StreamWriter(request.GetRequestStream()))
        streamWriter.Write(postData);

      string result;
      using (var response = (HttpWebResponse)request.GetResponse())
      {
        using (var reader = new StreamReader(response.GetResponseStream()))
          result = reader.ReadToEnd();
      }

      return JsonConvert.DeserializeObject<ReCaptchaResponse>(result);
    }

  internal class ReCaptchaResponse
  {
    [JsonProperty("success")]
    public bool Success { get; set; }

    [JsonProperty("challenge_ts")]
    public string ValidatedDateTime { get; set; }

    [JsonProperty("hostname")]
    public string HostName { get; set; }

    [JsonProperty("error-codes")]
    public List<string> ErrorCodes { get; set; }
  }

}
  #endregion
}

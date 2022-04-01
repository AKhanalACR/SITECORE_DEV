using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Glass.Mapper.Sc.Fields;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;
using Sitecore.Diagnostics;
using ACRHelix.Feature.RhecContent.Services;
using ACRHelix.Feature.RhecContent.ViewModels;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System.Web.Mvc;
using System.Data.SqlClient;
using ACRHelix.Feature.RhecContent.Models;
using ACRHelix.Feature.RhecContent.Helpers;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Net.Mail;
using Sitecore;

namespace ACRHelix.Feature.RhecContent.Helpers
{
    public static class RHECHelper
  {
    public const string SettingsItemID = "{2265A655-A074-4B67-9096-40D8DD506E6A}";
    public static IEnumerable<T> Slice<T>(this IEnumerable<T> list, int startIndex, int maxCount)
    {
      return list.Skip(startIndex).Take(maxCount);
    }
    public static string SubstringHtml(string stringValue, int length, bool dots)
    {
      var regexAllTags = new Regex(@"<[^>]*>");
      var regexIsTag = new Regex(@"<|>");
      var regexOpen = new Regex(@"<[^/][^>]*>");
      var regexClose = new Regex(@"</[^>]*>");
      var regexAttribute = new Regex(@"<[^ ]*");
      if (stringValue == null || string.IsNullOrEmpty(stringValue)) { return stringValue; }
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
      subs = string.Format("{0}{1}", subs, dots ? "..." : string.Empty); ;
      for (int i = OpenTags.Count - 1; i >= 0; i--)
      {
        subs += OpenTags[i];
      }
      return subs;
    }
    public static List<string> GetTopicsWithCount(string ResourceTemplate,string ResoureHomepage)
    {
      List<string> returnList = new List<string>();
      var resourceTemplate = GetResourceTemplateId(ResourceTemplate);
      var resourceHomepage = GetResourcePageId(ResoureHomepage);     
      try
      {
        //Item repositorySearchItem = XBlog.General.DataManager.GetBlogHomeItem(currentItem);
        ISearchIndex index = Sitecore.ContentSearch.ContentSearchManager.GetIndex("rhec_resources_index");

        using (IProviderSearchContext context = index.CreateSearchContext())
        {
          Expression<Func<ResourcesSearchResult, bool>> predicate = PredicateBuilder.True<ResourcesSearchResult>();
          predicate = predicate.And(item => item.TemplateId == resourceTemplate && item.Paths.Contains(resourceHomepage));
          var topicsList=context.GetQueryable<ResourcesSearchResult>().Where(predicate).Select(x => x.Topics);
          if (topicsList!=null && topicsList.Count()>0)
          {
            foreach (var topics in topicsList)
            {
              if (topics != null && topics.Count() > 0)
              {
                foreach (var topic in topics)
                {
                  returnList.Add(topic);
                }
              }
                
            }
          }
          
          return returnList.Distinct().ToList();
        }
      }
      catch (Exception ex)
      {
        Log.Error("RHEC GetResourceCategories error", ex, new object());
      }
      return returnList.Distinct().ToList();
    }

    public static int GetResourcesCount(List<string> Topics, string ResourceTemplate, string ResoureHomepage, bool filter = true)
    {
      var resourceTemplate = GetResourceTemplateId(ResourceTemplate);
      var resourceHomepage = GetResourcePageId(ResoureHomepage);
      try
      {
        //Item repositorySearchItem = XBlog.General.DataManager.GetBlogHomeItem(currentItem);
        ISearchIndex index = Sitecore.ContentSearch.ContentSearchManager.GetIndex("rhec_resources_index");

        using (IProviderSearchContext context = index.CreateSearchContext())
        {
          Expression<Func<SearchResultItem, bool>> predicate = PredicateBuilder.True<SearchResultItem>();
          predicate = predicate.And(item => item.TemplateId == resourceTemplate && item.Paths.Contains(resourceHomepage));

          if (Topics != null && Topics.Count() > 0)
          {
            foreach (var topic in Topics)
            {
              //predicate = predicate.And(c => c["resourcetopics"].Replace(" ", "%20").Contains(topic.Replace(" ", "%20")));
              if (filter) { predicate = predicate.And(c => c["resourcetopics"] == topic); }
              else { predicate = predicate.Or(c => c["resourcetopics"] == topic); }

            }


          }

          return context.GetQueryable<SearchResultItem>().Where(predicate).Count();
        }
      }
      catch (Exception ex)
      {
        Log.Error("RHEC GetResourceCount error", ex, new object());
      }
      return 0;
    }

    public static IEnumerable<ResourcesSearchResult> GetResources(List<string> Topics, int startRowIndex, int maximumRows, int totalRows,string ResourceTemplate,string ResoureHomepage,bool filter=true)
    {
      try
      {
        var resourceTemplate = GetResourceTemplateId(ResourceTemplate);
        var resourceHomepage = GetResourcePageId(ResoureHomepage);
        //Item repositorySearchItem = XBlog.General.DataManager.GetBlogHomeItem(currentItem);
        ISearchIndex index = Sitecore.ContentSearch.ContentSearchManager.GetIndex("rhec_resources_index");

        using (IProviderSearchContext context = index.CreateSearchContext())
        {
          Expression<Func<ResourcesSearchResult, bool>> predicate = PredicateBuilder.True<ResourcesSearchResult>();
          predicate = predicate.And(item => item.TemplateId == resourceTemplate && item.Paths.Contains(resourceHomepage));
          if (Topics != null && Topics.Count() > 0)
          {
            foreach (var topic in Topics)
            {
              //predicate = predicate.And(c => c["resourcetopics"].Replace(" ", "%20").Contains(topic.Replace(" ", "%20")));
              //predicate = predicate.And(c => c["resourcetopics"] == topic);
              if (filter) { predicate = predicate.And(c => c["resourcetopics"] == topic); }
              else { predicate = predicate.Or(c => c["resourcetopics"] == topic); }

            }
          }

          return context.GetQueryable<ResourcesSearchResult>().Where(predicate)
                        .OrderByDescending(t => t.PublishDate).ThenBy(t =>t.Title)
                        .Slice(startRowIndex, maximumRows).ToList();                        
        }
      }
      catch (Exception ex)
      {
        Log.Error("RHEC GetResourcesListError", ex, new object());
      }
      return null;
    }
    public static ID GetResourcePageId(string pageID)
    {
      bool idParse = false;
      //var resourceTemplate = ID.Parse("{7B3080EA-9EEC-44BA-9D6B-917640A995A4}");
      var resourceHomepage = ID.Parse("{C6EC0690-E442-4A09-BA09-7C6A044061C0}");
     // idParse = ID.TryParse(ResourceTemplate, out resourceTemplate);
      //if (!idParse) { resourceTemplate = ID.Parse("{7B3080EA-9EEC-44BA-9D6B-917640A995A4}"); }
      idParse = ID.TryParse(pageID, out resourceHomepage);
      if (!idParse) { resourceHomepage = ID.Parse("{C6EC0690-E442-4A09-BA09-7C6A044061C0}"); }
      return resourceHomepage;
    }
    public static ID GetResourceTemplateId(string pageID)
    {
      bool idParse = false;
      var resourceTemplate = ID.Parse("{7B3080EA-9EEC-44BA-9D6B-917640A995A4}");
     // var resourceHomepage = ID.Parse("{C6EC0690-E442-4A09-BA09-7C6A044061C0}");
       idParse = ID.TryParse(pageID, out resourceTemplate);
      if (!idParse) { resourceTemplate = ID.Parse("{7B3080EA-9EEC-44BA-9D6B-917640A995A4}"); }
      //idParse = ID.TryParse(pageID, out resourceHomepage);
      //if (!idParse) { resourceHomepage = ID.Parse("{C6EC0690-E442-4A09-BA09-7C6A044061C0}"); }
      return resourceTemplate;
    }
    //public static IHtmlString GoogleCaptcha(this HtmlHelper helper)
    //{
    //  //var publicSiteKey = WebConfigurationManager.AppSettings["GoogleRecaptchaSiteKey"];
    //  var publicSiteKey = Sitecore.Configuration.Settings.GetSetting("GoogleRecaptchaSiteKey");

    //  var mvcHtmlString = new TagBuilder("div")
    //  {
    //    Attributes =
    //            {
    //                new KeyValuePair<string, string>("class", "g-recaptcha"),
    //                new KeyValuePair<string, string>("data-sitekey", publicSiteKey),
    //                new KeyValuePair<string, string>("data-callback", "recaptcha_callback")
    //            }
    //  };

    //  var googleCaptchaScript = "<script src='https://www.google.com/recaptcha/api.js'></script>";
    //  var renderedCaptcha = mvcHtmlString.ToString(TagRenderMode.Normal);

    //  return MvcHtmlString.Create(string.Format("{0}{1}", googleCaptchaScript, renderedCaptcha));
    //}
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
    public static bool IsValidEmail(string emailaddress)
    {
      try
      {
        if (emailaddress.Trim().EndsWith("."))
        {
          return false; 
        }
        System.Net.Mail.MailAddress m = new System.Net.Mail.MailAddress(emailaddress);

        return true;
      }
      catch (FormatException)
      {
        return false;
      }
    }
    public static bool SendEmail(MailMessage message, string type)
    {      
      try
      {
        MainUtil.SendMail(message);
      }
      catch (Exception ex)
      {
        Sitecore.Diagnostics.Log.Error("Failed to Send RHEC pledge email"+type+ex, "RHEC");
        return false;
      }
      return true;

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
}
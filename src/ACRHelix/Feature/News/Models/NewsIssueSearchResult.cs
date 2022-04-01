using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.News.Models
{
  public class NewsIssueSearchResult : SearchResultItem
  {
    [IndexField("title")]
    public string Title { get; set; }

    [IndexField("subtitle")]
    public string SubTitle { get; set; }

    [IndexField("issuedate")]
    public DateTime IssueDate { get; set; }

    public List<NewsArticle> NewsArticles { get; set; }

    public string IssueUrl
    {
      get
      {
          var match = "sitecore/shell/ACR";
          var match2 = "sitecore/content/ACR";
          int index = Url.IndexOf(match, StringComparison.OrdinalIgnoreCase);
          if (index != -1)
          {
              //Url = Url.Substring(index + match.Length);
              Url = "://acr.org" + Url.Substring(index + match.Length);
          }

          index = Url.IndexOf(match2, StringComparison.OrdinalIgnoreCase);
          if (index != -1)
          {
          //Url = Url.Substring(index + match2.Length);
          Url = "://acr.org" + Url.Substring(index + match2.Length);
        }

        var newurl= HttpContext.Current.Request.Url.Scheme + Url; 
        string host = new System.Uri(newurl).Host;
        newurl =newurl.Replace(host, Sitecore.Context.Site.HostName);

        //Sitecore.Diagnostics.Log.Info("hostfromsolr- " + host, new object());
        //Sitecore.Diagnostics.Log.Info("currenthost- " + Sitecore.Context.Site.HostName, new object());
        //Sitecore.Diagnostics.Log.Info("newurl- " + newurl, new object());

        return newurl;
      }
    }
  }
}
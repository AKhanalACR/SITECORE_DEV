using ACRHelix.Feature.News.Models;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.News.ViewModels
{
  public class NewsIssueListViewModel
  {
    public ID Id { get; set; }

    public string Title { get; set; }

    public string Url { get; set; }

    public IEnumerable<NewsIssueSearchResult> Issues {get;set;}

    public List<int> Years { get; set; }

  }
}
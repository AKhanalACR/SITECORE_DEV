using ACRHelix.Feature.News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.News.ViewModels
{
  public class DashboardNewsViewModel
  {
    public IEnumerable<NewsPressReleaseSearchResult> DashboardNews {get;set;}

    public List<List<NewsPressReleaseSearchResult>> GetPagedNewsArticles(int pageSize)
    {
      List<List<NewsPressReleaseSearchResult>> articles = new List<List<NewsPressReleaseSearchResult>>();

      int added = 0;
      List<NewsPressReleaseSearchResult> allArticles = DashboardNews.ToList();
      while (added < DashboardNews.Count())
      {
        List<NewsPressReleaseSearchResult> elist = new List<NewsPressReleaseSearchResult>();
        elist = allArticles.Skip(added).Take(pageSize).ToList();
        articles.Add(elist);
        added += elist.Count;
      }
      return articles;
    }
  }
}
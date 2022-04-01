using ACRHelix.Feature.News.Models;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.News.ViewModels
{
  public class NewsArchiveViewModel
  {
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public int PageCount { get; set; }
    public int PageNumber { get; set; }
    public IEnumerable<Guid> TagFilter { get; set; } = new List<Guid>();
    public MultiSelectList TagList { get; set; }
    public IEnumerable<NewsArticle> NewsArticles { get; set; }
  }
}
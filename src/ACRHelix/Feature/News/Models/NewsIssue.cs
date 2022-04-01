using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.News.Models
{
  public class NewsIssue : INewsIssue
  {
    public ID Id { get; set; }
    public string Title { get; set; }
    //public string Type { get; set; }
    //public Link ArchivesLink { get; set; }
    public virtual IEnumerable<NewsArticle> Articles { get; set; }
  }
}
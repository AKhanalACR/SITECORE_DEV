using ACRHelix.Feature.News.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.News.Models
{
  public class RecentNewsList : IRecentNewsList
  {
    public virtual Guid Id { get; set; }
    public virtual string Title { get; set; }
    public virtual string Type { get; set; }
    public virtual Link ArchivesLink { get; set; }
    public virtual IEnumerable<NewsArticle> Articles { get; set; }
    public virtual int DisplayNumber { get; set; }
  }
}
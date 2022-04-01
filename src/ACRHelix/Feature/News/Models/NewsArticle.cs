using ACRHelix.Feature.News.Models;
using ACRHelix.Foundation.Dictionary.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.News.Models
{
  public class NewsArticle : INewsArticle
  {
    public virtual Guid Id { get; set; }
    public virtual string Title { get; set; }
    public virtual string SubTitle { get; set; }
    public virtual DateTime Date { get; set; }
    public virtual string Type { get; set; }
    public virtual string Content { get; set; }
    public virtual string Url { get; set; }
    public virtual IEnumerable<Guid> Tags { get; set; }

    public virtual string TileText { get; set; }
  }
}
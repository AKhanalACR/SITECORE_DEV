using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACRHelix.Feature.News.Models
{
  public interface INewsIssue : ICMSEntity
  {
  ID Id { get; set; }
  string Title { get; set; }

  //string Type { get; set; }
  //Link ArchivesLink { get; set; }

  [SitecoreQuery("../..//*[@@templatename='NewsArticle']", IsRelative = true)]
  IEnumerable<NewsArticle> Articles { get; set; }
}
}

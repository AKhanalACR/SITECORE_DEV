using ACRHelix.Feature.News.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.News.Models
{
  public interface IRecentNewsList : ICMSEntity
  {
    Guid Id { get; set; }
    string Title { get; set; }
    string Type { get; set; }
    Link ArchivesLink { get; set; }
       
    //[SitecoreQuery("/sitecore/content/ACR//*[@@templatename='NewsArticle' or @@templatename='PressRelease']")]
    //[SitecoreQuery("/sitecore/content//*[@@templatename='NewsArticle' or @@templatename='PressRelease']")]
    IEnumerable<NewsArticle> Articles { get; set; }
    [SitecoreField("Display Number")]
    int DisplayNumber { get; set; }
  }
}
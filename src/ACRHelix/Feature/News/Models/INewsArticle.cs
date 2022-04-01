using ACRHelix.Feature.News.Models;
using ACRHelix.Foundation.Dictionary.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.News.Models
{
  public interface INewsArticle : ICMSEntity
  {
    Guid Id { get; }
    string Title { get; }
    string SubTitle { get; }
    DateTime Date { get; set; }
    string Type { get; set; }
    string Content { get; set; }
    string Url { get; set; }
    IEnumerable<Guid> Tags { get; set; }

    [SitecoreField("Tile Text")]
    string TileText { get; set; }
  }
}
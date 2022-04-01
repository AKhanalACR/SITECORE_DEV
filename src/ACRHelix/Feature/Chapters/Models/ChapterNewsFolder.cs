using System.Collections.Generic;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;

namespace ACRHelix.Feature.Chapters.Models
{
  [SitecoreType(TemplateId = "{2393BB04-21F8-449F-8F70-E90D1D030823}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class ChapterNewsFolder : ICMSEntity
  {
    public virtual ID Id
    {
      get; set;
    }

    [SitecoreChildren]
    public virtual IEnumerable<ChapterNews> Children { get; set; }

  }
}
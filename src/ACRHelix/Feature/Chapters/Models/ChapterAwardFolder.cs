using System.Collections.Generic;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;

namespace ACRHelix.Feature.Chapters.Models
{

  [SitecoreType(TemplateId = "{6DE4DD31-0615-48D5-89E0-7AD4A392C781}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class ChapterAwardFolder : ICMSEntity
  {

    public virtual ID Id
    {
      get; set;
    }

    public virtual string Title
    {
      get; set;
    }

    [SitecoreChildren]
    public virtual IEnumerable<ChapterAward> Children { get; set; } 

  }
}
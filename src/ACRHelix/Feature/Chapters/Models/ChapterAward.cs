
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;

namespace ACRHelix.Feature.Chapters.Models
{
  [SitecoreType(TemplateId = "{7FFC1BEC-61B5-4830-A243-6AE901D9E3BC}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class ChapterAward : ICMSEntity
  {
    public virtual ID Id
    {
      get; set;
    }

    public virtual string Subtitle
    {
      get; set;
    }

    public virtual string Title
    {
      get; set;
    }

    public virtual int Year { get; set; }
  }
}
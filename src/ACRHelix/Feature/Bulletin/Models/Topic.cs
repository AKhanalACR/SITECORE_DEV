using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;

namespace ACRHelix.Feature.Bulletin.Models
{
  [SitecoreType(TemplateId = "{CEE9EB98-D110-4220-BD0E-5A3F3FC79A10}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class Topic : ICMSEntity
  {
    public virtual ID Id { get; set; }

    [SitecoreField("Phrase")]
    public virtual string Name { get; set; }
  }
}
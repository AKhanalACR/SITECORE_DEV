using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;

namespace ACRHelix.Feature.RSSFeed.Models
{
  [SitecoreType(TemplateId = "{CBBF3595-35AE-4B7B-A813-506F0F731E94}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.TemplateAndBase)]
  public class RSSFeed : ICMSEntity
  {
      public virtual ID Id { get; set; }

      [SitecoreField("Feed URL")]
      public virtual string feedURL { get; set; }
  }
}
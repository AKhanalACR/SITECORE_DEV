using System;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;

namespace ACRHelix.Feature.Tabs.Models
{
  [SitecoreType(TemplateId = "{56250079-B314-43C7-929F-2FA88C0AD8D6}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.TemplateAndBase)]
  public class Tabs : ICMSEntity
  {
    public virtual ID Id { get; set; }
    [SitecoreField("Tabs")]
    public virtual string TabNames { get; set; }
  }
}
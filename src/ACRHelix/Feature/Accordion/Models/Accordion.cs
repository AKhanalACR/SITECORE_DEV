using System.Collections.Generic;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;

namespace ACRHelix.Feature.Accordion.Models
{
  [SitecoreType(TemplateId = "{FFB128C9-78EF-4182-927B-8B93E14C20AD}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class Accordion : ICMSEntity
  {
    public virtual ID Id { get; set; }
    [SitecoreField("Section Name")]
    public virtual string SectionName { get; set; }
    [SitecoreChildren]
    public virtual IEnumerable<AccordionItem> Children { get; set; }
  }
}
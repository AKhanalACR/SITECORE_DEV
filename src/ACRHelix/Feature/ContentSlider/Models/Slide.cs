using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Fields;
using System;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;

namespace ACRHelix.Feature.ContentSlider.Models
{
  [SitecoreType(TemplateId = "{31004A2A-44E4-45A5-9362-0CC6226ADEAA}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class Slide : ICMSEntity
  {
    public virtual ID Id { get; set; }
    [SitecoreField("Alert Text")]
    public virtual string AlertText { get; set; }
    public virtual string Title { get; set; }
    public virtual string Text { get; set; }
    public virtual Link Link { get; set; }
    public virtual Image Image { get; set; }
  }
}

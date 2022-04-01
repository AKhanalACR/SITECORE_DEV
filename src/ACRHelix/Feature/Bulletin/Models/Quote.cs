using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;

namespace ACRHelix.Feature.Bulletin.Models
{
  [SitecoreType(TemplateId = "{60957BA5-5090-4E86-9E1B-FD446C459623}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class Quote : ICMSEntity
  {
    public virtual ID Id { get; set; }

    [SitecoreField("Quote")]
    public virtual string QuoteText { get; set; }

    [SitecoreField("Quote By")]
    public virtual string QuoteBy { get; set; }
  }
}
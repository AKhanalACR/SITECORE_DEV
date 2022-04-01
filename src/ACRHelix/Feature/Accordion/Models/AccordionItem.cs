using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;

namespace ACRHelix.Feature.Accordion.Models
{
  [SitecoreType(TemplateId = "{4BD22744-7231-42F3-B02B-ED634BEDA7ED}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.TemplateAndBase)]
  public class AccordionItem : ICMSEntity
  {
    public virtual ID Id
    {
      get; set;
    }

    public virtual string Text
    {
      get; set;
    }

    public virtual string Title
    {
      get; set;
    }

    [SitecoreField("Table Text")]
    public virtual string TableText
    {
      get; set;
    }
   


  }
}
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;

namespace ACRHelix.Feature.IdeasContent.Models
{
  [SitecoreType(TemplateId = "{3F959E29-DC26-43E5-94F7-691FF198F648}", AutoMap = true, EnforceTemplate = SitecoreEnforceTemplate.TemplateAndBase)]
  public class IdeasTextSection : ICMSEntity
  {
    public virtual ID Id { get; set; }
    public virtual string Title { get; set; }
    public virtual string SubTitle { get; set; }

    [SitecoreField("Text")]
    public virtual string Text { get; set; }

    [SitecoreInfo(SitecoreInfoType.TemplateId)]
    public virtual ID TemplateId { get; set; }

    public struct Template
    {
      public const string TemplateID = "{3F959E29-DC26-43E5-94F7-691FF198F648}";
    }

    public struct DefaultRendering
    {
      public const string RenderingID = "{63902F04-2003-4956-A89D-37B274026497}";
    }
  }
}
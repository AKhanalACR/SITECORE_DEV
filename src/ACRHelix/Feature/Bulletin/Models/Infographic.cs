using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.Bulletin.Models
{
  [SitecoreType(TemplateId = "{364E52C4-8F61-4FF4-B82A-87CB06F76504}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class Infographic : ICMSEntity
  {
    public virtual ID Id { get; set; }

    public virtual Image Thumbnail { get; set; }

    [SitecoreField("Infographic")]
    public virtual Image InfographicImage { get; set; }

    public virtual string Text { get; set; }

    [SitecoreIgnore()]
    public string InfographicUrl { get; set; }
  }
}
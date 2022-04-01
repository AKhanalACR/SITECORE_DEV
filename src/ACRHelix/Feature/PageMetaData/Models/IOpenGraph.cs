using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.HTMLMetadata.Models
{
  [SitecoreType(TemplateId = "{E3F9025B-EBB5-42AE-AB41-12E742AE376D}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.TemplateAndBase)]
  public interface IOpenGraph : ICMSEntity
  {
    //open graph
    [SitecoreField("og-title")]
    string OG_Title { get; set; }
    [SitecoreField("og-description")]
    string OG_Description { get; set; }
    [SitecoreField("og-image")]
    Image OG_Image { get; set; }
  }
}
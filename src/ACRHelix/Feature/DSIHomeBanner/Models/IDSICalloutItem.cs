using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Fields;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;

namespace ACRHelix.Feature.DSIHomeBanner.Models
{
  [SitecoreType(TemplateId = "{BFA8C97A-250E-4905-A500-8C2A03E6E269}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public interface IDSICalloutItem : ICMSEntity
  {
    ID Id { get; set; }
    string Title { get; set; }
    string SubTitle { get; set; }
    string Teaser { get; set; }
    Image Image { get; set; }
    Link Link { get; set; }
    Link SecondLink { get; set; }
  	bool AnimateFromRight { get; set; }
  }
}

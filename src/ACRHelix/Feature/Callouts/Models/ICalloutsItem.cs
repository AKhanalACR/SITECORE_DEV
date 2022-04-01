using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Fields;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;

namespace ACRHelix.Feature.Callouts.Models
{
  [SitecoreType(TemplateId = "{9B266E5D-6B70-4F8B-97B2-C6C6A863E223}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public interface ICalloutsItem : ICMSEntity
  {
    ID Id { get; set; }
    string Title { get; set; }
    string SubTitle { get; set; }
    string Teaser { get; set; }
    Image Image { get; set; }
    Link Link { get; set; }


  }
}

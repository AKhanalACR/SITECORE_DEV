
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;
using ACRHelix.Foundation.Model;

namespace ACRHelix.Feature.Chapters.Models
{
  [SitecoreType(TemplateId = "{185E7629-5035-4764-8439-ABC39402C4DC}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public interface IChapters : ICMSEntity
  {
    ID Id { get; set; }
    string Title { get; set; }
    [SitecoreField("Chapter Website")]
    Link ChapterWebsite { get; set; }
    [SitecoreField("Chapter Logo", FieldType =Glass.Mapper.Sc.Configuration.SitecoreFieldType.Image)]
    Image ChapterLogo { get; set; }
    //Image Image { get; set; }
  }
}
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;

namespace ACRHelix.Feature.ImageWiselyContent.Models
{
  [SitecoreType(TemplateId = "{6F6BA1BD-D899-41BB-9886-418EE1649871}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class InternationFacilityListSettingsModel : ICMSEntity
  {
    public virtual ID Id { get; set; }

    [SitecoreField(FieldId = "{3488A5CC-5B12-4827-B659-D0BF7D61D7CA}")]
    public virtual int Year { get; set; }

    [SitecoreField(FieldId = "{0D906E2D-6CFC-473F-A3F5-CAA9A34EBC05}")]
    public virtual string NoFacilities { get; set; }
  }
}
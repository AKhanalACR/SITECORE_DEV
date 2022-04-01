using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Fields;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;

namespace ACRHelix.Feature.Callouts.Models
{
  [SitecoreType(TemplateId = "{B33C4D73-8400-49A5-BDC8-C05F861DAD46}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class ChapterLocatorCallout : ICMSEntity
  {
    public virtual ID Id { get; set; }

    public virtual string Title { get; set; }

    [SitecoreField("Button Text")]
    public virtual string ButtonText { get; set; }

    public const string ChapterTemplateID = "{185E7629-5035-4764-8439-ABC39402C4DC}";
  }
}
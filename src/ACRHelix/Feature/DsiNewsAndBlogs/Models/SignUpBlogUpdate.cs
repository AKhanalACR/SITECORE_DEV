using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.DsiNewsAndBlogs.Models
{
  [SitecoreType(TemplateId = "{6241DE0F-C675-47A9-81DE-0981201F281D}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class SignUpBlogUpdate : ICMSEntity
  {
    public virtual ID ID { get; set; }

    [SitecoreField(FieldId = "{6A1F751C-E646-4D10-9916-E29410CE58AA}")]
    public virtual string Title { get; set; }


    [SitecoreField(FieldId = "{C8AF6579-4240-48F4-B5B9-FC5C8920510A}")]
    public virtual string ButtonText { get; set; }

    [SitecoreField(FieldId = "{B5C5376C-0DCB-4BFE-985F-7F74311D7C89}")]
    public virtual Link ButtonLink { get; set; }
  }
}
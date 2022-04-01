using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;

namespace ACRHelix.Feature.Bulletin.Models.Rendering_Models
{
  [SitecoreType(TemplateId = "{B3BA2DE1-1A1F-41C2-9CA3-190665933CF0}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class FeaturedArticle : ICMSEntity
  {
    public virtual ID Id { get; set; }

    [SitecoreField("Featured Article")]
    public virtual Article Article { get; set; }
  }
}
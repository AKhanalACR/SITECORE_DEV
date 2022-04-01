using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.Bulletin.Models.Rendering_Models
{
  [SitecoreType(TemplateId = "{8FB901EB-1905-4071-BDD3-EA2EAC2C4CD0}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class BulletinHomepageFeaturedQuoteArticle : ICMSEntity
  {
    public virtual ID Id { get; set; }

    [SitecoreField("Featured Article")]
    public virtual Article FeaturedArticle { get; set; }

    [SitecoreField("Quote Text")]
    public virtual string Quote { get; set; }

    [SitecoreField("Link")]
    public virtual Link QuoteLink { get; set; }
  }
}
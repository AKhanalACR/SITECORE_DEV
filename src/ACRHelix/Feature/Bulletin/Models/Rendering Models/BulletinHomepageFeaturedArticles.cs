using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using System.Collections.Generic;

namespace ACRHelix.Feature.Bulletin.Models.Rendering_Models
{
  [SitecoreType(TemplateId = "{23A249A1-EBD7-4706-B5F0-0C24A2A83143}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class BulletinHomepageFeaturedArticles : ICMSEntity
  {
    public virtual ID Id { get; set; }

    [SitecoreField("Articles", FieldType = Glass.Mapper.Sc.Configuration.SitecoreFieldType.Treelist)]
    public virtual IEnumerable<Article> Articles { get; set; }
  }
}
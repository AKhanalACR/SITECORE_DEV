using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using System.Collections.Generic;

namespace ACRHelix.Feature.Bulletin.Models.Rendering_Models
{
  [SitecoreType(TemplateId = "{98EE41CA-32C3-4B58-ADBD-3A7930D02732}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class TrendingArticles : ICMSEntity
  {
    public virtual ID Id { get; set; }

    public virtual string Title { get; set; }

    [SitecoreField("Manual Articles", FieldType = Glass.Mapper.Sc.Configuration.SitecoreFieldType.Treelist)]
    public virtual IEnumerable<Article> Articles { get; set; } = new List<Article>();
  }
}
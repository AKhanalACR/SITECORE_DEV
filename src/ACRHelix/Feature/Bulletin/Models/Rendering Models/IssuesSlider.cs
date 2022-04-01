using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System.Collections.Generic;

namespace ACRHelix.Feature.Bulletin.Models.Rendering_Models
{
  [SitecoreType(TemplateId = "{3707471F-B349-42F6-B2C4-B808DF9ABE81}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class IssuesSlider : ICMSEntity
  {
    public virtual ID Id { get; set; }

    public virtual string Title { get; set; }

    [SitecoreField("Archive Link")]
    public virtual Link ArchiveLink { get; set; }

    [SitecoreIgnore()]
    public virtual IEnumerable<IssueSearchItem> Issues { get; set; } = new List<IssueSearchItem>();
  }
}
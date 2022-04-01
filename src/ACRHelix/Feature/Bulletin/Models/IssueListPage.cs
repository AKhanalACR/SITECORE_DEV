using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;

namespace ACRHelix.Feature.Bulletin.Models
{
  [SitecoreType(TemplateId = "{5F51763B-2B59-430E-AF1B-AD95A2544A5C}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class IssueListPage : ICMSEntity
  {
    public virtual ID Id { get; set; }

    public virtual string Title { get; set; }
  }
}
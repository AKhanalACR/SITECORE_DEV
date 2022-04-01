using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;

namespace ACRHelix.Feature.Bulletin.Models
{
  [SitecoreType(TemplateId = Constants.BulletinTemplates.TopicPage.TemplateID, AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class TopicPage : ICMSEntity
  {
    public virtual ID Id { get; set; }

    [SitecoreField("Topic")]
    public virtual Topic Topic { get; set; }

    [SitecoreField("Title")]
    public virtual string Title { get; set; }

    public virtual string Url { get; set; }
  }
}
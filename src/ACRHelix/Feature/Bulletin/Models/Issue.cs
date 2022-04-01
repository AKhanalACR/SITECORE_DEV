using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;

namespace ACRHelix.Feature.Bulletin.Models
{
  [SitecoreType(TemplateId = "{4C919187-377A-42F1-AB65-E7F414F57638}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class Issue : ICMSEntity
  {
    public virtual ID Id { get; set; }

    [SitecoreField("Issue Name")]
    public virtual string IssueName { get; set; }

    [SitecoreField("Release Date")]
    public virtual DateTime ReleaseDate { get; set; }

    [SitecoreField("Bulletin PDF")]
    public virtual File BulletinPDF { get; set; }

    [SitecoreField("Articles")]
    public virtual IEnumerable<Article> Articles { get; set; }

    [SitecoreField("Image")]
    public virtual Image Image { get; set; }
  }
}
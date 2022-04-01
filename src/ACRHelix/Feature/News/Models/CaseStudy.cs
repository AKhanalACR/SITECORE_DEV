using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;

namespace ACRHelix.Feature.News.Models
{
  [SitecoreType(TemplateId = "{2C398991-B270-4F71-BEF9-A68DCA7283EA}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class CaseStudy : ICMSEntity
  {
    public virtual ID Id { get; set; }
    [SitecoreField("Tile Text")]
    public virtual string TileText {get;set;}
    [SitecoreField("Link Text")]
    public virtual string LinkText { get; set; }
    public virtual string Title { get; set; }
    public virtual string Url { get; set; }
    public virtual DateTime Date { get; set; }
    public virtual string Author { get; set; }
    public virtual IEnumerable<Guid> Tags { get; set; }
  }
}
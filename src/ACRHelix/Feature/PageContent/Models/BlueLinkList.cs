using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.PageContent.Models
{
  [SitecoreType(TemplateId = "{4DA74F6D-27C9-4E7F-BD38-A12355BAAC7A}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class BlueLinkList : ICMSEntity
  {
    public virtual ID Id { get; set; }
    public virtual string Title { get; set; }
    public virtual string SubTitle { get; set; }
    public bool DisplayHeader { get; set; }
    [SitecoreChildren]
    public virtual IEnumerable<LinkItem> Children { get; set; }
  }
  [SitecoreType(TemplateId = "{A64807CB-509A-4582-ABEC-29186FE0B338}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class LinkItem : ICMSEntity
  {
    public virtual ID Id { get; set; }  
    public virtual Link Link {get;set;}
  }
}
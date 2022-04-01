using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.RhecContent.Models
{
  [SitecoreType(TemplateId = "{7B3080EA-9EEC-44BA-9D6B-917640A995A4}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class Resource : ICMSEntity
  {
    public virtual ID Id { get; set; }

    [SitecoreField("{7CCC3E88-AD81-4F55-ABF9-AA87158518E1}", SitecoreFieldType.SingleLineText)]
    public virtual string Title { get; set; }
    [SitecoreField("{391DCE81-56CF-49C2-BE1E-2D319D81DC18}", SitecoreFieldType.RichText)]
    public virtual string Body { get; set; }
    [SitecoreField("{493E6565-402B-40A5-BB8F-DEB9CC429401}", SitecoreFieldType.RichText)]
    public virtual string Summary { get; set; }
    [SitecoreField("{FCD1E100-93E1-441B-B165-0E4D41F160D7}", SitecoreFieldType.Image)]
    public virtual Image  image { get; set; }
    [SitecoreField("{04DEFEB8-DF2C-4EE0-9E2F-ED25EBB9FE21}", SitecoreFieldType.DateTime)]
    public virtual DateTime PublishDate { get; set; }
    [SitecoreField("{26FA29EA-7C0E-405C-BBEA-4BEA5D5A8E6A}", SitecoreFieldType.Multilist)]
    public virtual IEnumerable<Models.ITopics> Topics { get; set; }

    [SitecoreField("Link Override")]
    public virtual string LinkOverride { get; set; }

    [SitecoreField("New Window")]
    public virtual bool NewWindow { get; set; }
    public virtual string Url { get; set; }


  }
}
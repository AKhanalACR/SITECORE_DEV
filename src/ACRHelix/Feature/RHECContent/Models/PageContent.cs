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
  [SitecoreType(TemplateId = "{9607276B-1967-475B-B410-CDA20F5B33A0}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class PageContent : ICMSEntity
  {
    public virtual ID Id { get; set; }

    [SitecoreField("Title")]
    public virtual string Title { get; set; }
    [SitecoreField("SubTitle")]
    public virtual string SubTitle { get; set; }
    [SitecoreField("RichText")]
    public virtual string RichText { get; set; }


  }
}
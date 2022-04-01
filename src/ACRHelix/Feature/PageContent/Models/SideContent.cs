using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.PageContent.Models
{
  [SitecoreType(TemplateId = "{08F42A3A-2C41-46BB-BB5E-5FDD49641944}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class SideContent : ICMSEntity
  {

    public virtual ID Id { get; set; }

    [SitecoreField(FieldName ="Section Title")]
    public virtual string SectionTitle { get; set; }


    [SitecoreField(FieldName = "Left Text")]
    public virtual string LeftText { get; set; }


    [SitecoreField(FieldName = "Right Text")]
    public virtual string RightRext { get; set; }


  }
}
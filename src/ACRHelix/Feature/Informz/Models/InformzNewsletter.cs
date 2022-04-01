using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Informz.Models
{
  [SitecoreType(TemplateId = "{C2018485-6AA3-473B-BB13-8B129D91B8D1}", AutoMap = true, EnforceTemplate = SitecoreEnforceTemplate.Template)]
  public class InformzNewsletter : ICMSEntity
  {
    public virtual ID Id { get; set; }

    [SitecoreField(FieldId = "{E103DEE8-E519-40B0-89EB-E77E5E285741}")]
    public virtual string DisplayName { get; set; }

    [SitecoreField(FieldId = "{B603C3EA-52FA-46E6-8292-0A9BE83153A1}")]
    public virtual string TooltipText { get; set; }

    [SitecoreField(FieldId = "{41DE6BDE-3F65-44EB-942D-E7764ED140C9}")]
    public virtual string PersonifyCode { get; set; }

        [SitecoreField("Available for Non-Member")]
        public virtual bool IsAvailableForNonMember { get; set; }
    }
}
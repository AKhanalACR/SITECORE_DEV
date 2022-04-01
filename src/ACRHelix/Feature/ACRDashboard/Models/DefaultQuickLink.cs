using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.ACRDashboard.Models
{
  [SitecoreType(TemplateId = TemplateId, AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class DefaultQuickLink : ICMSEntity
  {
    public const string TemplateId = "{801A0401-FA96-4807-885D-8E619BDC1656}";
    public virtual ID Id { get; set; }
    [SitecoreField(FieldName ="Link Text")]
    public virtual string LinkText { get; set; }
    [SitecoreField(FieldName = "Link")]
    public virtual Link Link { get; set; }
    [SitecoreField("Selected")]
    public bool Selected { get; set; }
  }
}
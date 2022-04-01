using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.CaseInPoint.Models
{
  [SitecoreType(TemplateId = "{FB2C288D-BC00-4906-B54B-3927FF5D402B}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.TemplateAndBase)]
  public class MiniCaseInPointContent : ICMSEntity
  {
    public virtual ID Id { get; set; }

    public virtual string Title { get; set; }

    [SitecoreField(FieldId = "{B6E4244E-5E69-43D3-8B30-2EF6EF75BE06}")]
    public virtual string LinkText { get; set; }

    [SitecoreField(FieldId = "{FF48E086-BBEF-4DB3-B7E5-AEC9883D1C8F}")]
    public virtual string LinkToolTipText { get; set; }
  }
}
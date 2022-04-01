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
  [SitecoreType(TemplateId = "{1545CC2E-4FEB-4EE6-9637-13432284F864}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class Button : ICMSEntity
  {
    public virtual ID Id { get; set; }

    [SitecoreField("{D224ABB5-CE8C-432A-A837-60C42C59F823}", SitecoreFieldType.SingleLineText)]
    public virtual string Text { get; set; }
    [SitecoreField("{3BC0C954-A91E-44D6-ABDD-B8991BAD5EDB}", SitecoreFieldType.GeneralLink)]
    public virtual Link Link { get; set; }



  }
}
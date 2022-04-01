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
  [SitecoreType(TemplateId = "{40694090-BB1C-4A94-9F45-5FFACB026FAD}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class DashboardNavigationItem : ICMSEntity
  {
    public virtual ID Id { get; set; }

    public virtual Link Link { get; set; }

    public virtual string Icon { get; set; }
  }
}
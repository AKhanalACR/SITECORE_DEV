using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.Tabs.Models
{
    [SitecoreType(TemplateId = "{EAE1FC80-8E4C-4A00-BF1A-C6F5A1E6A539}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.TemplateAndBase)]
    public class RLITabs : ICMSEntity
    {
        public virtual ID Id { get; set; }
        public virtual string Tabs { get; set; }
        public virtual string Links { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.ImageWiselyContent.Models
{
    [SitecoreType(TemplateId = "{5CAC45D7-E497-4E27-B345-115F7E3C8047}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
    public class AdditionalResourcesLink
    {
        public virtual ID Id { get; set; }
        
        public virtual Link Link { get; set; }
              
    }
}
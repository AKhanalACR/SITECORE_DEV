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
    [SitecoreType(TemplateId = "{B16531FB-F668-4EA3-9409-DB8806192675}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
    public class AdditionalResources : ICMSEntity
    {
        public virtual ID Id { get; set; }

        public virtual string Title { get; set; }
       
        public virtual string SubTitle { get; set; }

        [SitecoreQuery(".//*[@@templateid='{5CAC45D7-E497-4E27-B345-115F7E3C8047}']", IsRelative = true)]
        public virtual IEnumerable<AdditionalResourcesLink> LinksList { get; set; }
    }
}
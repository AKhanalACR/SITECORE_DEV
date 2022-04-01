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
    [SitecoreType(TemplateId = "{EDDD6AC6-6E31-4BA2-8689-223265B83936}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
    public class BlockWithTextCallout : ICMSEntity
    {
        public virtual ID Id { get; set; }

        public virtual string RichText { get; set; }

        public virtual Link Link { get; set; }
    }
}
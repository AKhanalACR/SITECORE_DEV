using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System.Collections.Generic;

namespace ACRHelix.Feature.SiteSection.Models
{
    [SitecoreType(TemplateId = "{CEE9EB98-D110-4220-BD0E-5A3F3FC79A10}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]

    public class IdeasTileColor : ICMSEntity
    {
        public virtual ID Id { get; set; }

        [SitecoreField("{F63EF5B1-0A58-4273-96DC-D5028DFE21D5}", SitecoreFieldType.SingleLineText)]
        public virtual string Phrase { get; set; }
    }
}
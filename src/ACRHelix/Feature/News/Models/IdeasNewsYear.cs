using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System.Collections.Generic;

namespace ACRHelix.Feature.News.Models
{
    [SitecoreType(TemplateId = "{CEE9EB98-D110-4220-BD0E-5A3F3FC79A10}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]

    public class IdeasNewsYear : ICMSEntity
    {
        public ID Id { get; set; }

        [SitecoreField("Phrase")]
        public virtual string Phrase { get; set; }
    }
}
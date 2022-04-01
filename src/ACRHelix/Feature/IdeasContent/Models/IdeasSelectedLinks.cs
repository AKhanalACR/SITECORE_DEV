using System.Collections.Generic;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;

namespace ACRHelix.Feature.IdeasContent.Models
{
    [SitecoreType(TemplateId = "{2F19278E-02A4-4B69-94AF-E233FAF12547}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]

    public class IdeasSelectedLinks : ICMSEntity
    {
        public virtual ID Id { get; set; }
        [SitecoreField("Links Title")]
        public virtual string PublicationsTitle { get; set; }

        [SitecoreField("Number of links to be displayed")]
        public virtual int NoOfLinks { get; set; }
        public virtual IEnumerable<LinkMenuItem> Children { get; set; }
    }
}
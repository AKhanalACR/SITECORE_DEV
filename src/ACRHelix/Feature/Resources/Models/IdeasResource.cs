using System.Collections.Generic;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using System;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.IdeasResources.Models
{
    //[SitecoreType(TemplateId = "{2EAD1608-9E8C-444F-AF66-766578E687F8}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]

    public class IdeasResource : ICMSEntity
    {
        public virtual ID Id { get; set; }
        [SitecoreField("Resource Title")]
        public virtual string Title { get; set; }

        [SitecoreField("Resource Image")]
        public virtual Image Image { get; set; }

        [SitecoreField("Resource Link")]
        public virtual Link Link { get; set; }

        [SitecoreField("Is YouTube Video")]
        public virtual bool IsYTVideo { get; set; }

        [SitecoreField("__Created")]
        public virtual DateTime Created { get; set; }

        [SitecoreField("Resource Type")]
        public virtual IEnumerable<ResourceType> ResourceType { get; set; }
       
        [SitecoreField("Resource SubTitle")]
        public virtual Link ResourceSubTitle { get; set; }

    }
}
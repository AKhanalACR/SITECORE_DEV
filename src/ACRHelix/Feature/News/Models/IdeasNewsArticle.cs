using System.Collections.Generic;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using System;

namespace ACRHelix.Feature.News.Models
{
    [SitecoreType(TemplateId = "{6656C222-8AA8-46BC-BE0B-BE85465B6500}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]

    public class IdeasNewsArticle : ICMSEntity
    {
        public virtual ID Id { get; set; }
        [SitecoreField("Date")]
        public virtual DateTime Date { get; set; }

        [SitecoreField("Enable Share Link")]
        public virtual bool EnableShareLink { get; set; }

        public virtual string Url { get; set; }

        public virtual string Title { get; set; }

        public virtual DateTime Created { get; set; }
    }
}
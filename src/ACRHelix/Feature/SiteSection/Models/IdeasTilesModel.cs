using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System.Collections.Generic;

namespace ACRHelix.Feature.SiteSection.Models
{
    [SitecoreType(TemplateId = "{475EC026-AD0B-4AEB-A93A-50807958C319}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
    public class IdeasTilesModel : ICMSEntity
    {
        public virtual ID Id { get; set; }

        [SitecoreField("{3EC4FCD2-6853-44CC-A561-2E774B7E4342}", SitecoreFieldType.RichText)]
        public virtual string TileText { get; set; }

        [SitecoreField("{D89626DC-359D-4765-89E4-63A5DD63FA41}", SitecoreFieldType.GeneralLink)]
        public virtual Link TileLink { get; set; }

        [SitecoreField("{1B8DE6CF-4A66-4CC5-8A7B-71083CC1EA12}", SitecoreFieldType.Droplink)]
        public virtual IdeasTileColor TileColor { get; set; }

    }
}
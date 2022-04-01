using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System.Collections.Generic;

namespace ACRHelix.Feature.SiteSection.Models
{
    [SitecoreType(TemplateId = "{62ECF7C7-9CC2-4459-BB46-697733E1E580}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
    public class IdeasSelectedTiles : ICMSEntity
    {
        public virtual ID Id { get; set; }

        [SitecoreField("{706A130A-0C2F-467C-AE45-B528FAA86DC3}", SitecoreFieldType.Multilist)]
        public virtual IEnumerable<IdeasTilesModel> SelectedTiles { get; set; }
    }
}
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System.Collections.Generic;


namespace ACRHelix.Feature.SiteSection.Models
{
    [SitecoreType(TemplateId = "{FD2DE249-72F5-4FFD-B404-25A1392A6DB2}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
    public class IdeasRichTextAndTilesModel : ICMSEntity
    {
        public virtual ID Id { get; set; }

        [SitecoreField("{F64AAD98-A0F4-4BC9-A018-DBAF091097F9}", SitecoreFieldType.SingleLineText)]
        public virtual string Title { get; set; }

        [SitecoreField("{A31B10B8-322A-436B-9177-E91CDA26F63E}", SitecoreFieldType.RichText)]
        public virtual string Subtitle { get; set; }

        [SitecoreField("{AD5EAA11-166E-48F6-B54E-5411A193CCAB}", SitecoreFieldType.RichText)]
        public virtual string RichText { get; set; }

        [SitecoreField("{706A130A-0C2F-467C-AE45-B528FAA86DC3}", SitecoreFieldType.Multilist)]
        public virtual IEnumerable<IdeasTilesModel> SelectedTiles { get; set; }
    }
}
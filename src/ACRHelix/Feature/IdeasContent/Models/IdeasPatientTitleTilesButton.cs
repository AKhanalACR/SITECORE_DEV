using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System.Collections.Generic;


namespace ACRHelix.Feature.IdeasContent.Models
{
  [SitecoreType(TemplateId = "{84A49BEB-C3E1-43E9-B212-5FB2A5A04D09}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
    public class IdeasPatientTitleTilesButton : ICMSEntity
    {
        public virtual ID Id { get; set; }

        [SitecoreField("{2E0B88CB-84FC-4555-AB73-EFE6ADDCD446}", SitecoreFieldType.SingleLineText)]
        public virtual string Title { get; set; }

        [SitecoreField("{BF4BAFCE-3515-4693-B071-C65B7B0AD0C2}", SitecoreFieldType.Multilist)]
        public virtual IEnumerable<Models.IdeasPatientTiles> Tiles { get; set; }

        [SitecoreField("{BCEA9FB8-8C09-4925-B570-36EF5CD29218}", SitecoreFieldType.SingleLineText)]
        public virtual string ButtonTitle { get; set; }

        [SitecoreField("{2428B157-2905-48A7-95F1-BFE47F24C9A3}", SitecoreFieldType.GeneralLink)]
        public virtual Link ButtonLink { get; set; }

        [SitecoreField("{1DEB1CA4-918F-4598-AB4B-67C69DE42627}", SitecoreFieldType.Checkbox)]
        public virtual bool ButtonDisplay { get; set; }

    }
}
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System.Collections.Generic;


namespace ACRHelix.Feature.IdeasContent.Models
{
  [SitecoreType(TemplateId = "{D914FBC6-A63D-4EF4-8EA1-21DC29FC05B5}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
    public class IdeasHero : ICMSEntity
    {
        public virtual ID Id { get; set; }

        [SitecoreField("{FB190C52-D1C1-4E40-9A87-DABE36B4DE71}", SitecoreFieldType.SingleLineText)]
        public virtual string ImageText { get; set; }

        [SitecoreField("{58446B81-40EE-46BE-B432-DFB23F971B08}", SitecoreFieldType.Image)]
        public virtual Image Image { get; set; }

        [SitecoreField("{BD8F81A9-CF44-430C-9510-9781A919DD1D}", SitecoreFieldType.SingleLineText)]
        public virtual string ButtonText { get; set; }

        [SitecoreField("{ACCCB192-DACB-4734-ACB7-43771229F958}", SitecoreFieldType.GeneralLink)]
        public virtual Link Link { get; set; }

        [SitecoreField("{26849E05-0F69-4049-A53A-70A5EEF61EC4}", SitecoreFieldType.Checkbox)]
        public virtual bool ButtonDisplay { get; set; }

    }
}
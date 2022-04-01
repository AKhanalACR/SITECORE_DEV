using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System.Collections.Generic;


namespace ACRHelix.Feature.IdeasContent.Models
{
  [SitecoreType(TemplateId = "{6C12C9A9-E894-4DA4-8497-2229EDCB0527}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
    public class IdeasPatientTiles : ICMSEntity
    {
        public virtual ID Id { get; set; }

        [SitecoreField("{14293BAD-456E-4082-B989-6A75A0BFACCE}", SitecoreFieldType.SingleLineText)]
        public virtual string Title { get; set; }

        [SitecoreField("{9E68C9A7-9EDC-4FD6-BBF0-E300DDD6973C}", SitecoreFieldType.Image)]
        public virtual Image Icon { get; set; }

        [SitecoreField("{ED4425C9-5BC0-46C3-8E6F-DE9913C02D77}", SitecoreFieldType.RichText)]
        public virtual string Text { get; set; }

    }
}
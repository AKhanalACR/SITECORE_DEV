using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System.Collections.Generic;


namespace ACRHelix.Feature.IdeasBanner.Models
{
    [SitecoreType(TemplateId = "{BB6BD623-3FC9-4D14-982E-E38C3F0D59AA}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
    public class IdeasBanner : ICMSEntity
    {
        public virtual ID Id { get; set; }

        [SitecoreField("{233020CB-FB4D-47DF-899F-33916D8352D2}", SitecoreFieldType.SingleLineText)]
        public virtual string DropdownTitle { get; set; }

        [SitecoreField("{1D51156B-2A54-44ED-9A4F-450D77E010BD}", SitecoreFieldType.Image)]
        public virtual Image BackgroundImage { get; set; }

        [SitecoreField("{28A9B132-44D7-475B-AD5A-48C33391FE7D}", SitecoreFieldType.Image)]
        public virtual Image OverlayImage1 { get; set; }

        [SitecoreField("{7DD331EE-53E5-4088-A1E7-30847140CB37}", SitecoreFieldType.Image)]
        public virtual Image OverlayImage2 { get; set; }

        [SitecoreField("{CFC25C2D-E397-4B5C-A5C9-FDF020882325}", SitecoreFieldType.Image)]
        public virtual Image OverlayImage3 { get; set; }

        [SitecoreField("{8FD4927A-5367-47EB-9EF4-582E54241EB0}", SitecoreFieldType.Multilist)]
        public virtual IEnumerable<LinkMenuItem> DropdownLinks { get; set; }

    }
}
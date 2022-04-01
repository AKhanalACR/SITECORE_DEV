using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.IdeasBanner.Models
{
    [SitecoreType(TemplateId = "{F51F5515-A618-4257-8EFC-F313CDAF5C6E}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
    public class LinkMenuItem : ICMSEntity
    {
        public ID Id { get; set; }

        [SitecoreField("{642F2F30-C8B3-424E-BC3B-087C457E9080}", SitecoreFieldType.SingleLineText)]
        public virtual string Title { get; set; }

        [SitecoreField("{3BFBC4FD-8A30-4EE9-963B-070A822D97B0}", SitecoreFieldType.GeneralLink)]
        public virtual Link Link { get; set; }

        [SitecoreField("{F8335057-7A33-4838-AA18-C77348BE2F0F}", SitecoreFieldType.SingleLineText)]
        public virtual string IconCSSClass { get; set; }

        
       
    }
}

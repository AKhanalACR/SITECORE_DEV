using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;
using Glass.Mapper.Sc.Configuration;

namespace ACRHelix.Feature.RadPACContent.Models
{
    //[SitecoreType(TemplateId = "{13C20322-C005-4AED-8DE8-CA6275666AB5}", EnforceTemplate = SitecoreEnforceTemplate.Template)]
    public interface IEventTile : ICMSEntity
    {
        ID Id { get; set; }
        string TileText { get; set; }        
        Image Image { get; set; }        
        Link Link { get; set; }
        IEnumerable<IEventTag> Tags { get; set; }
    }
}
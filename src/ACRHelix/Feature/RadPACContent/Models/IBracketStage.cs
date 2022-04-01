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
    [SitecoreType(AutoMap = true)] //, TemplateId = "{DD1AFC9A-92F8-4CF1-91B5-DE3D072B8960}", EnforceTemplate = SitecoreEnforceTemplate.Template)]
    public interface IBracketStage : ICMSEntity
    {
        ID Id { get; set; }
        string Name { get; set; }        
        string Color { get; set; }        

    }
}
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
    [SitecoreType(AutoMap = true)] //, TemplateId = "{5CF9F8D0-3017-4BB7-9891-896EBDB3B78D}", EnforceTemplate = SitecoreEnforceTemplate.Template)]
    public interface IChapter : ICMSEntity
    {
        ID Id { get; set; }
        string State { get; set; }        
        string Division { get; set; }        
        string Stage { get; set; } 
    }
}
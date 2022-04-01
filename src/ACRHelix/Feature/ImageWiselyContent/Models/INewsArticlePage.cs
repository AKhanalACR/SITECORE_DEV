using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.ImageWiselyContent.Models
{
    [SitecoreType(AutoMap = true, TemplateId = "{D030DE63-1B75-42DB-87BD-0A8C5F88EEDE}", EnforceTemplate = SitecoreEnforceTemplate.Template)]
    public interface INewsArticlePage : ICMSEntity
    {
        ID Id { get; } 

        string Title { get; set; }

        [SitecoreField("Tile Text")]
        string TileText { get; set; }

        [SitecoreInfo(SitecoreInfoType.Url, UrlOptions = SitecoreInfoUrlOptions.SiteResolving)]
        string Url { get; set; }
        
        DateTime Date { get; set; }

        string Topic { get; set; }
    }
}
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
    [SitecoreType(AutoMap = true, TemplateId = "{9C2B465D-D45D-46EE-9EF4-D20A938883DE}", EnforceTemplate = SitecoreEnforceTemplate.Template)]
    public interface IArticlePage : ICMSEntity
    {
        ID Id { get; } 

        string Title { get; set; }

        [SitecoreField("Tile Text")]
        string TileText { get; set; }

        [SitecoreInfo(SitecoreInfoType.Url, UrlOptions = SitecoreInfoUrlOptions.SiteResolving)]
        string Url { get; set; }

        [SitecoreField("Link Text")]
        string LinkText { get; set; }

        Image Image { get; set; }
        
        DateTime Date { get; set; }

        string Topic { get; set; }

        Link Link { get; set; }
    }
}
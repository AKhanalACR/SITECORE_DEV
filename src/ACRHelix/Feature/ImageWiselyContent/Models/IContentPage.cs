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
    [SitecoreType(AutoMap = true, TemplateId = "{E1ACDD50-F675-4FB9-87C7-EFDF7CAD9B8D}", EnforceTemplate = SitecoreEnforceTemplate.Template)]
    public interface IContentPage : ICMSEntity
    {
        ID Id { get; } 

        string Title { get; set; }

        [SitecoreField("Tile Text")]
        string TileText { get; set; }

        [SitecoreInfo(SitecoreInfoType.Url, UrlOptions = SitecoreInfoUrlOptions.SiteResolving)]
        string Url { get; set; }

        Image Image { get; set; }
       
    }
}
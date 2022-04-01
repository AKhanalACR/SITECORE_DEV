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
    [SitecoreType(AutoMap = true, TemplateId = "{4C05555A-8508-4B0C-8900-B30D024B861E}", EnforceTemplate = SitecoreEnforceTemplate.Template)]
    public interface ITopicFolder : ICMSEntity
    {
        ID Id { get; } 

        string Name { get; set; }

        //[SitecoreChildren]
        //IEnumerable<INewsArticlePage> NewsArticlePageList { get; set; }

        //[SitecoreChildren]
        //IEnumerable<IArticlePage> ArticlePageList { get; set; }


    }
}
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
    public interface INewsList : ICMSEntity
    {
        ID Id { get; set; }

        string Title { get; set; }

        [SitecoreField("Sub Title")]
        string SubTitle { get; set; }

        [SitecoreField("Page Size")]
        int PageSize { get; set; }

        [SitecoreInfo(SitecoreInfoType.Url, UrlOptions = SitecoreInfoUrlOptions.SiteResolving)]
        string Url { get; set; }

        [SitecoreQuery(".//*[@@templateid='{D030DE63-1B75-42DB-87BD-0A8C5F88EEDE}']", IsRelative = true)]
        IEnumerable<INewsArticlePage> NewsArticleList { get; set; }

        [SitecoreChildren]
        IEnumerable<ITopicFolder> TopicFolder { get; set; }

    }
}
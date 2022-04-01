using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;
using Glass.Mapper.Sc.Configuration;

namespace ACRHelix.Feature.ImageWiselyContent.Models
{
    public interface IArchive : ICMSEntity
    {
        ID Id { get; set; }

        string Title { get; set; }

        string SubTitle { get; set; }

        Link Link { get; set; }

        [SitecoreInfo(SitecoreInfoType.Url, UrlOptions = SitecoreInfoUrlOptions.SiteResolving)]
        string Url { get; set; }

        [SitecoreField("Page Size")]
        int PageSize { get; set; }

        Image Image { get; set; }

        string NewSectionTitle { get; set; }

        string PreviousSectionTitle { get; set; }

        [SitecoreChildren]
        IEnumerable<ITopicFolder> TopicFolder { get; set; }

        [SitecoreQuery(".//*[@@templateid='{E1ACDD50-F675-4FB9-87C7-EFDF7CAD9B8D}']", IsRelative = true)]
        IEnumerable<IContentPage> ContentPageList { get; set; }

        [SitecoreQuery(".//*[@@templateid='{9C2B465D-D45D-46EE-9EF4-D20A938883DE}']", IsRelative = true)]
        IEnumerable<IArticlePage> ArticlePageList { get; set; }
    }
}
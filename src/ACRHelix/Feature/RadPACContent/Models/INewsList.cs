using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.RadPACContent.Models
{
    public interface INewsList : ICMSEntity
    {
        ID Id { get; set; }
        string Title { get; set; }
                
        int PageSize { get; set; }

        [SitecoreQuery("/sitecore/content/RadPAC//*[@@templateid='{1B1B7AB0-2EAC-4DDA-9479-000C38FDC8DA}']")]
        IEnumerable<INewsArticle> NewsArticlesList { get; set; }
    }
}
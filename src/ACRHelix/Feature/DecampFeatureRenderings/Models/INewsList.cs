using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.DecampFeatureRenderings.Models
{
    public interface INewsList : ICMSEntity
    {
        ID Id { get; set; }
        string Title { get; set; }
                
        int PageSize { get; set; }

        Link Link { get; set; }

        [SitecoreQuery("/sitecore/content/DECAMP//*[@@templateid='{7051786E-9B2C-4B3E-8474-1A613406D476}']")]
        IEnumerable<INewsArticle> NewsArticlesList { get; set; }
    }
}
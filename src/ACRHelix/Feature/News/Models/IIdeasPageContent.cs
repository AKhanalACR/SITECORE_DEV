using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.News.Models
{
    public interface IIdeasPageContent : ICMSEntity
    {
        ID Id { get; set; }
        string Title { get; set; }
        string SubTitle { get; set; }
        string RichText { get; set; }
        //[SitecoreQuery("/sitecore/content/Ideas/Global/Dictionary/News Years/*[@@templateid = '{CEE9EB98-D110-4220-BD0E-5A3F3FC79A10}']", IsRelative = false)]
        //IEnumerable<IdeasNewsYear> Years { get; set; }

        [SitecoreQuery("/sitecore/content/Ideas/*[@@templateid = '{A10E60A0-79C7-40A1-8A7B-0D46EF606812}']/*[@@templateid = '{6656C222-8AA8-46BC-BE0B-BE85465B6500}']", IsRelative = false)]
        IEnumerable<IdeasNewsArticle> NewsArticles { get; set; }
    }
}
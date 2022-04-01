using System.Collections.Generic;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.News.Models
{
    [SitecoreType(TemplateId = "{D569CEDA-AF09-4CF6-A84B-05E214BDFE59}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]

    public class IdeasSelectedNewsList : ICMSEntity
    {
        public virtual ID Id { get; set; }
        [SitecoreField("Title")]
        public virtual string Title { get; set; }

        [SitecoreField("View More Link")]
        public virtual Link ViewMoreLink { get; set; }

        [SitecoreField("View More Link Text")]
        public virtual string ViewMoreLinkText { get; set; }

        [SitecoreField("Number of links to be displayed")]
        public virtual int NumberOfLinks { get; set; }


        [SitecoreField("Selected News")]
        public virtual IEnumerable<IdeasNewsArticle> SelectedArticles { get; set; }

        [SitecoreQuery("/sitecore/content/Ideas/*[@@templateid = '{A10E60A0-79C7-40A1-8A7B-0D46EF606812}']/*[@@templateid = '{6656C222-8AA8-46BC-BE0B-BE85465B6500}']", IsRelative = false)]
        public virtual IEnumerable<IdeasNewsArticle> AllArticles { get; set; }
    }
}
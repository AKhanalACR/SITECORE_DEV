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
    public class NewsList : INewsList
    {
        public ID Id { get; set; }
        public string Title { get; set; }

        public int PageSize { get; set; }

        public IEnumerable<INewsArticle> NewsArticlesList { get; set; }
    }
}
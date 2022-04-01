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
    public class LatestNewsList : ILatestNewsList
    {
        public ID Id { get; set; }
        public string Title { get; set; }
       
        public int DisplayNumber { get; set; }
        public Link Link { get; set; }

        public IEnumerable<INewsArticle> NewsArticlesList { get; set; }
    }
}
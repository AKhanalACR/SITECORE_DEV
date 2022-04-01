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
    public class TopicFolder : ITopicFolder
    {
        public ID Id { get; }

        public string Name { get; set; }

        //public IEnumerable<INewsArticlePage> NewsArticlePageList { get; set; }

        //public IEnumerable<IArticlePage> ArticlePageList { get; set; }


    }
}
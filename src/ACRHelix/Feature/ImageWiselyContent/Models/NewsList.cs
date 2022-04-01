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
    public class NewsList : INewsList
    {
        public ID Id { get; set; }

        public string Title { get; set; }
        
        public string SubTitle { get; set; }
        
        public int PageSize { get; set; }
        public string Url { get; set; }

        public virtual IEnumerable<INewsArticlePage> NewsArticleList { get; set; }
        public IEnumerable<ITopicFolder> TopicFolder { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.ImageWiselyContent.Models
{
    public class Archive : IArchive
    {
        public ID Id { get; set; }

        public string Title { get; set; }
       
        public string SubTitle { get; set; }

        public Link Link { get; set; }

        public string Url { get; set; }

        public int PageSize { get; set; }

        public Image Image { get; set; }

        public string NewSectionTitle { get; set; }

        public string PreviousSectionTitle { get; set; }

        public IEnumerable<ITopicFolder> TopicFolder { get; set; }

        public IEnumerable<IContentPage> ContentPageList { get; set; }

        public IEnumerable<IArticlePage> ArticlePageList { get; set; }
    }
}
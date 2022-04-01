using System;
using System.Collections.Generic;
using System.Linq;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.News.Models
{
    public class IdeasNewsHubPageContent : IIdeasPageContent
    {
        public IdeasNewsHubPageContent()
        {
            NewsArticles = new List<Models.IdeasNewsArticle>();
            Years = new List<Models.IdeasNewsYear>();
        }
        public virtual ID Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string SubTitle { get; set; }
        public virtual string RichText { get; set; }
        public virtual IEnumerable<IdeasNewsYear> Years { get; set; }

        public virtual IEnumerable<IdeasNewsArticle> NewsArticles { get; set; }
    }
}
using System;
using System.Collections.Generic;
using Glass.Mapper.Sc.Fields;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.DsiNewsAndBlogs.Models
{
    public class RecentBlogList : IRecentBlogList
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public Link ArchivesLink { get; set; }
        public IEnumerable<NewsArticle> Articles { get; set; }
        public int DisplayNumber { get; set; }
    }
}
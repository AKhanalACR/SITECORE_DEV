using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.DsiNewsAndBlogs.Models
{
    public class BlogArchive : IBlogArchive
    {
        public Guid Id { get; }
        public string Title { get; }
        public string Type { get; set; }
        public IEnumerable<NewsArticle> Articles { get; set; } 
        public int DisplayNumber { get; set; }
    }
}
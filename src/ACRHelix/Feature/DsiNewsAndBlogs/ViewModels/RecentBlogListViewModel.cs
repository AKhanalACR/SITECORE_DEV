using ACRHelix.Feature.DsiNewsAndBlogs.Models;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.DsiNewsAndBlogs.ViewModels
{
    public class RecentBlogListViewModel
    {        
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public Link ArchivesLink { get; set; }
        public IEnumerable<Guid> TagFilter { get; set; }
        public MultiSelectList TagList { get; set; }
        public IEnumerable<NewsArticle> NewsArticles { get; set; }
    }
}
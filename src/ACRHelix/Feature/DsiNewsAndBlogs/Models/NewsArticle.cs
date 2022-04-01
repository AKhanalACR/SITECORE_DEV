using System;
using System.Collections.Generic;
using Glass.Mapper.Sc.Fields;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.DsiNewsAndBlogs.Models
{
    public class NewsArticle : INewsArticle
    {
        public virtual Guid Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string SubTitle { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual string Author { get; set; }
        public virtual string Type { get; set; }
        public virtual string Content { get; set; }
        public virtual string Url { get; set; }
        public virtual  string Source { get; set; }
        public virtual IEnumerable<Guid> Tags { get; set; }
        public virtual string LinkOverride { get; set; }
        public virtual string TileText { get; set; }
        public virtual Image Image { get; set; }
    }
}
using Sitecore.Data.Items;
using Sitecore.Feature.XBlog.Areas.XBlog.Items.Blog;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Feature.XBlog.Areas.XBlog.Models.Blog
{
  public class VorBlogCommentsModel : RenderingModel
  {
        public string Title {get; set;}
        public IEnumerable<VORBlogComment> VORBlogComments { get; set; }
    }
}
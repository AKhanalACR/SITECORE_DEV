using System.Collections.Generic;
using System.Web;
using Sitecore.Data;
using ACRHelix.Feature.DsiNewsAndBlogs.Models;

namespace ACRHelix.Feature.DsiNewsAndBlogs.ViewModels
{
  public class FeaturedXBlogsViewModel 
  {
    public virtual ID Id { get; set; }
    public virtual IEnumerable<IBlogPost> MainFeaturedBlog { get; set; }
    public virtual IEnumerable<IBlogPost> SubFeaturedBlogs { get; set; }
  }
}
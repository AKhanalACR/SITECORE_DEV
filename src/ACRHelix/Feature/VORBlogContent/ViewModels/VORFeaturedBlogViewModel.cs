using System.Collections.Generic;
using System.Web;
using Sitecore.Data;
using ACRHelix.Feature.VORBlogContent.Models;

namespace ACRHelix.Feature.VORBlogContent.ViewModels
{
  public class VORFeaturedBlogViewModel
  {
    public virtual ID Id { get; set; }
    public virtual IEnumerable<IVORBlogPost> MainFeaturedBlog { get; set; }
    
  }
}
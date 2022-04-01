using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration;


namespace ACRHelix.Feature.DsiNewsAndBlogs.Models
{
  
  public class FeaturedXBlogs : IFeaturedXBlogs
  {
    public virtual ID Id { get; set; }  
    
    public virtual IEnumerable<IBlogPost> MainFeaturedBlog { get; set; }
    public virtual IEnumerable<IBlogPost> SubFeaturedBlogs { get; set; }
  }
}
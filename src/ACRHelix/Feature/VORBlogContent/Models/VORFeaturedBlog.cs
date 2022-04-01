using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration;


namespace ACRHelix.Feature.VORBlogContent.Models
{
  
  public class VORFeaturedBlog : IVORFeaturedBlog
  {
    public virtual ID Id { get; set; }  
    
    public virtual IEnumerable<IVORBlogPost> MainFeaturedBlog { get; set; }
   
  }
}
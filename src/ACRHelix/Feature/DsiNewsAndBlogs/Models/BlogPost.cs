using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using ACRHelix.Foundation.Model;
using Sitecore.Data;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.DsiNewsAndBlogs.Models
{
  public class BlogPost : IBlogPost
  {
    public virtual ID Id { get; }
    public virtual string Title { get; set; }
    public virtual string Summary { get; set; }    
    public virtual string Body { get; set; }    
    public virtual DateTime PublishDate { get; set; }
    public virtual Image FeaturedImage { get; set; }   
    public virtual string FeaturedPosition { get; set; }
    public virtual string Url { get; set; }
    public virtual string Category { get; set; }
    public virtual string Author { get; set; }
  }
}
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration;


namespace ACRHelix.Feature.DsiNewsAndBlogs.Models
{
  [SitecoreType(TemplateId = "{B754AEA1-FC4C-47B6-B99C-8044D5FA834C}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.TemplateAndBase)]
  public interface IFeaturedXBlogs : ICMSEntity
  {
    ID Id { get; set; }
    
    [SitecoreField("Main Featured Blog", FieldType = SitecoreFieldType.Treelist)]
    IEnumerable<IBlogPost> MainFeaturedBlog { get; set; }

    [SitecoreField("Sub Featured Blogs", FieldType = SitecoreFieldType.Treelist)]
    IEnumerable<IBlogPost> SubFeaturedBlogs { get; set; }
  }
}
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration;


namespace ACRHelix.Feature.VORBlogContent.Models
{
  [SitecoreType(TemplateId = "{5E2F4DC6-0C3B-41EA-AE0D-741F42CAC79A}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.TemplateAndBase)]
  public interface IVORFeaturedBlog : ICMSEntity
  {
    ID Id { get; set; }
    
    [SitecoreField("Main Featured Blog", FieldType = SitecoreFieldType.Treelist)]
    IEnumerable<IVORBlogPost> MainFeaturedBlog { get; set; }

    
  }
}
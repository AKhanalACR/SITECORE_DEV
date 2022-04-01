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
using Glass.Mapper.Sc.Configuration.Fluent;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.DsiNewsAndBlogs.Models
{
  
  [SitecoreType(TemplateId = "{60776C24-BEB7-4193-A6DC-FA560A40A15B}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public interface IBlogPost : ICMSEntity
  {
    ID Id { get; }
    string Title { get; set; }
    string Summary { get; set; }
    string Body { get; set; }

    //[SitecoreField("{9608E520-EF16-49FC-BD92-75CC101E5FEC}")]
    [SitecoreField("Publish Date")]
    DateTime PublishDate { get; set; }

    [SitecoreField("{833B419C-121F-4B40-863C-99B1F6CD32F0}", SitecoreFieldType.Image)]
    Image FeaturedImage { get; set; }

    [SitecoreField("{4CC04D77-9ED6-473C-9A27-C9F6BF780D2B}", SitecoreFieldType.Droplist)]
    string FeaturedPosition { get; set; }

    string Url { get; set; }

    [SitecoreField("Category")]
    string Category { get; set; }

    [SitecoreField("Author")]
    string Author { get; set; }
  }
}
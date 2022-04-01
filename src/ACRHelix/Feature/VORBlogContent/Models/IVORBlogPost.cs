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
using Sitecore.Feature.VORBlogContent;

namespace ACRHelix.Feature.VORBlogContent.Models
{
  
  [SitecoreType(TemplateId = "{F1EC5843-A85E-447D-A919-EDB4FF815615}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public interface IVORBlogPost : ICMSEntity
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

    [SitecoreField("{0E02704D-0AFD-4102-8D99-9241A8B03C89}")]
    string Category { get; set; }

    [SitecoreField("{06B84F39-CF71-446A-81AA-30E76FEBE4A5}")]
    IEnumerable <IAuthor> Authors { get; set; }
  }
}
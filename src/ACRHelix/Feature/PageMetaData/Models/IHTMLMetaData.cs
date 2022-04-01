using ACRHelix.Foundation.Model;
using System;
using Glass.Mapper.Sc.Fields;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;

namespace ACRHelix.Feature.HTMLMetadata.Models
{
  [SitecoreType(TemplateId = "{4492C968-D3D5-401A-8792-7951960B2E24}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.TemplateAndBase)]
  public interface IHTMLMetadata : ICMSEntity, IOpenGraph
  {
    ID Id { get; set; }
    string PageTitle { get; set; }
    string MetaDescription { get; set; }
    string MetaKeywords { get; set; }

        string SiteName { get; set; }

    }
}
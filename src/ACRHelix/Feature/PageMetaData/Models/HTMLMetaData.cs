using System;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.HTMLMetadata.Models
{
  public class HTMLMetadata : IHTMLMetadata
  {
    public ID Id { get; set; }
    public string PageTitle { get; set; }
    public string MetaDescription { get; set; }
    public string MetaKeywords { get; set; }
        public string SiteName { get; set; }
        public string OG_Title { get; set; }
    public string OG_Description { get; set; }
    public Image OG_Image { get; set; }
  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.HTMLMetadata.ViewModels
{
  public class PageMetadataViewModel
  {
    public ID Id { get; set; }
    public string PageTitle { get; set; }
    public string MetaDescription { get; set; }
    public string MetaKeywords { get; set; }
    public string SiteName { get; set; }
    
    public string OG_URL {get;set;}
    public string OG_Title { get; set; }
    public string OG_Description { get; set; }
    public string OG_Image { get; set; }

    }
}
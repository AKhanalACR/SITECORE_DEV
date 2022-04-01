using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Feature.PageContent.Models;
using Sitecore.Data;

namespace ACRHelix.Feature.PageContent.ViewModels
{
  public class KeyTakeawaysViewModel
  {
    public ID Id { get; set; }
    public string Title { get; set; }
    public string Instructions { get; set; }

    public string Takeaways { get; set; }

    public List<TextSection> AllSections { get; set; } = new List<TextSection>();

    public List<TextSection> TextSections { get; set; } = new List<TextSection>();
    public List<TextImageSection> TextImageSections { get; set; } = new List<TextImageSection>();
    public List<TextSectionCallout> TextSectionCallout { get; set; } = new List<Models.TextSectionCallout>();

  }
}
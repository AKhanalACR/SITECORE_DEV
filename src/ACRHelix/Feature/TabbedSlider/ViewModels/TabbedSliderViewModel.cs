using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.TabbedSlider.ViewModels
{
    public class TabbedSliderViewModel
    {

    public TabbedSliderViewModel()
    {
      if (Sitecore.Context.PageMode.IsExperienceEditor)
      {
        TabSliderCSSClass = "acr-news-slider-disabled";
      }
      else
      {
        TabSliderCSSClass = "acr-news-slider";
      }
    }

    public ID Id { get; set; }

    public string PageID { get; set; }

    public Link NewsLink { get; set; }

        public IEnumerable<TabViewModel> Tabs { get; set; } = new List<TabViewModel>();
        public string TabSliderCSSClass { get; }
    }
}
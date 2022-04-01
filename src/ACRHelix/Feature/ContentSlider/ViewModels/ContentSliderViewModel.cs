using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.ContentSlider.ViewModels
{
  public class ContentSliderViewModel
  {


    public ID Id { get; set; }
    public IEnumerable<SlideViewModel> Slides { get; set; } = new List<SlideViewModel>();
    
    public string SliderClass
    {
      get
      {
        if (Sitecore.Context.PageMode.IsExperienceEditor)
        {
          return "carousel-slider-disabled";
        }
        else
        {
          return "carousel-slider";
        }
      }
    }

    public string SliderID
    {
      get
      {
        if (Sitecore.Context.PageMode.IsExperienceEditor)
        {
          return "home-slider-disabled";
        }
        else
        {
          return "home-slider";
        }
      }
    }
    }
}
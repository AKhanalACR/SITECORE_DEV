using ACRHelix.Feature.ImageWiselyContent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.ImageWiselyContent.ViewModels
{
    public class IWCarouselViewModel
    {
        public ContentSlider ContentSlider { get; set; }

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
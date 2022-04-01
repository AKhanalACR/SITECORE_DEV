using ACRHelix.Feature.TabbedSlider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.TabbedSlider.Services
{
    public interface IContentService
    {
        ITabbedSlider GetTabbedSliderContent(string contentGuid);
        IEnumerable<ISlide> GetPopularTabSliderContent(Guid Id);
    }
}
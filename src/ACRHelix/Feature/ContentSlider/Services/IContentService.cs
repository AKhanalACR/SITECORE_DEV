using ACRHelix.Feature.ContentSlider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.ContentSlider.Services
{
  public interface IContentService
  {
    Models.ContentSlider GetContentSliderContent(string contentGuid);
  }
}
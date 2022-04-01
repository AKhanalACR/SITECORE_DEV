using ACRHelix.Feature.ContentSlider.Services;
using ACRHelix.Feature.ContentSlider.ViewModels;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.ContentSlider
{
  public class ContentSliderController : Controller
  {
    private readonly IContentService _contentService;

    public ContentSliderController(IContentService contentService)
    {
      _contentService = contentService;
    }

    public ViewResult ContentSlider()
    {
      var viewModel = new ContentSliderViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {    
          var sliderContent = _contentService.GetContentSliderContent(RenderingContext.Current.Rendering.DataSource);
          if (sliderContent != null)
          {
            viewModel.Id = sliderContent.Id;
            viewModel.Slides = sliderContent.Slides.Select(s => new SlideViewModel
            {
              AlertText = s.AlertText,
              Title = s.Title,
              Link = s.Link,
              Image = s.Image,
              Id = s.Id,
              Text = s.Text
            });
          }
        
      }
      return View(viewModel);
    }

    public ViewResult FullWidthSlider()
    {
      var viewModel = new ContentSliderViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var sliderContent = _contentService.GetContentSliderContent(RenderingContext.Current.Rendering.DataSource);
        if (sliderContent != null)
        {
          viewModel.Id = sliderContent.Id;
          viewModel.Slides = sliderContent.Slides.Select(s => new SlideViewModel
          {
            AlertText = s.AlertText,
            Title = s.Title,
            Link = s.Link,
            Image = s.Image,
            Id = s.Id,
            Text = s.Text
          });
        }
      }
      return View("FullWidthSlider", viewModel);
    }
  }
}
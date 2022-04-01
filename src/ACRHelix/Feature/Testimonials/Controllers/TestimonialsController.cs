using ACRHelix.Feature.Testimonials.Services;
using ACRHelix.Feature.Testimonials.ViewModels;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.Testimonials
{
  public class TestimonialsController : Controller
  {
    private readonly IContentService _contentService;

    public TestimonialsController(IContentService contentService)
    {
      _contentService = contentService;
    }

    public ViewResult Testimonials()
    {
      var viewModel = new TestimonialsViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (String.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      if (!String.IsNullOrEmpty(dataSource))
      {
        var TestimonialsContent = _contentService.GetTestimonialsContent(dataSource);
        if (TestimonialsContent != null)
        {
          viewModel.Id = TestimonialsContent.Id;
          viewModel.Title = TestimonialsContent.Title;
          viewModel.Testimonials = TestimonialsContent.TestimonialItems;
        }
      }
      return View(viewModel);
    }
  }
}
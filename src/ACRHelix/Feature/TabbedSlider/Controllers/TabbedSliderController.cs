using ACRHelix.Feature.TabbedSlider.Models;
using ACRHelix.Feature.TabbedSlider.Services;
using ACRHelix.Feature.TabbedSlider.ViewModels;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.TabbedSlider
{
  public class TabbedSliderController : Controller
  {
    private readonly IContentService _contentService;

    public TabbedSliderController(IContentService contentService)
    {
      _contentService = contentService;
    }

    public ViewResult TabbedSlider()
    {
      var viewModel = new TabbedSliderViewModel();
      viewModel.PageID = Sitecore.Context.Item.ID.ToShortID().ToString();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var TabbedSliderContent = _contentService.GetTabbedSliderContent(RenderingContext.Current.Rendering.DataSource);
        if (TabbedSliderContent != null)
        {
          viewModel.Id = TabbedSliderContent.ID;
          viewModel.NewsLink = TabbedSliderContent.Link;
          viewModel.Tabs = TabbedSliderContent.Tabs.Select(c => new TabViewModel
          {
            Id = c.Id,
            Title = c.Title,
            Anchor = c.Title.Replace(" ", ""),
            Slides = GetSlides(c)
          });
        }
      }
      return View(viewModel);
    }

    private IEnumerable<SlideViewModel> GetSlides(ITab tab)
    {
      if (tab.TemplateName == "PopularTab")
      {
        tab.Slides = _contentService.GetPopularTabSliderContent(tab.Id);
      }

      var slides = tab.Slides.Select(s => new SlideViewModel
      {
        Id = s.Id,
        Image = s.Image,
        Link = s.Link,
        Title = s.Title,
        Text = s.Text,
        PopularTab = tab.TemplateName == "PopularTab",
        LinkUrl = s.LinkUrl,
        ImageUrl = s.ImageUrl
      });
     
      return slides;
    }
  }
}
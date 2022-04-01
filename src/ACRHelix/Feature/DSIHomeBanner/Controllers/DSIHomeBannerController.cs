using ACRHelix.Feature.DSIHomeBanner.Services;
using Sitecore.Foundation.SitecoreExtensions.Extensions;
using Sitecore.Mvc.Presentation;
using System;
using System.Web.Mvc;
using ACRHelix.Feature.DSIHomeBanner.ViewModels;

namespace ACRHelix.Feature.DSIHomeBanner
{
  public class DSIHomeBannerController : Controller
  {
    private readonly IContentService _contentService;

    public DSIHomeBannerController(IContentService contentService)
    {
      _contentService = contentService;
    }

    public ViewResult DSIHomeBanner()
    {
      var viewModel = new Models.DSIHomeBanner();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var DSIHomeBannerContent = _contentService.GetDSIHomeBannerContent(RenderingContext.Current.Rendering.DataSource);
        if (DSIHomeBannerContent != null)
        {
          viewModel = DSIHomeBannerContent;


          viewModel.FixNullLinks<Models.DSIHomeBanner>();
        }
      }
      return View(viewModel);
    }
	
    public ViewResult HomeBanner()
    {     
      var viewModel = new HomeBannerViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var homeBannerContent = _contentService.GetHomeBannerContent(RenderingContext.Current.Rendering.DataSource);
        if (homeBannerContent != null)
        {
          viewModel.Id = homeBannerContent.Id;
          viewModel.Title = homeBannerContent.Title;
          viewModel.SubTitle = homeBannerContent.SubTitle;
          viewModel.BGImage = homeBannerContent.BGImage;
          viewModel.Link = homeBannerContent.Link;
        }
      }
      return View(viewModel);
    }

    public ViewResult DSICalloutItem()
    {
      var viewModel = new DSICalloutItemViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var CalloutsContent = _contentService.GetCalloutItem(RenderingContext.Current.Rendering.DataSource);
        if (CalloutsContent != null)
        {
          viewModel.Id = CalloutsContent.Id;
          viewModel.Title = CalloutsContent.Title;
          viewModel.SubTitle = CalloutsContent.SubTitle;
          viewModel.Teaser = CalloutsContent.Teaser;
          viewModel.Link = CalloutsContent.Link;
          viewModel.SecondLink = CalloutsContent.SecondLink;
          viewModel.Image = CalloutsContent.Image;
          viewModel.AnimateFromRight = CalloutsContent.AnimateFromRight;
        }
      }
      return View("DSICalloutItem", viewModel);
    }

    public ViewResult BlockCallout()
    {
      var viewModel = new BlockCalloutViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var CalloutsContent = _contentService.GetBlockCallout(RenderingContext.Current.Rendering.DataSource);
        if (CalloutsContent != null)
        {
          viewModel.Id = CalloutsContent.Id;
          viewModel.Title = CalloutsContent.Title;
          viewModel.Link = CalloutsContent.Link;
          viewModel.Image = CalloutsContent.Image;
        }
      }
      return View("BlockCallout", viewModel);
    }
  }
}
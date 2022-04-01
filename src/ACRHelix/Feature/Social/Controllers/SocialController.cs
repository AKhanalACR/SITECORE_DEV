using ACRHelix.Feature.Social.Services;
using ACRHelix.Feature.Social.ViewModels;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.Social
{
  public class SocialController : Controller
  {
    private readonly IContentService _contentService;

    public SocialController(IContentService contentService)
    {
      _contentService = contentService;
    }

    public ViewResult Footer()
    {
      var viewModel = new FooterViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var SocialContent = _contentService.GetSocialFooterContent(RenderingContext.Current.Rendering.DataSource);
        if (SocialContent != null)
        {
          viewModel.Title = SocialContent.Title;
          viewModel.Id = SocialContent.Id;
          viewModel.Image = SocialContent.Image;
          viewModel.EngageLink = SocialContent.EngageLink;
        }
      }
      return View(viewModel);
    }

    public ViewResult SocialList()
    {
      var viewModel = new SocialListViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var SocialContent = _contentService.GetSocialListContent(RenderingContext.Current.Rendering.DataSource);
        if (SocialContent != null)
        {
          viewModel.SocialItems = SocialContent.SocialItems.Select(i => new SocialItemViewModel { CSSClass = i.CSSClass, Id = i.Id, Link = i.Link });
        }
      }
      return View(viewModel);
    }

        public ViewResult IWConnect()
        {
            var viewModel = new SocialListViewModel();
            if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                var SocialContent = _contentService.GetSocialListContent(RenderingContext.Current.Rendering.DataSource);
                if (SocialContent != null)
                {
                    viewModel.SocialItems = SocialContent.SocialItems.Select(i => new SocialItemViewModel { CSSClass = i.CSSClass, Id = i.Id, Link = i.Link });
                }
            }
            return View(viewModel);
        }
    }
}
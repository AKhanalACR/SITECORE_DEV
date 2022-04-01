using ACRHelix.Feature.IdeasBanner.Services;
using ACRHelix.Feature.IdeasBanner.ViewModels;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.IdeasBanner
{
    public class IdeasBannerController : Controller
    {
        private readonly IContentService _contentService;

        public IdeasBannerController(IContentService contentService)
        {
            _contentService = contentService;
        }

        public ViewResult IdeasBanner()
        {
            var viewModel = new Models.IdeasBanner();
            if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                var IdeasBannerContent = _contentService.GetIdeasBannerContent(RenderingContext.Current.Rendering.DataSource);
                if (IdeasBannerContent != null)
                {
                    viewModel = IdeasBannerContent;
                }
            }
            return View(viewModel);
        }
    }
}
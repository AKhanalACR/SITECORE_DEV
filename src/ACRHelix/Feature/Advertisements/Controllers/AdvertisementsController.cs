using ACRHelix.Feature.Advertisements.Services;
using ACRHelix.Feature.Advertisements.ViewModels;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.Advertisements
{
    public class AdvertisementsController : Controller
    {
        private readonly IContentService _contentService;

        public AdvertisementsController(IContentService contentService)
        {
            _contentService = contentService;
        }

        public ViewResult TopBannerAd()
        {
            var viewModel = new TopBannerAdViewModel();
            if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                var AdvertisementsContent = _contentService.GetAdvertisementsContent(RenderingContext.Current.Rendering.DataSource);
                if (AdvertisementsContent != null)
                {
                    viewModel.Id = AdvertisementsContent.Id;
                    viewModel.Javascript = AdvertisementsContent.Javascript;
                }
            }
            return View(viewModel);
        }

        public ViewResult AdBar()
        {
            var viewModel = new AdBarViewModel();
            var dataSource = RenderingContext.Current.Rendering.DataSource;

            if (String.IsNullOrEmpty(dataSource))
            {
                dataSource = Sitecore.Context.Item.ID.ToString();
            }
            if (!String.IsNullOrEmpty(dataSource))
            {
                var AdvertisementsContent = _contentService.GetAdBarContent(dataSource);
                if (AdvertisementsContent != null)
                {
                    viewModel.Id = AdvertisementsContent.Id;
                    viewModel.HTML = AdvertisementsContent.HTML;
                }
            }
            return View(viewModel);
        }
    }
}
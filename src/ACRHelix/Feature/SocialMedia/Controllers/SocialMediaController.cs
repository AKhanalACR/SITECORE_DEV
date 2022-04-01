using ACRHelix.Feature.SocialMedia.Services;
using ACRHelix.Feature.SocialMedia.ViewModels;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.SocialMedia
{
    public class SocialMediaController : Controller
    {
        private readonly IContentService _contentService;

        public SocialMediaController(IContentService contentService)
        {
            _contentService = contentService;
        }

        public ViewResult SocialMedia()
        {
            var viewModel = new SocialMediaViewModel();
            var dataSource = RenderingContext.Current.Rendering.DataSource;

            if (String.IsNullOrEmpty(dataSource))
            {
                dataSource = Sitecore.Context.Item.ID.ToString();
            }
            if (!String.IsNullOrEmpty(dataSource))
            {
                var SocialMediaContent = _contentService.GetSocialMediaContent(dataSource);
                if (SocialMediaContent != null)
                {
                    viewModel.Id = SocialMediaContent.Id;
                    viewModel.Title = SocialMediaContent.Title;
                    viewModel.SubTitle = SocialMediaContent.SubTitle;
                }
            }
            return View(viewModel);
        }

        public ViewResult SocialMediaLinkList()
        {
            var viewModel = new SocialMediaLinkListViewModel();
            var dataSource = RenderingContext.Current.Rendering.DataSource;

            if (String.IsNullOrEmpty(dataSource))
            {
                dataSource = Sitecore.Context.Item.ID.ToString();
            }
            if (!String.IsNullOrEmpty(dataSource))
            {
                var SocialMediaLinkListContent = _contentService.GetSocialMediaLinkListContent(dataSource);
                if (SocialMediaLinkListContent != null)
                {
                    viewModel.Id = SocialMediaLinkListContent.Id;
                    viewModel.Title = SocialMediaLinkListContent.Title;
                    viewModel.Links = SocialMediaLinkListContent.Links;
                }
            }
            return View(viewModel);
        }

        public ViewResult SocialMediaFeed()
        {
            var viewModel = new SocialMediaFeedViewModel();
            var dataSource = RenderingContext.Current.Rendering.DataSource;

            if (String.IsNullOrEmpty(dataSource))
            {
                dataSource = Sitecore.Context.Item.ID.ToString();
            }
            if (!String.IsNullOrEmpty(dataSource))
            {
                var SocialMediaFeedContent = _contentService.GetSocialMediaFeedContent(dataSource);
                if (SocialMediaFeedContent != null)
                {
                    viewModel.Id = SocialMediaFeedContent.Id;
                    viewModel.EmbeddedHTML= SocialMediaFeedContent.EmbeddedHTML;
                }
            }
            return View(viewModel);
        }
    }
}
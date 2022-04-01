using ACRHelix.Feature.IdeasResources.Models;
using ACRHelix.Feature.IdeasResources.Services;
using ACRHelix.Feature.IdeasResources.ViewModels;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.IdeasResources
{
    public class IdeasResourcesController : Controller
    {
        private readonly IContentService _contentService;

        public IdeasResourcesController(IContentService contentService)
        {
            _contentService = contentService;
        }

        public ViewResult IdeasSelectedResources()
        {
            var viewModel = new IdeasSelectedResourcesViewModel();

            var dataSource = RenderingContext.Current.Rendering.DataSource;
            if (!string.IsNullOrWhiteSpace(dataSource))
            {
                var resourcesList = _contentService.GetIdeasSelectedResources(dataSource);
                if (resourcesList != null)
                {
                    viewModel.Id = resourcesList.Id;
                    viewModel.Title = resourcesList.Title;
                    viewModel.Subtitle = resourcesList.Subtitle;
                    viewModel.ViewMoreLink = resourcesList.ViewMoreLink;
                    viewModel.ViewMoreLinkText = resourcesList.ViewMoreLinkText;
                    foreach (var resource in resourcesList.SelectedResources.Take(resourcesList.NumberOfResources))
                    {
                        viewModel.SelectedResources.Add(resource);
                    }
                    if (viewModel.SelectedResources.Count < resourcesList.NumberOfResources)
                    {
                        foreach (var item in resourcesList.AllResources.OrderByDescending(x => x.Created))
                        {
                            if (viewModel.SelectedResources.Where(x => x.Id == item.Id).Count() == 0)
                            {
                                viewModel.SelectedResources.Add(item);
                            }
                            if (viewModel.SelectedResources.Count >= resourcesList.NumberOfResources)
                                break;
                        }
                        //var items = new <Sitecore.Data.Items.Item>(Sitecore.Context.Database.SelectItems(query)).ToList().OrderByDescending(x => x.Date).ToList().Take(newsList.NumberOfLinks).ToList();
                    }
                }
            }
            return View(viewModel);
        }

        public ViewResult IdeasVideoDetail()
        {
            var viewModel = new IdeasVideoDetailViewModel();
            var resourceItem = Sitecore.Context.Item;
            if (!string.IsNullOrEmpty(resourceItem.ID.ToString()))
            {
                var videoResource = _contentService.GetIdeasVideoResource(resourceItem.ID.ToString());
                if (videoResource != null)
                {
                    viewModel.Id = videoResource.Id;
                    viewModel.Title = videoResource.Title;
                    viewModel.Image = videoResource.Image;
                    viewModel.Link = videoResource.Link;
                    viewModel.IsYTVideo = videoResource.IsYTVideo;
                    viewModel.Created = videoResource.Created;
                    viewModel.ResourceType = videoResource.ResourceType;
                    viewModel.ResourceSubTitle= videoResource.ResourceSubTitle;
                }
            }
            return View(viewModel);
        }
        public ViewResult IdeasResourceListings()
        {
            var viewModel = new IdeasResourceListingsViewModel();

            var dataSource = RenderingContext.Current.Rendering.DataSource;
            if (!string.IsNullOrWhiteSpace(dataSource))
            {
                var resourcesList = _contentService.GetIdeasResourceLsitings(dataSource);
                if (resourcesList != null)
                {
                    viewModel.Id = resourcesList.Id;
                    viewModel.Title = resourcesList.Title;
                    viewModel.NumberOfResources = resourcesList.NumberOfResources;
                    viewModel.NumberOfResourcesLoadMore = resourcesList.NumberOfResourcesLoadMore;
                    //foreach (var item in resourcesList.AllResources.OrderBy(x => x.Created).
                    //        Where(x => x.ResourceType != null && (x.ResourceType != null && resourcesList.ResourceType != null ? x.ResourceType.Phrase == resourcesList.ResourceType.Phrase : true)))
                    //{
                    //    viewModel.Resources.Add(item);
                    //}
                    foreach (var item in resourcesList.AllResources.OrderByDescending(x => x.Created).
                            Where(x => x.ResourceType != null && (x.ResourceType != null && resourcesList.ResourceType != null ? x.ResourceType.Any(y=>y.Phrase == resourcesList.ResourceType.Phrase) : true)))
                    {
                        viewModel.Resources.Add(item);
                    }
                }
            }
            return View(viewModel);
        }
    }
}
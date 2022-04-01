using ACRHelix.Feature.DecampFeatureRenderings.Models;
using ACRHelix.Feature.DecampFeatureRenderings.Services;
using ACRHelix.Feature.DecampFeatureRenderings.ViewModels;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.DecampFeatureRenderings
{
  public class DecampFeatureRenderingsController : Controller
  {
    private readonly IContentService _contentService;
    private LocationService _locationService;

    public DecampFeatureRenderingsController(IContentService contentService)
    {
      _contentService = contentService;
      _locationService = new LocationService();
    }

    public ViewResult PageTitle()
    {
      var viewModel = new PageTitleViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;
      if (String.IsNullOrEmpty(dataSource))
        dataSource = Sitecore.Context.Item.ID.ToString();

      if (!String.IsNullOrEmpty(dataSource))
      {
        
        var content = _contentService.GetPageTitleContent(dataSource);
        if (content != null)
        {
          viewModel.Id = content.Id;
          viewModel.Title = content.Title;
          viewModel.Date = content.Date != null ? content.Date : DateTime.MaxValue;
          viewModel.SubTitle = content.SubTitle;
          viewModel.RichText = content.RichText;         
        }
      }
      return View(viewModel);
    }
    public ViewResult HomepageBanner()
    {
      var viewModel = new BannerViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;
      
      if (!String.IsNullOrEmpty(dataSource))
      {
        var bannerContent = _contentService.GetBannerContent(dataSource);
        if (bannerContent != null)
        {
          viewModel.Id = bannerContent.Id;
          viewModel.Title = bannerContent.Title;
          viewModel.Richtext = bannerContent.Richtext;
          viewModel.BannerLink = bannerContent.BannerLink;
          viewModel.BannerImage = bannerContent.BannerImage;
        }
      }
      return View(viewModel);
    }

    public ViewResult LatestNewsList()
    {
      var viewModel = new LatestNewsListViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (!String.IsNullOrEmpty(dataSource))
      {
        var content = _contentService.GetLatestNewsListContent(dataSource);
        if (content != null)
        {
          viewModel.Id = content.Id;
          viewModel.Title = content.Title;         
          viewModel.Link = content.Link;
          viewModel.NewsArticlesList = content.NewsArticlesList.OrderByDescending(d => d.Date).Take(content.PageSize);
        }
      }
      return View(viewModel);
    }

    public ViewResult NewsList()
    {
      var viewModel = new LatestNewsListViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (!String.IsNullOrEmpty(dataSource))
      {
        var content = _contentService.GetLatestNewsListContent(dataSource);
        if (content != null)
        {
          viewModel.Id = content.Id;
          viewModel.Title = content.Title;
          viewModel.NewsArticlesList = content.NewsArticlesList.OrderByDescending(d => d.Date).Take(content.PageSize);
        }
      }
      return View(viewModel);
    }

    public ViewResult RichTextSection()
    {
      var viewModel = new RichTextSectionViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (!String.IsNullOrEmpty(dataSource))
      {
        var content = _contentService.GetRichTextSectionContent(dataSource);
        if (content != null)
        {
          viewModel.Id = content.Id;
          viewModel.Title = content.Title;
          viewModel.UseDefaultTitleLocation = content.UseDefaultTitleLocation;
          viewModel.SubTitle = content.SubTitle;
          viewModel.RichText = content.RichText;
          viewModel.Image = content.Image;
          viewModel.UseDefaultImageLocation = content.UseDefaultImageLocation;
        }
      }
      return View(viewModel);
    }

    public ViewResult TextCalloutSection()
    {
      var viewModel = new TextCalloutSectionViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (!String.IsNullOrEmpty(dataSource))
      {
        var content = _contentService.GetTextCalloutSectionContent(dataSource);
        if (content != null)
        {
          viewModel.Id = content.Id;
          viewModel.Title = content.Title;
          viewModel.SubTitle = content.SubTitle;
          viewModel.RichText = content.RichText;
          viewModel.Image = content.Image;
        }
      }
      return View(viewModel);
    }

    public ViewResult Locations()
    {
      var viewModel = new PageTitleViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;
      if (String.IsNullOrEmpty(dataSource))
        dataSource = Sitecore.Context.Item.ID.ToString();

      if (!String.IsNullOrEmpty(dataSource))
      {
        var content = _contentService.GetPageTitleContent(dataSource);
        if (content != null)
        {
          viewModel.Id = content.Id;
          viewModel.Title = content.Title;
          viewModel.SubTitle = content.SubTitle;
        }
      }
      return View(viewModel);
    }

    public JsonResult GetAllLocations()
    {
      //Sitecore.Diagnostics.Log.Info("-- decamp locations: came to getalllocations ", new object());
      var Data = _locationService.GetLocations();
      //Sitecore.Diagnostics.Log.Info("-- decamp locations: came to getalllocations " + Data, new object());
      return Json(Data, JsonRequestBehavior.AllowGet);
    }
  }
}
using ACRHelix.Project.Decamp.Models;
using ACRHelix.Project.Decamp.Services;
using ACRHelix.Project.Decamp.ViewModels;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Project.Decamp.Controllers
{
  public class DecampController : Controller
  {
    private readonly IContentService _contentService;
    private static ID MainSearchPageField = new ID("{0B262391-DF56-4749-807F-11437CE26F23}");

    public DecampController(IContentService contentService)
    {
      _contentService = contentService;
    }

    public ViewResult Logo()
    {
      var viewModel = new LogoViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var logoContent = _contentService.GetLogoContent(RenderingContext.Current.Rendering.DataSource);
        if (logoContent != null)
        {
          viewModel.Id = logoContent.Id;
          viewModel.Link = logoContent.Link;
          viewModel.Image = logoContent.Image;
        }
      }
      return View("Logo/Logo", viewModel);
    }

    public ViewResult DecampSearchBox()
    {
      var settingsModel = new SearchSettings();
      var searchSettings = Sitecore.Context.Database.GetItem(RenderingContext.Current.Rendering.DataSource);

      if (searchSettings != null)
      {
        LinkField link = searchSettings.Fields[MainSearchPageField];
        if (link != null)
        {
          settingsModel.SearchPageUrl = link.GetFriendlyUrl();
        }
      }
      return View("UtilityMenu/DecampSearchBox", settingsModel);
    }

    public ViewResult UtilityMenu()
    {
      var viewModel = new LinkMenuViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var content = _contentService.GetLinkMenuContent(RenderingContext.Current.Rendering.DataSource);
        if (content != null)
        {
          viewModel.Id = content.Id;
          viewModel.MenuItems = content.MenuItems.Select(i => new MenuItemViewModel { Title = i.Title, IconCSSClass = i.IconCssClass, Id = i.Id, Link = i.Link });
        }
      }
      return View("UtilityMenu/UtilityMenu", viewModel);
    }

    public ViewResult DecampFooter()
    {
      var viewModel = new DecampFooterViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var content = _contentService.GetCopyrightContent(RenderingContext.Current.Rendering.DataSource);
        if (content != null)
        {
          viewModel.Id = content.Id;
          viewModel.Copyright = content.Copyright;
          viewModel.Richtext = content.Richtext;
          viewModel.LeftImage = content.LeftImage;
          viewModel.LeftLink = content.LeftLink;
          viewModel.CenterLeftImage = content.CenterLeftImage;
          viewModel.CenterLeftLink = content.CenterLeftLink;
          viewModel.CenterRightImage = content.CenterRightImage;
          viewModel.CenterRightLink = content.CenterRightLink;
          viewModel.RightImage = content.RightImage;
          viewModel.RightLink = content.RightLink;
        }
      }
      return View("Identity/DecampFooter", viewModel);
    }
  }
}
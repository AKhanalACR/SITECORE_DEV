using RHEC.Website.Services;
using RHEC.Website.ViewModels;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RHEC.Website.Controllers
{
    public class RHECController : Controller
    {
    private readonly IContentService _contentService;
     
    public RHECController(IContentService contentService)
    {
      _contentService = contentService;
    }
   /// <summary>
   /// To get logo item from sitecore,
   /// </summary>  
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
      return View("Common/Logo", viewModel);
    }
   
    public ViewResult Button()
    {
      var viewModel = new ButtonViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var buttonContent = _contentService.GetButtonContent(RenderingContext.Current.Rendering.DataSource);
        if (buttonContent != null)
        {
          viewModel.Id = buttonContent.Id;
          viewModel.Text = buttonContent.Text;
          viewModel.Link = buttonContent.Link;
        }
      }
      return View("Common/Button", viewModel);
    }
    public ViewResult FooterTitleLinks()
    {
      var viewModel = new LinkMenuViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        //datasource is folder with items
        var NavigationContent = _contentService.GetLinkMenuContent(RenderingContext.Current.Rendering.DataSource);
        if (NavigationContent != null)
        {
          viewModel.Id = NavigationContent.Id;
          viewModel.MenuItems = NavigationContent.MenuItems.Select(i => new MenuItemViewModel { Title = i.Title, Id = i.Id, Link = i.Link });
          viewModel.Title = NavigationContent.Title;
          viewModel.Name = NavigationContent.Name;
        }
      }
      return View("Common/FooterTitleLinks", viewModel);
    }
    public ViewResult Copyright()
    {
      var viewModel = new CopyrightViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        //datasource is folder with items
        var NavigationContent = _contentService.GetCopyrightContent(RenderingContext.Current.Rendering.DataSource);
        if (NavigationContent != null)
        {
          viewModel.Id = NavigationContent.Id;
          viewModel.MenuItems = NavigationContent.MenuItems.Select(i => new MenuItemViewModel { Title = i.Title, Id = i.Id, Link = i.Link });
          viewModel.CopyrightText = NavigationContent.CopyrightText;
          viewModel.Name = NavigationContent.Name;
        }
      }
      return View("Common/Copyright", viewModel);
    }
    public ViewResult PartnersLogo()
    {
      var viewModel = new PartnersLogoViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var PartnerslogoContent = _contentService.GetPartnersLogoContent(RenderingContext.Current.Rendering.DataSource);
        if (PartnerslogoContent != null)
        {
          viewModel.Id = PartnerslogoContent.Id;
          viewModel.Partners = PartnerslogoContent.Partners.Select(i => new LogoViewModel { Image = i.Image, Id = i.Id, Link = i.Link });
        }
      }
      return View("Common/PartnersLogo", viewModel);
    }
  }
}

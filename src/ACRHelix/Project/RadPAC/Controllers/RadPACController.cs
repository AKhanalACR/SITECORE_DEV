using ACRHelix.Project.RadPAC.Models;
using ACRHelix.Project.RadPAC.Services;
using ACRHelix.Project.RadPAC.ViewModels;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Project.RadPAC.Controllers
{
    public class RadPACController : Controller
    {
        private readonly IContentService _contentService;
        private static ID MainSearchPageField = new ID("{DA006121-7B79-4F72-8E80-B76AAFAB67DC}");

        public RadPACController(IContentService contentService)
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

        public ViewResult RPSearchBox()
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
            return View("UtilityMenu/RPSearchBox", settingsModel);
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

        public ViewResult Copyright()
        {
            var viewModel = new CopyrightViewModel();
            if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                var content = _contentService.GetCopyrightContent(RenderingContext.Current.Rendering.DataSource);
                if (content != null)
                {
                    viewModel.Id = content.Id;
                    viewModel.Copyright = content.Copyright;
                    viewModel.Richtext = content.Richtext;
                }
            }
            return View("Identity/Copyright", viewModel);            
        }

        public ViewResult Signup()
        {
            var viewModel = new SignupViewModel();
            if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                var content = _contentService.GetSignupContent(RenderingContext.Current.Rendering.DataSource);
                if (content != null)
                {
                    viewModel.Id = content.Id;
                    viewModel.Title = content.Title;
                    viewModel.Richtext = content.Richtext;
                    viewModel.ButtonText = content.ButtonText;
                }
            }
            return View("Identity/Signup", viewModel);
        }
    }
}
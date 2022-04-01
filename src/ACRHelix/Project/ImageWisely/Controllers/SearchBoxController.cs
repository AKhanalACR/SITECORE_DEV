using ACRHelix.Project.ImageWisely.Models;
using ACRHelix.Project.ImageWisely.ViewModels;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Project.ImageWisely
{
    public class SearchBoxController : Controller
    {
        private static ID MainSearchPageField = new ID("{D2B03473-126B-450B-BF14-010AC3299DFD}");

        public ViewResult IWSearchBox()
        {
            var settingsModel = new SearchSettings();
            var searchSettings = Sitecore.Context.Database.GetItem(RenderingContext.Current.Rendering.DataSource);
            var viewModel = new IWSearchBoxViewModel();

            if (searchSettings != null)
            {
                LinkField link = searchSettings.Fields[MainSearchPageField];
                if (link != null)
                {
                    viewModel.SearchPageUrl = link.GetFriendlyUrl();
                }
            }
            return View(viewModel);
        }
    }
}
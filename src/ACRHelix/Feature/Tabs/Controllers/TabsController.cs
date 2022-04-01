using ACRHelix.Feature.Tabs.Models;
using ACRHelix.Feature.Tabs.Services;
using ACRHelix.Feature.Tabs.ViewModels;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.Tabs
{
  public class TabsController : Controller
  {
    private readonly IContentService _contentService;

    public TabsController(IContentService contentService)
    {
      _contentService = contentService;
    }

    public ViewResult ChapterTabs()
    {
      return TabsViewResult("ChapterTabs");
    }

    public ViewResult MeetingTabs()
    {
      return TabsViewResult("MeetingTabs");
    }

    public ViewResult Tabs()
    {
      return TabsViewResult("Tabs");
    }


    public ViewResult TabsViewResult(string view)
    {
      var viewModel = new TabsViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var TabsContent = _contentService.GetTabsContent(RenderingContext.Current.Rendering.DataSource);
        if (TabsContent != null)
        {
          viewModel.Id = TabsContent.Id;
          viewModel.TabNames = GetTabNamesIDs(TabsContent.TabNames);
        }
      }
      return View(view,viewModel);
    }

        public ViewResult RliTabs()
        {
            var viewModel = new RliTabsViewModel();
            if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                var tabsContent = _contentService.GetRliTabsContent(RenderingContext.Current.Rendering.DataSource);
                if (tabsContent != null)
                {
                    if (tabsContent != null)
                    {
                        List<TabItem> tabItems = new List<TabItem>();
                        viewModel.Id = tabsContent.Id;
                        string[] tabNames = tabsContent.Tabs.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries); 
                        string[] tabLinks = tabsContent.Links.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                        for(int i=0; i<tabNames.Length; i++)
                        {
                            tabItems.Add(new TabItem()
                            {
                                TabName = tabNames[i],
                                TabURL = tabLinks[i]
                            });                            
                        }
                        viewModel.Tabs = tabItems;
                    }
                }
            }
            return View(viewModel);
        }

        private List<TabNameViewModel> GetTabNamesIDs(string tabs)
        {
          List<TabNameViewModel> tabNames = new List<TabNameViewModel>();

          string[] splitTabs = tabs.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
          foreach (string s in splitTabs)
          {
            tabNames.Add(new TabNameViewModel(s));
          }
          return tabNames;
        }


  }
}
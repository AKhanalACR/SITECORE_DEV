using ACRHelix.Feature.Navigation.Services;
using ACRHelix.Feature.Navigation.ViewModels;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Links;
using Sitecore.Foundation.SitecoreExtensions.Extensions;
using Glass.Mapper.Sc.Fields;
using ACRHelix.Feature.Navigation.Models;
using ACR.Foundation.Utilities.Url;
using ACR.Foundation.SSO.Users;

namespace ACRHelix.Feature.Navigation
{
  public class NavigationController : Controller
  {
    private readonly IContentService _contentService;

    public NavigationController(IContentService contentService)
    {
      _contentService = contentService;
    }
	
	    public ActionResult RobotsTxt()
    {
      Response.ContentType = "text/plain";
      RobotsTxtService robotsTxtService = new RobotsTxtService(Request.Url.Host);
      return Content(robotsTxtService.GetRobotsContent(), "text/plain", System.Text.Encoding.UTF8);    
    }
	

        public ActionResult SitemapXml()
    {
      //Stopwatch stopwatch = new Stopwatch();
      //stopwatch.Start();

      SitemapService sitemapService = new SitemapService(Request.Url.Host);
      SitemapList sitemapList = new SitemapList();

      var siteItem = sitemapService.GetCurrentSiteRoot();  
      if (siteItem != null)
      {        
        sitemapList.SiteMapItems = sitemapService.GetAllItemsWithLayout(siteItem);
      }

      Response.ContentType = "text/xml";

      //stopwatch.Stop();
      //string elapsedTime = stopwatch.Elapsed.ToString();

      return View(sitemapList);
    }

    public ViewResult SiteMap()
    {
      var viewModel = new MainNavbarViewModel();
      List<MainNavItemViewModel> navItems = new List<MainNavItemViewModel>();

      var navContent = _contentService.GetMainNavigationContent();
      var children = navContent.Children.Where(x => x.Item.IsDerived(Constants.Templates.Navigable.ID) && x.ShowInNavigation == true).ToList();
      foreach (var c in children) //level 1
      {
        var navItem = new MainNavItemViewModel()
        {
          NewWindow = c.NewWindow,
          Title = string.IsNullOrWhiteSpace(c.ShortTitle) ? c.Name : c.ShortTitle,
          URL = string.IsNullOrWhiteSpace(c.LinkOverride) ? c.Url : c.LinkOverride,
          TemplateID = c.TemplateID
        };

        List<MainNavItemViewModel> secondChildren = new List<MainNavItemViewModel>();
        var navChildren = c.Children.Where(x => x.Item.IsDerived(Constants.Templates.Navigable.ID) && x.ShowInNavigation == true).ToList();  //level 2
        foreach (var nc in navChildren)
        {
          var secondChild = new MainNavItemViewModel()
          {
            NewWindow = nc.NewWindow,
            Title = string.IsNullOrWhiteSpace(nc.ShortTitle) ? nc.Name : nc.ShortTitle,
            URL = string.IsNullOrWhiteSpace(nc.LinkOverride) ? nc.Url : nc.LinkOverride,
          };


          List<MainNavItemViewModel> thirdChildren = new List<MainNavItemViewModel>();
          var child3 = nc.Children.Where(x => x.Item.IsDerived(Constants.Templates.Navigable.ID) && x.ShowInNavigation == true).ToList();  //level 3
          foreach (var c3 in child3)
          {
            var thirdChild = new MainNavItemViewModel()
            {
              NewWindow = c3.NewWindow,
              Title = string.IsNullOrWhiteSpace(c3.ShortTitle) ? c3.Name : c3.ShortTitle,
              URL = string.IsNullOrWhiteSpace(c3.LinkOverride) ? c3.Url : c3.LinkOverride,
            };

            List<MainNavItemViewModel> fourthChildren = new List<MainNavItemViewModel>();
            var child4 = c3.Children.Where(x => x.Item.IsDerived(Constants.Templates.Navigable.ID) && x.ShowInNavigation == true).ToList();
            foreach (var fourth in child4)
            {
              fourthChildren.Add(new MainNavItemViewModel()
              {
                NewWindow = fourth.NewWindow,
                Title = string.IsNullOrWhiteSpace(fourth.ShortTitle) ? fourth.Name : fourth.ShortTitle,
                URL = string.IsNullOrWhiteSpace(fourth.LinkOverride) ? fourth.Url : fourth.LinkOverride,
              });
            }

            thirdChild.Children = fourthChildren;
            thirdChildren.Add(thirdChild);
          }
          secondChild.Children = thirdChildren;
          secondChildren.Add(secondChild);
        }
        navItem.Children = secondChildren;
        navItems.Add(navItem);
      }
      viewModel.NavigationItems = navItems;
      return View(viewModel);
    }

    public ViewResult MainNavbar()
    {
      var viewModel = new MainNavbarViewModel();
      List<MainNavItemViewModel> navItems = new List<MainNavItemViewModel>();

      var navContent = _contentService.GetMainNavigationContent();
      var children = navContent.Children.Where(x => x.Item.IsDerived(Constants.Templates.Navigable.ID) && x.ShowInNavigation == true).ToList();
      foreach (var c in children) //level 1
      {
        var navItem = new MainNavItemViewModel()
        {
          NewWindow = c.NewWindow,
          Title = string.IsNullOrWhiteSpace(c.ShortTitle) ? c.Name : c.ShortTitle,
          URL = string.IsNullOrWhiteSpace(c.LinkOverride) ? c.Url : c.LinkOverride,
          TemplateID = c.TemplateID
        };
         
        List<MainNavItemViewModel> secondChildren = new List<MainNavItemViewModel>();
        var navChildren = c.Children.Where(x => x.Item.IsDerived(Constants.Templates.Navigable.ID) && x.ShowInNavigation == true).ToList();  //level 2
        foreach (var nc in navChildren)
        {
          var secondChild = new MainNavItemViewModel()
          {
            NewWindow = nc.NewWindow,
            Title = string.IsNullOrWhiteSpace(nc.ShortTitle) ? nc.Name : nc.ShortTitle,
            URL = string.IsNullOrWhiteSpace(nc.LinkOverride) ? nc.Url : nc.LinkOverride,
          };


          List<MainNavItemViewModel> thirdChildren = new List<MainNavItemViewModel>();
          var child3 = nc.Children.Where(x => x.Item.IsDerived(Constants.Templates.Navigable.ID) && x.ShowInNavigation == true).ToList();  //level 3
          foreach (var c3 in child3)
          {
            var thirdChild = new MainNavItemViewModel()
            {
              NewWindow = c3.NewWindow,
              Title = string.IsNullOrWhiteSpace(c3.ShortTitle) ? c3.Name : c3.ShortTitle,
              URL = string.IsNullOrWhiteSpace(c3.LinkOverride) ? c3.Url : c3.LinkOverride,
            };

            List<MainNavItemViewModel> fourthChildren = new List<MainNavItemViewModel>();
            var child4 = c3.Children.Where(x => x.Item.IsDerived(Constants.Templates.Navigable.ID) && x.ShowInNavigation == true).ToList();
            foreach (var fourth in child4)
            {
              fourthChildren.Add(new MainNavItemViewModel()
              {
                NewWindow = fourth.NewWindow,
                Title = string.IsNullOrWhiteSpace(fourth.ShortTitle) ? fourth.Name : fourth.ShortTitle,
                URL = string.IsNullOrWhiteSpace(fourth.LinkOverride) ? fourth.Url : fourth.LinkOverride,
              });
            }

            thirdChild.Children = fourthChildren;
            thirdChildren.Add(thirdChild);
          }
          secondChild.Children = thirdChildren;
          secondChildren.Add(secondChild);
        }
        navItem.Children = secondChildren;
        navItems.Add(navItem);
      }
      viewModel.NavigationItems = navItems;
      return View(viewModel);
    }

    public ViewResult LinkMenu()
    {
      var viewModel = new LinkMenuViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        //datasource is folder with items


        var NavigationContent = _contentService.GetLinkMenuContent(RenderingContext.Current.Rendering.DataSource);
        if (NavigationContent != null)
        {
          viewModel.MenuItems = NavigationContent.MenuItems.Select(i => new MenuItemViewModel { Title = i.Title, IconCSSClass = i.IconCSSClass, Id = i.Id, Link = i.Link });
          viewModel.IncludeCharacterBasedDivider = NavigationContent.IncludeCharacterBasedDivider;
        }
      }
      return View(viewModel);
    }

    public ViewResult Breadcrumbs()
    {
        var viewModel = new BreadcrumbsViewModel();

        var dataSource = RenderingContext.Current.Rendering.DataSource;

        if (String.IsNullOrEmpty(dataSource))
        {
            dataSource = Sitecore.Context.Item.ID.ToString();
        }        
            
        var NavigationContent = _contentService.GetBreadcrumbsContent(dataSource);
        if (NavigationContent != null)
        {
            viewModel.Id = NavigationContent.Id;
            viewModel.Links = NavigationContent.Links;
        }
        
        return View(viewModel);
    }
    public ViewResult VORBreadcrumbs()
    {
      var viewModel = new BreadcrumbsViewModel();

      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (String.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }

      var NavigationContent = _contentService.GetBreadcrumbsContent(dataSource);
      if (NavigationContent != null)
      {
        viewModel.Id = NavigationContent.Id;
        viewModel.Links = NavigationContent.Links;
      }

      return View(viewModel);
    }


        public ViewResult IWLinkMenu()
        {
            var viewModel = new LinkMenuViewModel();
            if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                //datasource is folder with items


                var NavigationContent = _contentService.GetLinkMenuContent(RenderingContext.Current.Rendering.DataSource);
                if (NavigationContent != null)
                {
                    viewModel.MenuItems = NavigationContent.MenuItems.Select(i => new MenuItemViewModel { Title = i.Title, IconCSSClass = i.IconCSSClass, Id = i.Id, Link = i.Link });
                    viewModel.IncludeCharacterBasedDivider = NavigationContent.IncludeCharacterBasedDivider;
                }
            }
            return View(viewModel);
        }

        public ViewResult IWMainNavbar()
        {
            var viewModel = new IWMainNavbarViewModel();
            List<IWMainNavItemViewModel> navItems = new List<IWMainNavItemViewModel>();

            var navContent = _contentService.GetIWMainNavigationContent();
            var children = navContent.Children.Where(x => x.Item.IsDerived(Constants.Templates.Navigable.ID) && x.ShowInNavigation == true).ToList();
            foreach (var c in children) //level 1
            {
                var navItem = new IWMainNavItemViewModel()
                {
                    NewWindow = c.NewWindow,
                    Title = string.IsNullOrWhiteSpace(c.ShortTitle) ? c.Name : c.ShortTitle,
                    URL = string.IsNullOrWhiteSpace(c.LinkOverride) ? c.Url : c.LinkOverride,
                    TemplateID = c.TemplateID,
                    PageNavCategory = c.PageNavCategory,
                    MainMenuCss = c.MainMenuCss,
                    SubMenuCss = c.SubMenuCss
                    
                };

                List<IWMainNavItemViewModel> secondChildren = new List<IWMainNavItemViewModel>();
                var navChildren = c.Children.Where(x => x.Item.IsDerived(Constants.Templates.Navigable.ID) && x.ShowInNavigation == true).ToList();  //level 2
                foreach (var nc in navChildren)
                {
                    var secondChild = new IWMainNavItemViewModel()
                    {
                        NewWindow = nc.NewWindow,
                        Title = string.IsNullOrWhiteSpace(nc.ShortTitle) ? nc.Name : nc.ShortTitle,
                        URL = string.IsNullOrWhiteSpace(nc.LinkOverride) ? nc.Url : nc.LinkOverride,
                        PageNavCategory = nc.PageNavCategory
                    };


                    //List<IWMainNavItemViewModel> thirdChildren = new List<IWMainNavItemViewModel>();
                    //var child3 = nc.Children.Where(x => x.Item.IsDerived(Constants.Templates.Navigable.ID) && x.ShowInNavigation == true).ToList();  //level 3
                    //foreach (var c3 in child3)
                    //{
                    //    var thirdChild = new IWMainNavItemViewModel()
                    //    {
                    //        NewWindow = c3.NewWindow,
                    //        Title = string.IsNullOrWhiteSpace(c3.ShortTitle) ? c3.Name : c3.ShortTitle,
                    //        URL = string.IsNullOrWhiteSpace(c3.LinkOverride) ? c3.Url : c3.LinkOverride,
                    //    };

                    //    List<IWMainNavItemViewModel> fourthChildren = new List<IWMainNavItemViewModel>();
                    //    var child4 = c3.Children.Where(x => x.Item.IsDerived(Constants.Templates.Navigable.ID) && x.ShowInNavigation == true).ToList();
                    //    foreach (var fourth in child4)
                    //    {
                    //        fourthChildren.Add(new IWMainNavItemViewModel()
                    //        {
                    //            NewWindow = fourth.NewWindow,
                    //            Title = string.IsNullOrWhiteSpace(fourth.ShortTitle) ? fourth.Name : fourth.ShortTitle,
                    //            URL = string.IsNullOrWhiteSpace(fourth.LinkOverride) ? fourth.Url : fourth.LinkOverride,
                    //        });
                    //    }

                    //    thirdChild.Children = fourthChildren;
                    //    thirdChildren.Add(thirdChild);
                    //}
                    //secondChild.Children = thirdChildren;
                    secondChildren.Add(secondChild);
                }
                navItem.Children = secondChildren;
                navItems.Add(navItem);
            }
            viewModel.NavigationItems = navItems;
            return View(viewModel);
        }

        public ViewResult IWBreadcrumbs()
        {
            var viewModel = new BreadcrumbsViewModel();

            var dataSource = RenderingContext.Current.Rendering.DataSource;

            if (String.IsNullOrEmpty(dataSource))
            {
                dataSource = Sitecore.Context.Item.ID.ToString();
            }

            var NavigationContent = _contentService.GetIWBreadcrumbsContent(dataSource);
            if (NavigationContent != null)
            {
                viewModel.Id = NavigationContent.Id;
                viewModel.Links = NavigationContent.Links;
            }

            return View(viewModel);
        }

        public ViewResult IdeasLinkMenu()
        {
            var viewModel = new LinkMenuViewModel();
            if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                //datasource is folder with items

                var NavigationContent = _contentService.GetLinkMenuContent(RenderingContext.Current.Rendering.DataSource);
                if (NavigationContent != null)
                {
                    viewModel.MenuItems = NavigationContent.MenuItems.Select(i => new MenuItemViewModel { Title = i.Title, IconCSSClass = i.IconCSSClass, Id = i.Id, Link = i.Link }).Where(i => !string.IsNullOrEmpty(i.Title) && i.Link != null);
                    viewModel.IncludeCharacterBasedDivider = NavigationContent.IncludeCharacterBasedDivider;
                }
            }
            return View(viewModel);
        }
    public ViewResult IdeasPatientLinkMenu()
    {
      var viewModel = new LinkMenuViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        //datasource is folder with items

        var NavigationContent = _contentService.GetLinkMenuContent(RenderingContext.Current.Rendering.DataSource);
        if (NavigationContent != null)
        {
          viewModel.MenuItems = NavigationContent.MenuItems.Select(i => new MenuItemViewModel { Title = i.Title, IconCSSClass = i.IconCSSClass, Id = i.Id, Link = i.Link }).Where(i => !string.IsNullOrEmpty(i.Title));
          viewModel.IncludeCharacterBasedDivider = NavigationContent.IncludeCharacterBasedDivider;
        }
      }
      return View(viewModel);
    }

    public ViewResult IdeasLinkMenuMobile()
        {
            var viewModel = new LinkMenuViewModel();
            if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                //datasource is folder with items

                var NavigationContent = _contentService.GetLinkMenuContent(RenderingContext.Current.Rendering.DataSource);
                if (NavigationContent != null)
                {
                    viewModel.MenuItems = NavigationContent.MenuItems.Select(i => new MenuItemViewModel { Title = i.Title, IconCSSClass = i.IconCSSClass, Id = i.Id, Link = i.Link }).Where(i => !string.IsNullOrEmpty(i.Title) && i.Link != null);
                    viewModel.IncludeCharacterBasedDivider = NavigationContent.IncludeCharacterBasedDivider;
                }
            }
            return View(viewModel);
        }
    public ViewResult IdeasPatientLinkMenuMobile()
    {
      var viewModel = new LinkMenuViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        //datasource is folder with items

        var NavigationContent = _contentService.GetLinkMenuContent(RenderingContext.Current.Rendering.DataSource);
        if (NavigationContent != null)
        {
          viewModel.MenuItems = NavigationContent.MenuItems.Select(i => new MenuItemViewModel { Title = i.Title, IconCSSClass = i.IconCSSClass, Id = i.Id, Link = i.Link }).Where(i => !string.IsNullOrEmpty(i.Title));
          viewModel.IncludeCharacterBasedDivider = NavigationContent.IncludeCharacterBasedDivider;
        }
      }
      return View(viewModel);
    }

    public ViewResult IdeasFooterLinkMenu()
        {
            var viewModel = new LinkMenuViewModel();
            if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                //datasource is folder with items

                var NavigationContent = _contentService.GetLinkMenuContent(RenderingContext.Current.Rendering.DataSource);
                if (NavigationContent != null)
                {
                    viewModel.MenuItems = NavigationContent.MenuItems.Select(i => new MenuItemViewModel { Title = i.Title, IconCSSClass = i.IconCSSClass, Id = i.Id, Link = i.Link }).Where(i => !string.IsNullOrEmpty(i.Title) && i.Link != null);
                    viewModel.IncludeCharacterBasedDivider = NavigationContent.IncludeCharacterBasedDivider;
                }
            }
            return View(viewModel);
        }
		
        public ViewResult RadPACMainNavbar()
        {
            var viewModel = new RadPACMainNavbarViewModel();
            List<RadPACMainNavItemViewModel> navItems = new List<RadPACMainNavItemViewModel>();

            var navContent = _contentService.GetMainNavigationContent();
            var children = navContent.Children.Where(x => x.Item.IsDerived(Constants.Templates.Navigable.ID) && x.ShowInNavigation == true).ToList();
            foreach (var c in children) //level 1
            {
                var navItem = new RadPACMainNavItemViewModel()
                {
                    NewWindow = c.NewWindow,
                    Title = string.IsNullOrWhiteSpace(c.ShortTitle) ? c.Name : c.ShortTitle,
                    URL = string.IsNullOrWhiteSpace(c.LinkOverride) ? c.Url : c.LinkOverride,
                    TemplateID = c.TemplateID
                };

                List<RadPACMainNavItemViewModel> secondChildren = new List<RadPACMainNavItemViewModel>();
                var navChildren = c.Children.Where(x => x.Item.IsDerived(Constants.Templates.Navigable.ID) && x.ShowInNavigation == true).ToList();  //level 2
                foreach (var nc in navChildren)
                {
                    var secondChild = new RadPACMainNavItemViewModel()
                    {
                        NewWindow = nc.NewWindow,
                        Title = string.IsNullOrWhiteSpace(nc.ShortTitle) ? nc.Name : nc.ShortTitle,
                        URL = string.IsNullOrWhiteSpace(nc.LinkOverride) ? nc.Url : nc.LinkOverride,
                    };


                    List<RadPACMainNavItemViewModel> thirdChildren = new List<RadPACMainNavItemViewModel>();
                    var child3 = nc.Children.Where(x => x.Item.IsDerived(Constants.Templates.Navigable.ID) && x.ShowInNavigation == true).ToList();  //level 3
                    foreach (var c3 in child3)
                    {
                        var thirdChild = new RadPACMainNavItemViewModel()
                        {
                            NewWindow = c3.NewWindow,
                            Title = string.IsNullOrWhiteSpace(c3.ShortTitle) ? c3.Name : c3.ShortTitle,
                            URL = string.IsNullOrWhiteSpace(c3.LinkOverride) ? c3.Url : c3.LinkOverride,
                        };
                        
                        thirdChildren.Add(thirdChild);
                    }
                    secondChild.Children = thirdChildren;
                    secondChildren.Add(secondChild);
                }
                navItem.Children = secondChildren;
                navItems.Add(navItem);
            }
            viewModel.NavigationItems = navItems;
            return View(viewModel);
        }
    
      public ViewResult IdeasPatientNavBar()
    {
      var viewModel = new IdeasMainNavbarViewModel();
      List<IdeasMainNavItemViewModel> navItems = new List<IdeasMainNavItemViewModel>();

      var navContent = _contentService.GetNavigationContentByItem(RenderingContext.Current.Rendering.DataSource);
      var children = navContent.Children.Where(x => x.Item.IsDerived(Constants.Templates.Navigable.ID) && x.ShowInNavigation == true).ToList();
      foreach (var c in children) //level 1
      {
        var navItem = new IdeasMainNavItemViewModel()
        {
          NewWindow = c.NewWindow,
          Title = string.IsNullOrWhiteSpace(c.ShortTitle) ? c.Name : c.ShortTitle,
          URL = string.IsNullOrWhiteSpace(c.LinkOverride) ? c.Url : c.LinkOverride,
          TemplateID = c.TemplateID
        };

        List<IdeasMainNavItemViewModel> secondChildren = new List<IdeasMainNavItemViewModel>();
        var navChildren = c.Children.Where(x => x.Item.IsDerived(Constants.Templates.Navigable.ID) && x.ShowInNavigation == true).ToList();  //level 2
        foreach (var nc in navChildren)
        {
          var secondChild = new IdeasMainNavItemViewModel()
          {
            NewWindow = nc.NewWindow,
            Title = string.IsNullOrWhiteSpace(nc.ShortTitle) ? nc.Name : nc.ShortTitle,
            URL = string.IsNullOrWhiteSpace(nc.LinkOverride) ? nc.Url : nc.LinkOverride,
          };

          secondChildren.Add(secondChild);
        }
        navItem.Children = secondChildren;
        navItems.Add(navItem);
      }
      viewModel.NavigationItems = navItems;
      return View("~/Views/Navigation/IdeasMainNavBar.cshtml", viewModel);
      
    }
    public ViewResult IdeasMainNavBar()
        {
            var viewModel = new IdeasMainNavbarViewModel();
            List<IdeasMainNavItemViewModel> navItems = new List<IdeasMainNavItemViewModel>();

            var navContent = _contentService.GetMainNavigationContent();
      if (navContent != null)
      {
            var children = navContent.Children.Where(x => x.Item.IsDerived(Constants.Templates.Navigable.ID) && x.ShowInNavigation == true).ToList();
            foreach (var c in children) //level 1
            {
                var navItem = new IdeasMainNavItemViewModel()
                {
                    NewWindow = c.NewWindow,
                    Title = string.IsNullOrWhiteSpace(c.ShortTitle) ? c.Name : c.ShortTitle,
                    URL = string.IsNullOrWhiteSpace(c.LinkOverride) ? c.Url : c.LinkOverride,
                    TemplateID = c.TemplateID
                };

                List<IdeasMainNavItemViewModel> secondChildren = new List<IdeasMainNavItemViewModel>();
                var navChildren = c.Children.Where(x => x.Item.IsDerived(Constants.Templates.Navigable.ID) && x.ShowInNavigation == true).ToList();  //level 2
                foreach (var nc in navChildren)
                {
                    var secondChild = new IdeasMainNavItemViewModel()
                    {
                        NewWindow = nc.NewWindow,
                        Title = string.IsNullOrWhiteSpace(nc.ShortTitle) ? nc.Name : nc.ShortTitle,
                        URL = string.IsNullOrWhiteSpace(nc.LinkOverride) ? nc.Url : nc.LinkOverride,
                    };

                    secondChildren.Add(secondChild);
                }
                navItem.Children = secondChildren;
                navItems.Add(navItem);
            }
            viewModel.NavigationItems = navItems;
    }
            return View(viewModel);
        }


public ViewResult IdeasMainNavBarMobile()
        {
            var viewModel = new IdeasMainNavbarViewModel();
            List<IdeasMainNavItemViewModel> navItems = new List<IdeasMainNavItemViewModel>();

            var navContent = _contentService.GetMainNavigationContent();
            var children = navContent.Children.Where(x => x.Item.IsDerived(Constants.Templates.Navigable.ID) && x.ShowInNavigation == true).ToList();
            foreach (var c in children) //level 1
            {
                var navItem = new IdeasMainNavItemViewModel()
                {
                    NewWindow = c.NewWindow,
                    Title = string.IsNullOrWhiteSpace(c.ShortTitle) ? c.Name : c.ShortTitle,
                    URL = string.IsNullOrWhiteSpace(c.LinkOverride) ? c.Url : c.LinkOverride,
                    TemplateID = c.TemplateID
                };

                List<IdeasMainNavItemViewModel> secondChildren = new List<IdeasMainNavItemViewModel>();
                var navChildren = c.Children.Where(x => x.Item.IsDerived(Constants.Templates.Navigable.ID) && x.ShowInNavigation == true).ToList();  //level 2
                foreach (var nc in navChildren)
                {
                    var secondChild = new IdeasMainNavItemViewModel()
                    {
                        NewWindow = nc.NewWindow,
                        Title = string.IsNullOrWhiteSpace(nc.ShortTitle) ? nc.Name : nc.ShortTitle,
                        URL = string.IsNullOrWhiteSpace(nc.LinkOverride) ? nc.Url : nc.LinkOverride,
                    };

                    secondChildren.Add(secondChild);
                }
                navItem.Children = secondChildren;
                navItems.Add(navItem);
            }
            viewModel.NavigationItems = navItems;
            
            return View(viewModel);
        }
    public ViewResult IdeasPatientNavBarMobile()
    {
      var viewModel = new IdeasMainNavbarViewModel();
      List<IdeasMainNavItemViewModel> navItems = new List<IdeasMainNavItemViewModel>();

      var navContent = _contentService.GetNavigationContentByItem(RenderingContext.Current.Rendering.DataSource);
      var children = navContent.Children.Where(x => x.Item.IsDerived(Constants.Templates.Navigable.ID) && x.ShowInNavigation == true).ToList();
      foreach (var c in children) //level 1
      {
        var navItem = new IdeasMainNavItemViewModel()
        {
          NewWindow = c.NewWindow,
          Title = string.IsNullOrWhiteSpace(c.ShortTitle) ? c.Name : c.ShortTitle,
          URL = string.IsNullOrWhiteSpace(c.LinkOverride) ? c.Url : c.LinkOverride,
          TemplateID = c.TemplateID
        };

        List<IdeasMainNavItemViewModel> secondChildren = new List<IdeasMainNavItemViewModel>();
        var navChildren = c.Children.Where(x => x.Item.IsDerived(Constants.Templates.Navigable.ID) && x.ShowInNavigation == true).ToList();  //level 2
        foreach (var nc in navChildren)
        {
          var secondChild = new IdeasMainNavItemViewModel()
          {
            NewWindow = nc.NewWindow,
            Title = string.IsNullOrWhiteSpace(nc.ShortTitle) ? nc.Name : nc.ShortTitle,
            URL = string.IsNullOrWhiteSpace(nc.LinkOverride) ? nc.Url : nc.LinkOverride,
          };

          secondChildren.Add(secondChild);
        }
        navItem.Children = secondChildren;
        navItems.Add(navItem);
      }
      viewModel.NavigationItems = navItems;

      return View("~/Views/Navigation/IdeasMainNavBarMobile.cshtml", viewModel);
     
    }

    public ViewResult IdeasLoginButton()
        {
            var viewModel = new LinkMenuViewModel();
            if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                //datasource is folder with items

                var NavigationContent = _contentService.GetLinkMenuContent(RenderingContext.Current.Rendering.DataSource);
                if (NavigationContent != null)
                {
                    viewModel.MenuItems = NavigationContent.MenuItems.Select(i => new MenuItemViewModel { Title = i.Title, IconCSSClass = i.IconCSSClass, Id = i.Id, Link = i.Link });
                    viewModel.IncludeCharacterBasedDivider = NavigationContent.IncludeCharacterBasedDivider;
                }
            }
            return View(viewModel);
        }
        public ViewResult RadPACBreadcrumbs()
        {
            var viewModel = new RadPACBreadcrumbsViewModel();

            var dataSource = RenderingContext.Current.Rendering.DataSource;

            if (String.IsNullOrEmpty(dataSource))
            {
                dataSource = Sitecore.Context.Item.ID.ToString();
            }

            var NavigationContent = _contentService.GetBreadcrumbsContent(dataSource);
            if (NavigationContent != null)
            {
                viewModel.Id = NavigationContent.Id;
                viewModel.Links = NavigationContent.Links;
            }

            return View(viewModel);
        }
		
		 public ViewResult IdeasBreadcrumbs()
        {
            var viewModel = new BreadcrumbsViewModel();

            var dataSource = RenderingContext.Current.Rendering.DataSource;

            if (String.IsNullOrEmpty(dataSource))
            {
                dataSource = Sitecore.Context.Item.ID.ToString();
            }

            var NavigationContent = _contentService.GetBreadcrumbsContent(dataSource);
            if (NavigationContent != null)
            {
                viewModel.Id = NavigationContent.Id;
                viewModel.Links = NavigationContent.Links;
            }

            return View(viewModel);
        }

    public ViewResult DecampMainNavbar()
    {
      var viewModel = new MainNavbarViewModel();
      List<MainNavItemViewModel> navItems = new List<MainNavItemViewModel>();

      var navContent = _contentService.GetMainNavigationContent();
      var children = navContent.Children.Where(x => x.Item.IsDerived(Constants.Templates.Navigable.ID) && x.ShowInNavigation == true).ToList();
      foreach (var c in children) //level 1
      {
        var navItem = new MainNavItemViewModel()
        {
          NewWindow = c.NewWindow,
          Title = string.IsNullOrWhiteSpace(c.ShortTitle) ? c.Name : c.ShortTitle,
          URL = string.IsNullOrWhiteSpace(c.LinkOverride) ? c.Url : c.LinkOverride,
          TemplateID = c.TemplateID
        };

        List<MainNavItemViewModel> secondChildren = new List<MainNavItemViewModel>();
        var navChildren = c.Children.Where(x => x.Item.IsDerived(Constants.Templates.Navigable.ID) && x.ShowInNavigation == true).ToList();  //level 2
        foreach (var nc in navChildren)
        {
          var secondChild = new MainNavItemViewModel()
          {
            NewWindow = nc.NewWindow,
            Title = string.IsNullOrWhiteSpace(nc.ShortTitle) ? nc.Name : nc.ShortTitle,
            URL = string.IsNullOrWhiteSpace(nc.LinkOverride) ? nc.Url : nc.LinkOverride,
          };


          List<MainNavItemViewModel> thirdChildren = new List<MainNavItemViewModel>();
          var child3 = nc.Children.Where(x => x.Item.IsDerived(Constants.Templates.Navigable.ID) && x.ShowInNavigation == true).ToList();  //level 3
          foreach (var c3 in child3)
          {
            var thirdChild = new MainNavItemViewModel()
            {
              NewWindow = c3.NewWindow,
              Title = string.IsNullOrWhiteSpace(c3.ShortTitle) ? c3.Name : c3.ShortTitle,
              URL = string.IsNullOrWhiteSpace(c3.LinkOverride) ? c3.Url : c3.LinkOverride,
            };

            thirdChildren.Add(thirdChild);
          }
          secondChild.Children = thirdChildren;
          secondChildren.Add(secondChild);
        }
        navItem.Children = secondChildren;
        navItems.Add(navItem);
      }
      viewModel.NavigationItems = navItems;
      return View(viewModel);
    }

    public ViewResult DecampBreadcrumbs()
    {
      var viewModel = new BreadcrumbsViewModel();

      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (String.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }

      var NavigationContent = _contentService.GetBreadcrumbsContent(dataSource);
      if (NavigationContent != null)
      {
        viewModel.Id = NavigationContent.Id;
        viewModel.Links = NavigationContent.Links;
      }

      return View(viewModel);
    }

   
    
    
    public ViewResult RHECBreadcrumbs()
    {
      var viewModel = new RHECBreadcrumbsViewModel();

      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (String.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }

      var NavigationContent = _contentService.GetBreadcrumbsContent(dataSource);
      if (NavigationContent != null)
      {
        viewModel.Id = NavigationContent.Id;
        viewModel.Links = NavigationContent.Links;
      }

      return View(viewModel);
    }
    public ViewResult RHECMainNavbar()
    {
      var viewModel = new RHECMainNavbarViewModel();
      List<RHECMainNavItemViewModel> navItems = new List<RHECMainNavItemViewModel>();

      var navContent = _contentService.GetMainNavigationContent();
      var children = navContent.Children.Where(x => x.Item.IsDerived(Constants.Templates.Navigable.ID) && x.ShowInNavigation == true).ToList();
      foreach (var c in children) //level 1
      {
        var navItem = new RHECMainNavItemViewModel()
        {
          NewWindow = c.NewWindow,
          Title = string.IsNullOrWhiteSpace(c.ShortTitle) ? c.Name : c.ShortTitle,
          URL = string.IsNullOrWhiteSpace(c.LinkOverride) ? c.Url : c.LinkOverride,
          TemplateID = c.TemplateID
        };
        List<RHECMainNavItemViewModel> secondChildren = new List<RHECMainNavItemViewModel>();
        var navChildren = c.Children.Where(x => x.Item.IsDerived(Constants.Templates.Navigable.ID) && x.ShowInNavigation == true).ToList();  //level 2
        foreach (var nc in navChildren)
        {
          var secondChild = new RHECMainNavItemViewModel()
          {
            NewWindow = nc.NewWindow,
            Title = string.IsNullOrWhiteSpace(nc.ShortTitle) ? nc.Name : nc.ShortTitle,
            URL = string.IsNullOrWhiteSpace(nc.LinkOverride) ? nc.Url : nc.LinkOverride,
          };


          List<RHECMainNavItemViewModel> thirdChildren = new List<RHECMainNavItemViewModel>();
          var child3 = nc.Children.Where(x => x.Item.IsDerived(Constants.Templates.Navigable.ID) && x.ShowInNavigation == true).ToList();  //level 3
          foreach (var c3 in child3)
          {
            var thirdChild = new RHECMainNavItemViewModel()
            {
              NewWindow = c3.NewWindow,
              Title = string.IsNullOrWhiteSpace(c3.ShortTitle) ? c3.Name : c3.ShortTitle,
              URL = string.IsNullOrWhiteSpace(c3.LinkOverride) ? c3.Url : c3.LinkOverride,
            };

            thirdChildren.Add(thirdChild);
          }
          secondChild.Children = thirdChildren;
          secondChildren.Add(secondChild);
        }
        navItem.Children = secondChildren;
        navItems.Add(navItem);
      }
      viewModel.NavigationItems = navItems;
      return View(viewModel);
    }
  }
}
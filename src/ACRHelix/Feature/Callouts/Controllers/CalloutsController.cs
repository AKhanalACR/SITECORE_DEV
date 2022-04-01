using ACRHelix.Feature.Callouts.Services;
using ACRHelix.Feature.Callouts.ViewModels;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Foundation.SitecoreExtensions.RenderingExtensions;
using ACRHelix.Feature.Callouts.Models;

namespace ACRHelix.Feature.Callouts
{
  public class CalloutsController : Controller
  {
    private readonly IContentService _contentService;

    public CalloutsController(IContentService contentService)
    {
      _contentService = contentService;
    }

    public ViewResult ThreeBoxCallouts()
    {
      var viewModel = new CalloutsViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var CalloutsContent = _contentService.GetCalloutsContent(RenderingContext.Current.Rendering.DataSource);
        if (CalloutsContent != null)
        {       
          viewModel.Id = CalloutsContent.Id;
          viewModel.Title = CalloutsContent.Title;

          ChapterLocatorCallout chapter = null;
          if (CalloutsContent.ChaperLocator != null)
          {
            if (CalloutsContent.ChaperLocator.Count() > 0)
            {
              chapter = CalloutsContent.ChaperLocator.First();
            }
          }

          if (chapter == null)
          {
            viewModel.CalloutItems = CalloutsContent.CalloutItems.Take(3).Select(c => new CalloutsItemViewModel { Id = c.Id, Title = c.Title, Link = c.Link });
          }
          else
          {
            List<CalloutsItemViewModel> callouts = new List<CalloutsItemViewModel>();
             
            var calloutItems = CalloutsContent.CalloutItems.Take(2).Select(c => new CalloutsItemViewModel { Id = c.Id, Title = c.Title, Link = c.Link });
            foreach (var calloutItem in calloutItems)
            {
              callouts.Add(calloutItem);
            }

            var chapterViewModel = new CalloutsItemViewModel() { Id = chapter.Id, Title = chapter.Title, SubTitle = chapter.ButtonText, ChapterLocator = true };
            if (callouts.Count >= 2)
            {
              callouts.Insert(1, chapterViewModel);
            }
            else
            {
              callouts.Add(chapterViewModel);
            }
            viewModel.CalloutItems = callouts;           
          }

        }
      }
      return View("3BoxCallouts", viewModel);
    }


    public ViewResult TwoBoxCallouts()
    {
      var viewModel = new CalloutsViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (String.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      if (!String.IsNullOrEmpty(dataSource))
      {
        var CalloutsContent = _contentService.GetCalloutsContent(dataSource);
        if (CalloutsContent != null)
        {
          viewModel.Id = CalloutsContent.Id;
          viewModel.Title = CalloutsContent.Title;
          //viewModel.Title = CalloutsContent.Title;
          viewModel.CalloutItems = CalloutsContent.CalloutItems.Take(2).Select(c => new CalloutsItemViewModel { Id = c.Id, Title = c.Title, Link = c.Link, Teaser = c.Teaser, Image = c.Image });
        }
      }
      return View("2BoxCallouts", viewModel);
    }

    public ViewResult WaysToLearnCallouts()
    {
      var viewModel = new CalloutsViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var CalloutsContent = _contentService.GetCalloutsContent(RenderingContext.Current.Rendering.DataSource);
        if (CalloutsContent != null)
        {
          viewModel.Id = CalloutsContent.Id;
          viewModel.Title = CalloutsContent.Title;
          //viewModel.Title = CalloutsContent.Title;
          viewModel.CalloutItems = CalloutsContent.CalloutItems.Take(4).Select(c => new CalloutsItemViewModel { Id = c.Id, Title = c.Title, Link = c.Link, Teaser = c.Teaser, Image = c.Image });
        }
      }
      return View("WaysToLearn", viewModel);
    }

    public ViewResult ProductBlockCallout()
    {
      var viewModel = new CalloutsItemViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var CalloutsContent = _contentService.GetCalloutItem(RenderingContext.Current.Rendering.DataSource);
        if (CalloutsContent != null)
        {
          viewModel.Id = CalloutsContent.Id;
          viewModel.Title = CalloutsContent.Title;
          viewModel.Teaser = CalloutsContent.Teaser;
          viewModel.Link = CalloutsContent.Link;
        }
      }
      return View("ProductBlockCallout", viewModel);
    }

    public ViewResult BlockCallout()
    {
      var viewModel = new CalloutsItemViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var CalloutsContent = _contentService.GetCalloutItem(RenderingContext.Current.Rendering.DataSource);
        if (CalloutsContent != null)
        {
          viewModel.Id = CalloutsContent.Id;
          viewModel.Title = CalloutsContent.Title;
          viewModel.Teaser = CalloutsContent.Teaser;
          viewModel.Link = CalloutsContent.Link;
        }
      }
      return View("BlockCallout", viewModel);
    }

    public ViewResult BlockButton()
    {
      var viewModel = new CalloutsItemViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var CalloutsContent = _contentService.GetCalloutItem(RenderingContext.Current.Rendering.DataSource);
        if (CalloutsContent != null)
        {
          viewModel.Id = CalloutsContent.Id;
          viewModel.Title = CalloutsContent.Title;
          viewModel.Teaser = CalloutsContent.Teaser;
          viewModel.Link = CalloutsContent.Link;
        }
      }
      return View("BlockButton", viewModel);
    }

    public ViewResult PageHeaderCallout()
    {
      var viewModel = new CalloutsItemViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var CalloutsContent = _contentService.GetCalloutItem(RenderingContext.Current.Rendering.DataSource);
        if (CalloutsContent != null)
        {
          viewModel.Id = CalloutsContent.Id;
          viewModel.Title = CalloutsContent.Title;
          viewModel.SubTitle = CalloutsContent.SubTitle;
          viewModel.Teaser = CalloutsContent.Teaser;
          viewModel.Link = CalloutsContent.Link;
          viewModel.Image = CalloutsContent.Image;
          if (viewModel.Image == null)
          {
            viewModel.Image = new Glass.Mapper.Sc.Fields.Image()
            {
              Src = "/images/bg-heading-blue-default.jpg",
              Alt = "blue background",
            };
          }
        }
      }
      return View("PageHeaderCallout", viewModel);
    }

    public ViewResult PageTeaserImageSummary()
    {
      var viewModel = new CalloutsItemViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var CalloutsContent = _contentService.GetCalloutItem(RenderingContext.Current.Rendering.DataSource);
        if (CalloutsContent != null)
        {
          viewModel.Id = CalloutsContent.Id;
          viewModel.Title = CalloutsContent.Title;
          viewModel.SubTitle = CalloutsContent.SubTitle;
          viewModel.Teaser = CalloutsContent.Teaser;
          viewModel.Link = CalloutsContent.Link;
          viewModel.Image = CalloutsContent.Image;


          //specific rendering params
          viewModel.ImageLeftRightClass = RenderingContext.Current.Rendering.GetImageLeftRightClass("fl-right");
          viewModel.NoContainCss = RenderingContext.Current.Rendering.GetNoContainCss();
          viewModel.OppositeImageLeftRightClass = RenderingContext.Current.Rendering.GetOppositeImageLeftRightClass();
        }
      }
      return View("PageTeaserImageSummary", viewModel);
    }

    public ViewResult PublicationCallout()
    {
      var viewModel = new CalloutsItemViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var CalloutsContent = _contentService.GetCalloutItem(RenderingContext.Current.Rendering.DataSource);
        if (CalloutsContent != null)
        {
          viewModel.Id = CalloutsContent.Id;
          viewModel.Title = CalloutsContent.Title;
          viewModel.SubTitle = CalloutsContent.SubTitle;
          viewModel.Teaser = CalloutsContent.Teaser;
          viewModel.Link = CalloutsContent.Link;
          viewModel.Image = CalloutsContent.Image;


          //specific rendering params
          viewModel.ImageLeftRightClass = RenderingContext.Current.Rendering.GetImageLeftRightClass("fl-left");
          viewModel.NoContainCss = RenderingContext.Current.Rendering.GetNoContainCss();
          viewModel.OppositeImageLeftRightClass = RenderingContext.Current.Rendering.GetOppositeImageLeftRightClass();
        }
      }
      return View("PublicationCallout", viewModel);
    }
  }
}
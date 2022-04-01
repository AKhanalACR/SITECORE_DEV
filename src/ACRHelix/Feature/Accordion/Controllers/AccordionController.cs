using ACRHelix.Feature.Accordion.Services;
using ACRHelix.Feature.Accordion.ViewModels;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.Accordion
{
  public class AccordionController : Controller
  {
    private readonly IContentService _contentService;

    public AccordionController(IContentService contentService)
    {
      _contentService = contentService;
    }



    public ViewResult Accordion()
    {
      var viewModel = new AccordionViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var accordionRoot = _contentService.GetAccordionContent(RenderingContext.Current.Rendering.DataSource);
        if (accordionRoot != null)
        {
          foreach (var child in accordionRoot.Children)
          {
            viewModel.AccordionItems.Add(child);
          }
        }
      }
      return View(viewModel);
    }

    public ViewResult IWAccordion()
    {
      var viewModel = new AccordionViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var accordionRoot = _contentService.GetAccordionContent(RenderingContext.Current.Rendering.DataSource);
        if (accordionRoot != null)
        {
          foreach (var child in accordionRoot.Children)
          {
            viewModel.AccordionItems.Add(child);
          }
        }
      }
      return View(viewModel);
    }

        public ViewResult IdeasAccordion()
        {
            var viewModel = new AccordionViewModel();
            if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                var accordionRoot = _contentService.GetAccordionContent(RenderingContext.Current.Rendering.DataSource);
                if (accordionRoot != null)
                {
                    foreach (var child in accordionRoot.Children)
                    {
                        viewModel.AccordionItems.Add(child);
                    }
                }
            }
            return View(viewModel);
        }
        public ViewResult IdeasSelectedAccordionItems()
        {
            var viewModel = new IdeasSelectedAccordionItemsViewModel();
            if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                var selectedAccordions = _contentService.GetIdeasSelectedAccordionContent(RenderingContext.Current.Rendering.DataSource);
                if (selectedAccordions != null)
                {
                    viewModel.Id = selectedAccordions.Id;
                    viewModel.Title = selectedAccordions.Title;
                    if(selectedAccordions.SelectedAccordions.Count() > 0)
                    {
                        foreach(var accordionItem in selectedAccordions.SelectedAccordions)
                        {
                            viewModel.AccordionItems.Add(accordionItem);
                        }
                    }
                    else if(selectedAccordions.SelectedCategory != null)
                    {
                        foreach (var accordionItem in selectedAccordions.AllFAQs.Where(f => f.Category != null && f.Category.Id == selectedAccordions.SelectedCategory.Id))
                        {
                            viewModel.AccordionItems.Add(accordionItem);
                        }
                    }
                }
            }
            return View(viewModel);
        }
    }
}
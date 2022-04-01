using ACRHelix.Feature.CodingSource.Services;
using ACRHelix.Feature.CodingSource.ViewModels;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.CodingSource
{
  public class CodingSourceController : Controller
  {
    private readonly IContentService _contentService;

    public CodingSourceController(IContentService contentService)
    {
      _contentService = contentService;
    }

    public ViewResult CodingSourceList()
    {
      var viewModel = new CodingSourceViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var CodingSourceContent = _contentService.GetCodingSourceListContent(RenderingContext.Current.Rendering.DataSource);
        if (CodingSourceContent != null)
        {
          viewModel.Id = CodingSourceContent.Id;
          viewModel.Title = CodingSourceContent.Title;
          viewModel.CodingSources = CodingSourceContent.CodingSources.OrderByDescending(x => x.Date).ToList();
          viewModel.CodingSourceYears = new List<int>();
          foreach (var cd in viewModel.CodingSources)
          {
            var year = cd.Date.Year;
            if (!viewModel.CodingSourceYears.Contains(year))
            {
              viewModel.CodingSourceYears.Add(year);
            }
          }
        }
      }
      return View(viewModel);
    }
  }
}
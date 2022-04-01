using ACRHelix.Feature.Biography.Services;
using ACRHelix.Feature.Biography.ViewModels;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.Biography
{
  public class BiographyController : Controller
  {
    private readonly IContentService _contentService;

    public BiographyController(IContentService contentService)
    {
      _contentService = contentService;
    }

    public ViewResult Biography()
    {
      var viewModel = new BiographyViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (String.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      if (!String.IsNullOrEmpty(dataSource))
      {
        var BiographyContent = _contentService.GetBiographyContent(dataSource);
        if (BiographyContent != null)
        {
          viewModel.Id = BiographyContent.Id;
          viewModel.Title = BiographyContent.Title;
          viewModel.SubTitle = BiographyContent.SubTitle;
          //viewModel.Image = BiographyContent.Image;
          viewModel.BioImage = BiographyContent.BioImage;
          viewModel.OtherPositions = BiographyContent.OtherPositions;
          viewModel.RichText = BiographyContent.RichText;
          viewModel.Phone = BiographyContent.Phone;
          viewModel.Email = BiographyContent.Email;
          viewModel.DisplayDetailLink = BiographyContent.DisplayDetailLink;
        }
      }
      return View(viewModel);
    }
  }
}
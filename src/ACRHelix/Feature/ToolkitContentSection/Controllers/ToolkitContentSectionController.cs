using ACRHelix.Feature.ToolkitContentSection.Services;
using ACRHelix.Feature.ToolkitContentSection.ViewModels;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.ToolkitContentSection
{
  public class ToolkitContentSectionController : Controller
  {
    private readonly IContentService _contentService;

    public ToolkitContentSectionController(IContentService contentService)
    {
      _contentService = contentService;
    }

    public ViewResult ToolkitContentSection()
    {
      var viewModel = new ToolkitContentSectionViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var ToolkitContentSectionContent = _contentService.GetToolkitContentSectionContent(RenderingContext.Current.Rendering.DataSource);
        if (ToolkitContentSectionContent != null)
        {
          //viewModel.Id = ToolkitContentSectionContent.Id;
          //viewModel.Link1 = ToolkitContentSectionContent.Link1;
          //viewModel.Link2 = ToolkitContentSectionContent.Link2;
          //viewModel.Link3 = ToolkitContentSectionContent.Link3;
          //viewModel.LinkImage1 = ToolkitContentSectionContent.LinkImage1;
          //viewModel.LinkImage2 = ToolkitContentSectionContent.LinkImage2;
          //viewModel.LinkImage3 = ToolkitContentSectionContent.LinkImage3;
          //viewModel.SectionImage = ToolkitContentSectionContent.SectionImage;
          //viewModel.SectionText = ToolkitContentSectionContent.SectionText;
          //viewModel.SectionTitle = ToolkitContentSectionContent.SectionTitle;

          viewModel.Content = ToolkitContentSectionContent;
        }
      }
      return View(viewModel);
    }

    public ViewResult ToolkitWithoutShareLink()
    {
        var viewModel = new ToolkitContentSectionViewModel();
        if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
        {
            var ToolkitContentSectionContent = _contentService.GetToolkitContentSectionContent(RenderingContext.Current.Rendering.DataSource);
            if (ToolkitContentSectionContent != null)
            {
                //viewModel.Id = ToolkitContentSectionContent.Id;
                //viewModel.Link1 = ToolkitContentSectionContent.Link1;
                //viewModel.Link2 = ToolkitContentSectionContent.Link2;
                //viewModel.Link3 = ToolkitContentSectionContent.Link3;
                //viewModel.LinkImage1 = ToolkitContentSectionContent.LinkImage1;
                //viewModel.LinkImage2 = ToolkitContentSectionContent.LinkImage2;
                //viewModel.LinkImage3 = ToolkitContentSectionContent.LinkImage3;
                //viewModel.SectionImage = ToolkitContentSectionContent.SectionImage;
                //viewModel.SectionText = ToolkitContentSectionContent.SectionText;
                //viewModel.SectionTitle = ToolkitContentSectionContent.SectionTitle;
    
                viewModel.Content = ToolkitContentSectionContent;
            }
        }
        return View("ToolkitWithoutShareLink", viewModel);
   }
  }
}
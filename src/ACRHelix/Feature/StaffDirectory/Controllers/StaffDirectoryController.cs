using ACRHelix.Feature.Biography.ViewModels;
using ACRHelix.Feature.StaffDirectory.Services;
using ACRHelix.Feature.StaffDirectory.ViewModels;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACR.Foundation.SSO.UserContext;
using ACR.Foundation.SSO.Users;

namespace ACRHelix.Feature.StaffDirectory
{
  public class StaffDirectoryController : Controller
  {
    private readonly IContentService _contentService;

    public StaffDirectoryController(IContentService contentService)
    {
      _contentService = contentService;
    }

    public ViewResult StaffDirectory()
    {
      var viewModel = new StaffDirectoryViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (String.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      if (!String.IsNullOrEmpty(dataSource))
      {
        var StaffDirectoryContent = _contentService.GetStaffDirectoryContent(dataSource);
        if (StaffDirectoryContent != null)
        {
          viewModel.Id = StaffDirectoryContent.Id;
          viewModel.Title = StaffDirectoryContent.Title;
          viewModel.HideEmailPhone = StaffDirectoryContent.HideEmailPhone;
          viewModel.Biographies = StaffDirectoryContent.Biographies.Select(x => new BiographyViewModel
          {
            Id = x.Id,
            Title = x.Title,
            SubTitle = x.SubTitle,
            RichText = x.RichText,
            Email = x.Email,
            BioImage = x.BioImage,
            DisplayDetailLink = x.DisplayDetailLink,
            OtherPositions = x.OtherPositions,
            Phone = x.Phone,
            URL = x.URL,
            GroupPracticeName = x.GroupPracticeName,
            ParentOrganization = x.ParentOrganization
          });
          viewModel.UserAuthenticated = UserManager.CurrentUserContext.CurrentUser.IsAuthenticated;
        }
      }
      return View(viewModel);
    }
  }
}
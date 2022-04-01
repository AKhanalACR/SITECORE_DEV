using ACRHelix.Feature.MemberDirectory.Services;
using ACRHelix.Feature.MemberDirectory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ACRHelix.Feature.MemberDirectory
{
  public class MemberDirectoryController : Controller
  {
    private readonly IContentService _contentService;

    public MemberDirectoryController(IContentService contentService)
    {
      _contentService = contentService;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ViewResult MemberDirectory(MemberDirectoryViewModel viewModel)
    {
      return MemberDirectoryViewResult(viewModel);
    }

    private ViewResult MemberDirectoryViewResult(MemberDirectoryViewModel viewModel)
    {
      var dataSource = Sitecore.Context.Item.ID.ToString();

      if (!String.IsNullOrEmpty(dataSource))
      {
        var MemberDirectoryContent = _contentService.GetMemberDirectoryContent(dataSource);
        if (MemberDirectoryContent != null)
        {
          viewModel.Id = MemberDirectoryContent.Id;
          viewModel.Title = MemberDirectoryContent.Title;
          viewModel.SubTitle = MemberDirectoryContent.SubTitle;
          viewModel.Members = GetMembers(viewModel);
        }
      }
      return View(viewModel);
    }

    [HttpGet]
    public ViewResult MemberDirectory()
    {
      return MemberDirectoryViewResult(new MemberDirectoryViewModel());
    }

    //[HttpPost]
    //public ViewResult MemberDirectory(MemberDirectoryViewModel viewModel)
    //{
    //    var dataSource = Sitecore.Context.Item.ID.ToString();

    //    if (!String.IsNullOrEmpty(dataSource))
    //    {
    //        var MemberDirectoryContent = _contentService.GetMemberDirectoryContent(dataSource);
    //        if (MemberDirectoryContent != null)
    //        {
    //            viewModel.Id = MemberDirectoryContent.Id;
    //            viewModel.Title = MemberDirectoryContent.Title;
    //            viewModel.SubTitle = MemberDirectoryContent.SubTitle;
    //            viewModel.Members = GetMembers(viewModel);
    //        }
    //    }
    //    return View(viewModel);
    //}

    private List<MemberViewModel> GetMembers(MemberDirectoryViewModel viewModel)
    {
      List<MemberViewModel> members = null;
      bool searchForMembers = !String.IsNullOrWhiteSpace(viewModel.City) ||
                              !String.IsNullOrWhiteSpace(viewModel.State) ||
                              !String.IsNullOrWhiteSpace(viewModel.Zip) ||
                              !String.IsNullOrWhiteSpace(viewModel.FirstName) ||
                              !String.IsNullOrWhiteSpace(viewModel.LastName) ||
                              !String.IsNullOrWhiteSpace(viewModel.Country);


      if (searchForMembers)
      {
        var matchingMembers = _contentService.SearchMembers(viewModel.FirstName, viewModel.LastName, viewModel.City, GetStateValue(viewModel.State), viewModel.Zip, viewModel.Country);
        return matchingMembers.Select(x => new MemberViewModel { Member = x }).ToList();
      }

      return members;
    }

    private string GetStateValue(string viewModelState)
    {
      string stateValue = "";
      if (!string.IsNullOrWhiteSpace(viewModelState))
      {
        int i = viewModelState.IndexOf("|");
        if (i > 0)
        {
          stateValue = viewModelState.Substring(0, i);
        }
      }
      return stateValue;
    }

  }
}
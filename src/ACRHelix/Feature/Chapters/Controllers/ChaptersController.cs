using ACRHelix.Feature.Chapters.Services;
using ACRHelix.Feature.Chapters.ViewModels;
using Sitecore.Mvc.Presentation;
using System;
using System.Web.Mvc;
using System.Linq;
using ACRHelix.Feature.Chapters.Models;
using ACR.Foundation.Personify.PersonifyService;
using ACR.Foundation.Personify.Services;
using Sitecore.Data;
using ACRHelix.Feature.Chapters.Settings;
using ACR.Foundation.Personify.Models.Committees;
using System.Collections.Generic;

namespace ACRHelix.Feature.Chapters
{
  public class ChaptersController : Controller
  {
    private readonly IContentService _contentService;

    public ChaptersController(IContentService contentService)
    {
      _contentService = contentService;
    }

    public ViewResult CommitteeMembers()
    {
      var viewModel = new ViewModels.CommitteeMemberList();
      string dataSource = RenderingContext.Current.Rendering.DataSource;
      if (!String.IsNullOrEmpty(dataSource))
      {
        var content = _contentService.GetCommitteeMemberList(dataSource);
        if (content != null)
        {
          viewModel.CommitteeListContent = content;

          ID taxonomyItem = new ID();

          if (ID.TryParse(content.Committee, out taxonomyItem))
          {
            ACR.Foundation.Personify.Services.SitecoreContentService contentService = new ACR.Foundation.Personify.Services.SitecoreContentService();
            var taxonomy = contentService.GetTaxonomyItem(ID.Parse(content.Committee));
            if (taxonomy != null)
            {
              var personifySvc = new PersonifyEntitiesACR();
              var members = personifySvc.GetCommiteeMembers(taxonomy.PersonifyID);
              if (members != null)
              {
                viewModel.Members = members.Where(x => x.Position == "Member").OrderBy(x => x.SearchName).ToList();
              }
              else
              {
                return null;
              }
             
            
            }
          }

        }
      }
      return View(viewModel);
    }

    public ViewResult ChapterMembers()
    {
      var viewModel = new ViewModels.ChapterOfficers();
      string dataSource = RenderingContext.Current.Rendering.DataSource;
      if (!String.IsNullOrEmpty(dataSource))
      {
        var content = _contentService.GetChapterMemberContent(dataSource);
        if (content != null)
        {         
          ID taxonomyItem = new ID();

          if (ID.TryParse(content.Chapter, out taxonomyItem))
          {
            ACR.Foundation.Personify.Services.SitecoreContentService contentService = new ACR.Foundation.Personify.Services.SitecoreContentService();
            var taxonomy = contentService.GetTaxonomyItem(ID.Parse(content.Chapter));
            if (taxonomy != null)
            {
              var personifySvc = new PersonifyEntitiesACR();

              var members = personifySvc.GetChapterMembers(taxonomy.PersonifyID);
              if (members != null)
              {
                foreach (var m in members)
                {
                  if (Settings.ChapterCategorySettings.OfficerPositions.Contains(m.Position))
                  {
                    viewModel.Officers.Add(m);
                  }
                  else if (Settings.ChapterCategorySettings.Councilors.Contains(m.Position))
                  {
                    viewModel.Coucilors.Add(m);
                  }
                  else if (Settings.ChapterCategorySettings.AlternateCouncilors.Contains(m.Position))
                  {
                    viewModel.AlternateCouncilors.Add(m);
                  }
                }

                viewModel.Officers.Sort();
                viewModel.Coucilors = viewModel.Coucilors.OrderBy(x => x.LastName).ToList();
                viewModel.AlternateCouncilors = viewModel.AlternateCouncilors.OrderBy(x => x.LastName).OrderBy(x => x.Position).ToList();
              }
              else
              {
                return null;
              }
            }
          }
        }
      }

      return View(viewModel);
    }

    public ViewResult CommitteeLeadershipList()
    {
      var viewModel = new ViewModels.CommitteeMemberList();
      string dataSource = RenderingContext.Current.Rendering.DataSource;
      if (!String.IsNullOrEmpty(dataSource))
      {
        var content = _contentService.GetCommitteeMemberList(dataSource);
        if (content != null)
        {
          viewModel.CommitteeListContent = content;

          ID taxonomyItem = new ID();

          if (ID.TryParse(content.Committee, out taxonomyItem))
          {
            ACR.Foundation.Personify.Services.SitecoreContentService contentService = new ACR.Foundation.Personify.Services.SitecoreContentService();
            var taxonomy = contentService.GetTaxonomyItem(ID.Parse(content.Committee));
            if (taxonomy != null)
            {
              var personifySvc = new PersonifyEntitiesACR();

              var all = personifySvc.GetCommiteeMembers(taxonomy.PersonifyID);
              if (all != null) {
                var allLeaders = all.Where(x => x.Position != "Member").OrderBy(x => x.Position).ToList();

                var commiteeLeaders = new List<CommitteeMember>();

                foreach (var m in allLeaders)
                {
                  foreach (var kvp in CommitteeMemberSettings.DisplayedLeadershipPositions)
                  {

                    if (kvp.Key == m.Position)
                    {
                      m.Order = kvp.Value;
                      commiteeLeaders.Add(m);
                      break;
                    }
                  }

                }


                viewModel.Leadership = commiteeLeaders.OrderBy(x => x.Order).ToList(); ;
              }
            }
          }

        }
      }
      return View(viewModel);
    }

    public ViewResult ChapterMeetingHeader()
    {
      var viewModel = new ChapterMeetingViewModel();

      string dataSource = Sitecore.Context.Item.ID.ToString();

      var meeting = _contentService.GetChapterMeeting(dataSource);
      if (meeting != null)
      {
        viewModel.ChapterMeeting = meeting;
        if (meeting.StartDate.Hour == 0 && meeting.StartDate.Minute == 0)
        {
          viewModel.StartTimeSet = false;
        }
        else
        {
          viewModel.StartTimeSet = true;
        }
        if (meeting.EndDate.Hour == 0 && meeting.EndDate.Minute == 0)
        {
          viewModel.EndTimeSet = false;
        }
        else
        {
          viewModel.EndTimeSet = true;
        }
      }


      return View(viewModel);
    }

    public ViewResult ChapterHeader()
    {
      var viewModel = new ChapterViewModel();
      string dataSource = RenderingContext.Current.Rendering.DataSource;
      if (String.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      var chapterContent = _contentService.GetChaptersContent(dataSource);
      if (chapterContent != null)
      {
        viewModel.Id = chapterContent.Id;
        viewModel.ChapterWebsite = chapterContent.ChapterWebsite;
        viewModel.Title = chapterContent.Title;
        viewModel.ChapterLogo = chapterContent.ChapterLogo;
        //viewModel.Image = chapterContent.Image;
      }
      return View("ChapterHeader", viewModel);
    }

    public ViewResult ChapterAwards()
    {
      var viewModel = new Models.ChapterAwardFolder();
      string dataSource = RenderingContext.Current.Rendering.DataSource;
      if (!string.IsNullOrWhiteSpace(dataSource))
      {
        var awards = _contentService.GetChapterAwards(dataSource);
        if (awards != null)
        {/*
          if (awards.Children != null)
          {
            awards.Children = awards.Children.OrderByDescending(x => x.Year);
          }*/
          viewModel = awards;
        }
      }
      return View("ChapterAwards", viewModel);
    }

    public ViewResult UpcomingMeetings()
    {
      var viewModel = new UpcomingMeetingsViewModel();
      string dataSource = RenderingContext.Current.Rendering.DataSource;
      if (!string.IsNullOrWhiteSpace(dataSource))
      {
        var chapterFolder = _contentService.GetChapterMeetingsFolder(dataSource);
        if (chapterFolder != null)
        {
          viewModel.Id = chapterFolder.Id;
          viewModel.HeaderText = chapterFolder.HeaderText;
          if (chapterFolder.Children != null)
          {
            if (chapterFolder.Children.Count() > 0)
            {
              viewModel.Meetings = chapterFolder.Children.Where(x => x.FilterDate.Date >= DateTime.UtcNow.Date).OrderBy(x => x.StartDate).ToList();
            }
          }
        }
      }
      return View("UpcomingMeetings", viewModel);
    }

    public ViewResult ChapterNewsList()
    {
      var viewModel = new ChapterNewsViewModel();

      string dataSource = RenderingContext.Current.Rendering.DataSource;
      if (!string.IsNullOrWhiteSpace(dataSource))
      {
        var chapterNews = _contentService.GetChapterNewsFolder(dataSource);
        if (chapterNews != null)
        {
          if (chapterNews.Children != null)
          {
            if (chapterNews.Children.Count() > 0)
            {
              viewModel.ChapterNews = chapterNews.Children.OrderByDescending(x => x.Date).Take(2).ToList();
            }
          }
        }
      }
      return View("ChapterNewsList", viewModel);
    }

    public ViewResult ChapterNewsArchive()
    {
      var viewModel = new ChapterNewsViewModel();

      string dataSource = RenderingContext.Current.Rendering.DataSource;
      if (!string.IsNullOrWhiteSpace(dataSource))
      {
        var chapterNews = _contentService.GetChapterNewsFolder(dataSource);
        if (chapterNews != null)
        {
          if (chapterNews.Children != null)
          {
            if (chapterNews.Children.Count() > 2)
            {
              viewModel.ChapterNews = chapterNews.Children.OrderByDescending(x => x.Date).Skip(2).ToList();
            }
            else if (!Sitecore.Context.PageMode.IsExperienceEditor)
            {
              return null;
            }
          }
        }
      }
      return View("ChapterNewsArchive", viewModel);
    }
  }
}
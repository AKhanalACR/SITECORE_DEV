using ACR.Foundation.Personify.Models.Products;
using ACRHelix.Feature.MeetingsCalendar.Models;
using ACRHelix.Feature.MeetingsCalendar.Services;
using ACRHelix.Feature.MeetingsCalendar.ViewModels;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ACR.Foundation.Personify.Helpers;

namespace ACRHelix.Feature.MeetingsCalendar
{
  public class MeetingsCalendarController : Controller
  {
    private readonly IContentService _contentService;

    public MeetingsCalendarController(IContentService contentService)
    {
      _contentService = contentService;
    }
    /*
    public ViewResult MeetingsCalendar()
    {
      var viewModel = new MeetingsCalendarViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (String.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      if (!String.IsNullOrEmpty(dataSource))
      {
        var MeetingsCalendarContent = _contentService.GetMeetingsCalendarContent(dataSource);
        if (MeetingsCalendarContent != null)
        {
          DateTime thisMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
          DateTime nextMonth = thisMonth.AddMonths(1);

          viewModel.Id = MeetingsCalendarContent.Id;
          viewModel.Title = MeetingsCalendarContent.Title;
          viewModel.ThisMonth = thisMonth.ToString("MMMM");
          viewModel.NextMonth = nextMonth.ToString("MMMM");
          viewModel.ThisMonthsMeetingsAndCourses = MeetingsCalendarContent.MeetingsAndCourses
          .Where(m => m.Date >= thisMonth && m.Date < nextMonth)
          .OrderBy(m => m.Date)
          .Select(m => new MeetingOrCourseViewModel
          {
            Id = m.Id,
            Title = m.Title,
            Location = m.Location,
            Date = m.Date,
            Url = m.Url
          });
          viewModel.NextMonthsMeetingsAndCourses = MeetingsCalendarContent.MeetingsAndCourses
          .Where(m => m.Date >= nextMonth && m.Date < nextMonth.AddMonths(1))
          .OrderBy(m => m.Date)
          .Select(m => new MeetingOrCourseViewModel
          {
            Id = m.Id,
            Title = m.Title,
            Location = m.Location,
            Date = m.Date,
            Url = m.Url
          });
        }
      }
      return View(viewModel);
    }
    */

    /*
    public ViewResult MeetingOrCourse()
    {
      var viewModel = new MeetingOrCourseViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (String.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      if (!String.IsNullOrEmpty(dataSource))
      {
        var MeetingOrCourseContent = _contentService.GetMeetingOrCourseContent(dataSource);
        if (MeetingOrCourseContent != null)
        {
          viewModel.Id = MeetingOrCourseContent.Id;
          viewModel.Title = MeetingOrCourseContent.Title;
          viewModel.Date = MeetingOrCourseContent.Date;
          viewModel.Location = MeetingOrCourseContent.Location;
        }
      }
      return View(viewModel);
    }*/

    public ViewResult SocietyMeetingHeader()
    {
      var viewModel = new SocietyMeetingViewModel();

      string dataSource = Sitecore.Context.Item.ID.ToString();

      var meeting = _contentService.GetSocietyMeetingContent(dataSource);
      if (meeting != null)
      {
        viewModel.SocietyMeeting = meeting;
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


    public ViewResult MeetingOrCourseHeader()
    {
      if (Sitecore.Context.Item.TemplateID.ToString() == MeetingCourseHeaderNoProductStub.TemplateId)
      {
        return MeetingOrCourseNoProductStubHeader();
      }

      var viewModel = new MeetingOrCourseHeader();
      var dataSource = RenderingContext.Current.Rendering.DataSource;
      if (String.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      if (!String.IsNullOrEmpty(dataSource))
      {
        var MeetingOrCourseContent = _contentService.GetMeetingOrCourseHeaderContent(dataSource);
        if (MeetingOrCourseContent != null)
        {
          viewModel = MeetingOrCourseContent;
        
        }
      }
      return View(viewModel);
    }

    public ViewResult MeetingOrCourseNoProductStubHeader()
    {
      var viewModel = new MeetingCourseHeaderNoProductStub();

      var dataSource = Sitecore.Context.Item.ID.ToString();
      if (!String.IsNullOrEmpty(dataSource))
      {
        var meetingNoProduct = _contentService.GetMeetingCourseHeaderNoProductStub(dataSource);
        if (meetingNoProduct != null)
        {
          viewModel = meetingNoProduct;
        }
      }

      return View("MeetingOrCourseNoProductStubHeader", viewModel);
    }

    public ViewResult RegistrationTable()
    {
      var viewModel = new RegistrationTableViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (String.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      if (!String.IsNullOrEmpty(dataSource))
      {
        var MeetingOrCourseContent = _contentService.GetMeetingOrCourseHeaderContent(dataSource);
        if (MeetingOrCourseContent != null)
        {
          viewModel.Id = MeetingOrCourseContent.Id;
          viewModel.Title = MeetingOrCourseContent.Title;
          viewModel.Products = MeetingOrCourseContent.Products.Where(x => x.MeetingLastRegistrationDate >= DateTime.Now).OrderBy(x => x.MeetingStartDate).ToList();
        }
      }
      return View(viewModel);
    }

   

    public ViewResult RegistrationPricingTable()
    {
      var viewModel = new RegistrationPriceTable();

      string dataSource = RenderingContext.Current.Rendering.DataSource;
      if (!string.IsNullOrWhiteSpace(dataSource))
      {
        var content = _contentService.GetRegistrationPriceContent(dataSource);
        if (content != null)
        {
          viewModel = content;
          var MeetingOrCourseContent = _contentService.GetMeetingOrCourseHeaderContent(Sitecore.Context.Item.ID.ToString());
          if (MeetingOrCourseContent != null)
          {
            if (MeetingOrCourseContent.Products.Any())
            {
              var products = MeetingOrCourseContent.Products.Where(x => x.MeetingStartDate >= DateTime.Now.Date).OrderBy(x => x.MeetingStartDate).ToList();
              if (products.Any())
              {
                viewModel.RegisterLink = products.First().GetProductPersonifyUrl();
              }
              else
              {
                products = MeetingOrCourseContent.Products.Where(x => x.MeetingStartDate <= DateTime.Now.Date).OrderByDescending(x => x.MeetingStartDate).ToList();
                if (products.Any())
                {
                  viewModel.RegisterLink = products.First().GetProductPersonifyUrl();
                }
              }
            }
          }
        }
      }

      return View(viewModel);
    }

    public ViewResult EventTiles()
    {
      var viewModel = new EventTilesViewModel();
      string dataSource = RenderingContext.Current.Rendering.DataSource;
      if (!string.IsNullOrWhiteSpace(dataSource))
      {
        var eventFolder = _contentService.GetEventTilesFolder(dataSource);
        if (eventFolder != null)
        {
          viewModel.Id = eventFolder.Id;
          viewModel.HeaderText = eventFolder.HeaderText;
          if (eventFolder.Children != null)
          {
            if (eventFolder.Children.Count() > 0)
            {
              viewModel.Events = eventFolder.Children.Where(x => x.FilterDate.Date >= DateTime.UtcNow.Date || x.FilterDate == DateTime.MinValue).OrderBy(x => x.StartDate).ToList();
            }
          }
        }
      }
      return View("EventTiles", viewModel);
    }

        public ViewResult RliEventTiles()
        {
            var viewModel = new RliEventTilesViewModel();
            string dataSource = RenderingContext.Current.Rendering.DataSource;
            if (!string.IsNullOrWhiteSpace(dataSource))
            {
                var eventTiles = _contentService.GetRliEventTilesContent(dataSource);
                if (eventTiles != null)
                {
                    viewModel.Id = eventTiles.Id;
                    viewModel.Title = eventTiles.Title;
                    viewModel.DisplayNbr = eventTiles.NbrItemsToDisplay;
                    if (viewModel.DisplayNbr == 0)
                        viewModel.DisplayNbr = 4;

                    viewModel.ArchiveLink = eventTiles.ArchiveLink;
                    viewModel.Events = eventTiles.EventTiles.ToList();
                    if (eventTiles.EventTiles != null && eventTiles.EventTiles.Count() > 0)
                    {
                        viewModel.Events = eventTiles.EventTiles.Where(x => x.WebDisplay != false && x.FilterDate != DateTime.MinValue && x.ProductClassName == "RLI" && x.ProductTypeName == "Meeting").OrderBy(x => x.FilterDate).Take(viewModel.DisplayNbr).ToList();                                             
                    }
                }
            }
            return View(viewModel);
        }
    }
}
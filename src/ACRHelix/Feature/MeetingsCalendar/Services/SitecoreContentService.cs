using ACRHelix.Feature.MeetingsCalendar.Models;
using ACRHelix.Foundation.Repository.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.MeetingsCalendar.Services
{
  public class SitecoreContentService : IContentService
  {
    private readonly IContentRepository _repository;
    public SitecoreContentService(IContentRepository repository)
    {
        _repository = repository;
    }
    public MeetingOrCourseHeader GetMeetingOrCourseHeaderContent(string contentGuid)
    {
      return _repository.GetContentItem<MeetingOrCourseHeader>(contentGuid);
    }

    public EventTilesFolder GetEventTilesFolder(string contentGuid)
    {
      return _repository.GetContentItem<EventTilesFolder>(contentGuid);
    }

    public RegistrationPriceTable GetRegistrationPriceContent(string contentGuid)
    {
      return _repository.GetContentItem<RegistrationPriceTable>(contentGuid);
    }

    public SocietyMeeting GetSocietyMeetingContent(string contentGuid)
    {
      return _repository.GetContentItem<SocietyMeeting>(contentGuid);
    }

    public MeetingCourseHeaderNoProductStub GetMeetingCourseHeaderNoProductStub(string contentGuid)
    {
      return _repository.GetContentItem<MeetingCourseHeaderNoProductStub>(contentGuid);
    }

        public RliEventTiles GetRliEventTilesContent(string contentGuid)
        {
            return _repository.GetContentItem<RliEventTiles>(contentGuid);
        }
    }
}
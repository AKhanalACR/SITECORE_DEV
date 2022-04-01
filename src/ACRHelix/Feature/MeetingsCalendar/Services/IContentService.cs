using ACRHelix.Feature.MeetingsCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.MeetingsCalendar.Services
{
  public interface IContentService
  {
    MeetingOrCourseHeader GetMeetingOrCourseHeaderContent(string contentGuid);
    EventTilesFolder GetEventTilesFolder(string contentGuid);

    RegistrationPriceTable GetRegistrationPriceContent(string contentGuid);

    SocietyMeeting GetSocietyMeetingContent(string contentGuid);

    MeetingCourseHeaderNoProductStub GetMeetingCourseHeaderNoProductStub(string contentGuid);
        RliEventTiles GetRliEventTilesContent(string contentGuid);
    }
}
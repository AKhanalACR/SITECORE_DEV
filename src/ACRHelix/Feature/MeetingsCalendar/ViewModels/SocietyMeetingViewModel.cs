using ACRHelix.Feature.MeetingsCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.MeetingsCalendar.ViewModels
{
  public class SocietyMeetingViewModel
  {
    public SocietyMeeting SocietyMeeting { get; set; }

    public bool StartTimeSet { get; set; }

    public bool EndTimeSet { get; set; }
  }
}
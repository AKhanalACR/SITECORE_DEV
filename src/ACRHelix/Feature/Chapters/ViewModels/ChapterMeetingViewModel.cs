using ACRHelix.Feature.Chapters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Chapters.ViewModels
{
  public class ChapterMeetingViewModel
  {
    public ChapterMeeting ChapterMeeting { get; set; }

    public bool StartTimeSet { get; set; }

    public bool EndTimeSet { get; set; }
  }
}
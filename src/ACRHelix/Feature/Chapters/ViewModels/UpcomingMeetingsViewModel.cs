using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.Chapters.ViewModels
{
  public class UpcomingMeetingsViewModel
  {
    public ID Id { get; set; }
    public string HeaderText { get; set; }
    public List<Models.ChapterMeeting> Meetings { get; set; } = new List<Models.ChapterMeeting>();


    //Paging client side lists
    public int PageSize = 4;
    public List<List<Models.ChapterMeeting>> MeetingPages
    {
      get
      {
        List<List<Models.ChapterMeeting>> listofList = new List<List<Models.ChapterMeeting>>();

        int added = 0;
        List<Models.ChapterMeeting> allMeetings = Meetings;
        while (added < Meetings.Count)
        {
          List<Models.ChapterMeeting> mlist = new List<Models.ChapterMeeting>();
          mlist = allMeetings.Skip(added).Take(PageSize).ToList();
          listofList.Add(mlist);
          added += mlist.Count;
        }
        return listofList;
      }
    }


  }
}
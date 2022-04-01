using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.MeetingsCalendar.ViewModels
{
  public class EventTilesViewModel
  {
    public ID Id { get; set; }
    public string HeaderText { get; set; }
    public List<Models.EventTile> Events { get; set; } = new List<Models.EventTile>();


    //Paging client side lists
    public int PageSize = 4;
    public List<List<Models.EventTile>> EventTilePages
    {
      get
      {
        List<List<Models.EventTile>> listofList = new List<List<Models.EventTile>>();

        int added = 0;
        List<Models.EventTile> allEvents = Events;
        while (added < Events.Count)
        {
          List<Models.EventTile> elist = new List<Models.EventTile>();
          elist = allEvents.Skip(added).Take(PageSize).ToList();
          listofList.Add(elist);
          added += elist.Count;
        }
        return listofList;
      }
    }


  }
}
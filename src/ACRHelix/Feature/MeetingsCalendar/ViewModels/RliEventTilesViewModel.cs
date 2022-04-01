using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.MeetingsCalendar.ViewModels
{
  public class RliEventTilesViewModel
  {
        public ID Id { get; set; }
        public string Title { get; set; }
        public int DisplayNbr { get; set; }
        public Link ArchiveLink { get; set; }

        public List<Models.RliEventTile> Events { get; set; } = new List<Models.RliEventTile>();

        //Paging client side lists
        public int PageSize = 4;
        public List<List<Models.RliEventTile>> EventTilePages
        {
            get
            {
              List<List<Models.RliEventTile>> listofList = new List<List<Models.RliEventTile>>();

              int added = 0;
              List<Models.RliEventTile> allEvents = Events;
              while (added < Events.Count)
              {
                List<Models.RliEventTile> elist = new List<Models.RliEventTile>();
                    elist = allEvents.Skip(added).Take(DisplayNbr).ToList();
                    listofList.Add(elist);
                added += elist.Count;
              }
              return listofList;
            }
        }


  }
}
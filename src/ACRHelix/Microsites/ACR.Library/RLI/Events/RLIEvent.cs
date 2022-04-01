using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.RLI.Interfaces;
using ACR.Library.RLI.Taxonomy;

namespace ACR.Library.RLI.Events
{
    public class RLIEvent : IRLIEvent
    {
        public RLIEvent()
        {

        }

        public RLIEvent(RLIEvent evnt)
        {
            EventStartDate = evnt.EventStartDate;
            EventShortDescription = evnt.EventShortDescription;
            EventShortDescriptionFull = evnt.EventShortDescriptionFull;
            EventBody = evnt.EventBody;
            EventDuration = evnt.EventDuration;
            EventEndDate = evnt.EventEndDate;
            EventTitle = evnt.EventTitle;
            EventUrl = evnt.EventUrl;
            EventUrlTarget = evnt.EventUrlTarget;
            ItemUrl = evnt.ItemUrl;
            EventTimezone = evnt.EventTimezone;
            LectureDaysOfWeek = evnt.LectureDaysOfWeek;
            Tags = evnt.Tags;
        }


        public DateTime EventStartDate { get; set; }

        public string EventShortDescription { get; set; }

        public string EventShortDescriptionFull { get; set; }

        public string EventBody { get; set; }

        public string EventTitle { get; set; }

        public string EventUrl { get; set; }

        public string EventUrlTarget { get; set; }

        public string ItemUrl { get; set; }

        public DateTime EventEndDate { get; set; }

        public string EventDuration { get; set; }

        public string EventTimezone { get; set; }

        public List<DayOfWeekItem> LectureDaysOfWeek { get; set; }

        public List<string> Tags { get; set; }
    }
}

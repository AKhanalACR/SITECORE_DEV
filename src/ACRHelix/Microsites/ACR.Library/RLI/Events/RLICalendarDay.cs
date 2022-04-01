using System;
using ACR.Library.RLI.Interfaces;
using ACR.Library.Utils;

namespace ACR.Library.RLI.Events
{
    public class RLICalendarDay
    {
        public RLICalendarDay(IRLIEvent evt)
        {
            StartTime = evt.EventStartDate.ToString("h:mm tt");
            Title = evt.EventTitle;
            Description = evt.EventShortDescription;
            Url = evt.EventUrl;
        }

        public string StartTime { get; set; }

        public string Description { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }
    }
}

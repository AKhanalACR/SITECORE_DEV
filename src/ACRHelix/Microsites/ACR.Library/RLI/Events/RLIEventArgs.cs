using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACR.Library.RLI.Events
{
    public class RLIEventArgs
    {
        /// <summary>
        /// Event Date passed
        /// </summary>
        public DateTime EventDate { get; set; }
        /// <summary>
        /// Sitecore ID of Event Tag to filter on
        /// </summary>
        public string EventTagId { get; set; }

        /// <summary>
        /// Sitecore ID of Event Type to filter on
        /// </summary>
        public string EventTypeId { get; set; }

        /// <summary>
        /// String of Month events in object format
        /// </summary>
        public string MonthEvents { get; set; }

        /// <summary>
        /// Event Day items
        /// </summary>
        public List<RLICalendarDay> DayEvents { get; set; }
    }
}

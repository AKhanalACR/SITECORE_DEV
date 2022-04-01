using System;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using ACR.Constants;
using Sitecore.Data.Items;
using Sitecore.Data.Fields;

namespace ACRAccreditationInformaticsLibrary.RLI
{
    public class NewRLIEvent : SearchResultItem
    {
        [IndexField("start_date")]
        public DateTime EventStartDate
        {
            get;set;
        }

        [IndexField("short_description")]
        public String EventShortDescription { get; set; }


        //public String EventShortDescriptionFull { get; }

        [IndexField("body")]
        public String EventBody { get; set; }

        [IndexField("title")]
        public String EventTitle { get; set; }


        public String EventUrl { get; set; }
        public String EventUrlTarget { get; set; }
        public String ItemUrl { get; set; }

        [IndexField("end_date")] 
        public DateTime EventEndDate { get; set; }

        [IndexField("duration")]
        public String EventDuration { get; set; }

        [IndexField("timezone")]
        public String EventTimezone { get; set; }

        [IndexField("lecture_days_of_week")]
        public string DaysOfWeek { get; set; }
        //public List<DayOfWeekItem> LectureDaysOfWeek { get; }

        [IndexField("tags")]
        public string Tags { get; set; }

    }
}

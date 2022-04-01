using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore;
using Sitecore.Data;

namespace ACRHelix.Feature.MeetingsCalendar.Models
{
    public class EventTile : ICMSEntity
    {
        public virtual ID Id { get; set; }

        [SitecoreField("Event Title")]
        public virtual string EventTitle { get; set; }

        [SitecoreField("Start Date")]
        public virtual DateTime StartDate { get; set; }

        [SitecoreField("End Date")]
        public virtual DateTime EndDate { get; set; }

        [SitecoreField("Link")]
        public virtual Link Link { get; set; }

        public virtual string Url { get; set; }

        public virtual string Location { get; set; }

        public virtual DateTime FilterDate
        {
            get
            {
                if (EndDate != DateTime.MinValue)
                {
                    return EndDate;
                }
                return StartDate;
            }
        }




    }
}
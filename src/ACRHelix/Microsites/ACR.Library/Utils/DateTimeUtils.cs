using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.RLI.Base;
using ACR.Library.RLI.Interfaces;
using ACR.Library.RLI.Pages;

namespace ACR.Library.Utils
{
	public class DateTimeUtils
	{
		public static string FormatRLIEventDate(IRLIEvent item)
		{
			string date;

			if (item.EventEndDate == DateTime.MinValue)
			{
				date = string.Format("{0:MMMM d} {1}", item.EventStartDate, item.EventTimezone);
			}
			else if (item.EventStartDate.Year != item.EventEndDate.Year)
			{
				date = string.Format("{0:MMMM d, yyyy} - {1:MMMM d, yyyy}", item.EventStartDate, item.EventEndDate);
			}
			else if(item.EventStartDate.Month != item.EventEndDate.Month)
			{
				date = string.Format("{0:MMMM d} - {1:MMMM d, yyyy}", item.EventStartDate, item.EventEndDate);
			}
			else
			{
				date = string.Format("{0:MMMM d} - {1:d, yyyy}", item.EventStartDate, item.EventEndDate);
			}
			return String.Format("{0}", date);
		}

		public static string FormatRLIEventDateTime(IRLIEvent item)
		{
			if(item.EventStartDate == DateTime.MinValue)
			{
				return "";
			}

			string date;
			string time = "";
			DateTime displayedEndDate = item.EventEndDate.ToLocalTime(); //ToLocalTime added
			int minute =0;
			int hour =0;
			if (item.EventStartDate.TimeOfDay.TotalSeconds != 0)
			{
                time = string.Format("{0:h:mm tt}", item.EventStartDate.ToLocalTime()).ToLower(); 

                if (!String.IsNullOrEmpty(item.EventDuration))
                {
                    string[] duration = item.EventDuration.Split(new[] { ':' }, 2);
                    if (duration.Count() == 2 && int.TryParse(duration[0], out hour) && int.TryParse(duration[1], out minute))
                    {
                        time = time + string.Format(" - {0:h:mm tt}", item.EventStartDate.ToLocalTime().AddHours(hour).AddMinutes(minute)).ToLower();
                    }
                }

                //modified on 8/2/2016
                //if (!string.IsNullOrEmpty(item.EventTimezone))
                //{
                //    time = time + " " + item.EventTimezone;
                //}

                time = time != "12:00 am" ? time : "";
                if (time != "")
                    time = string.Format("({0} EST)", time);
			}

			if (displayedEndDate == DateTime.MinValue)
			{
                displayedEndDate = item.EventStartDate.ToLocalTime();
				displayedEndDate = displayedEndDate.AddHours(hour).AddMinutes(minute);	
			}

            if (item.EventStartDate.ToLocalTime().Year != displayedEndDate.Year)
			{
                date = string.Format("{0:MMMM d, yyyy} - {1:MMMM d, yyyy}", item.EventStartDate.ToLocalTime(), displayedEndDate);
			}
            else if (item.EventStartDate.ToLocalTime().Month != displayedEndDate.Month)
			{
                date = string.Format("{0:MMMM d} - {1:MMMM d, yyyy}", item.EventStartDate.ToLocalTime(), displayedEndDate);
			}
            else if (item.EventStartDate.ToLocalTime().Day != displayedEndDate.Day)
			{
                date = string.Format("{0:MMMM d} - {1:d, yyyy}", item.EventStartDate.ToLocalTime(), displayedEndDate);
			}
			else
			{
                date = string.Format("{0:MMMM d, yyyy}", item.EventStartDate.ToLocalTime());
			}
            
			return String.Format("{0} {1}", date, time);
		}

		public static string FormatRLIEventTime(IRLIEvent item, bool encloseTimeInParenteses)
		{
			string time = string.Empty;

			if (item.EventStartDate != DateTime.MinValue && item.EventStartDate.TimeOfDay.TotalSeconds > 0)
			{
                time = string.Format("{0:h:mm tt}", item.EventStartDate.ToLocalTime()).ToLower();

                if (!String.IsNullOrEmpty(item.EventDuration))
				{
					int minute;
					int hour;
					string[] duration = item.EventDuration.Split(new[] { ':' }, 2);
					if (duration.Count() == 2 && int.TryParse(duration[0], out hour) && int.TryParse(duration[1], out minute))
					{
						time = time + string.Format(" - {0:h:mm tt}", item.EventStartDate.ToLocalTime().AddHours(hour).AddMinutes(minute)).ToLower();
					}
				}

                //if (!string.IsNullOrEmpty(item.EventTimezone))
                //{
                //    time = string.Format("{0} {1}", time, item.EventTimezone);
                //}

                //modified on 8/2/2016
                time = time != "12:00 am" ? time : "";
                if (time != "")
                    time = encloseTimeInParenteses ? string.Format("({0} EST)", time) : time;
                
                return time;
			}
            return time;
		}
	}
}

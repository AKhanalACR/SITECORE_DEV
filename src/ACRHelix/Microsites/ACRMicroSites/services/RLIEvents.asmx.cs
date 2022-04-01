using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using ACR.Library.RLI.Base;
using ACR.Library.RLI.Events;
using ACR.Library.RLI.Interfaces;
using ACR.Library.RLI.Pages;
using ACR.Library.Utils;
using Sitecore.Collections;
using Sitecore.Data;
using Sitecore.Data.Fields;

namespace ACR.services
{
    /// <summary>
    /// Summary description for RLIEvents
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class RLIEvents : System.Web.Services.WebService
    {

        [WebMethod]
        public RLIEventArgs GetMonthEvents(RLIEventArgs args)
        {
            const int maxNumOfEventsPerDay = 2;
            try
            {
                //SafeDictionary<string> filters = BuildFilters(args.EventTypeId, args.EventTagId);


                string tagID = args.EventTagId;
                string typeID = args.EventTypeId;
                DateTime eventDate = NormalizeUtc(args.EventDate);
                string monthEvents = args.MonthEvents;
                var searchIndex = Sitecore.ContentSearch.ContentSearchManager.GetIndex("rliEvents_index");

                DateTime startMonthDate = new DateTime(eventDate.Year, eventDate.Month, 1);
                DateTime endMonthDate = startMonthDate.AddMonths(1);


                List<ACRAccreditationInformaticsLibrary.RLI.NewRLIEvent> rliEvents = ACRAccreditationInformaticsLibrary.RLI.RLIEventSearcher.GetEvents(startMonthDate, endMonthDate, tagID);
                List<ACRAccreditationInformaticsLibrary.RLI.NewRLIEvent> recurring = ACRAccreditationInformaticsLibrary.RLI.RLIEventSearcher.GetRecurringEventsForCalendar(tagID);

                List<RLIEvent> eventList = ACRAccreditationInformaticsLibrary.RLI.RLIEventSearcher.ConvertNewRLIEventsToRLIEvent(rliEvents);

                eventList = ACRAccreditationInformaticsLibrary.RLI.RLIEventSearcher.AddAllDaysForCalendar(eventList, startMonthDate, endMonthDate);


                List<RLIEvent> recurringEvents = ACRAccreditationInformaticsLibrary.RLI.RLIEventSearcher.ConvertNewRLIEventsToRLIEvent(recurring,startMonthDate);
                eventList.AddRange(recurringEvents);




                eventList.Sort((a, b) =>
                {
                    if (a.EventStartDate != b.EventStartDate)
                    {
                        return a.EventStartDate.CompareTo(b.EventStartDate);
                    }
                    return a.EventTitle.CompareTo(b.EventTitle);
                });

                args.MonthEvents = GetCalendarEventsJSON(eventList, maxNumOfEventsPerDay);

                /*
                using (var context = searchIndex.CreateSearchContext())
                {
                   List<ACRAccreditationInformaticsLibrary.RLI.NewRLIEvent> events = context.GetQueryable<ACRAccreditationInformaticsLibrary.RLI.NewRLIEvent>().Where(x => x.EventStartDate >= startMonthDate && x.EventStartDate <= endMonthDate).ToList();

                   List<ACRAccreditationInformaticsLibrary.RLI.NewRLIEvent> onlineCourse = context.GetQueryable<ACRAccreditationInformaticsLibrary.RLI.NewRLIEvent>().Where(x => x.TemplateId.Guid == Guid.Parse("2F8D268E-BA70-4762-AA22-A7F0ACE28DDA")).ToList();


                    //List <IRLIEvent> eList = new List<IRLIEvent>();

                    List <RLIEvent> eventList = new List<RLIEvent>();


                    foreach (var e in onlineCourse)
                    {

                        Sitecore.Data.Items.Item sitem = e.GetItem();
                        RLIEvent ev = new RLIEvent();
                        try
                        {
                            DateTime endDate = DateTime.MaxValue;
                            DateField dfield = (DateField)sitem.Fields["Start Date"];

                            MultilistField mfield = (MultilistField)sitem.Fields["Lecture Days of Week"];

                            List<Sitecore.Data.Items.Item> items = new List<Sitecore.Data.Items.Item>();
                            var listItems = mfield.GetItems();

                            if (listItems.Any())
                            {
                                items.AddRange(listItems);
                            }

                            foreach (var item in items)
                            {
                                LinkField lfield = (LinkField)sitem.Fields["Registration Link"];
                                if (lfield.IsInternal)
                                {
                                    ev.EventUrl = lfield.GetFriendlyUrl();
                                }
                                else
                                {
                                    ev.EventUrl = lfield.Url;
                                }
                                ev.EventUrlTarget = lfield.Target;

                                ev.EventStartDate = dfield.DateTime;
                                ev.EventShortDescription = sitem.Fields["Short Description"].Value;
                                ev.EventShortDescriptionFull = sitem.Fields["Short Description"].Value;
                                ev.EventBody = sitem.Fields["Body"].Value;
                                ev.EventTitle = sitem.Fields["Title"].Value;

                                ev.ItemUrl = ACRAccreditationInformaticsLibrary.ItemHelper.GetExtensionlessUrl(sitem);

                                ev.EventDuration = sitem.Fields["Duration"].Value;

                                if (sitem.Fields["Timezone"] != null)
                                {
                                    ev.EventTimezone = sitem.Fields["Timezone"].Value;
                                }
                                if (sitem.Fields["End Date"] != null)
                                {
                                    dfield = (DateField)sitem.Fields["End Date"];
                                    ev.EventEndDate = dfield.DateTime;
                                }

                            }


                        }
                        catch (Exception ex)
                        {

                        }
                        eventList.Add(ev);
                    }


                    foreach (var e in events)
                    {

                            Sitecore.Data.Items.Item sitem = e.GetItem();
                            RLIEvent ev = new RLIEvent();
                        try
                        {
                            DateTime endDate = DateTime.MaxValue;
                            DateField dfield = (DateField)sitem.Fields["Start Date"];

                            LinkField lfield = (LinkField)sitem.Fields["Registration Link"];
                            if (lfield.IsInternal)
                            {
                                ev.EventUrl = lfield.GetFriendlyUrl();
                            }
                            else
                            {
                                ev.EventUrl = lfield.Url;
                            }
                            ev.EventUrlTarget = lfield.Target;

                            ev.EventStartDate = dfield.DateTime;
                            ev.EventShortDescription = sitem.Fields["Short Description"].Value;
                            ev.EventShortDescriptionFull = sitem.Fields["Short Description"].Value;
                            ev.EventBody = sitem.Fields["Body"].Value;
                            ev.EventTitle = sitem.Fields["Title"].Value;

                            ev.ItemUrl = ACRAccreditationInformaticsLibrary.ItemHelper.GetExtensionlessUrl(sitem);

                            ev.EventDuration = sitem.Fields["Duration"].Value;

                            if (sitem.Fields["Timezone"] != null)
                            {
                                ev.EventTimezone = sitem.Fields["Timezone"].Value;
                            }
                            if (sitem.Fields["End Date"] != null)
                            {
                                dfield = (DateField)sitem.Fields["End Date"];
                                ev.EventEndDate = dfield.DateTime;
                            }


                        }
                        catch (Exception ex) {

                        }
                        eventList.Add(ev);


                        eventList.Sort((a, b) =>
                        {
                            if (a.EventStartDate != b.EventStartDate)
                            {
                                return a.EventStartDate.CompareTo(b.EventStartDate);
                            }
                            return a.EventTitle.CompareTo(b.EventTitle);
                        });

                    }

                    args.MonthEvents = GetCalendarEventsJSON(eventList, maxNumOfEventsPerDay);





                }*/

                /*
                    RLIEventsIndex eventsindex = new RLIEventsIndex();

                args.EventDate = NormalizeUtc(args.EventDate);

                //Get events for the month
                List<IRLIEvent> events =
                    eventsindex.GetEventsForMonthWithFilters(filters, args.EventDate.Year, args.EventDate.Month).Where(i => i!= null)
                        .Select(i => new OnlineCourseItem(i))
                        .Where(i => (i.EventEndDate == DateTime.MinValue))
                        .Select(i => (IRLIEvent) i.EventBase).ToList();

                events.AddRange(eventsindex.GetReccuringEventsForMonthWithFilters(filters, args.EventDate.Year,
                                                                                  args.EventDate.Month)
                                    .SelectMany(rliEvent => eventsindex.GetOccurancesInMonth(rliEvent, args.EventDate)));

                events.AddRange(eventsindex.GetMultidayEventsForMonthWithFilters(filters, args.EventDate.Year,
                                                                                  args.EventDate.Month)
                                    .SelectMany(rliEvent => eventsindex.GetOccurancesInMonth(rliEvent, args.EventDate)));

                events.Sort((a, b) =>
                {
                    if (a.EventStartDate != b.EventStartDate)
                    {
                        return a.EventStartDate.CompareTo(b.EventStartDate);
                    }
                    return a.EventTitle.CompareTo(b.EventTitle);
                });

                //Collect events into the json object format
                args.MonthEvents = GetCalendarEventsJSON(events, maxNumOfEventsPerDay);
                return args; */
            }
            catch (Exception ex)
            {
        //Make sure any web service errors get logged to Elmah before throwing, otherwise Elmah does not log them
        Sitecore.Diagnostics.Log.Error("rli event web service error", ex, this);
                //Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(ex, HttpContext.Current));
                throw;
            }
            //args.MonthEvents = "";
            return args;
        }

        [WebMethod]
        public RLIEventArgs GetDayEvents(RLIEventArgs args)
        {
            try
            {

                //SafeDictionary<string> filters = BuildFilters(args.EventTypeId, args.EventTagId);


                string tagID = args.EventTagId;
                string typeID = args.EventTypeId;
                DateTime eventDate = NormalizeUtc(args.EventDate);
                string monthEvents = args.MonthEvents;
                var searchIndex = Sitecore.ContentSearch.ContentSearchManager.GetIndex("rliEvents_index");

                DateTime startMonthDate = new DateTime(eventDate.Year, eventDate.Month, 1);
                DateTime endMonthDate = startMonthDate.AddMonths(1);


                List<ACRAccreditationInformaticsLibrary.RLI.NewRLIEvent> rliEvents = ACRAccreditationInformaticsLibrary.RLI.RLIEventSearcher.GetEvents(startMonthDate, endMonthDate, tagID);
                List<ACRAccreditationInformaticsLibrary.RLI.NewRLIEvent> recurring = ACRAccreditationInformaticsLibrary.RLI.RLIEventSearcher.GetRecurringEventsForCalendar(tagID);

                List<RLIEvent> eventList = ACRAccreditationInformaticsLibrary.RLI.RLIEventSearcher.ConvertNewRLIEventsToRLIEvent(rliEvents);

                eventList = ACRAccreditationInformaticsLibrary.RLI.RLIEventSearcher.AddAllDaysForCalendar(eventList, startMonthDate, endMonthDate);


                List<RLIEvent> recurringEvents = ACRAccreditationInformaticsLibrary.RLI.RLIEventSearcher.ConvertNewRLIEventsToRLIEvent(recurring, startMonthDate);
                eventList.AddRange(recurringEvents);

                DateTime dayDate = NormalizeUtc(args.EventDate);

                eventList = eventList.Where(x => x.EventStartDate >= dayDate.Date && x.EventStartDate < dayDate.Date.AddDays(1)).ToList();


                eventList.Sort((a, b) =>
                {
                    if (a.EventStartDate != b.EventStartDate)
                    {
                        return a.EventStartDate.CompareTo(b.EventStartDate);
                    }
                    return a.EventTitle.CompareTo(b.EventTitle);
                });



                args.DayEvents = GetRLICalendarDayObjects(eventList);

                return args;
                /*
                SafeDictionary<string> filters = BuildFilters(args.EventTypeId, args.EventTagId);
                RLIEventsIndex eventsindex = new RLIEventsIndex();

                args.EventDate = NormalizeUtc(args.EventDate);

                //Need to write DAY specific method sorted ascending, this is just for quick test
                List<IRLIEvent> events =
                    eventsindex.GetEventsForDayWithFilters(filters, args.EventDate)
                    .Where(i => i != null)
                    .Select(i => new OnlineCourseItem(i))
                    .Where(i => (i.EventEndDate == DateTime.MinValue))
                    .Select(i => (IRLIEvent)i.EventBase).ToList();

                IEnumerable<IRLIEvent> recurringEventsForMonth = eventsindex.GetReccuringEventsForMonthWithFilters(filters, args.EventDate.Year, args.EventDate.Month)
                        .SelectMany(rliEvent => eventsindex.GetOccurancesInMonth(rliEvent, args.EventDate));

                events.AddRange(recurringEventsForMonth.Where(e => e.EventStartDate.Date == args.EventDate.Date));
                events.AddRange(eventsindex.GetMultidayEventsForMonthWithFilters(filters, args.EventDate.Year,
                                                                                  args.EventDate.Month)
                                    .SelectMany(rliEvent => eventsindex.GetOccurancesInMonth(rliEvent, args.EventDate)).Where(e => e.EventStartDate.Date == args.EventDate.Date));

                events.Sort((a, b) =>
                                {
                                    if (a.EventStartDate != b.EventStartDate)
                                    {
                                        return a.EventStartDate.CompareTo(b.EventStartDate);
                                    }
                                    return a.EventTitle.CompareTo(b.EventTitle);
                                });

                args.DayEvents = GetRLICalendarDayObjects(events);

                */
            }
            catch (Exception ex)
            {
        //Make sure any web service errors get logged to Elmah before throwing, otherwise Elmah does not log them
        //Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(ex, HttpContext.Current));
        Sitecore.Diagnostics.Log.Error("rli event web service error", ex, this);
        throw;
            }
        }

        private SafeDictionary<string> BuildFilters(string eventTypeId, string eventTagId)
        {
            var filters = new SafeDictionary<string>();
            ID id;
            //if we were provided an event type then add it to filters
            if (!String.IsNullOrEmpty(eventTypeId))
            {
                id = new ID(eventTypeId);
                filters.Add(EventBaseItem.FieldName_Type, id.ToString());
            }

            //if we were provided an event tag then add it to  filters
            if (!String.IsNullOrEmpty(eventTagId))
            {
                id = new ID(eventTagId);
                filters.Add(EventBaseItem.FieldName_Tags, id.ToString());
            }
            return filters;
        }

        private List<RLICalendarDay> GetRLICalendarDayObjects(IEnumerable<IRLIEvent> events)
        {
            List<RLICalendarDay> calendarDays = new List<RLICalendarDay>();

            if (events == null || events.Count() == 0)
                return calendarDays;

            calendarDays = events.Select(evt => new RLICalendarDay(evt)).ToList();
            return calendarDays;
        }

        /// <summary>
        /// Collects events into the json object format, i.e.: 
        /// {   
        ///     '03-31-2013':'<span>event data</span>',
        ///     '04-01-2013':'<span>event data</span><span>event data</span>',
        ///     '04-10-2013':'<span>event data</span>',
        /// }
        /// </summary>
        /// <param name="events"></param>
        /// <param name="maxPerDay"></param>
        /// <returns></returns>
        private string GetCalendarEventsJSON(IEnumerable<IRLIEvent> events, int maxPerDay)
        {
            if (events.Count() == 0)
                return String.Empty;

            StringBuilder results = new StringBuilder();
            IRLIEvent lastEvt = events.Last();
            DateTime previousDate = DateTime.MinValue.Date;
            string dateString = String.Empty;
            StringBuilder evtString = new StringBuilder();
            string more = "<span class=more>More >></span>";
            int eventsPerDayCount = 0;

            foreach (IRLIEvent evt in events)
            {
                if (evt.EventStartDate.Date != previousDate)
                {
                    //check if this is the first time through - dateString will be empty
                    if (dateString != String.Empty)
                    {
                        //append the events for the previous date
                        results.AppendFormat("'{0}':'{1}{2}',", dateString, evtString, (eventsPerDayCount > maxPerDay) ? more : String.Empty);

                        //clear the events and reset count
                        evtString.Length = 0;
                        eventsPerDayCount = 0;

                    }
                    //reset the previousDate variable to this event's date
                    previousDate = evt.EventStartDate.Date;

                    if (!SitecoreUtils.IsDefaultDate(evt.EventStartDate))
                    {
                        dateString = evt.EventStartDate.ToString("MM-dd-yyyy");
                        evtString.AppendFormat(GetMonthEvent(evt));
                        eventsPerDayCount++;
                    }
                }
                else
                {
                    if (eventsPerDayCount < maxPerDay)
                    {
                        evtString.Append(GetMonthEvent(evt));
                    }
                    eventsPerDayCount++;
                }

                if (evt.Equals(lastEvt) && dateString != String.Empty)
                {
                    results.AppendFormat("'{0}':'{1}{2}',", dateString, evtString, (eventsPerDayCount > maxPerDay) ? more : String.Empty);
                }

            }
            //delete trailing comma
            results.Length = results.Length - 1;
            return results.ToString();
        }

        /// <summary>
        /// Gets HTML for the Day cell of the Calendar month view
        /// </summary>
        /// <param name="evt">the Event</param>
        /// <returns></returns>
        private string GetMonthEvent(IRLIEvent evt)
        {
            string eventFormat = "<span><a href=\"{0}\" onclick=\"var event = arguments[0] || window.event; event.stopPropagation();\">{1}</a></span>";

            //for the Month titles, we need to shorten for the Day cells on the Calendar view
            string title = StringUtil.GetShortenString(evt.EventTitle, 30);
            title = HttpUtility.JavaScriptStringEncode(title);

            return String.Format(eventFormat, evt.EventUrl, title + ">>");
        }

        private DateTime NormalizeUtc(DateTime dttm)
        {
            DateTime convertedDate = TimeZoneInfo.ConvertTimeToUtc(dttm, TimeZoneInfo.Local);
            return convertedDate;
        }
    }
}

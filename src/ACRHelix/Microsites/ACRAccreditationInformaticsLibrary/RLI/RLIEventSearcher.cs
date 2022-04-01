using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACR.Library.RLI.Events;
using ACR.Library.RLI.Interfaces;
using ACR.Library.RLI.Taxonomy;
using Sitecore.Data.Fields;

namespace ACRAccreditationInformaticsLibrary.RLI
{
    public class RLIEventSearcher
    {

        public static List<NewRLIEvent> GetFutureEvents(DateTime startDate)
        {
            List<NewRLIEvent> newRliEvents = new List<NewRLIEvent>();


            var searchIndex = Sitecore.ContentSearch.ContentSearchManager.GetIndex("rliEvents_index");

            using (var context = searchIndex.CreateSearchContext())
            {
                newRliEvents = context.GetQueryable<ACRAccreditationInformaticsLibrary.RLI.NewRLIEvent>().Where(x => x.EventStartDate >= startDate.ToUniversalTime()).ToList();
            }

            return newRliEvents;

        }

        public static List<NewRLIEvent> GetRecurringEventsForCalendar(string tagID)
        {
            List<NewRLIEvent> recurringList = new List<NewRLIEvent>();

            var searchIndex = Sitecore.ContentSearch.ContentSearchManager.GetIndex("rliEvents_index");
            using (var context = searchIndex.CreateSearchContext())
            {
                recurringList = context.GetQueryable<NewRLIEvent>().Where(x => x.TemplateName == "Online Course" && x.Tags.Contains(tagID)).ToList();



            }
            return recurringList;
        }

        public static List<NewRLIEvent> GetEvents(DateTime startDate, DateTime endDate, string tag)
        {
            List<NewRLIEvent> newRliEvents = new List<NewRLIEvent>();


            var searchIndex = Sitecore.ContentSearch.ContentSearchManager.GetIndex("rliEvents_index");

            using (var context = searchIndex.CreateSearchContext())
            {
                newRliEvents = context.GetQueryable<ACRAccreditationInformaticsLibrary.RLI.NewRLIEvent>().Where(x => x.EventStartDate >= startDate.ToUniversalTime() && x.EventStartDate <= endDate.ToUniversalTime() && x.Tags.Contains(tag)).ToList();
            }

            return newRliEvents;

        }





        public static List<RLIEvent> ConvertNewRLIEventsToRLIEvent(List<NewRLIEvent> events)
        {
            List<IRLIEvent> ievents = ConvertNewRLIEventsToIRLIEvent(events);

            List<RLIEvent> revents = new List<RLIEvent>();

            foreach (var i in ievents)
            {
                revents.Add((RLIEvent)i);
            }
            return revents;          
        }

        public static List<RLIEvent> ConvertNewRLIEventsToRLIEvent(List<NewRLIEvent> events,DateTime month)
        {
            List<IRLIEvent> ievents = ConvertNewRLIEventsToIRLIEvent(events);

            List<RLIEvent> revents = new List<RLIEvent>();

            foreach (var i in ievents)
            {
                RLIEvent rEvent = (RLIEvent)i;

                DateTime startDate = i.EventStartDate;
                DateTime endDate = i.EventEndDate;

                DateTime gDate = startDate;
                foreach (var dw in i.LectureDaysOfWeek)
                {
                    while (gDate <= endDate)
                    {
                        if (gDate.DayOfWeek.ToString() == dw.Day.Text)
                        {
                            RLIEvent dEvent = new RLIEvent(rEvent);
                            dEvent.EventStartDate = gDate;
                            if (gDate.Month == month.Month)
                            {
                                revents.Add(dEvent);
                            }
                        }
                        
                        gDate = gDate.AddDays(1);
                    }

                }


                //revents.Add((RLIEvent)i);
            }


            return revents;
        }


        public static List<IRLIEvent> ConvertNewRLIEventsToIRLIEvent(List<NewRLIEvent> events)
        {
            List<IRLIEvent> iRLIEvents = new List<IRLIEvent>();

            foreach (var e in events)
            {
                Sitecore.Data.Items.Item sitem = e.GetItem();
                RLIEvent ev = new RLIEvent();

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


                ev.ItemUrl = ItemHelper.GetExtensionlessUrl(sitem);

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

                MultilistField tagField = (MultilistField)sitem.Fields["Tags"];
                List<Sitecore.Data.Items.Item> items = new List<Sitecore.Data.Items.Item>();
                var listItems = tagField.GetItems();

                if (listItems.Any())
                {
                    items.AddRange(listItems);
                }
                List<string> tags = new List<string>();
                foreach (var i in items)
                {
                    tags.Add(i.Name);
                }
                ev.Tags = tags;


                if (sitem.Fields["Lecture Days of Week"] != null)
                {
                    MultilistField mfield = (MultilistField)sitem.Fields["Lecture Days of Week"];
                    List<Sitecore.Data.Items.Item> dayItems = new List<Sitecore.Data.Items.Item>();
                    var dItems = mfield.GetItems();
                    if (dItems.Any())
                    {
                        dayItems.AddRange(dItems);
                    }
                    ev.LectureDaysOfWeek = new List<DayOfWeekItem>();
                    foreach (var d in dayItems)
                    {
                        ev.LectureDaysOfWeek.Add(new DayOfWeekItem(d));
                    }
                }




                iRLIEvents.Add(ev);
            }

            return iRLIEvents;
        }


        public static List<RLIEvent> AddAllDaysForCalendar(List<RLIEvent> events,DateTime start, DateTime end)
        {

            List<RLIEvent> addedEvents = new List<RLIEvent>();

            foreach (var e in events)
            {
                if (e.EventEndDate.Date != e.EventStartDate.Date && e.EventEndDate != DateTime.MinValue)
                {
                    DateTime sdate = e.EventStartDate;

                    while (sdate <= e.EventEndDate)
                    {
                        if (sdate > start && sdate <= end.Date && sdate != e.EventStartDate)
                        {
                            RLIEvent ev = new RLIEvent(e);
                            ev.EventStartDate = sdate;
                            addedEvents.Add(ev);
                        }
                        sdate = sdate.AddDays(1);
                    }
                }
                
            }
            events.AddRange(addedEvents);
            return events;
        }


    }
}

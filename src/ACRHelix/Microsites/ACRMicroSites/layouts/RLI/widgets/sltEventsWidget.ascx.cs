using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.Reference;
using ACR.controls.Common;
using ACR.controls.RLI;
using ACR.Library.RLI.Base;
using ACR.Library.RLI.Pages;
using ACR.Library.RLI.Taxonomy;
using ACR.Library.RLI.Widgets;
using ACR.Library.Utils;

namespace ACR.layouts.RLI.widgets
{
    public partial class sltEventsWidget : RLIWidgetControl
    {
        public string className;

        protected void Page_Load(object sender, EventArgs e)
        {
            //get our current item as an Upcoming Events item
            UpcomingEventsItem widgetItem = WidgetItem;

            if (widgetItem == null)
            {
                Visible = false;
                return;
            }

            //icon
            if (widgetItem.Icon != null && widgetItem.Icon.MediaItem != null)
            {
                imgIcon.Initialize(widgetItem.Icon.MediaItem);
            }
            else
            {
                imgIcon.Visible = false;
            }

            //header
            ltlTitle.Text = widgetItem.Title.Rendered;

            IEnumerable<EventTypeItem> types =
                widgetItem.EventTypes.ListItems
                    .Where(i => i != null && SitecoreUtils.IsValid(EventTypeItem.TemplateId, i))
                    .Select(i => (EventTypeItem)i);

            IEnumerable<EventTagItem> tags =
                widgetItem.EventTags.ListItems
                    .Where(i => i != null && SitecoreUtils.IsValid(EventTagItem.TemplateId, i))
                    .Select(i => (EventTagItem)i);

            List<string> typesIDs = new List<string>();
            List<string> tagIDS = new List<string>();

            foreach (var t in types)
            {
                typesIDs.Add(t.ID.ToString());
            }
            foreach (var t in tags)
            {
                tagIDS.Add(t.ID.ToString());
            }


            int maxNumOfEvents = widgetItem.NumberofEvents.Integer;
            if (maxNumOfEvents == 0) maxNumOfEvents = 3;

            //RLIEventsIndex eventsindex = new RLIEventsIndex();
            //var events = eventsindex.GetFutureEventsByTypesAndTags(types.ToList(), tags.ToList(), maxNumOfEvents);

            //var events = Sitecore.Context.Database.SelectItems("/sitecore/content/Sites/RLI//*[@@templateid='{207A95C3-1E65-4FF8-AE36-3B8E2383DE5B}' or @@templateid='{1BB91691-F73D-4C17-8ED0-9B28159C1F69}' or @@templateid='{78AE2533-A95E-4891-95F8-D6D433CA63E9}'  or @@templateid='{2F8D268E-BA70-4762-AA22-A7F0ACE28DDA}']");
            /* = new List<ACRAccreditationInformaticsLibrary.RLI.NewRLIEvent>();
            var searchIndex = Sitecore.ContentSearch.ContentSearchManager.GetIndex("rliEvents_index");
            using (var context = searchIndex.CreateSearchContext())
            {
                events = context.GetQueryable<ACRAccreditationInformaticsLibrary.RLI.NewRLIEvent>().ToList();

            }
            */

            List<ACRAccreditationInformaticsLibrary.RLI.NewRLIEvent> events = ACRAccreditationInformaticsLibrary.RLI.RLIEventSearcher.GetFutureEvents(DateTime.Now.Date);
            List<EventBaseItem> matchedEvents = new List<EventBaseItem>();

            foreach (var ev in events)
            {
                var i = ev.GetItem();
                bool et = false;
                bool eta = false;
                bool future = false;

                string etype = i.Fields["Type"].ToString();
                string[] etagsa = i.Fields["Tags"].ToString().Split("|".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);
                if (etagsa.Length > 0)
                {
                    foreach (string s in etagsa)
                    {
                        if (tagIDS.Contains(s))
                        {
                            eta = true;
                        }
                        else
                        {
                            eta = false;
                            break;
                        }
                    }
                }
                else
                {
                    eta = true;
                }
                if (typesIDs.Contains(etype))
                {
                    et = true;
                }

                /*
                DateTime stdate = new DateTime();
                string sdate = i.Fields["Start Date"].ToString();
                if (DateTime.TryParse(sdate, out stdate))
                {

                    if (stdate >= DateTime.Now.Date.AddMonths(-6))
                    {
                        future = true;
                    }
                }*/

                if (et && eta )//&& future)
                {
                    matchedEvents.Add(new EventBaseItem(i));
                }




            }
            matchedEvents = matchedEvents.OrderByDescending(x => x.StartDateTime).Take(4).ToList();

            if (Sitecore.Context.Item.ID == ItemReference.RLI.InnerItem.ID)
            {
                plcEventwidget.Visible = false;
                plcEventFeatureItem.Visible = true;
                className = "HomePage";
            }
            else
            {
                className = "widget";
            }

            rptEvt.DataSource = matchedEvents;
            rptEvt.DataBind();

            rptEvtFeature.DataSource = matchedEvents;
            rptEvtFeature.DataBind();
        }

        protected void rptEvt_DataBound(object sender, RepeaterItemEventArgs e)
        {
            EventBaseItem evt = e.Item.DataItem as EventBaseItem;
            if (evt == null)
            {
                return;
            }

            Literal litStartdate = (Literal)e.Item.FindControl("litStartdate");
            Literal litLocation = (Literal)e.Item.FindControl("litLocation");
            Literal litLectureName = (Literal)e.Item.FindControl("litLecturename");
            Literal litTagName = (Literal)e.Item.FindControl("litTagName");
            var hlEvt = (HyperLink)e.Item.FindControl("hlEvt");

            string url = evt.EventUrl;
            string title = evt.PageBase.Title.Text.Trim();

            if (url != String.Empty && title != String.Empty)
            {
                hlEvt.Text = StringUtil.GetShortenString(title, 30);
                hlEvt.NavigateUrl = url;
                hlEvt.Target = evt.EventUrlTarget;
            }
            else
            {
                hlEvt.Visible = false;
            }

            if (litStartdate != null)
            {
                if (evt.EventStartDate != DateTime.MinValue && (evt.EventEndDate.DayOfYear == evt.EventStartDate.DayOfYear || evt.EventEndDate == DateTime.MinValue))
                {
                    litStartdate.Text = string.Format("{0} {1}<br/>", evt.EventStartDate.ToString("MMMM d, yyyy"), DateTimeUtils.FormatRLIEventTime(evt, true));
                }
                else if (evt.EventStartDate != DateTime.MinValue && (evt.EventEndDate.DayOfYear > evt.EventStartDate.DayOfYear || evt.EventEndDate.Year > evt.EventStartDate.Year))
                {
                    litStartdate.Text = evt.EventStartDate.ToString("MMMM d, yyyy") + " - " + evt.EventEndDate.ToString("MMMM d, yyyy") + "<br/>";
                }
                else
                {
                    litStartdate.Text = "";
                }
            }

            if (litLocation != null)
            {
                if (!string.IsNullOrEmpty(evt.Location))
                {
                    litLocation.Text = evt.Location + "<br/>";
                }
                else
                {
                    litLocation.Text = "";
                }
            }

            if (litLectureName != null)
            {
                if (!string.IsNullOrEmpty(evt.LecturerName.Text))
                {
                    litLectureName.Text = evt.LecturerName.Text + "<br/>";
                }
                else
                {
                    litLectureName.Text = "";
                }
            }

            if (litTagName != null)
            {
                if (!string.IsNullOrEmpty(evt.Type.Item.DisplayName))
                {
                    litTagName.Text = evt.Type.Item.DisplayName + "<br/>";
                }
                else
                {
                    litTagName.Text = "";
                }
            }
        }

        protected void rptEvtFeature_DataBound(object sender, RepeaterItemEventArgs e)
        {
            EventBaseItem evt = e.Item.DataItem as EventBaseItem;
            if (evt == null)
            {
                return;
            }

            Literal litStartdate = (Literal)e.Item.FindControl("litStartdate");
            Literal litLocation = (Literal)e.Item.FindControl("litLocation");
            Literal litLectureName = (Literal)e.Item.FindControl("litLecturename");
            Literal litShortdescription = (Literal)e.Item.FindControl("litShortdescription");
            Literal litTagName = (Literal)e.Item.FindControl("litTagName");
            PlaceHolder plcEventLink = (PlaceHolder)e.Item.FindControl("plcEventLink");

            var itemListedAlready = false;

            if (plcEventLink != null && (!string.IsNullOrEmpty(evt.EventUrl)))
            {
                plcEventLink.Visible = true;
                var hlEvt = (HyperLink)e.Item.FindControl("hlEvt");

                string url = evt.EventUrl;
                string title = evt.PageBase.Title.Text.Trim();

                if (url != String.Empty && title != String.Empty)
                {
                    hlEvt.Text = StringUtil.GetShortenString(title, 30);
                    hlEvt.NavigateUrl = url;
                    hlEvt.Target = evt.EventUrlTarget;
                }
            }

            if (litStartdate != null)
            {
                if (evt.EventStartDate != DateTime.MinValue && (evt.EventEndDate.DayOfYear == evt.EventStartDate.DayOfYear || evt.EventEndDate == DateTime.MinValue))
                {
                    litStartdate.Text = string.Format(" &ndash; {0} {1}", evt.EventStartDate.ToString("MMMM d, yyyy"), DateTimeUtils.FormatRLIEventTime(evt, true));
                    itemListedAlready = true;
                }
                else if (evt.EventStartDate != DateTime.MinValue && (evt.EventEndDate.DayOfYear > evt.EventStartDate.DayOfYear || evt.EventEndDate.Year > evt.EventStartDate.Year))
                {
                    litStartdate.Text = string.Format(" &ndash; {0} - {1}", evt.EventStartDate.ToString("MMMM d, yyyy"), evt.EventEndDate.ToString("MMMM d, yyyy"));
                    itemListedAlready = true;
                }
                else
                {
                    litStartdate.Text = "";
                }
            }

            if (litLocation != null)
            {
                if (!string.IsNullOrEmpty(evt.Location))
                {
                    litLocation.Text = " . " + evt.Location;

                    if (itemListedAlready)
                    {
                        litLocation.Text = " &middot; " + evt.Location;
                    }
                    else
                    {
                        litLocation.Text = " &ndash; " + evt.Location;
                    }

                    itemListedAlready = true;
                }
                else
                {
                    litLocation.Text = "";
                }
            }

            if (litLectureName != null)
            {
                if (!string.IsNullOrEmpty(evt.LecturerName.Text))
                {
                    litLectureName.Text = " . " + evt.LecturerName.Text;

                    if (itemListedAlready)
                    {
                        litLectureName.Text = " &middot; " + evt.LecturerName.Text;
                    }
                    else
                    {
                        litLectureName.Text = " &ndash; " + evt.LecturerName.Text;
                    }
                    itemListedAlready = true;

                }
                else
                {
                    litLectureName.Text = "";
                }
            }

            if (litShortdescription != null)
            {
                if (!string.IsNullOrEmpty(evt.EventShortDescription))
                {
                    litShortdescription.Text = evt.EventShortDescription;
                }
            }

            if (litTagName != null)
            {
                if (!string.IsNullOrEmpty(evt.Type.Item.DisplayName))
                {
                    if (itemListedAlready)
                    {
                        litTagName.Text = " &middot; " + evt.Type.Item.DisplayName;
                    }
                    else
                    {
                        litTagName.Text = " &ndash; " + evt.Type.Item.DisplayName;
                    }

                    itemListedAlready = true;
                }
                else
                {
                    litTagName.Text = "";
                }
            }
        }
    }
}
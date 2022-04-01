using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.RLI.Base;
using ACR.Library.RLI.Interfaces;
using ACR.Library.RLI.Pages;
using ACR.Library.RLI.Taxonomy;
using ACR.Library.Utils;
using ACRAccreditationInformaticsLibrary.RLI;

namespace ACR.layouts.RLI
{
	public partial class sltEventListing : System.Web.UI.UserControl
	{
		List<EventBaseItem> _events = new List<EventBaseItem>();
		protected void Page_Load(object sender, EventArgs e)
		{
			//RLIEventsIndex index = new RLIEventsIndex();
			EventListPageItem item = Sitecore.Context.Item;
			if(item == null)
			{
				return;
			}

			List<EventTagItem> tags = item.TagsIncluded.ListItems.Select(i => (EventTagItem) i).ToList();
            List<EventTypeItem> types = item.EventTypesIncluded.ListItems.Select(i => (EventTypeItem)i).ToList();


            List<NewRLIEvent> events = new List<NewRLIEvent>();
            events = RLIEventSearcher.GetFutureEvents(DateTime.Now.Date);

            foreach (var ev in events)
            {
                _events.Add(new EventBaseItem(ev.GetItem()));
            }

            if (tags.Count > 0)
            {
                List<EventBaseItem> tag_events = new List<EventBaseItem>();

                foreach (EventBaseItem evb in _events)
                {
                    List<EventTagItem> etags = evb.Tags.ListItems.Select(x => (EventTagItem) x).ToList();

                    foreach (var t in tags)
                    {
                        foreach (var et in etags)
                        {
                            if (et.EventTagTitle.Text == t.EventTagTitle.Text)
                            {
                                tag_events.Add(evb);
                            }
                        }
                    }
                }
                tag_events = tag_events.Distinct().ToList();
                _events = tag_events;
            }

            if (types.Count > 0)
            {
                List<EventBaseItem> type_events = new List<EventBaseItem>();

                foreach (EventBaseItem evb in _events)
                {
                  
                }
                type_events = type_events.Distinct().ToList();
                //_events = type_events;
            } 

            //_events = index.GetFutureEventsByTypesAndTags(, tags, 1000).ToList();
			//_events.AddRange(index.GetRecurringEventsByTypesAndTags(item.EventTypesIncluded.ListItems.Select(i => (EventTypeItem) i).ToList(), tags).Select(i => i.EventBase).ToList());




			if(!item.DisplayTags.Checked)
			{
				rptEventsNoTag.DataSource = _events;
				rptEventsNoTag.DataBind();
				noTags.Visible = true;
				return;
			}
				tags =
					_events.Select(i => (EventTagItem) i.Tags.ListItems.FirstOrDefault()).Where(i => i != null).GroupBy(tag => tag.EventTagTitle.Text).Select
						(grp => grp.FirstOrDefault()).ToList();

			List<EventTagItem> tagsSorted = tags;
			if (tags.Count > 1)
			{
				var query = from x in item.TagsIncluded.ListItems.Select(i => (EventTagItem) i).ToList()
				            join y in tags on x.Name equals y.Name
				            select y;

				tagsSorted = query.ToList();
			}


			rptTags.DataSource = tagsSorted;
			rptTags.DataBind();

			List<EventBaseItem> taglessEvents = _events.Where(i => !i.Tags.ListItems.Any()).ToList();
			if(taglessEvents.Any())
			{
				rptEventsNoTag.DataSource = taglessEvents;
				rptEventsNoTag.DataBind();
				noTags.Visible = true;
			}
		}

		protected void rptTags_OnItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			EventTagItem tag = (EventTagItem) e.Item.DataItem;
			List<EventBaseItem> events = _events.Where(i => i.Tags.ListItems.FirstOrDefault() != null && i.Tags.ListItems.FirstOrDefault().ID == tag.ID).ToList();
			if (!events.Any())
			{
				Visible = false;
				return;
			}
			Repeater rptEvents = (Repeater) e.Item.FindControl("rptEvents");
			//events.Sort((i, j) => i.EventStartDate.CompareTo(j.EventStartDate));
			Literal litTag = (Literal) e.Item.FindControl("litTag");
			litTag.Text = tag.EventTagTitle.Text;
			rptEvents.DataSource = events;
			rptEvents.DataBind();

		}

		protected void rptEvents_OnItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			EventBaseItem item = (EventBaseItem) e.Item.DataItem;

			HyperLink hlTitle = (HyperLink) e.Item.FindControl("hlTitle");
			hlTitle.Text = item.EventTitle;
			if(string.IsNullOrEmpty(item.EventUrl))
			{
				hlTitle.Enabled = false;
			}
			hlTitle.NavigateUrl = item.EventUrl;
			hlTitle.Target = item.EventUrlTarget;

			HyperLink hlRegistration = (HyperLink) e.Item.FindControl("hlRegistration");
			if(string.IsNullOrEmpty(item.EventUrl))
			{
				hlRegistration.Enabled = false;
			}
			hlRegistration.NavigateUrl = item.EventUrl;
			hlRegistration.Target = item.EventUrlTarget;

			Literal litLocation = (Literal) e.Item.FindControl("litLocation");
			litLocation.Text = item.Location;

			Literal litDate = (Literal) e.Item.FindControl("litDate");
			litDate.Text = String.Join(", ", item.LectureDaysOfWeek.Select(i=>i.Day.Text + "s").ToArray()) +" "+ DateTimeUtils.FormatRLIEventDateTime(item);

			Literal litTeaser = (Literal)e.Item.FindControl("litTeaser");
			litTeaser.Text = item.EventShortDescriptionFull;
		}
	}
}
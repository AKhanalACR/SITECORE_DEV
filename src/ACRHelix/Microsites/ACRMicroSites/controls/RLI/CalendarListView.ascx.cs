using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using ACR.Library.RLI.Base;
using ACR.Library.RLI.Folders;
using ACR.Library.RLI.Interfaces;
using ACR.Library.RLI.Taxonomy;
using ACR.Library.Utils;
using Sitecore.Data;
using Sitecore.Collections;
using Sitecore.Data.Items;
using ACR.Library.RLI.Events;
using Sitecore.Data.Fields;
using ACRAccreditationInformaticsLibrary.RLI;

namespace ACR.controls.RLI
{
	public partial class CalendarListView : System.Web.UI.UserControl
	{
		//private RLIEventsIndex index;
		private List<IRLIEvent> events = new List<IRLIEvent>();
		private SafeDictionary<string> filters = new SafeDictionary<string>();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack)
			{
				return;
			}

			//populate Tags dropdown
			PopulateEventTagFilterDropDown();

			//retrieve months with meetings and populate the repeater
			RetrieveMonthsAndPopulateRepeater();
		}

		protected void rptMonths_OnItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			DateTime month = (DateTime) e.Item.DataItem;
			Literal litMonth = (Literal) e.Item.FindControl("litMonth");
			Repeater rptEvents = (Repeater) e.Item.FindControl("rptEvents");
			litMonth.Text = string.Format("{0:MMMM yyyy}", month);



            List<IRLIEvent> monthEvents = new List<IRLIEvent>();

            monthEvents = events.Where(x => x.EventStartDate.Month == month.Month).ToList();


            //events = index.GetEventsForMonthWithFilters(filters, month.Year, month.Month).Where(i => i != null && !i.LectureDaysOfWeek.Any()).Cast<IRLIEvent>().ToList();
            //events.AddRange(index.GetCombinedRecurringEventsForMonthWithFilters(filters, month.Year, month.Month));
            monthEvents.Sort((a, b) =>
			            	{
			            		if (a.EventStartDate != b.EventStartDate)
			            		{
			            			return a.EventStartDate.CompareTo(b.EventStartDate);
			            		}
			            		return a.EventTitle.CompareTo(b.EventTitle);
			            	});

			rptEvents.DataSource = monthEvents;
			rptEvents.DataBind();
		}

		protected void rptEvents_OnItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			IRLIEvent eventItem = (IRLIEvent) e.Item.DataItem;
			Literal hlTitle = (Literal) e.Item.FindControl("litTitle");
			Literal litTime = (Literal) e.Item.FindControl("litTime");
			Literal litDetails = (Literal) e.Item.FindControl("litDetails");
			HyperLink hlRegister = (HyperLink) e.Item.FindControl("hlRegister");
			PlaceHolder plcSeparator = (PlaceHolder) e.Item.FindControl("plcSeparator");

			if (eventItem.EventStartDate.Day != eventItem.EventEndDate.Day && eventItem.EventEndDate != DateTime.MinValue)
			{
				hlTitle.Text = string.Format("{0}-{1} &ndash; {2}", eventItem.EventStartDate.Day, eventItem.EventEndDate.Day, eventItem.EventTitle);
			}
			else
			{
				hlTitle.Text = string.Format("{0} &ndash; {1}", eventItem.EventStartDate.Day, eventItem.EventTitle);
			}

			litDetails.Text = StringUtil.GetWholeShortenString(!string.IsNullOrEmpty(eventItem.EventShortDescription)
						? UtilStripHtml.GetRawText(eventItem.EventShortDescription)
						: UtilStripHtml.GetRawText(eventItem.EventBody), 100);

			string day = eventItem.LectureDaysOfWeek != null && eventItem.LectureDaysOfWeek.Any()
			             	? string.Format("{0}, ", eventItem.LectureDaysOfWeek.First().Day.Text)
			             	: string.Empty;

			string time = eventItem.EventStartDate.Minute == 0
			              	? string.Format("{0:h tt}", eventItem.EventStartDate).ToLower()
			              	: string.Format("{0:h:mm tt}", eventItem.EventStartDate).ToLower();

			litTime.Text = string.Format("{0}{1}", day, time);

			if (string.IsNullOrEmpty(litDetails.Text) || string.IsNullOrEmpty(litTime.Text))
			{
				plcSeparator.Visible = false;
			}

			hlRegister.NavigateUrl = eventItem.EventUrl;
			hlRegister.Target = eventItem.EventUrlTarget;
		}

		protected void btnFiltersListView_Click(object sender, EventArgs e)
		{
			RetrieveMonthsAndPopulateRepeater();
			HiddenField hiddenField = (HiddenField) Parent.FindControl("hdnFilterOptionId");
			hiddenField.Value = ddEventTags.SelectedValue;
		}

		private SafeDictionary<string> BuildFilters(string eventTagId)
		{
			var tampFilters = new SafeDictionary<string>();
			ID id;

			//if we were provided an event tag then add it to  filters
			if (!String.IsNullOrEmpty(eventTagId))
			{
				id = new ID(eventTagId);
				tampFilters.Add(EventBaseItem.FieldName_Tags, id.ToString());
			}
			return tampFilters;
		}

		private void PopulateEventTagFilterDropDown()
		{
			ddEventTags.Items.Add(new ListItem("- All Tags -", ""));

			foreach (EventTagItem tag in EventTagFolderItem.GetAllEventTags())
			{
				ddEventTags.Items.Add(new ListItem(tag.EventTagTitle.Text, tag.ID.ToShortID().ToString()));
			}

			if (!string.IsNullOrEmpty(Request.QueryString["f"]))
			{
				ddEventTags.SelectedValue = Request.QueryString["f"];
				HiddenField hiddenField = (HiddenField)Parent.FindControl("hdnFilterOptionId");
				hiddenField.Value = Request.QueryString["f"];
			}
		}

		private void RetrieveMonthsAndPopulateRepeater()
		{
            //index = new RLIEventsIndex();


            List<NewRLIEvent> newEvents = RLIEventSearcher.GetFutureEvents(DateTime.Now.Date);

           List<RLIEvent> rliEvents = RLIEventSearcher.ConvertNewRLIEventsToRLIEvent(newEvents);
      


            /*
            var searchIndex = Sitecore.ContentSearch.ContentSearchManager.GetIndex("rliEvents_index");




            using (var context = searchIndex.CreateSearchContext())
            {
                List<ACRAccreditationInformaticsLibrary.RLI.NewRLIEvent> rlievents = context.GetQueryable<ACRAccreditationInformaticsLibrary.RLI.NewRLIEvent>().Where(x => x.EventStartDate >= DateTime.Now.Date).ToList();
                */

            if (!string.IsNullOrEmpty(ddEventTags.SelectedItem.Text))
            {
                if (ddEventTags.SelectedItem.Text == "- All Tags -")
                {
                    //events = index.GetAllFutureEvents().ToList().Cast<IRLIEvent>().ToList();
                    //events.AddRange(index.GetRecurringFutureEvents().SelectMany(i => index.GetOccurances(i, DateTime.Now, DateTime.MaxValue)).ToList());
                    /*
                    foreach (var e in rlievents)
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
                        catch (Exception ex)
                        {

                        }
                        events.Add(ev);
                        */


                }
                else
                {
                    //filters = BuildFilters(ddEventTags.SelectedValue);
                    //events = index.GetAllFutureEventsWithFilters(filters, 50).ToList().Cast<IRLIEvent>().ToList();
                    //events.AddRange(index.GetRecurringEventsWithFilters(filters).SelectMany(i => index.GetOccurances(i, DateTime.Now, DateTime.MaxValue)).ToList());

                    /*
                            foreach (var e in rlievents)
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


                                    MultilistField tagField = (MultilistField)sitem.Fields["Tags"];
                                    List<Sitecore.Data.Items.Item> items = new List<Sitecore.Data.Items.Item>();
                                    var listItems = tagField.GetItems();

                                    if (listItems.Any())
                                    {
                                        items.AddRange(listItems);
                                    }

                                    foreach (var i in items)
                                    {

                                        if (i.Name.ToLower() == ddEventTags.SelectedItem.Text.ToLower())
                                        {
                                            events.Add(ev);
                                            break;
                                        }


                                    }



                                }
                                catch (Exception ex)
                                {

                                }


        */

                    rliEvents = rliEvents.Where(x => x.Tags.Contains(ddEventTags.SelectedItem.Text)).ToList();
                }
            }

            events = rliEvents.Cast<IRLIEvent>().ToList();
			
			HashSet<DateTime> months = new HashSet<DateTime>();

			foreach (int year in events.Select(i => i.EventStartDate.Year).Distinct())
			{
				foreach (int month in events.Where(i => i.EventStartDate.Year == year).Select(i => i.EventStartDate.Month).Distinct())
				{
					months.Add(new DateTime(year, month, 1));
				}
			}

			rptMonths.DataSource = months.OrderBy(m => m.Date);
			rptMonths.DataBind();

		}
	}
}
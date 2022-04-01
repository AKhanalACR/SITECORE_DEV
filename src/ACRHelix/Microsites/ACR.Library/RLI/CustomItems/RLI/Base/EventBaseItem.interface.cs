using System;
using ACR.Library.RLI.Interfaces;
using ACR.Library.RLI.Pages;
using ACR.Library.RLI.Taxonomy;
using ACR.Library.Utils;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using Sitecore;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using System.Linq;
using StringUtil = ACR.Library.Utils.StringUtil;

namespace ACR.Library.RLI.Base
{
public partial class EventBaseItem :IRLIEvent
{
	public DateTime EventStartDate
	{
		get { return StartDate.DateTime; }
	}

	public string EventShortDescription
	{
		get
		{
			return !String.IsNullOrEmpty(InternalPageBase.ShortDescription.Raw)
			       	? StringUtil.GetShortenString(InternalPageBase.ShortDescription.Text, 100)
			       	: StringUtil.GetWholeShortenString(UtilStripHtml.GetRawText(EventBody), 100);
		}
	}

	public string EventShortDescriptionFull
	{
		get { return InternalPageBase.ShortDescription.Text; }
	}

	public string EventBody
	{
		get { return InternalPageBase.Body.Text; }
	}

	public string EventTitle
	{
		get { return PageBase.Title.Text; }
	}

	public string EventUrl
	{
		get {
			if(InnerItem.TemplateID.ToString() == ExternalMeetingItem.TemplateId)
				{ 
					return LinkUtils.GetLinkFieldUrl(RegistrationLink.Field); 
				}
			return LinkUtils.GetItemUrl(this);}
	}

	public string EventUrlTarget
	{
		get
		{
			if (InnerItem.TemplateID.ToString() == ExternalMeetingItem.TemplateId)
			{
				return "_blank";
			}

			return RegistrationLink.Field.Target;
		}
	}

	public string ItemUrl
	{
		get { return LinkUtils.GetItemUrl(this); }
	}

	public DateTime EventEndDate
	{
		get
		{
			DateTime endDate;
			if (InnerItem.Fields["End Date"] != null)
			{
				return DateUtil.ParseDateTime(InnerItem.Fields["End Date"].Value, new DateTime());
			}
			return new DateTime();
		}
	}

	public string EventDuration
	{
		get
		{
			
			if(InnerItem.Fields["Duration"]!= null)
			{
				return InnerItem.Fields["Duration"].Value;
			}
			return string.Empty;
		}
	}

	public string EventTimezone
	{
		get {
			if (InnerItem.Fields["Timezone"] != null)
			{
				CustomLookupField timezone = new CustomLookupField(InnerItem, InnerItem.Fields["Timezone"]);
				TimezoneItem item = timezone.Item;
				return item != null ? item.TimezoneAbbreviation.Text : string.Empty;
			}
			return string.Empty;
		}
	}

	public List<DayOfWeekItem> LectureDaysOfWeek
	{
		get
		{
			if (InnerItem.Fields["Lecture Days of Week"] != null)
			{
				CustomMultiListField days = new CustomMultiListField(InnerItem, InnerItem.Fields["Lecture Days of Week"]);
				return days.ListItems.Select(i => new DayOfWeekItem(i)).ToList();
			}
			return new List<DayOfWeekItem>();
		}
	}

	public string Location
	{
		get
		{
			if(InnerItem.Fields["Location"] != null)
			{
				return InnerItem.Fields["Location"].Value;
			}
			return "Online";
		}
	}
}
}
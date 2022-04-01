using System;
using System.Linq;
using ACR.Library.RLI.Interfaces;
using ACR.Library.RLI.Taxonomy;
using ACR.Library.Utils;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.RLI.Pages
{
	public partial class OnlineCourseItem : IFeatured, IRLIEvent
	{
		//public string CoveoTitle(string collectionName)
		//{
		//	return EventBase.PageBase.Title.Text;
		//}

		//public string CoveoOverrideUrl(string collectionName)
		//{
		//	return LinkUtils.GetItemUrl(InnerItem);
		//}

		//public string CoveoDescription(string collectionName)
		//{
		//	return EventBase.InternalPageBase.ShortDescription.Text;
		//}

		//public DateTime CoveoDate(string collectionName)
		//{
		//	return InnerItem.Statistics.Updated;
		//}

		//public DateTime CoveoCreatedDate(string collectionName)
		//{
		//	return InnerItem.Publishing.PublishDate;
		//}

		//public string CoveoDisplayDate(string collectionName)
		//{
		//	return CoveoDate(collectionName).ToString(AcrConstants.DateFormats.MonthDayYear);
		//}

		//public Dictionary<string, string> CoveoAdditionalFields(string collectionName)
		//{
		//	Dictionary<string, string> fields = new Dictionary<string, string>();
		//	fields.Add("Body", this.EventBase.InternalPageBase.Body.Text);
		//	return fields;
		//}

		//public bool CoveoExcludeFromIndex(string collectionName)
		//{
		//	//only allow through general search collection crawlers
		//	return collectionName != SearchContext.RLICollectionName && !SearchContext.RLICollectionName.StartsWith(collectionName);
		//}




        #region Implementation of IFeatured
        public string FeaturedTitle
        {
            get { return EventBase.PageBase.Title.Rendered; }
        }

        public string FeaturedSubheader
        {
            get { return String.Empty; }
        }

        public string FeaturedDescription
        {
            get { return EventBase.InternalPageBase.ShortDescription.Rendered; }
        }

        public string FeaturedUrl
        {
            get { return LinkUtils.GetItemUrl(this); }
        }
        #endregion

		public DateTime EventStartDate
		{
			get { return EventBase.StartDate.DateTime; }
		}

		public string EventShortDescription
		{
			get { return EventBase.EventShortDescription; }
		}

		public string EventShortDescriptionFull
		{
			get { return EventBase.EventShortDescriptionFull; }
		}

		public string EventBody
		{
			get { return EventBase.EventBody; }
		}

		public string EventTitle
		{
			get { return EventBase.EventTitle; }
		}

		public string EventUrl
		{
			get { return EventBase.EventUrl; }
		}

		public string EventUrlTarget
		{
			get { return  EventBase.EventUrlTarget; }
		}

		public string ItemUrl
		{
			get { return EventBase.ItemUrl; }
		}

		public DateTime EventEndDate
		{
			get { return EndDate.DateTime; }
		}

		public string EventDuration
		{
			get { return Duration.Text; }
		}

		public string EventTimezone
		{
			get {
				return Timezone.Item != null ? Timezone.Item.Name : "EST";
			}
		}

		public List<DayOfWeekItem> LectureDaysOfWeek
		{
			get { return LectureDaysofWeek.ListItems.Select(i => new DayOfWeekItem(i)).ToList(); }
		}
	}
}
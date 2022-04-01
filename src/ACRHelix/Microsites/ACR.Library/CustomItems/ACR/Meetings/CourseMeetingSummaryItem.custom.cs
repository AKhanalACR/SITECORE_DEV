using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.ACR.Products;
using ACR.Library.Reference;
using Sitecore.Data.Items;

namespace ACR.Library.ACR.Meetings
{
	public partial class CourseMeetingSummaryItem
	{

		public List<ProductStubItem> GetMeetingProducts()
		{
			var products = new List<ProductStubItem>();
			foreach (Item item in Products.ListItems)
			{
				if (item == null)
				{
					continue;
				}
				if (!BaseTemplateReference.IsValidTemplate(item, ProductStubItem.TemplateId))
				{ 
					continue;
				}
				products.Add(item);
			}
			return products;
		}

		public DateTime GetStartDate()
		{
			var products = GetMeetingProducts().Where(p => p.MeetingStartDate != null && p.MeetingStartDate.DateTime >= DateTime.MinValue);
			if (products.Count() < 1)
			{
				return DateTime.MinValue;
			}
			return products.Min(p => p.MeetingStartDate.DateTime);
		}

		public DateTime GetEndDate()
		{
			var products = GetMeetingProducts().Where(p => p.MeetingEndDate != null && p.MeetingEndDate.DateTime > DateTime.MinValue);
			if (products.Count() < 1)
			{
				return DateTime.MinValue;
			}
			return products.Max(p => p.MeetingEndDate.DateTime);
		}

		public DateTime GetNextSessionStartDate()
		{
			var products = GetMeetingProducts().Where(p => p.MeetingStartDate != null && p.MeetingStartDate.DateTime >= DateTime.Now);
			if (products.Count() < 1)
			{
				return DateTime.MinValue;
			}
			return products.Min(p => p.MeetingStartDate.DateTime);
		}

		public DateTime GetNextSessionEndDate()
		{
			var products = GetMeetingProducts().Where(p => p.MeetingStartDate != null
				&& p.MeetingEndDate != null
				&& p.MeetingStartDate.DateTime > DateTime.Now
				&& p.MeetingEndDate.DateTime > DateTime.Now);
			if (products.Count() < 1)
			{
				return DateTime.MinValue;
			}
			return products.Min(p => p.MeetingEndDate.DateTime);
		}

		/// <summary>
		/// This method will determine if it should display a single date, or a range of dates if EndDate and StartDate differ.
		/// </summary>
		/// <returns>returns a string of the Dates.</returns>
		public String GetDatesDisplayValue(bool nextSessionOnly)
		{
			String displayDates = String.Empty;
			DateTime startDate = nextSessionOnly ? GetNextSessionStartDate() : GetStartDate();
			DateTime endDate = nextSessionOnly? GetNextSessionEndDate() : GetEndDate();

			if(startDate.Equals(DateTime.MinValue) && endDate.Equals(DateTime.MinValue))
			{
				
			}
			else if (endDate.Equals(DateTime.MinValue))
			{
				// No End Date, only Display Start Date
				displayDates = startDate.ToString(AcrConstants.DateFormats.MonthDayYear);

			}
			else if(GetStartDate().CompareTo(GetEndDate()) == 0)
			{
				// Start and End Date are the same day
				displayDates = startDate.ToString(AcrConstants.DateFormats.MonthDayYear);
			}
			else
			{
				if(startDate.CompareTo(endDate) > 0)
				{
					//The End date is prior to the Start date. Flip them arround
					DateTime tmpDate = endDate;
					endDate = startDate;
					startDate = tmpDate;
				}

				if(endDate.Year != startDate.Year)
				{
					displayDates = startDate.ToString(AcrConstants.DateFormats.MonthDayYear) + " - " + endDate.ToString(AcrConstants.DateFormats.MonthDayYear);
				}
				else if(endDate.Month != startDate.Month)
				{
					displayDates = startDate.ToString(AcrConstants.DateFormats.MonthDay) + " - " + endDate.ToString(AcrConstants.DateFormats.MonthDayYear);
				}
				else
				{
					displayDates = startDate.ToString(AcrConstants.DateFormats.MonthDay) + "-" + endDate.ToString(AcrConstants.DateFormats.DayYear);
				}
			}

			return displayDates;
		}
	}
}

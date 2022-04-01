using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.RLI.Base;
using ACR.Library.RLI.Events;
using ACR.Library.RLI.Interfaces;
using ACR.Library.RLI.Taxonomy;
using ACR.Library.RLI.Pages;
using ACR.Lucene.Indices;
using ACR.Lucene.Options;
using ACR.Lucene.Parameters;
using ACR.Lucene.Util;
using Sitecore;
using Sitecore.Collections;
using Sitecore.Data.Items;

namespace ACR.Library.RLI.RLILucene.Indices.Events
{
	public class RLIEventsIndex : BaseIndex
	{
		public RLIEventsIndex() : base(RLISiteIndexes.RLIEvents)
		{
		}

		public static DateRangeSearchParam GetDefaultDateParam()
		{
			return GetDateParam(DateTime.Now.AddYears(-1), DateTime.Now);
		}

		private static DateRangeSearchParam GetDateParam(DateTime startDate, DateTime endDate)
		{
			DateRangeSearchParam dateRangeSearchParam = new DateRangeSearchParam();
			dateRangeSearchParam.Ranges = new List<DateRangeSearchParam.DateRangeField>();
			dateRangeSearchParam.Ranges.Add(new DateRangeSearchParam.DateRangeField(EventBaseItem.FieldName_StartDate, startDate, endDate));
			return dateRangeSearchParam;
		}

		public static SearchOptions GetDefaultSort(int maxItems)
		{
			return new SearchOptions(new SortOptions(EventBaseItem.FieldName_StartDate, SortDirection.Reverse), new PaginationOptions(1, maxItems));
		}

		/// <summary>
		/// Returns the latest events ordered by Date.
		/// </summary>
		/// <returns></returns>
		public IList<EventBaseItem> GetLatestEvents(int maxItems)
		{
			return GetEvents(new SafeDictionary<string>(), GetDefaultDateParam(), GetDefaultSort(maxItems));
		}

		#region Month methods

		/// <summary>
		/// Returns the events for the year and month specified, sorted by the Start Date ascending.
		/// </summary>
		/// <param name="year">The year to get Events for.</param>
		/// <param name="month">The month to get Events for.</param>
		/// <returns>The RLI Events for the year specified.</returns>
		public IList<EventBaseItem> GetEventsForMonth(int year, int month)
		{
			return GetEventsForMonthWithFilters(new SafeDictionary<string>(), year, month);
		}

		/// <summary>
		/// Returns the filtered events for the year and month specified, sorted by the Start Date ascending.
		/// </summary>
		/// <param name="filters">Filters</param>
		/// <param name="year">The year to get Events for.</param>
		/// <param name="month">The month to get Events for.</param>
		/// <returns>The RLI Events for the year specified.</returns>
		public IList<EventBaseItem> GetEventsForMonthWithFilters(SafeDictionary<string> filters, int year, int month)
		{
			//get our data param to search on
			DateRangeSearchParam dateParam = GetDateParam(new DateTime(year, month, 1, 0, 0, 0),
			                                              new DateTime(year, month, 1, 23, 59, 59).AddMonths(1).AddDays(-1));

			//create our search options to sort our results by date
			SearchOptions searchOptions = new SearchOptions(new SortOptions(EventBaseItem.FieldName_StartDate, SortDirection.Normal));

			return GetEvents(filters, dateParam, searchOptions);
		}
		
		/// <summary>
		/// Returns the Online Courses for the year and month specified, sorted by the Start Date ascending.
		/// </summary>
		/// <param name="year">The year to get Events for.</param>
		/// <param name="month">The month to get Events for.</param>
		/// <returns>The RLI Events for the month specified.</returns>
		public IList<IRLIEvent> GetReccuringEventsForMonth(int year, int month)
		{
			return GetReccuringEventsForMonthWithFilters(new SafeDictionary<string>(), year, month);
		}

		/// <summary>
		/// Returns the filtered Online Courses for the year and month specified, sorted by the Start Date ascending.
		/// </summary>
		/// <param name="year">The year to get Events for.</param>
		/// <param name="month">The month to get Events for.</param>
		/// <returns>The RLI Events for the month specified.</returns>
		public IList<IRLIEvent> GetReccuringEventsForMonthWithFilters(SafeDictionary<string> filters, int year, int month)
		{
			//get our data param to search on
			DateRangeSearchParam dateParam = GetDateParam(DateTime.MinValue, new DateTime(year, month, 1, 23, 59, 59).AddMonths(1).AddDays(-1));

			//create our search options to sort our results by date
			SearchOptions searchOptions = new SearchOptions(new SortOptions(EventBaseItem.FieldName_StartDate, SortDirection.Normal));

			return GetEvents(filters, dateParam, searchOptions)
				.Cast<IRLIEvent>()
				.Where(i => i != null && i.EventEndDate.Year >= year && i.EventEndDate.Month >= month)
				.Where(i => i.LectureDaysOfWeek.Any())
				.ToList();
		}

		public IList<IRLIEvent> GetCombinedRecurringEventsForMonth(int year, int month)
		{
			return GetCombinedRecurringEventsForMonthWithFilters(new SafeDictionary<string>(), year, month);
		}

		public IList<IRLIEvent> GetCombinedRecurringEventsForMonthWithFilters(SafeDictionary<string> filters, int year, int month)
		{
			IList<IRLIEvent> recurringEvents = GetReccuringEventsForMonthWithFilters(filters, year, month);
			IList<IRLIEvent> combinedRecurringEvents = new List<IRLIEvent>();

			foreach(IRLIEvent recurringEvent in recurringEvents)
			{
				IList<IRLIEvent> eventOccurrences = GetOccurancesInMonth(recurringEvent, new DateTime(year, month, 1));

				if (eventOccurrences != null && eventOccurrences.Count > 0)
				{
					RLIEvent item = new RLIEvent
					                	{
					                		EventStartDate = eventOccurrences.First().EventStartDate,
															EventEndDate = eventOccurrences.Last().EventStartDate,
															EventBody = eventOccurrences.First().EventBody,
															EventTitle = eventOccurrences.First().EventTitle,
															EventUrl = eventOccurrences.First().EventUrl,
															EventUrlTarget = eventOccurrences.First().EventUrlTarget,
															ItemUrl = eventOccurrences.First().ItemUrl,
															EventShortDescription = eventOccurrences.First().EventShortDescription
					                	};

					combinedRecurringEvents.Add(item);
				}
			}

			return combinedRecurringEvents;
		}

		/// <summary>
		/// Returns the Events for the year and month specified, sorted by the Start Date ascending.
		/// </summary>
		/// <param name="year">The year to get Events for.</param>
		/// <param name="month">The month to get Events for.</param>
		/// <returns>The RLI Events for the month specified.</returns>
		public IList<IRLIEvent> GetMultidayEventsForMonth(int year, int month)
		{
			return GetMultidayEventsForMonthWithFilters(new SafeDictionary<string>(), year, month);
		}

		public IList<IRLIEvent> GetMultidayEventsForMonthWithFilters(SafeDictionary<string> filters, int year, int month)
		{
			//get our data param to search on
			DateRangeSearchParam dateParam = GetDateParam(DateTime.MinValue, new DateTime(year, month, 1, 23, 59, 59).AddMonths(1).AddDays(-1));

			//create our search options to sort our results by date
			SearchOptions searchOptions = new SearchOptions(new SortOptions(EventBaseItem.FieldName_StartDate, SortDirection.Normal));

			return GetEvents(filters, dateParam, searchOptions)
				.Cast<IRLIEvent>()
				.Where(i => i != null && i.EventEndDate.Year >= year && i.EventEndDate.Month >= month)
				.Where(i => !i.LectureDaysOfWeek.Any())
				.ToList();
		}

		#endregion

		#region Day methods

		/// <summary>
		/// Returns the events for a specific day with filters applied, sorted by the Start Date ascending.
		/// </summary>
		/// <param name="filters">Filter fields for taxonomy</param>
		/// <param name="dttm">The Date to get Events for.</param>
		/// <returns>The RLI Events for the day specified filtered by the taxonomy filters.</returns>
		public IList<EventBaseItem> GetEventsForDayWithFilters(SafeDictionary<string> filters, DateTime dttm)
		{
			//get our data param to search on
			DateRangeSearchParam dateParam = GetDateParam(new DateTime(dttm.Year, dttm.Month, dttm.Day, 0, 0, 0),
			                                              new DateTime(dttm.Year, dttm.Month, dttm.Day, 23, 59, 59));

			//create our search options to sort our results by date
			SearchOptions searchOptions = new SearchOptions(new SortOptions(EventBaseItem.FieldName_StartDate, SortDirection.Normal));

			return GetEvents(filters, dateParam, searchOptions);
		}

		#endregion

		/// <summary>
		/// Returns the all future events, sorted by the Start Date ascending.
		/// </summary>
		/// <returns>The RLI Events for the day specified filtered by the taxonomy filters.</returns>
		public IList<EventBaseItem> GetAllFutureEvents()
		{
			//get our data param to search on
			DateRangeSearchParam dateParam = GetDateParam(DateTime.Now, DateTime.MaxValue);

			//create our search options to sort our results by date
			SearchOptions searchOptions = new SearchOptions(new SortOptions(EventBaseItem.FieldName_StartDate, SortDirection.Normal));

			return GetEvents(new SafeDictionary<string>(), dateParam, searchOptions);
		}

		/// <summary>
		/// Gets the Online Courses that start in the past, but have occurences in the future.
		/// </summary>
		/// <returns></returns>
		public IList<OnlineCourseItem> GetRecurringFutureEvents(SafeDictionary<string> filters)
		{
			//get our data param to search on
			DateRangeSearchParam dateParam = GetDateParam(DateTime.MinValue, DateTime.MaxValue);

			//create our search options to sort our results by date
			SearchOptions searchOptions = new SearchOptions(new SortOptions(EventBaseItem.FieldName_StartDate, SortDirection.Normal));

			return GetEvents(filters, dateParam, searchOptions)
				.Where(i => i != null)
				.Select(i => new OnlineCourseItem(i))
				.Where(i => i.EndDate.DateTime >= DateTime.Now)
				.ToList();
		}

		public IList<OnlineCourseItem> GetRecurringFutureEvents()
		{
			return GetRecurringFutureEvents(new SafeDictionary<string>());

		}

		/// <summary>
		/// Returns the Online Courses with occurences in the future ordered by Date Ascending that are of the specified meeting types.
		/// </summary>
		/// <param name="eventTypes">The types of Events to return</param>
		/// <param name="eventTags">The types of Events to return</param>
		/// <param name="howMany">Maximum number of items to get</param>
		/// <returns></returns>
		public IList<OnlineCourseItem> GetRecurringEventsByTypesAndTags(List<EventTypeItem> eventTypes, List<EventTagItem> eventTags)
		{
			var filters = new SafeDictionary<string>();

			//if we were provided event types then add them to our filters
			if (eventTypes != null && eventTypes.Any())
			{
				//get the string values for our event types
				string[] eventTypeValues = eventTypes.Select(e => e.ID.ToString()).ToArray();

				//add our event type filters by placing a space between each type.
				//this will give us an OR query for each type passed.
				filters.Add(EventBaseItem.FieldName_Type, string.Join(" ", eventTypeValues));
			}

			//if we were provided event tags then add them to our filters
			if (eventTags != null && eventTags.Any())
			{
				//get the string values for our event types
				string[] eventTagValues = eventTags.Select(e => e.ID.ToString()).ToArray();

				//add our event tag filters by placing a space between each tag.
				//this will give us an OR query for each tag passed.
				filters.Add(EventBaseItem.FieldName_Tags, string.Join(" ", eventTagValues));
			}

			return GetRecurringEventsWithFilters(filters);
		}

		/// <summary>
		/// Returns the all future events with filters applied, sorted by the Start Date ascending.
		/// </summary>
		/// <param name="filters">Filter fields for taxonomy</param>
		/// <param name="maxItems">Maximum number of items to get</param>
		/// <returns>The RLI Events for the day specified filtered by the taxonomy filters.</returns>
		public IList<OnlineCourseItem> GetRecurringEventsWithFilters(SafeDictionary<string> filters)
		{
			return GetRecurringFutureEvents(filters);
		}
		
		/// <summary>
		/// Returns the all future events with filters applied, sorted by the Start Date ascending.
		/// </summary>
		/// <param name="filters">Filter fields for taxonomy</param>
		/// <param name="maxItems">Maximum number of items to get</param>
		/// <returns>The RLI Events for the day specified filtered by the taxonomy filters.</returns>
		public IList<EventBaseItem> GetAllFutureEventsWithFilters(SafeDictionary<string> filters, int maxItems)
		{
			//get our data param to search on
			DateRangeSearchParam dateParam = GetDateParam(DateTime.Now, DateTime.MaxValue);

			//create our search options to sort our results by date
			SearchOptions searchOptions = new SearchOptions(new SortOptions(EventBaseItem.FieldName_StartDate, SortDirection.Normal), new PaginationOptions(1, maxItems));

			return GetEvents(filters, dateParam, searchOptions);
		}

		public IList<EventBaseItem> GetAllMonthEventsWithFilters(SafeDictionary<string> filters, DateTime day, int maxItems)
		{
			//get our data param to search on
			DateRangeSearchParam dateParam = GetDateParam(new DateTime(day.Year, day.Month, 1, 0, 0, 0),
			                                              new DateTime(day.Year, day.Month, 1, 23, 59, 59).AddMonths(12).AddDays(-1));

			//create our search options to sort our results by date
			SearchOptions searchOptions = new SearchOptions(new SortOptions(EventBaseItem.FieldName_StartDate, SortDirection.Normal), new PaginationOptions(1, maxItems));

			return GetEvents(filters, dateParam, searchOptions);
		}

		/// <summary>
		/// Returns the latest meetings ordered by Date Ascending that are of the specified meeting types.
		/// </summary>
		/// <param name="eventTypes">The types of Events to return</param>
		/// <param name="eventTags">The types of Events to return</param>
		/// <param name="howMany">Maximum number of items to get</param>
		/// <returns></returns>
		public IList<EventBaseItem> GetFutureEventsByTypesAndTags(List<EventTypeItem> eventTypes, List<EventTagItem> eventTags, int howMany)
		{
			var filters = new SafeDictionary<string>();

			//if we were provided event types then add them to our filters
			if (eventTypes != null && eventTypes.Any())
			{
				//get the string values for our event types
				string[] eventTypeValues = eventTypes.Select(e => e.ID.ToString()).ToArray();

				//add our event type filters by placing a space between each type.
				//this will give us an OR query for each type passed.
				filters.Add(EventBaseItem.FieldName_Type, string.Join(" ", eventTypeValues));
			}

			//if we were provided event tags then add them to our filters
			if (eventTags != null && eventTags.Any())
			{
				//get the string values for our event types
				string[] eventTagValues = eventTags.Select(e => e.ID.ToString()).ToArray();

				//add our event tag filters by placing a space between each tag.
				//this will give us an OR query for each tag passed.
				filters.Add(EventBaseItem.FieldName_Tags, string.Join(" ", eventTagValues));
			}

			return GetAllFutureEventsWithFilters(filters, howMany);
		}

		/// <summary>
		/// Gets Event Base Items from the events index.
		/// </summary>
		/// <param name="filters"></param>
		/// <param name="dateRange"></param>
		/// <param name="searchOptions"></param>
		/// <returns></returns>
		public IList<EventBaseItem> GetEvents(SafeDictionary<string> filters, DateRangeSearchParam dateRange, SearchOptions searchOptions)
		{
			if (searchOptions == null) searchOptions = new SearchOptions();

			//Setting time on end date to 11:59:59 to include all items from the date, regardless of time.
			DateTime endDate = dateRange.Ranges[0].EndDate;
			DateTime newEndDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59);
			dateRange.Ranges[0].EndDate = newEndDate;

      //Get the wrappers
      List<LightweightItem> lightweightItems = new List<LightweightItem>();// GetLightweightItems(filters, dateRange, searchOptions);

			//Convert items
			List<EventBaseItem> events = new List<EventBaseItem>();
			foreach (LightweightItem lightweightItem in lightweightItems)
			{
				Item item = searchOptions.Database.GetItem(lightweightItem.ItemID);
				events.Add(item);
			}

			return events;
		}

		/// <summary>
		/// Creates a list of events for each occurance of an Online Course within a date range.
		/// </summary>
		/// <param name="course"></param>
		/// <param name="rangeStart"></param>
		/// <param name="rangeEnd"></param>
		/// <returns></returns>
		public IList<IRLIEvent> GetOccurances(IRLIEvent course, DateTime rangeStart, DateTime rangeEnd)
		{
			if (course.EventStartDate > rangeEnd || course.EventEndDate < rangeStart)
			{
				return new List<IRLIEvent>();
			}

			IList<IRLIEvent> occurences = new List<IRLIEvent>();

			TimeSpan time = course.EventStartDate.TimeOfDay;
			DateTime start = rangeStart < course.EventStartDate
			                 	? course.EventStartDate
			                 	: rangeStart.AddHours(time.Hours).AddMinutes(time.Minutes);
			DateTime end = rangeEnd > course.EventEndDate ? course.EventEndDate : rangeEnd;
			end = new DateTime(end.Year, end.Month, end.Day, 23, 59, 59);
			DateTime day = start;
			List<string> days = new List<string>();
			bool allDays = !course.LectureDaysOfWeek.Any();

			foreach (DayOfWeekItem item in course.LectureDaysOfWeek)
			{
				days.Add(item.Day.Text);
			}

			while (day <= end)
			{
				if (allDays || days.IndexOf(day.DayOfWeek.ToString()) >= 0)
				{
					RLIEvent item = new RLIEvent
					                	{
					                		EventStartDate = day,
					                		EventBody = course.EventBody,
					                		EventTitle = course.EventTitle,
					                		EventUrl = course.EventUrl,
					                		EventUrlTarget = course.EventUrlTarget,
					                		ItemUrl = course.ItemUrl,
					                		EventShortDescription = course.EventShortDescription
					                	};

					occurences.Add(item);
				}

				day = day.AddDays(1);
			}

			return occurences;
		}

		/// <summary>
		/// Creates a list of events for each occurance of an Event in a month.
		/// </summary>
		/// <param name="course"></param>
		/// <param name="month"></param>
		/// <returns></returns>
		public IList<IRLIEvent> GetOccurancesInMonth(IRLIEvent course, DateTime month)
		{
			return GetOccurances(course, new DateTime(month.Year, month.Month, 1),
			                     new DateTime(month.Year, month.Month, 1, 23, 59, 59).AddMonths(1).AddDays(-1));
		}
	}
}
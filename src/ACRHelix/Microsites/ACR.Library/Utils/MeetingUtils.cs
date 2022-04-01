using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.CustomItems.ACR.Interface;
using ACR.Library.Search.Indices.Meetings;

namespace ACR.Library.Utils
{
	public static class MeetingUtils
	{
		/// <summary>
		/// Will generate a formatted date range from a start and end date provided.
		/// </summary>
		/// <param name="startDate">The start date.</param>
		/// <param name="endDate">The end date.</param>
		/// <returns>The formatted date range.</returns>
		public static string FormatDateRange(DateTime startDate, DateTime endDate)
		{
			return FormatDateRange(startDate, endDate, null, null, null);
		}

		/// <summary>
		/// Will generate a formatted date range from a start and end date provided.
		/// </summary>
		/// <param name="startDate">The start date.</param>
		/// <param name="endDate">The end date.</param>
		/// <param name="monthDateFormat">The month date format (default MMMM)</param>
		/// <param name="dayDateFormat">The day date format (default dd)</param>
		/// <param name="yearDateFormat">The year date format (default yyyy)</param>
		/// <returns>The formatted date range.</returns>
		public static string FormatDateRange(DateTime startDate, DateTime endDate, string monthDateFormat, string dayDateFormat, string yearDateFormat)
		{
			//if we don't have a start or end date then return empty string
			if (startDate == DateTime.MinValue && endDate == DateTime.MinValue)
			{
				return string.Empty;
			}

			//default our date formats if necessary
			monthDateFormat = string.IsNullOrEmpty(monthDateFormat) ? "MMMM" : monthDateFormat;
			dayDateFormat = string.IsNullOrEmpty(dayDateFormat) ? "d" : dayDateFormat;
			yearDateFormat = string.IsNullOrEmpty(yearDateFormat) ? "yyyy" : yearDateFormat;

			//generate our single date format
			string fullDateFormat = string.Format("{0} {1}, {2}", monthDateFormat, dayDateFormat, yearDateFormat);

			//if we don't have an end date then just return our start date formatted
			if (endDate == DateTime.MinValue)
			{
				return startDate.ToString(fullDateFormat);
			}

			//if we don't have a start date then just return our end date formatted
			if (startDate == DateTime.MinValue)
			{
				return endDate.ToString(fullDateFormat);
			}

			//if our dates don't have the same year, then we should just return each fully formatted
			if (startDate.Year != endDate.Year)
			{
				return string.Format("{0} - {1}", startDate.ToString(fullDateFormat), endDate.ToString(fullDateFormat));
			}

			//we will need a month day format, so generate it
			string monthDayDateFormat = string.Format("{0} {1}", monthDateFormat, dayDateFormat);

			//if our dates don't have the same month, then format with the same year
			if (startDate.Month != endDate.Month)
			{
				return string.Format("{0} - {1}, {2}", startDate.ToString(monthDayDateFormat), endDate.ToString(monthDayDateFormat),
									 startDate.Year);
			}

			//if our dates don't have the same day, then format with the same month and year
			if (startDate.Day != endDate.Day)
			{
				return string.Format("{0} - {1}, {2}", startDate.ToString(monthDayDateFormat), endDate.Day, startDate.Year);
			}

			//both our dates are the same, just return the start date formatted
			return startDate.ToString(fullDateFormat);
		}

		/// <summary>
		/// Will format our venue and location into a single string.
		/// </summary>
		/// <param name="venue">The venue of the meeting.</param>
		/// <param name="location">The location of the meeting.</param>
		/// <returns>The venue and location formatted into a single string.</returns>
		public static string FormatVenueLocation(string venue, string location)
		{
			//initialize our return string with our venue.
			StringBuilder venueLocation = new StringBuilder(venue);

			//if we have a location, then add it
			if (!string.IsNullOrEmpty(location))
			{
				//if we have a venue then add a space first
				if (!string.IsNullOrEmpty(venue))
				{
					venueLocation.Append(", ");
				}

				//add our location
				venueLocation.Append(location);
			}

			//return our string
			return venueLocation.ToString();
		}

		/// <summary>
		/// Will take meeting results from a lucene search and flatten them by removing
		/// any container meetings (summary) and include the meetings that the container references.
		/// </summary>
		/// <param name="luceneResults">The direct lucene results.</param>
		/// <returns>A flattened meeting list.</returns>
		public static IList<IMeeting> GetFinalMeetingsFromLuceneSearch(IList<IMeeting> luceneResults)
		{
			//if we weren't provided any lucene results then just return empty list
			if (luceneResults == null || !luceneResults.Any())
			{
				return new List<IMeeting>(0);
			}

			//go through each potential meeting and add them to a new list
			//of "real" meetings
			List<IMeeting> meetings = new List<IMeeting>();
			foreach (IMeeting meeting in luceneResults)
			{
				//if our meeting is null then just continue, can't use null
				if (meeting == null)
				{
					continue;
				}

				//if we are a valid meeting then just add it to our list and continue
				if (meeting.MeetingType != MeetingType.None)
				{
					meetings.Add(meeting);
					continue;
				}

				//now check to see if we are a meeting container (meeting summary item).
				//we will do this by checking if we have any meeting occurrences.
				//it's important to note that we should only do this if the meeting type is none.
				if (meeting.MeetingOccurrences != null && meeting.MeetingOccurrences.Any())
				{
					//go through each meeting occurrence and add it to our list
					foreach (IMeeting meetingOccurrence in meeting.MeetingOccurrences)
					{
						//if our meeting occurrence is null then just continue
						if (meetingOccurrence == null)
						{
							continue;
						}

						//if we are a valid meeting then add it to our list.
						if (meetingOccurrence.MeetingType != MeetingType.None)
						{
							meetings.Add(meetingOccurrence);
						}
					}
				}
			}

			//return our results
			return meetings;
		}

		/// <summary>
		/// Will get the coveo search parameter for the provided meeting type.
		/// </summary>
		/// <param name="meetingType">The meeting type to get the coveo search param for.</param>
		/// <returns></returns>
		//public static string GetCoveoSearchParam(MeetingType meetingType)
		//{
		//	//return the correct coveo search param
		//	switch (meetingType)
		//	{
		//		case MeetingType.Society:
		//			return MeetingTypeParameter.SocietyMeetingType;
		//		case MeetingType.Chapter:
		//			return MeetingTypeParameter.ChapterMeetingType;
		//		case MeetingType.ACR:
		//			return MeetingTypeParameter.ACRMeetingType;
		//		case MeetingType.EducationCenter:
		//			return MeetingTypeParameter.EducationCenterMeetingType;
		//		case MeetingType.RLI:
		//			return MeetingTypeParameter.RLIMeetingType;
		//		case MeetingType.AIRP:
		//			return MeetingTypeParameter.AIRPMeetingType;
		//		default:
		//			return string.Empty;
		//	}
		//}
	}
}

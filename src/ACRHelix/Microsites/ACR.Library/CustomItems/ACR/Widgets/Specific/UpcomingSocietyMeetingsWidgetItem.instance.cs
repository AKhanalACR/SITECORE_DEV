using System.Linq;
using ACR.Library.CustomItems.ACR.Interface;
using ACR.Library.Search.Indices.Meetings;
using System.Collections.Generic;

namespace ACR.Library.ACR.Widgets.Specific
{
	public partial class UpcomingSocietyMeetingsWidgetItem
	{
		private List<IMeeting> _upcomingSocietyMeetings;

		/// <summary>
		/// Will return if this widget has any content to display.
		/// </summary>
		/// <returns>Flag determining if this widget has content.</returns>
		public bool HasContent()
		{
			if (ReturnSocietyMeetings() != null && ReturnSocietyMeetings().Any())
				return true;

			//else return false
			return false;
		}

		public List<IMeeting> ReturnSocietyMeetings()
		{
			return ReturnSocietyMeetings(6);
		}

		public List<IMeeting> ReturnSocietyMeetings(int number)
		{
			if (_upcomingSocietyMeetings == null)
				FetchSocietyMeetings(number);

			return _upcomingSocietyMeetings;
		}

		private void FetchSocietyMeetings(int number)
		{
			_upcomingSocietyMeetings = new List<IMeeting>();
			using (MeetingsIndex index = new MeetingsIndex())
			{
				_upcomingSocietyMeetings = index.GetUpcomingMeetingsByType(MeetingType.Society, number).ToList();
			}
		}
	}
}
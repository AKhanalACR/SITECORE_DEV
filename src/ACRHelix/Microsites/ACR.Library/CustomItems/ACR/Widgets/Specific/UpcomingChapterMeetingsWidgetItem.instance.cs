using System;
using System.Linq;
using ACR.Library.ACR.Base;
using ACR.Library.ACR.News;
using ACR.Library.CustomItems.ACR.Interface;
using ACR.Library.CustomSitecore.Extensions;
using ACR.Library.Search.Indices.Meetings;
using ACR.Library.Search.Indices.News;
using Sitecore.Collections;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.Widgets.Specific
{
public partial class UpcomingChapterMeetingsWidgetItem 
{
	private List<IMeeting> _upcomingChapterMeetings;


	/// <summary>
	/// Will return if this widget has any content to display.
	/// </summary>
	/// <returns>Flag determining if this widget has content.</returns>
	public bool HasContent()
	{
		if (ReturnChapterMeetings() != null && ReturnChapterMeetings().Any())
			return true;

		//else return false
		return false;
	}

	public List<IMeeting> ReturnChapterMeetings()
	{
		return ReturnChapterMeetings(6);
	}

	public List<IMeeting> ReturnChapterMeetings(int number)
	{
		if (_upcomingChapterMeetings == null)
			FetchChapterMeetings(number);

		return _upcomingChapterMeetings;
	}

	private void FetchChapterMeetings(int number)
	{
		_upcomingChapterMeetings = new List<IMeeting>();
		using (MeetingsIndex index = new MeetingsIndex())
		{
			_upcomingChapterMeetings = index.GetUpcomingMeetingsByType(MeetingType.Chapter, number).ToList();
		}
	}
}
}
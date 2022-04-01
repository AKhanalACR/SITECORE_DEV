using System;
using System.Linq;
using System.Web.UI.WebControls;
using ACR.Library.ACR.Membership;
using ACR.Library.CustomItems.ACR.Interface;
using ACR.Library.CustomSitecore.Extensions;
using ACR.Library.Search.Indices.Meetings;
using ACR.Library.Search.Indices.Membership;
using ACR.Library.UserServices;
using Sitecore.Collections;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.Widgets.Personify
{
public partial class MyUpcomingChapterMeetingsWidgetItem 
{
	private List<IMeeting> _upcomingMeetings;

	/// <summary>
	/// Will return if this widget has any content to display.
	/// </summary>
	/// <returns>Flag determining if this widget has content.</returns>
	public bool HasContent()
	{
		if (UserManager.CurrentUserContext.CurrentUser.IsAnonymous || !UserManager.CurrentUserContext.CurrentUser.IsAuthenticated)
			return false;

		if (ReturnUpcomingMeetings().Any())
			return true;

		//else return false
		return false;
	}

	public List<IMeeting> ReturnUpcomingMeetings()
	{
		if (_upcomingMeetings == null)
			FetchUpcomingMeetings();

		return _upcomingMeetings;
	}

	/// <summary>
	/// Performs the a search for related News Articles based upon a users related Taxonomy profile.
	/// It will first try to use Interests. If no matches will fall back upon Modality, then finally subspecialty.
	/// </summary>
	private void FetchUpcomingMeetings()
	{
		// Calculate the Taxonomy of the current page
		// Set the _relatedCourses that have the same taxonomy

		_upcomingMeetings = new List<IMeeting>();
		IAcrProfile acrProfile = UserManager.CurrentUserContext.CurrentUser.Profile;

		using (ChapterLandingIndex chapterIndex = new ChapterLandingIndex())
		{
			using (MeetingsIndex meetingIndex = new MeetingsIndex())
			{
				foreach (ChapterLandingItem c in chapterIndex.GetChapterLandingItems(acrProfile.PurchaseHistory.ToList()))
				{
					_upcomingMeetings.AddRange(meetingIndex.GetUpcomingChapterMeetings(c.ID, 2));
				}
			}

		}

		if(_upcomingMeetings.Count > 2)
		{
			_upcomingMeetings = _upcomingMeetings.OrderBy(m => m.MeetingStartDate).Take(2).ToList();
		}
	}
}
}
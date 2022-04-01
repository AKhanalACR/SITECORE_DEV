using System;
using System.Linq;
using ACR.Library.ACR.Base;
using ACR.Library.ACR.Taxonomy;
using ACR.Library.CustomItems.ACR.Interface;
using ACR.Library.Search.Indices.Meetings;
using ACR.Library.UserServices;
using ACR.Library.Utils;
using ACR.Lucene.Options;
using Sitecore.Collections;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.Widgets.Personify
{
public partial class RecommendedMeetingsWidgetItem 
{
	private List<IMeeting> _recommendedMeetings;

	/// <summary>
	/// Will return if this widget has any content to display.
	/// </summary>
	/// <returns>Flag determining if this widget has content.</returns>
	public bool HasContent()
	{
		if (ReturnRecommendedMeetings().Any())
			return true;

		return false;
	}


	public List<IMeeting> ReturnRecommendedMeetings()
	{
		if (_recommendedMeetings == null)
			FetchRecommendedMeetings();

		return _recommendedMeetings;
	}

	private void FetchRecommendedMeetings()
	{
		// Calculate the Taxonomy of the current page
		// Set the _relatedCourses that have the same taxonomy

		_recommendedMeetings = new List<IMeeting>();
		IAcrProfile acrProfile = UserManager.CurrentUserContext.CurrentUser.Profile;

		SafeDictionary<string> safeDictionary = new SafeDictionary<string>();

		switch (TaxonomyType.Text.ToLower())
		{
			case "interest":
				if(acrProfile.Interests.Any())
					safeDictionary.Add(TaxonomyContentItem.FieldName_RelatedInterests,
				                   PersonifyTaxonomyItem.ReturnRelatedTaxonomyQuery(acrProfile.Interests));
				break;
			case "modality":
				if (acrProfile.Modalities.Any())
				safeDictionary.Add(TaxonomyContentItem.FieldName_RelatedModalities,
				                   PersonifyTaxonomyItem.ReturnRelatedTaxonomyQuery(acrProfile.Modalities));
				break;
			case "subspecialty":
				if (acrProfile.Subspecialities.Any())
					safeDictionary.Add(TaxonomyContentItem.FieldName_RelatedSubspecialites,
				                   PersonifyTaxonomyItem.ReturnRelatedTaxonomyQuery(acrProfile.Subspecialities));
				break;
		}

		if (!safeDictionary.Any())
			return;

		using (MeetingsIndex index = new MeetingsIndex())
		{
			// Get the upcoming meeting summary items
			var potential = index.GetUpcomingAcrEdcrMeetings(safeDictionary, 20);
			// filter out meetings the user is already in on
			var filtered = potential.Where(m => !acrProfile.MeetingsList.Select(ml => ((CustomItemBase)ml).ID.ToString()).ToList().Contains(((CustomItemBase)m).ID.ToString())).ToList();
			// Get the specific eventsfiltered
			_recommendedMeetings = MeetingUtils.GetFinalMeetingsFromLuceneSearch(filtered).OrderBy(m => m.MeetingStartDate).Where(m => m.MeetingStartDate >= DateTime.Now).ToList();
			
			// return the first 2.
			if (_recommendedMeetings.Count > 2)
				_recommendedMeetings = _recommendedMeetings.Take(2).ToList();

		}

	}
}
}
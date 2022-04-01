using System;
using System.Collections.Generic;
using ACR.Library.Common.Interfaces;
using ACR.Library.Common.Interfaces.Factory;
using ACR.Library.Search.Indices.Meetings;
using CustomItemGenerator.Fields.SimpleTypes;
using Sitecore.Data.Items;

namespace ACR.Library.CustomItems.ACR.Interface
{
	[FactoryInterface]
	public interface IMeeting
	{
		/// <summary>
		/// The type of meeting.
		/// </summary>
		MeetingType MeetingType { get; }

		/// <summary>
		/// This meetings title.
		/// </summary>
		string MeetingTitle { get; }

		/// <summary>
		/// This meetings subtitle.
		/// </summary>
		string MeetingSubtitle { get; }

		/// <summary>
		/// This meetings start date.
		/// DateTime.MinValue if there is no start date.
		/// </summary>
		DateTime MeetingStartDate { get; }

		/// <summary>
		/// This meetings end date.
		/// DateTime.MinValue if there is no end date.
		/// </summary>
		DateTime MeetingEndDate { get; }

		/// <summary>
		/// This meetings location.
		/// </summary>
		string MeetingLocation { get; }

		/// <summary>
		/// This meetings venue.
		/// </summary>
		string MeetingVenue { get; }

		/// <summary>
		/// This meetings description.
		/// </summary>
		string MeetingDescription { get; }

		/// <summary>
		/// This meetings short description.
		/// </summary>
		string MeetingShortDescription { get; }

		/// <summary>
		/// This meetings objectives.
		/// </summary>
		string MeetingObjectives { get; }

		/// <summary>
		/// This meetings testimonials.
		/// </summary>
		string MeetingTestimonials { get; }

		/// <summary>
		/// This meetings image.
		/// </summary>
		string MeetingImageUrl { get; }

		/// <summary>
		/// This meetings summary url.  This should point to a page
		/// containing more details about the meeting.
		/// </summary>
		string MeetingSummaryUrl { get; }

		/// <summary>
		/// This meetings register url.  This should point to a page
		/// allowing the user to register for the meeting.
		/// </summary>
		string MeetingRegisterUrl { get; }

		/// <summary>
		/// Additional information for registration.
		/// </summary>
		string MeetingRegisterInfo { get; }

		/// <summary>
		/// Additional Information for hotel info.
		/// </summary>
		string MeetingAdditionalInfo { get; }

		/// <summary>
		/// Any additional website that this meeting will link to.
		/// </summary>
		string MeetingAdditionalWebsiteUrl { get; }

		/// <summary>
		/// This meetings cme credit.
		/// -1 if this meeting doesn't qualify for cme credit.
		/// </summary>
		int MeetingCmeCredit { get; }

		/// <summary>
		/// Any documents containing more details about this meeting.
		/// </summary>
		List<IListItem> MeetingDocuments { get; }

		/// <summary>
		/// The different occurrences for this meeting.
		/// This represents different meetings that relate to this meeting.
		/// For example, this meeting may contain multiple times in which someone
		/// can attend.  This will allow us to link these meetings together.
		/// </summary>
		List<IMeeting> MeetingOccurrences { get; }

		/// <summary>
		/// Hotel information for this meeting.
		/// </summary>
		List<IListItem> MeetingAccommodations { get; }

		/// <summary>
		/// Any contacts for this meeting.
		/// </summary>
		List<IAcrPersonnel> MeetingContacts { get; }

		/// <summary>
		/// Gets Associated Item.
		/// </summary>
		List<Item> MeetingAssociatedItems { get; }
	}
}
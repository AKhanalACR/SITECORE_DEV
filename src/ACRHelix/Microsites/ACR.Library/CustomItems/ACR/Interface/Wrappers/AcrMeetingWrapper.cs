using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.Search.Indices.Meetings;
using ACR.Library.Common.Interfaces;
using Sitecore.Data.Items;


namespace ACR.Library.CustomItems.ACR.Interface.Wrappers
{
    public class AcrMeetingWrapper : IMeeting 
	{
  
        /// <summary>
        /// The type of meeting.
        /// </summary>
      public  MeetingType MeetingType {get; set; }

        /// <summary>
        /// This meetings title.
        /// </summary>
      public string MeetingTitle { get; set; }

        /// <summary>
        /// This meetings subtitle.
        /// </summary>
      public string MeetingSubtitle { get; set; }

        /// <summary>
        /// This meetings start date.
        /// DateTime.MinValue if there is no start date.
        /// </summary>
      public DateTime MeetingStartDate { get; set; }

        /// <summary>
        /// This meetings end date.
        /// DateTime.MinValue if there is no end date.
        /// </summary>
      public DateTime MeetingEndDate { get; set; }

        /// <summary>
        /// This meetings location.
        /// </summary>
      public string MeetingLocation { get; set; }

        /// <summary>
        /// This meetings venue.
        /// </summary>
      public string MeetingVenue { get; set; }

        /// <summary>
        /// This meetings description.
        /// </summary>
      public string MeetingDescription { get; set; }

        /// <summary>
        /// This meetings short description.
        /// </summary>
      public string MeetingShortDescription { get; set; }

        /// <summary>
        /// This meetings objectives.
        /// </summary>
      public string MeetingObjectives { get; set; }

        /// <summary>
        /// This meetings testimonials.
        /// </summary>
      public string MeetingTestimonials { get; set; }

        /// <summary>
        /// This meetings image.
        /// </summary>
      public string MeetingImageUrl { get; set; }

        /// <summary>
        /// This meetings summary url.  This should point to a page
        /// containing more details about the meeting.
        /// </summary>
      public string MeetingSummaryUrl { get; set; }

        /// <summary>
        /// This meetings register url.  This should point to a page
        /// allowing the user to register for the meeting.
        /// </summary>
      public string MeetingRegisterUrl { get; set; }

        /// <summary>
        /// Additional information for registration.
        /// </summary>
      public string MeetingRegisterInfo { get; set; }

        /// <summary>
        /// Additional Information for hotel info.
        /// </summary>
      public string MeetingAdditionalInfo { get; set; }

        /// <summary>
        /// Any additional website that this meeting will link to.
        /// </summary>
      public string MeetingAdditionalWebsiteUrl { get; set; }

        /// <summary>
        /// This meetings cme credit.
        /// -1 if this meeting doesn't qualify for cme credit.
        /// </summary>
      public int MeetingCmeCredit { get; set; }

        /// <summary>
        /// Any documents containing more details about this meeting.
        /// </summary>
      public List<IListItem> MeetingDocuments { get; set; }

        /// <summary>
        /// The different occurrences for this meeting.
        /// This represents different meetings that relate to this meeting.
        /// For example, this meeting may contain multiple times in which someone
        /// can attend.  This will allow us to link these meetings together.
        /// </summary>
      public List<IMeeting> MeetingOccurrences { get; set; }

        /// <summary>
        /// Hotel information for this meeting.
        /// </summary>
      public List<IListItem> MeetingAccommodations { get; set; }

        /// <summary>
        /// Any contacts for this meeting.
        /// </summary>
      public List<IAcrPersonnel> MeetingContacts { get; set; }

        /// <summary>
        /// Gets Associated Item.
        /// </summary>
      public List<Item> MeetingAssociatedItems { get; set; }
    }
}

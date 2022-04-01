using System;
using System.Collections.Generic;
using ACR.Library.Common.Interfaces;
using ACR.Library.CustomItems.ACR.Interface;
using ACR.Library.Search.Indices.Meetings;
using ACR.Library.Utils;
using Sitecore.Data.Items;
using Sitecore.Links;

namespace ACR.Library.ACR.Meetings
{
    //public partial class MeetingsEventsLandingPageItem : IMeeting
    //{
    //    #region IMeeting

    //    public MeetingType MeetingType
    //    {
    //        get
    //        {
    //            //featured meetings are not necessarily a specific type
    //            return MeetingType.None;
    //        }
    //    }

    //    string IMeeting.MeetingTitle
    //    {
    //        get
    //        {
    //            //if we don't have a meeting title then return an empty string
    //            if (MeetingTitle == null)
    //            {
    //                return string.Empty;
    //            }

    //            //return our meeting title
    //            return MeetingTitle.Text;
    //        }
    //    }

    //    public string MeetingSubtitle
    //    {
    //        get
    //        {
    //            //featured meetings don't have a subtitle
    //            return string.Empty;
    //        }
    //    }

    //    DateTime IMeeting.MeetingStartDate
    //    {
    //        get
    //        {
    //            //if we don't have a start date then return min value
    //            if (MeetingStartDate == null)
    //            {
    //                return DateTime.MinValue;
    //            }

    //            //return our start date
    //            return MeetingStartDate.DateTime;
    //        }
    //    }

    //    DateTime IMeeting.MeetingEndDate
    //    {
    //        get
    //        {
    //            //if we don't have a meeting end date then return min value
    //            if (MeetingEndDate == null)
    //            {
    //                return DateTime.MinValue;
    //            }

    //            //return our end date
    //            return MeetingEndDate.DateTime;
    //        }
    //    }

    //    string IMeeting.MeetingLocation
    //    {
    //        get
    //        {
    //            //if we don't have a meeting location then return empty string
    //            if (MeetingLocation == null)
    //            {
    //                return string.Empty;
    //            }

    //            //return our meeting location
    //            return MeetingLocation.Text;
    //        }
    //    }

    //    string IMeeting.MeetingVenue
    //    {
    //        get
    //        {
    //            //if we don't have a meeting venue then return empty string
    //            if (MeetingVenue == null)
    //            {
    //                return string.Empty;
    //            }

    //            //return our meeting venue
    //            return MeetingVenue.Text;
    //        }
    //    }

    //    string IMeeting.MeetingDescription
    //    {
    //        get
    //        {
    //            //if we don't have a meeting description then return empty string
    //            if (MeetingDescription == null)
    //            {
    //                return string.Empty;
    //            }

    //            //return our meeting description
    //            return MeetingDescription.Text;
    //        }
    //    }

    //    public string MeetingShortDescription
    //    {
    //        get
    //        {
    //            //our featured meeting currently doesn't have a short description
    //            return string.Empty;
    //        }
    //    }

    //    public string MeetingObjectives
    //    {
    //        get
    //        {
    //            //our featured meeting currently doesn't have objectives
    //            return string.Empty;
    //        }
    //    }

    //    public string MeetingTestimonials
    //    {
    //        get
    //        {
    //            //our featured meeting currently doesn't have testimonials
    //            return string.Empty;
    //        }
    //    }

    //    public string MeetingImageUrl
    //    {
    //        get
    //        {
    //            //if we dont' have an image then return an empty string
    //            if (MeetingImage == null)
    //            {
    //                return string.Empty;
    //            }

    //            //return our meeting image url scaled
    //            return ImageUtil.GetScaledImageUrl(MeetingImage, 166, 134);
    //        }
    //    }

    //    public string MeetingSummaryUrl
    //    {
    //        get
    //        {
    //            //if we don't have a meeting link then return empty string
    //            if (MeetingLink == null)
    //            {
    //                return string.Empty;
    //            }

    //            //return our meeting link
    //            return MeetingLink.Url;
    //        }
    //    }

    //    public string MeetingRegisterUrl
    //    {
    //        get
    //        {
    //            //our featured meeting currently doesn't have a register url.
    //            return string.Empty;
    //        }
    //    }

    //    public string MeetingRegisterInfo
    //    {
    //        get { return string.Empty; }
    //    }

    //    public string MeetingAdditionalInfo
    //    {
    //        get { return string.Empty; }
    //    }

    //    public string MeetingAdditionalWebsiteUrl
    //    {
    //        get
    //        {
    //            //our featured meeting currently doesn't have an additional link
    //            return string.Empty;
    //        }
    //    }

    //    public int MeetingCmeCredit
    //    {
    //        get
    //        {
    //            //if we don't have a cme credit field then return -1
    //            if (MeetingCMECredit == null)
    //            {
    //                return -1;
    //            }

    //            //get our cme credit
    //            int cmeCredit;
    //            if (!int.TryParse(MeetingCMECredit.Text, out cmeCredit))
    //            {
    //                cmeCredit = -1;
    //            }

    //            //return our cme credit
    //            return cmeCredit;
    //        }
    //    }

    //    public List<IListItem> MeetingDocuments
    //    {
    //        get
    //        {
    //            //our featured meeting currently doesn't have any documents
    //            return new List<IListItem>(0);
    //        }
    //    }

    //    public List<IMeeting> MeetingOccurrences
    //    {
    //        get
    //        {
    //            //a featured meeting is the only occurrence, so return empty list.
    //            return new List<IMeeting>(0);
    //        }
    //    }

    //    public List<IListItem> MeetingAccommodations
    //    {
    //        get
    //        {
    //            //out featured meeting currently doesn't have any accommodations
    //            return new List<IListItem>(0);
    //        }
    //    }

    //    public List<IAcrPersonnel> MeetingContacts
    //    {
    //        get
    //        {
    //            //our featured meeting currently doesn't have any contacts
    //            return new List<IAcrPersonnel>(0);
    //        }
    //    }

    //    public List<Item> MeetingAssociatedItems
    //    {
    //        get { throw new NotImplementedException(); } //TODO: IMPLEMENT IF APPLICABLE
    //    }

    //    #endregion
    //}
}
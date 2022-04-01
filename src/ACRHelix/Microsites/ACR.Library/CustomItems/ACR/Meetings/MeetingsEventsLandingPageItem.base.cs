using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.CustomSitecore.CustomFields;
using ACR.Library.ACR.Base;
using ACR.Library.CustomItems.ACR.Interface;
using ACR.Library.CustomItems.ACR.Interface.Wrappers;

namespace ACR.Library.ACR.Meetings
{
    public partial class MeetingsEventsLandingPageItem : CustomItem
    {

        public static readonly string TemplateId = "{D27B211C-677A-443E-919A-8C5251F544E3}";

        #region Inherited Base Templates

        private readonly BasePageItem _BasePageItem;
        public BasePageItem BasePage { get { return _BasePageItem; } }
        private readonly WidgetPageItem _WidgetPageItem;
        public WidgetPageItem WidgetPage { get { return _WidgetPageItem; } }
        private readonly TaxonomyContentItem _TaxonomyContentItem;
        public TaxonomyContentItem TaxonomyContent { get { return _TaxonomyContentItem; } }

        #endregion

        #region Boilerplate CustomItem Code

        public MeetingsEventsLandingPageItem(Item innerItem)
            : base(innerItem)
        {
            _BasePageItem = new BasePageItem(innerItem);
            _WidgetPageItem = new WidgetPageItem(innerItem);
            _TaxonomyContentItem = new TaxonomyContentItem(innerItem);

        }

        public static implicit operator MeetingsEventsLandingPageItem(Item innerItem)
        {
            return innerItem != null ? new MeetingsEventsLandingPageItem(innerItem) : null;
        }

        public static implicit operator Item(MeetingsEventsLandingPageItem customItem)
        {
            return customItem != null ? customItem.InnerItem : null;
        }

        #endregion //Boilerplate CustomItem Code


        #region Field Instance Methods

        #region Meeting1 Fields
        public CustomTextField Meeting1Title
        {
            get
            {
                return new CustomTextField(InnerItem, InnerItem.Fields["Meeting1 Title"]);
            }
        }

        public static string FieldName_Meeting1Title
        {
            get
            {
                return "Meeting1 Title";
            }
        }


        public CustomGeneralLinkField Meeting1Link
        {
            get
            {
                return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Meeting1 Link"]);
            }
        }

        public static string FieldName_Meeting1Link
        {
            get
            {
                return "Meeting1 Link";
            }
        }


        public CustomImageField Meeting1Image
        {
            get
            {
                return new CustomImageField(InnerItem, InnerItem.Fields["Meeting1 Image"]);
            }
        }

        public static string FieldName_Meeting1Image
        {
            get
            {
                return "Meeting1 Image";
            }
        }


        public CustomDateField Meeting1StartDate
        {
            get
            {
                return new CustomDateField(InnerItem, InnerItem.Fields["Meeting1 Start Date"]);
            }
        }

        public static string FieldName_Meeting1StartDate
        {
            get
            {
                return "Meeting1 Start Date";
            }
        }


        public CustomDateField Meeting1EndDate
        {
            get
            {
                return new CustomDateField(InnerItem, InnerItem.Fields["Meeting1 End Date"]);
            }
        }

        public static string FieldName_Meeting1EndDate
        {
            get
            {
                return "Meeting1 End Date";
            }
        }


        public CustomTextField Meeting1Location
        {
            get
            {
                return new CustomTextField(InnerItem, InnerItem.Fields["Meeting1 Location"]);
            }
        }

        public static string FieldName_Meeting1Location
        {
            get
            {
                return "Meeting1 Location";
            }
        }


        public CustomTextField Meeting1Venue
        {
            get
            {
                return new CustomTextField(InnerItem, InnerItem.Fields["Meeting1 Venue"]);
            }
        }

        public static string FieldName_Meeting1Venue
        {
            get
            {
                return "Meeting1 Venue";
            }
        }


        public CustomTextField Meeting1Description
        {
            get
            {
                return new CustomTextField(InnerItem, InnerItem.Fields["Meeting1 Description"]);
            }
        }

        public static string FieldName_Meeting1Description
        {
            get
            {
                return "Meeting1 Description";
            }
        }


        public CustomTextField Meeting1CMECredit
        {
            get
            {
                return new CustomTextField(InnerItem, InnerItem.Fields["Meeting1 CME Credit"]);
            }
        }

        public static string FieldName_Meeting1CMECredit
        {
            get
            {
                return "Meeting1 CME Credit";
            }
        }

        #endregion
        #region Meeting2 Fields
        public CustomTextField Meeting2Title
        {
            get
            {
                return new CustomTextField(InnerItem, InnerItem.Fields["Meeting2 Title"]);
            }
        }

        public static string FieldName_Meeting2Title
        {
            get
            {
                return "Meeting2 Title";
            }
        }


        public CustomGeneralLinkField Meeting2Link
        {
            get
            {
                return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Meeting2 Link"]);
            }
        }

        public static string FieldName_Meeting2Link
        {
            get
            {
                return "Meeting2 Link";
            }
        }


        public CustomImageField Meeting2Image
        {
            get
            {
                return new CustomImageField(InnerItem, InnerItem.Fields["Meeting2 Image"]);
            }
        }

        public static string FieldName_Meeting2Image
        {
            get
            {
                return "Meeting2 Image";
            }
        }


        public CustomDateField Meeting2StartDate
        {
            get
            {
                return new CustomDateField(InnerItem, InnerItem.Fields["Meeting2 Start Date"]);
            }
        }

        public static string FieldName_Meeting2StartDate
        {
            get
            {
                return "Meeting2 Start Date";
            }
        }


        public CustomDateField Meeting2EndDate
        {
            get
            {
                return new CustomDateField(InnerItem, InnerItem.Fields["Meeting2 End Date"]);
            }
        }

        public static string FieldName_Meeting2EndDate
        {
            get
            {
                return "Meeting2 End Date";
            }
        }


        public CustomTextField Meeting2Location
        {
            get
            {
                return new CustomTextField(InnerItem, InnerItem.Fields["Meeting2 Location"]);
            }
        }

        public static string FieldName_Meeting2Location
        {
            get
            {
                return "Meeting2 Location";
            }
        }


        public CustomTextField Meeting2Venue
        {
            get
            {
                return new CustomTextField(InnerItem, InnerItem.Fields["Meeting2 Venue"]);
            }
        }

        public static string FieldName_Meeting2Venue
        {
            get
            {
                return "Meeting2 Venue";
            }
        }


        public CustomTextField Meeting2Description
        {
            get
            {
                return new CustomTextField(InnerItem, InnerItem.Fields["Meeting2 Description"]);
            }
        }

        public static string FieldName_Meeting2Description
        {
            get
            {
                return "Meeting2 Description";
            }
        }


        public CustomTextField Meeting2CMECredit
        {
            get
            {
                return new CustomTextField(InnerItem, InnerItem.Fields["Meeting2 CME Credit"]);
            }
        }

        public static string FieldName_Meeting2CMECredit
        {
            get
            {
                return "Meeting2 CME Credit";
            }
        }

        #endregion
        #region Meeting3 Fields
        public CustomTextField Meeting3Title
        {
            get
            {
                return new CustomTextField(InnerItem, InnerItem.Fields["Meeting3 Title"]);
            }
        }

        public static string FieldName_Meeting3Title
        {
            get
            {
                return "Meeting3 Title";
            }
        }


        public CustomGeneralLinkField Meeting3Link
        {
            get
            {
                return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Meeting3 Link"]);
            }
        }

        public static string FieldName_Meeting3Link
        {
            get
            {
                return "Meeting3 Link";
            }
        }


        public CustomImageField Meeting3Image
        {
            get
            {
                return new CustomImageField(InnerItem, InnerItem.Fields["Meeting3 Image"]);
            }
        }

        public static string FieldName_Meeting3Image
        {
            get
            {
                return "Meeting3 Image";
            }
        }


        public CustomDateField Meeting3StartDate
        {
            get
            {
                return new CustomDateField(InnerItem, InnerItem.Fields["Meeting3 Start Date"]);
            }
        }

        public static string FieldName_Meeting3StartDate
        {
            get
            {
                return "Meeting3 Start Date";
            }
        }


        public CustomDateField Meeting3EndDate
        {
            get
            {
                return new CustomDateField(InnerItem, InnerItem.Fields["Meeting3 End Date"]);
            }
        }

        public static string FieldName_Meeting3EndDate
        {
            get
            {
                return "Meeting3 End Date";
            }
        }


        public CustomTextField Meeting3Location
        {
            get
            {
                return new CustomTextField(InnerItem, InnerItem.Fields["Meeting3 Location"]);
            }
        }

        public static string FieldName_Meeting3Location
        {
            get
            {
                return "Meeting3 Location";
            }
        }


        public CustomTextField Meeting3Venue
        {
            get
            {
                return new CustomTextField(InnerItem, InnerItem.Fields["Meeting3 Venue"]);
            }
        }

        public static string FieldName_Meeting3Venue
        {
            get
            {
                return "Meeting3 Venue";
            }
        }


        public CustomTextField Meeting3Description
        {
            get
            {
                return new CustomTextField(InnerItem, InnerItem.Fields["Meeting3 Description"]);
            }
        }

        public static string FieldName_Meeting3Description
        {
            get
            {
                return "Meeting3 Description";
            }
        }


        public CustomTextField Meeting3CMECredit
        {
            get
            {
                return new CustomTextField(InnerItem, InnerItem.Fields["Meeting3 CME Credit"]);
            }
        }

        public static string FieldName_Meeting3CMECredit
        {
            get
            {
                return "Meeting3 CME Credit";
            }
        }

        #endregion

        public  List<IMeeting> GetFeaturedMeetings
        {
           get
            {
                return GetMeetings();
			}
        }
        private  List<IMeeting> GetMeetings()
          {
              //we will be returning our hotel information.
              List<IMeeting> featuredMeetings = new List<IMeeting>();

              #region Meeting 1
              if (Meeting1Title != null && !string.IsNullOrEmpty(Meeting1Title.Text))
              {
                  //create our hotel
                  AcrMeetingWrapper meeting = new AcrMeetingWrapper();
                  meeting.MeetingTitle = Meeting1Title.Text;
                  if (Meeting1Link != null)
                  {
                      meeting.MeetingSummaryUrl = Meeting1Link.Url;
                  }
									if (Meeting1Image != null && Meeting1Image.MediaItem != null)
                  {
                      meeting.MeetingImageUrl = Sitecore.Resources.Media.MediaManager.GetMediaUrl(Meeting1Image.MediaItem);
                  }
                  if (Meeting1StartDate != null)
                  {
                      meeting.MeetingStartDate = Meeting1StartDate.DateTime;
                  }
                  if (Meeting1EndDate != null)
                  {
                      meeting.MeetingEndDate = Meeting1EndDate.DateTime;
                  }
                  if (Meeting1Location != null)
                  {
                      meeting.MeetingLocation = Meeting1Location.Text;
                  }
                  if (Meeting1Venue != null)
                  {
                      meeting.MeetingVenue = Meeting1Venue.Text;
                  }
                  if (Meeting1Description != null)
                  {
                      meeting.MeetingDescription = Meeting1Description.Text;
                  }
                  if (Meeting1CMECredit != null && !string.IsNullOrEmpty(Meeting1CMECredit.Text))
                  {
                      try
                      {
                          int n = 0;
                          bool isNumeric = int.TryParse(Meeting1CMECredit.Text.ToString(), out n); 

                          meeting.MeetingCmeCredit = n;
                      }
                      catch (Exception e)
                      {
                          meeting.MeetingCmeCredit = 0;
                      }
                     
                  }
                  //add our featured meeting
                  featuredMeetings.Add(meeting);
              }
              #endregion
              #region Meeting2

              if (Meeting2Title != null && !string.IsNullOrEmpty(Meeting2Title.Text))
              {
                  //create our hotel
                  AcrMeetingWrapper meeting = new AcrMeetingWrapper();
                  meeting.MeetingTitle = Meeting2Title.Text;
                  if (Meeting2Link != null)
                  {
                      meeting.MeetingSummaryUrl = Meeting2Link.Url;
                  }
									if (Meeting2Image != null && Meeting2Image.MediaItem != null)
                  {
                      meeting.MeetingImageUrl = Sitecore.Resources.Media.MediaManager.GetMediaUrl(Meeting2Image.MediaItem);
                  }
                  if (Meeting2StartDate != null)
                  {
                      meeting.MeetingStartDate = Meeting2StartDate.DateTime;
                  }
                  if (Meeting2EndDate != null)
                  {
                      meeting.MeetingEndDate = Meeting2EndDate.DateTime;
                  }
                  if (Meeting2Location != null)
                  {
                      meeting.MeetingLocation = Meeting2Location.Text;
                  }
                  if (Meeting2Venue != null)
                  {
                      meeting.MeetingVenue = Meeting2Venue.Text;
                  }
                  if (Meeting2Description != null)
                  {
                      meeting.MeetingDescription = Meeting2Description.Text;
                  }
                  if (Meeting2CMECredit != null && !string.IsNullOrEmpty(Meeting2CMECredit.Text))
                  {
                      try
                      {
                          int n = 0;
                          bool isNumeric = int.TryParse(Meeting2CMECredit.Text.ToString(), out n);

                          meeting.MeetingCmeCredit = n;
                      }
                      catch (Exception e)
                      {
                          meeting.MeetingCmeCredit = 0;
                      }

                  }
                  //add our featured meeting
                  featuredMeetings.Add(meeting);
              }
#endregion
              #region Meeting3

              if (Meeting3Title != null && !string.IsNullOrEmpty(Meeting3Title.Text))
              {
                  //create our hotel
                  AcrMeetingWrapper meeting = new AcrMeetingWrapper();
                  meeting.MeetingTitle = Meeting3Title.Text;
                  if (Meeting3Link != null)
                  {
                      meeting.MeetingSummaryUrl = Meeting3Link.Url;
                  }
									if (Meeting3Image != null && Meeting3Image.MediaItem != null)
                  {
                      meeting.MeetingImageUrl = Sitecore.Resources.Media.MediaManager.GetMediaUrl(Meeting3Image.MediaItem);
                  }
                  if (Meeting3StartDate != null)
                  {
                      meeting.MeetingStartDate = Meeting3StartDate.DateTime;
                  }
                  if (Meeting3EndDate != null)
                  {
                      meeting.MeetingEndDate = Meeting3EndDate.DateTime;
                  }
                  if (Meeting3Location != null)
                  {
                      meeting.MeetingLocation = Meeting3Location.Text;
                  }
                  if (Meeting3Venue != null)
                  {
                      meeting.MeetingVenue = Meeting3Venue.Text;
                  }
                  if (Meeting3Description != null)
                  {
                      meeting.MeetingDescription = Meeting3Description.Text;
                  }
                  if (Meeting3CMECredit != null && !string.IsNullOrEmpty(Meeting3CMECredit.Text))
                  {
                      try
                      {
                          int n = 0;
                          bool isNumeric = int.TryParse(Meeting3CMECredit.Text.ToString(), out n);

                          meeting.MeetingCmeCredit = n;
                      }
                      catch (Exception e)
                      {
                          meeting.MeetingCmeCredit = 0;
                      }

                  }
                  //add our featured meeting
                  featuredMeetings.Add(meeting);
              }
              #endregion
              
              //return our accommodations
              return featuredMeetings;
          }
        #endregion //Field Instance Methods
      

      
}
    }

   
  
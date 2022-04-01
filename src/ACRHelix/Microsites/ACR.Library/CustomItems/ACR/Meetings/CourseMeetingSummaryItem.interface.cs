using System;
using System.Linq;
using ACR.Library.ACR.Pages;
using ACR.Library.ACR.Products;
using ACR.Library.Common.Interfaces;
using ACR.Library.Common.Interfaces.Factory;
using ACR.Library.Common.Wrappers;
using ACR.Library.CustomItems.ACR.Interface;
using ACR.Library.CustomSitecore.Extensions;
using ACR.Library.Search.Indices.Meetings;
using ACR.Library.Utils;
using CustomItemGenerator.Fields.SimpleTypes;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;
using Velir.SitecoreLibrary.Extensions;

namespace ACR.Library.ACR.Meetings
{
	public partial class CourseMeetingSummaryItem : IAcrContent, IMeeting, IAcrEducationCenterFeature
	{
		private const string _customWeight = "10";

		#region IAcrContent

		public string HeaderTitle
		{
			get
			{
				//get our parent landing page, we will use that header title
				BasicLandingPageItem landingPage = InnerItem.GetAncestor(BasicLandingPageItem.TemplateId);

				//if our landing page is null return an empty string
				if (landingPage == null)
				{
					return string.Empty;
				}

				//get our landing page as an IAcrContent object
				IAcrContent landingContent = ItemInterfaceFactory.GetItem<IAcrContent>(landingPage);

				//if we don't have landing content then return empty string
				if (landingContent == null)
				{
					return string.Empty;
				}

				//return our landing pages header title
				return landingContent.HeaderTitle;
			}
		}

		public string ContentTitle
		{
			get { return BasePage.ContentTitle; }
		}

		public string ContentSubTitle
		{
			get { return BasePage.ContentSubTitle; }
		}

		public DateTime ContentDate
		{
			get { return BasePage.ContentDate; }
		}

		public string ContentAuthor
		{
			get { return BasePage.ContentAuthor; }
		}

		public string ContentImageUrl
		{
			get { return BasePage.ContentImageUrl; }
		}

		public bool ReplacePageTitleBannerWithHeaderImage
		{
			get { return false; }
		}

		public string ContentBodyText
		{
			get { return BasePage.ContentBodyText; }
		}

		public string ContentAdditionalInformation
		{
			get { return BasePage.ContentAdditionalInformation; }
		}

		public string ContentResourceTitle
		{
			get { return BasePage.ContentResourceTitle; }
		}

		public IList<IListItem> ContentResourceLinks
		{
			get { return BasePage.ContentResourceLinks; }
		}

		public string ContentProductsTitle
		{
			get { return BasePage.ContentProductsTitle; }
		}

		public IList<ProductStubItem> ContentProducts
		{
			get { return BasePage.ContentProducts; }
		}

		#endregion

		#region IMeeting

		MeetingType IMeeting.MeetingType
		{
			get
			{
				//a meeting summary is not really a meeting so return none for our type.
				//there is a meeting type field on the meeting summary item, but we don't
				//want to use this value.  this is because a summary item isn't necessarily
				//a "meeting" and shouldn't really be treated as such.  This is more of a 
				//container for product meetings.  If we need the type we can look at the 
				//first meeting occurrence to determine the meeting type.
				return Search.Indices.Meetings.MeetingType.None;
			}
		}

		string IMeeting.MeetingTitle
		{
			get
			{
				//if we don't have a meeting title then return empty string
				if (MeetingTitle == null)
				{
					return string.Empty;
				}

				//return our meeting title
				return MeetingTitle.Text;
			}
		}

		public string MeetingSubtitle
		{
			get
			{
				//meeting summary items don't have a subtitle
				return string.Empty;
			}
		}

		public DateTime MeetingStartDate
		{
			get
			{
				//return our start date
				//this will represent the ealiest start date from all occurrences
				//of this meeting.
				return GetStartDate();
			}
		}

		public DateTime MeetingEndDate
		{
			get
			{
				//return our end date
				//this will represent the latest end date from all occurrences
				//of this meeting.
				return GetEndDate();
			}
		}

		public string MeetingLocation
		{
			get
			{
				//get our meeting occurrences
				List<IMeeting> meetingOccurrences = MeetingOccurrences;

				//if we don't have any occurrences, return empty string
				if (meetingOccurrences == null || !meetingOccurrences.Any())
				{
					return string.Empty;
				}

				//get our first occurrence. we will just return the location
				//of the first occurrence.
				IMeeting meetingOccurrence = meetingOccurrences.FirstOrDefault();

				//if we don't have a meeting occurrence then return an empty string
				if (meetingOccurrence == null)
				{
					return string.Empty;
				}

				//return the location of our meeting occurrence
				return meetingOccurrence.MeetingLocation;
			}
		}

		public string MeetingVenue
		{
			get
			{
				//get our meeting occurrences
				List<IMeeting> meetingOccurrences = MeetingOccurrences;

				//if we don't have any occurrences, return empty string
				if (meetingOccurrences == null || !meetingOccurrences.Any())
				{
					return string.Empty;
				}

				//get our first occurrence. we will just return the venue
				//of the first occurrence.
				IMeeting meetingOccurrence = meetingOccurrences.FirstOrDefault();

				//if we don't have a meeting occurrence then return an empty string
				if (meetingOccurrence == null)
				{
					return string.Empty;
				}

				//return the venue of our meeting occurrence
				return meetingOccurrence.MeetingVenue;
			}
		}

		public string MeetingDescription
		{
			get
			{
				//if we don't have an overview, return an empty string
				if (Overview == null)
				{
					return string.Empty;
				}

				//return our overview
				return Overview.Text;
			}
		}

		public string MeetingShortDescription
		{
			get
			{
				//course meeting summary items don't have a short descriptions
				return string.Empty;
			}
		}

		public string MeetingObjectives
		{
			get
			{
				//if we don't have objectives, return empty string
				if (ProgramsandObjectives == null)
				{
					return string.Empty;
				}

				//return our objectives
				return ProgramsandObjectives.Text;
			}
		}

		public string MeetingTestimonials
		{
			get
			{
				//if we don't have testimonials, return empty string
				if (Testimonials == null)
				{
					return string.Empty;
				}

				//return our testimonials
				return Testimonials.Text;
			}
		}

		public string MeetingImageUrl
		{
			get
			{
				//course meeting summary items don't have a meeting image
				return string.Empty;
			}
		}

		public string MeetingSummaryUrl
		{
			get
			{
				//return the url for this item
				return InnerItem.GetItemUrl();
			}
		}

		public string MeetingRegisterUrl
		{
			get
			{
				//meeting summary pages will have multiple register url's shown in tab details.
				//we should return empty string so that the control can handle the url
				//and add functionality for showing this register tab instead of linking to a page.
				return string.Empty;
			}
		}

		public string MeetingRegisterInfo
		{
			get { return RegistrationInformation.Text; }
		}

		public string MeetingAdditionalInfo
		{
			get { return AdditionalInformation.Text; }
		}

		public string MeetingAdditionalWebsiteUrl
		{
			get
			{
				//meeting summary items don't have an additional website url
				return string.Empty;
			}
		}

		public int MeetingCmeCredit
		{
			get
			{
				//get our meeting occurrences
				List<IMeeting> meetingOccurrences = MeetingOccurrences;

				//if we don't have any occurrences, return -1
				if (meetingOccurrences == null || !meetingOccurrences.Any())
				{
					return -1;
				}

				//get our first occurrence. we will just return the cme credit
				//of the first occurrence.
				IMeeting meetingOccurrence = meetingOccurrences.FirstOrDefault();

				//if we don't have a meeting occurrence then return -1
				if (meetingOccurrence == null)
				{
					return -1;
				}

				//return the cme credit of our meeting occurrence
				return meetingOccurrence.MeetingCmeCredit;
			}
		}

		public List<IListItem> MeetingDocuments
		{
			get
			{
				//our meeting summary contains a brochure.  lets return that
				List<IListItem> documents = new List<IListItem>();

				//if we have a brochure, add it to our list
				if (Brochure != null && !string.IsNullOrEmpty(Brochure.Url))
				{
					//create our list item.
					ListItemWrapper brochure = new ListItemWrapper();
					brochure.LiTitle = "Brochure";
					brochure.LiUrl = LinkUtils.GetLinkFieldUrl(Brochure.Field);

					//add to our list
					documents.Add(brochure);
				}

				//return our documents
				return documents;
			}
		}

		public List<IMeeting> MeetingOccurrences
		{
			get
			{
				//get all our meeting products
				List<ProductStubItem> meetingProducts = GetMeetingProducts();

				//if we don't have any products then return an empty list
				if (meetingProducts == null || !meetingProducts.Any())
				{
					return new List<IMeeting>(0);
				}

				//order our meeting products
				meetingProducts = meetingProducts.OrderByDescending(m => m.MeetingStartDate.DateTime).Reverse().ToList();

				//return our products as IMeeting objects
				return ItemInterfaceFactory.GetItems<IMeeting>(meetingProducts.Select(i => (Item) i).ToList());
			}
		}

		public List<IListItem> MeetingAccommodations
		{
			get
			{
				//we will be returning our hotel information.
				List<IListItem> accommodations = new List<IListItem>();

				//if we have a first hotel, then add it to our accommodations.
				//we will key off the name.
				if (HotelName1 != null && !string.IsNullOrEmpty(HotelName1.Text))
				{
					//create our hotel
					ListItemWrapper hotel = new ListItemWrapper();
					hotel.LiTitle = HotelName1.Text;
					if (HotelLocation1 != null)
					{
						hotel.LiDescription = HotelLocation1.Text;
					}
					if (HotelBooking1 != null)
					{
						hotel.LiUrl = HotelBooking1.Url;
						hotel.LiLinkTarget = "_blank";
					}

					//add our hotel
					accommodations.Add(hotel);
				}

				//if we have a second hotel, then add it to our accommodations.
				//we will key off the name.
				if (HotelName2 != null && !string.IsNullOrEmpty(HotelName2.Text))
				{
					//create our hotel
					ListItemWrapper hotel = new ListItemWrapper();
					hotel.LiTitle = HotelName2.Text;
					if (HotelLocation2 != null)
					{
						hotel.LiDescription = HotelLocation2.Text;
					}
					if (HotelBooking2 != null)
					{
						hotel.LiUrl = HotelBooking2.Url;
					}

					//add our hotel
					accommodations.Add(hotel);
				}

				//if we have a third hotel, then add it to our accommodations.
				//we will key off the name.
				if (HotelName3 != null && !string.IsNullOrEmpty(HotelName3.Text))
				{
					//create our hotel
					ListItemWrapper hotel = new ListItemWrapper();
					hotel.LiTitle = HotelName3.Text;
					if (HotelLocation3 != null)
					{
						hotel.LiDescription = HotelLocation3.Text;
					}
					if (HotelBooking3 != null)
					{
						hotel.LiUrl = HotelBooking3.Url;
					}

					//add our hotel
					accommodations.Add(hotel);
				}

				//return our accommodations
				return accommodations;
			}
		}

		public List<IAcrPersonnel> MeetingContacts
		{
			get
			{
				//a meeting summary currently doesn't have any contacts, return empty list
				return new List<IAcrPersonnel>(0);
			}
		}

		public List<Item> MeetingAssociatedItems
		{
			get { throw new NotImplementedException(); } //TODO: IMPLEMENT FUNCTION IF APPLICABLE
		}

		#endregion

		#region ICoveoCrawlable Members
        /*
		public string CoveoTitle(string collectionName)
		{
			return StringUtil.GetNonEmptyString(BasePage.HeaderTitle.Text, BasePage.ShortTitle.Text, BasePage.PageTitle.Text,
			                                    BasePage.Name);
		}

		public string CoveoOverrideUrl(string collectionName)
		{
			return string.Empty;
		}

		public string CoveoDescription(string collectionName)
		{
			return string.Empty;
		}

		public DateTime CoveoDate(string collectionName)
		{
			return BasePage.InnerItem.Statistics.Updated;
		}

		public DateTime CoveoCreatedDate(string collectionName)
		{
			return this.BasePage.InnerItem.Publishing.PublishDate;
		}

		public string CoveoDisplayDate(string collectionName)
		{
			return CoveoDate(collectionName).ToString(AcrConstants.DateFormats.MonthDayYear);
		}

		public Dictionary<string, string> CoveoAdditionalFields(string collectionName)
		{
			var additionalFields = new Dictionary<string, string>();

			additionalFields.Add(CoveoFields.CustomWeight.FieldName, _customWeight);

			if (TaxonomyContent != null)
			{
				additionalFields.Add(CoveoFields.Modality.FieldName,
				                     TaxonomyContent.GetTaxonomyForCoveo(TaxonomyContent.RelatedModalities));
				additionalFields.Add(CoveoFields.SubSpecialty.FieldName,
				                     TaxonomyContent.GetTaxonomyForCoveo(TaxonomyContent.RelatedSubspecialites));
				additionalFields.Add(CoveoFields.Interest.FieldName,
				                     TaxonomyContent.GetTaxonomyForCoveo(TaxonomyContent.RelatedInterests));
				additionalFields.Add(CoveoFields.MetaData.FieldName, MetaUtils.GetMetaKeywordsForCoveo(BasePage.MetaKeywords.Text));
			}

			additionalFields.Add(CoveoFields.ContentType.FieldName, "Content Page");


			return additionalFields;
		}

		public bool CoveoExcludeFromIndex(string collectionName)
		{
			//only allow through general search collection crawlers
			if (collectionName != SearchContext.ACRGeneralCollectionName &&
			    !SearchContext.ACRGeneralCollectionName.StartsWith(collectionName))
			{
				return true;
			}

			foreach (ProductStubItem productStubItem in Products.ListItems)
			{
				if (productStubItem.WebDisplayValid())
				{
					return true;
				}
			}

			return false;
		}
        */
		#endregion

		#region IAcrEducationCenterFeature

		public string EducationFeatureTitle
		{
			get
			{
				return EducationCenterFeature.FeaturedName.Text;
			}
		}

		public CustomImageField EducationFeatureThumbnail 
		{
			get
			{
				return EducationCenterFeature.FeaturedThumbnail;
			}
		}

		public string EducationFeatureUrl
		{
			get
			{
				return LinkUtils.GetItemUrl(InnerItem);
			}
		}

		#endregion
	}
}
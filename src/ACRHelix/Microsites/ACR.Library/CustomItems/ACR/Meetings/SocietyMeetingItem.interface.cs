using System;
using ACR.Library.ACR.Pages;
using ACR.Library.ACR.Products;
using ACR.Library.Common.Interfaces;
using ACR.Library.Common.Interfaces.Factory;

using ACR.Library.CustomItems.ACR.Interface;
using ACR.Library.CustomItems.ACR.Interface.Wrappers;
using ACR.Library.CustomSitecore.Extensions;
using ACR.Library.Search.Indices.Meetings;
using ACR.Library.Utils;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Links;
using Velir.SitecoreLibrary.Extensions;

namespace ACR.Library.ACR.Meetings
{
	public partial class SocietyMeetingItem : IAcrContent, IListItem, IMeeting, INavigationItem
	{
		#region ICoveoCrawlable
        /*

		public string CoveoTitle(string collectionName)
		{
			return MeetingTitle.Text;
		}

		public string CoveoOverrideUrl(string collectionName)
		{
			return string.Empty;
		}

		public string CoveoDescription(string collectionName)
		{
			return SocietyName.Text;
		}

		public DateTime CoveoDate(string collectionName)
		{
			return MeetingStartDate.DateTime;
		}

		public DateTime CoveoCreatedDate(string collectionName)
		{
			return this.InnerItem.Publishing.PublishDate;
		}

		public string CoveoDisplayDate(string collectionName)
		{
			return MeetingUtils.FormatDateRange(MeetingStartDate.DateTime, MeetingEndDate.DateTime);
		}

		public Dictionary<string, string> CoveoAdditionalFields(string collectionName)
		{
			Dictionary<string, string> additionalFields = new Dictionary<string, string>();

			//Add taxonomy
			additionalFields.Add(CoveoFields.Modality.FieldName, TaxonomyContent.GetTaxonomyForCoveo(TaxonomyContent.RelatedModalities));
			additionalFields.Add(CoveoFields.SubSpecialty.FieldName, TaxonomyContent.GetTaxonomyForCoveo(TaxonomyContent.RelatedSubspecialites));
			additionalFields.Add(CoveoFields.Interest.FieldName, TaxonomyContent.GetTaxonomyForCoveo(TaxonomyContent.RelatedInterests));
			additionalFields.Add(CoveoFields.MeetingType.FieldName, MeetingTypeParameter.SocietyMeetingType);
			additionalFields.Add(CoveoFields.ContentType.FieldName, "Meeting");

			return additionalFields;
		}

		public bool CoveoExcludeFromIndex(string collectionName)
		{
			if (collectionName == SearchContext.ACRGeneralCollectionName || collectionName == SearchContext.ACRMeetingsCollectionName
				|| SearchContext.ACRGeneralCollectionName.StartsWith(collectionName) || SearchContext.ACRMeetingsCollectionName.StartsWith(collectionName))
			{
				return false;
			}
			return true;
		}
        */
		#endregion

		#region IListItem

		public string LiTopic
		{
			get { return string.Empty; }
		}

		public string LiTitle
		{
			get { return MeetingTitle.Text; }
		}

		public string LiDescription
		{
			get { return SocietyName.Text; }
		}

		public string LiUrl
		{
			get { return LinkUtils.GetItemFullUrl(InnerItem); }
		}

		public string LiLinkTarget
		{
			get { return string.Empty; }
		}

		public bool LiIsPdf
		{
			get { return false; }
		}

		public string LiAssociatedPdfUrl
		{
			get { return string.Empty; }
		}

		public string LiType
		{
			get { return "Society Meeting"; }
		}

		public DateTime LiDate
		{
			get { return MeetingStartDate.DateTime; }
		}

		public MediaItem LiImage
		{
			get { return null; }
		}

		#endregion

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
			get { return HeaderTitle; }
		}

		public string ContentSubTitle
		{
			get { return string.Empty; }
		}

		public DateTime ContentDate
		{
			get { return DateTime.MinValue; }
		}

		public string ContentAuthor
		{
			get { return string.Empty; }
		}

		public string ContentImageUrl
		{
			get { return string.Empty; }
		}

		public bool ReplacePageTitleBannerWithHeaderImage
		{
			get
			{
				return false;
			}
		}

		public string ContentBodyText
		{
			get { return string.Empty; }
		}

		public string ContentAdditionalInformation
		{
			get { return string.Empty; }
		}

		public string ContentResourceTitle
		{
			get { return string.Empty; }
		}

		public IList<IListItem> ContentResourceLinks
		{
			get { return new List<IListItem>(0); }
		}

		public string ContentProductsTitle
		{
			get { return string.Empty; }
		}

		public IList<ProductStubItem> ContentProducts
		{
			get { return new List<ProductStubItem>(0); }
		}

		#endregion

		#region IMeeting

		public MeetingType MeetingType
		{
			get
			{
				//return that we are a society meeting
				return MeetingType.Society;
			}
		}

		string IMeeting.MeetingTitle
		{
			get
			{
				//FB 13580 Swapping Title and Subtitle
				//for our society meeting we will use the society name as the subtitle
				if (SocietyName == null)
				{
					return string.Empty;
				}

				//return our society name
				return SocietyName.Text;
			}
		}

		public string MeetingSubtitle
		{
			get
			{
				//FB 13580 Swapping Title and Subtitle
				//if we don't have a meeting title then return empty string
				if (MeetingTitle == null)
				{
					return string.Empty;
				}

				//return our meeting title
				return MeetingTitle.Text;
			}
		}

		DateTime IMeeting.MeetingStartDate
		{
			get
			{
				//if we don't have a start date then return min value.
				if (MeetingStartDate == null)
				{
					return DateTime.MinValue;
				}

				//return our start date
				return MeetingStartDate.DateTime;
			}
		}

		DateTime IMeeting.MeetingEndDate
		{
			get
			{
				//if we don't have an end date then return min value.
				if (MeetingEndDate == null)
				{
					return DateTime.MinValue;
				}

				//return our end date
				return MeetingEndDate.DateTime;
			}
		}

		string IMeeting.MeetingLocation
		{
			get
			{
				//if we don't have a location then return empty string
				if (MeetingLocation == null)
				{
					return string.Empty;
				}

				//return our location
				return MeetingLocation.Text;
			}
		}

		string IMeeting.MeetingVenue
		{
			get
			{
				//if we don't have a venue then return empty string
				if (MeetingVenue == null)
				{
					return string.Empty;
				}

				//return our venue
				return MeetingVenue.Text;
			}
		}

		public string MeetingDescription
		{
			get
			{
				//if we don't have a description then return empty string
				if (Description == null)
				{
					return string.Empty;
				}

				//return our description
				return Description.Text;
			}
		}

		public string MeetingShortDescription
		{
			get
			{
				//FB 13580 Swapping Title and Subtitle
				//if we don't have a meeting title then return empty string
				if (MeetingTitle == null)
				{
					return string.Empty;
				}

				//return our meeting title
				return MeetingTitle.Text;
			}
		}

		public string MeetingObjectives
		{
			get
			{
				//society meetings currently don't have objectives
				return string.Empty;
			}
		}

		public string MeetingTestimonials
		{
			get
			{
				//society meetings currently don't have testimonials
				return string.Empty;
			}
		}

		public string MeetingImageUrl
		{
			get
			{
				//society meetings currently don't have an image
				return string.Empty;
			}
		}

		public string MeetingSummaryUrl
		{
			get
			{
				//return a link to this item
				return InnerItem.GetItemUrl();
			}
		}

		public string MeetingRegisterUrl
		{
			get
			{
				//currently no register url
				return string.Empty;
			}
		}

		public string MeetingRegisterInfo
		{
			get { return string.Empty; }
		}

		public string MeetingAdditionalInfo
		{
			get { return string.Empty; }
		}

		public string MeetingAdditionalWebsiteUrl
		{
			get
			{
				//if we don't have a site url then return empty string
				if (SiteURL == null)
				{
					return string.Empty;
				}

				//return our site url
				return SiteURL.Url;
			}
		}

		public int MeetingCmeCredit
		{
			get
			{
				//society meetings currently don't have a cme credit
				return -1;
			}
		}

		public List<IListItem> MeetingDocuments
		{
			get
			{
				//society meetings currently don't have any documents.
				return new List<IListItem>(0);
			}
		}

		public List<IMeeting> MeetingOccurrences
		{
			get
			{
				//society meetings only have one occurrence, so return empty list
				return new List<IMeeting>(0);
			}
		}

		public List<IListItem> MeetingAccommodations
		{
			get
			{
				//society meetings currently don't have accommodations.
				return new List<IListItem>(0);
			}
		}

		public List<IAcrPersonnel> MeetingContacts
		{
			get
			{
				List<IAcrPersonnel> contacts = new List<IAcrPersonnel>();

				//we need to wrap our contact info in an AcrPersonnel wrapper
				//we will key off the contact name to see if we have a contact
				if (ContactName != null && !string.IsNullOrEmpty(ContactName.Text))
				{
					//create our contact
					AcrPersonnelWrapper contact = new AcrPersonnelWrapper();
					contact.PersonnelName = ContactName.Text;

					//create any details our contact has
					contact.ShortPersonnelDetails = new List<IAcrPersonnelDetail>();
					contact.PersonnelDetails = new List<IAcrPersonnelDetail>();

					//if we have a title then add it to our details
					if (ContactTitle != null && !string.IsNullOrEmpty(ContactTitle.Text))
					{
						//create our detail
						AcrPersonnelDetailWrapper title = new AcrPersonnelDetailWrapper();
						title.PersonnelDetailType = AcrPersonnelDetailType.Title;
						title.PersonnelDetailText = ContactTitle.Text;

						//add to our details
						contact.ShortPersonnelDetails.Add(title);
						contact.PersonnelDetails.Add(title);
					}

					//if we have an email then add it to our details
					if (ContactEmail != null && !string.IsNullOrEmpty(ContactEmail.Text))
					{
						//create our detail
						AcrPersonnelDetailWrapper email = new AcrPersonnelDetailWrapper();
						email.PersonnelDetailType = AcrPersonnelDetailType.Email;
						email.PersonnelDetailText = ContactEmail.Text;
						email.PersonnelDetailUrl = "mailto:" + ContactEmail.Text;

						//add to our details
						contact.ShortPersonnelDetails.Add(email);
						contact.PersonnelDetails.Add(email);
					}

					//if we have a phone then add it to our details
					if (ContactPhone != null && !string.IsNullOrEmpty(ContactPhone.Text))
					{
						//create our detail
						AcrPersonnelDetailWrapper phone = new AcrPersonnelDetailWrapper();
						phone.PersonnelDetailType = AcrPersonnelDetailType.Phone;
						phone.PersonnelDetailText = ContactPhone.Text;

						//add to our details
						contact.ShortPersonnelDetails.Add(phone);
						contact.PersonnelDetails.Add(phone);
					}

					//if we have an address then add it to our details
					if (ContactAddress != null && !string.IsNullOrEmpty(ContactAddress.Text))
					{
						//create our detail
						AcrPersonnelDetailWrapper address = new AcrPersonnelDetailWrapper();
						address.PersonnelDetailType = AcrPersonnelDetailType.Address;
						address.PersonnelDetailText = ContactAddress.Text;

						//add to our details
						contact.PersonnelDetails.Add(address);
					}

					//add our contact
					contacts.Add(contact);
				}

				//return our contacts
				return contacts;
			}
		}

		public List<Item> MeetingAssociatedItems
		{
			get { throw new NotImplementedException(); } //TODO: IMPLEMENT IF APPLICABLE
		}

		#endregion

		#region Implementation of INavigationItem

		public string NavShortTitle
		{
			get { return MeetingTitle.Text; }
		}

		public bool HideBreadcrumb
		{
			get { return false; }
		}

		public bool ShowInTopNavigation
		{
			get { return false; }
		}

		public bool ShowInSideNavigation
		{
			get { return false; }
		}

		public bool ShowInFooter
		{
			get { return false; }
		}

		public bool ShowInSitemap
		{
			get { return false; }
		}

		public bool HideSideNavigation
		{
			get { return false; }
		}

		public string NavUrl
		{
			get { return LinkManager.GetItemUrl(InnerItem); }
		}

		public bool HideTextControl
		{
			get { return false; }
		}

		public bool HideToolbarControl
		{
			get { return false; }
		}

		#endregion
	}
}
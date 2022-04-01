using System;
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

namespace ACR.Library.ACR.Membership
{
	public partial class ChapterMeetingItem : IAcrContent, IMeeting, INavigationItem
	{
		#region IAcrContent

		public string HeaderTitle
		{
			get
			{
				//if we don't have any associated chapters then return empty string
				if (AssociatedChapter == null)
				{
					return string.Empty;
				}

				//we will want to use the title for our associated chapter
				//get our associated chapter
				Item chapter = AssociatedChapter.Item;

				//if we don't have a chapter return empty string
				if (chapter == null)
				{
					return string.Empty;
				}

				//get our chapter as an IAcrContent item
				IAcrContent content = ItemInterfaceFactory.GetItem<IAcrContent>(chapter);

				//if we don't have a content item then return empty string
				if (content == null)
				{
					return string.Empty;
				}

				//return our header title.
				return content.HeaderTitle;
			}
		}

		public string ContentTitle
		{
			get { return string.Empty; }
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
				//return that we are a chapter meeting
				return MeetingType.Chapter;
			}
		}

		public string MeetingTitle
		{
			get
			{
				//if we don't have a title then return empty string
				if (Title == null)
				{
					return string.Empty;
				}

				//return our title
				return Title.Text;
			}
		}

		public string MeetingSubtitle
		{
			get
			{
				//if we don't have any associated chapters then return empty string
				if (AssociatedChapter == null)
				{
					return string.Empty;
				}

				//we will want to use the title for our associated chapter
				//get our associated chapter
				Item chapter = AssociatedChapter.Item;

				//if we don't have a chapter return empty string
				if (chapter == null)
				{
					return string.Empty;
				}

				//get our chapter as an IAcrContent item
				IAcrContent content = ItemInterfaceFactory.GetItem<IAcrContent>(chapter);

				//if we don't have a content item then return empty string
				if (content == null)
				{
					return string.Empty;
				}

				//return our header title.
				return content.HeaderTitle;
			}
		}

		public DateTime MeetingStartDate
		{
			get
			{
				//if we don't have a start date then return min value.
				if (StartDate == null)
				{
					return DateTime.MinValue;
				}

				//return our start date
				return StartDate.DateTime;
			}
		}

		public DateTime MeetingEndDate
		{
			get
			{
				//if we don't have an end date then return min value.
				if (EndDate == null)
				{
					return DateTime.MinValue;
				}

				//return our end date
				return EndDate.DateTime;
			}
		}

		public string MeetingLocation
		{
			get
			{
				//if we don't have a location then return empty string
				if (Location == null)
				{
					return string.Empty;
				}

				//return our location
				return Location.Text;
			}
		}

		public string MeetingVenue
		{
			get
			{
				//if we don't have a venue then return empty string
				if (Venue == null)
				{
					return string.Empty;
				}

				//return our venue
				return Venue.Text;
			}
		}

		public string MeetingDescription
		{
			get
			{
				//if we don't have a description then return empty string
				if (Description == null)
				{
					return MeetingShortDescription;
				}

				//return our description
				return Description.Text;
			}
		}

		public string MeetingShortDescription
		{
			get
			{
				//if we don't have any associated chapters then return empty string
				if (AssociatedChapter == null)
				{
					return string.Empty;
				}

				//we will want to use the title for our associated chapter
				//get our associated chapter
				Item chapter = AssociatedChapter.Item;

				//if we don't have a chapter return empty string
				if (chapter == null)
				{
					return string.Empty;
				}

				//get our chapter as an IAcrContent item
				IAcrContent content = ItemInterfaceFactory.GetItem<IAcrContent>(chapter);

				//if we don't have a content item then return empty string
				if (content == null)
				{
					return string.Empty;
				}

				//return our header title.
				return content.HeaderTitle;
			}
		}

		public string MeetingObjectives
		{
			get
			{
				//chapter meetings currently don't have objectives
				return string.Empty;
			}
		}

		public string MeetingTestimonials
		{
			get
			{
				//chapter meetings currently don't have testimonials
				return string.Empty;
			}
		}

		public string MeetingImageUrl
		{
			get
			{
				//chapter meetings currently don't have an image
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
				//chapter meetings currenlty don't have an additional website url
				return string.Empty;
			}
		}

		public int MeetingCmeCredit
		{
			get
			{
				//chapter meetings currently don't have a cme credit
				return -1;
			}
		}

		public List<IListItem> MeetingDocuments
		{
			get
			{
				//chapter meetings currently don't have any documents.
				return new List<IListItem>(0);
			}
		}

		public List<IMeeting> MeetingOccurrences
		{
			get
			{
				//chapter meetings only have one occurrence, so return empty list
				return new List<IMeeting>(0);
			}
		}

		public List<IListItem> MeetingAccommodations
		{
			get
			{
				//chapter meetings currently don't have accommodations.
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

					//add our contact
					contacts.Add(contact);
				}

				//return our contacts
				return contacts;
			}
		}

		public List<Item> MeetingAssociatedItems
		{
			get { return new List<Item> {AssociatedChapter.Item}; }
		}

		#endregion

		#region Implementation of INavigationItem

		public string NavShortTitle
		{
			get { return MeetingTitle; }
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

		#region ICoveoCrawlable
        /*
		public string CoveoTitle(string collectionName)
		{
			return MeetingTitle;
		}

		public string CoveoOverrideUrl(string collectionName)
		{
			return string.Empty;
		}

		public string CoveoDescription(string collectionName)
		{
			return MeetingShortDescription;
		}

		public DateTime CoveoDate(string collectionName)
		{
			return MeetingStartDate;
		}

		public DateTime CoveoCreatedDate(string collectionName)
		{
			return this.InnerItem.Publishing.PublishDate;
		}

		public string CoveoDisplayDate(string collectionName)
		{
			return MeetingUtils.FormatDateRange(MeetingStartDate, MeetingEndDate);
		}


		public Dictionary<string, string> CoveoAdditionalFields(string collectionName)
		{
			Dictionary<string, string> additionalFields = new Dictionary<string, string>();

			//Add taxonomy
			additionalFields.Add(CoveoFields.Modality.FieldName, TaxonomyContent.GetTaxonomyForCoveo(TaxonomyContent.RelatedModalities));
			additionalFields.Add(CoveoFields.SubSpecialty.FieldName, TaxonomyContent.GetTaxonomyForCoveo(TaxonomyContent.RelatedSubspecialites));
			additionalFields.Add(CoveoFields.Interest.FieldName, TaxonomyContent.GetTaxonomyForCoveo(TaxonomyContent.RelatedInterests));
			additionalFields.Add(CoveoFields.MeetingType.FieldName, MeetingTypeParameter.ChapterMeetingType);
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
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.ACR.Meetings;
using ACR.Library.ACR.Products;
using ACR.Library.Common.Interfaces;
using ACR.Library.Common.Interfaces.Factory;
using ACR.Library.CustomItems.ACR.Interface;
using ACR.Library.CustomItems.ACR.Interface.Wrappers;
using ACR.Library.CustomSitecore.Extensions;
using ACR.Library.Search.Indices.Meetings;
using ACR.Library.Utils;
using Sitecore.Data.Items;
using Sitecore.Links;
using Velir.SitecoreLibrary.Extensions;

namespace ACR.Library.ACR.Membership
{
	public partial class ResidentFellowsMeetingItem: INavigationItem, IMeeting, IAcrContent, IListItem
	{
		#region Implementation of INavigationItem

		public string NavShortTitle
		{
			get { return Title.Text; }
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


		#region IListItem

		public string LiTopic
		{
			get { return string.Empty; }
		}

		public string LiTitle
		{
			get { return String.Empty; }
		}

		public string LiDescription
		{
			get { return String.Empty; }
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
			get { return "Resident & Fellows Meeting"; }
		}

		public DateTime LiDate
		{
			get { return DateTime.MinValue; }
		}

		public MediaItem LiImage
		{
			get { return null; }
		}

		#endregion


		#region IMeeting

		public MeetingType MeetingType
		{
			get
			{
				return MeetingType.None;
			}
		}

		string IMeeting.MeetingTitle
		{
			get
			{
				//return our meeting title
				return Title.Text;
			}
		}

		public string MeetingSubtitle
		{
			get
			{
				//return our society name
				return String.Empty;
			}
		}

		DateTime IMeeting.MeetingStartDate
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

		DateTime IMeeting.MeetingEndDate
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

		string IMeeting.MeetingLocation
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

		string IMeeting.MeetingVenue
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
				//return our description
				return Description.Text;
			}
		}

		public string MeetingShortDescription
		{
			get
			{
				return string.Empty;
			}
		}

		public string MeetingObjectives
		{
			get
			{
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
				//return our site url
				return string.Empty;
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
			get { return new List<Item>(); } //TODO: IMPLEMENT IF APPLICABLE
		}

		#endregion

		#region IAcrContent

		public string HeaderTitle
		{
			get { return "Resident & Fellows Meeting"; }
		}

		public string ContentTitle
		{
			get { return Title.Text; }
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
	}
}

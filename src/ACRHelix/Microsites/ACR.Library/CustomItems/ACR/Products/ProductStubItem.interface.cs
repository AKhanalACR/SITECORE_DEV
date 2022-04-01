using System;
using System.Linq;
using System.Text;
using ACR.Library.ACR.Education;
using ACR.Library.ACR.Meetings;
using ACR.Library.ACR.Pages;
using ACR.Library.ACR.Taxonomy;
using ACR.Library.Common.Interfaces;
using ACR.Library.Common.Interfaces.Factory;
using ACR.Library.CustomItems.ACR.Interface;
using ACR.Library.CustomSitecore.Extensions;
using ACR.Library.Reference;
using ACR.Library.Search.Indices.Meetings;
using ACR.Library.Utils;
using ACR.Library.Utils.ACR;
using CustomItemGenerator.Fields.SimpleTypes;
using Sitecore.Data.Items;
using System.Collections.Generic;

namespace ACR.Library.ACR.Products
{
	public partial class ProductStubItem : IListItem, IMeeting
	{
		//#region ICoveoCrawlable

		//public string CoveoTitle(string collectionName)
		//{
		//	return Name.Text;
		//}

		//public string CoveoOverrideUrl(string collectionName)
		//{
		//	if (!string.IsNullOrEmpty(GetProductDetailUrl()))
		//		return GetProductDetailUrl();

		//	return LiUrl;
		//}

		//public string CoveoDescription(string collectionName)
		//{
		//	return ShortDescription.Text;
		//}

		//public DateTime CoveoDate(string collectionName)
		//{
		//	//TODO: figure out the date for different collections
		//	if (MeetingStartDate.DateTime != DateTime.MinValue)
		//	{
		//		return MeetingStartDate.DateTime;
		//	}

		//	return InnerItem.Statistics.Updated;
		//}

		//public DateTime CoveoCreatedDate(string collectionName)
		//{
		//	return WebDisplayStartDate.DateTime;
		//}

		//public string CoveoDisplayDate(string collectionName)
		//{
		//	if (MeetingStartDate.DateTime != DateTime.MinValue && (MeetingEndDate.DateTime != DateTime.MinValue))
		//	{
		//		return MeetingUtils.FormatDateRange(MeetingStartDate.DateTime, MeetingEndDate.DateTime);
		//	}

		//	if (ProductIsMeetingOrCourse())
		//	{
		//		return CoveoDate(collectionName).ToString(AcrConstants.DateFormats.MonthDayYear);
		//	}

		//	return "";
		//}


		//public Dictionary<string, string> CoveoAdditionalFields(string collectionName)
		//{
		//	Dictionary<string, string> additionalFields = new Dictionary<string, string>();

		//	additionalFields.Add(CoveoFields.LongDescription.FieldName, LongDescription.Text);

		//	//Add taxonomy
		//	additionalFields.Add(CoveoFields.Modality.FieldName, TaxonomyContent.GetTaxonomyForCoveo(TaxonomyContent.RelatedModalities));
		//	additionalFields.Add(CoveoFields.SubSpecialty.FieldName, TaxonomyContent.GetTaxonomyForCoveo(TaxonomyContent.RelatedSubspecialites));
		//	additionalFields.Add(CoveoFields.Interest.FieldName, TaxonomyContent.GetTaxonomyForCoveo(TaxonomyContent.RelatedInterests));
		//	additionalFields.Add(CoveoFields.Topic.FieldName, TaxonomyContent.GetTaxonomyForCoveo(RelatedTopics));


		//	additionalFields.Add(CoveoFields.ContentType.FieldName, ProductIsMeetingOrCourse() ? "Meeting" : "Product");

		//	if (collectionName == SearchContext.ACRProductsCollectionName || SearchContext.ACRProductsCollectionName.StartsWith(collectionName))
		//	{
		//		additionalFields.Add(CoveoFields.CatalogType.FieldName, TaxonomyContent.GetTaxonomyForCoveo(DeliveryMethod));
		//		additionalFields.Add(CoveoFields.CreditType.FieldName, TaxonomyContent.GetTaxonomyForCoveo(CreditTypes));
		//	}

		//	if (collectionName == SearchContext.ACRMeetingsCollectionName || SearchContext.ACRMeetingsCollectionName.StartsWith(collectionName))
		//	{
		//		//Add meeting type

		//		if (ProductIsMeetingOrCourse())
		//		{
		//			//Add roll up page info for this type of meeting
		//			additionalFields.Add(CoveoFields.SummaryPageContent.FieldName, getMeetingSummaryPageContent());
		//		}
				
		//		additionalFields.Add(CoveoFields.MeetingType.FieldName, MeetingTypeString());
		//	}

		//	return additionalFields;
		//}

		//public bool CoveoExcludeFromIndex(string collectionName)
		//{
		//	PersonifyTaxonomyItem productArea = ProductArea.Item;
		//	PersonifyTaxonomyItem productType = ProductType.Item;
		//	PersonifyTaxonomyItem productClass = ProductClass.Item;

		//	if (!WebDisplay.Checked || productArea == null || productType == null || productClass == null)
		//	{
		//		return true;
		//	}

		//	if (collectionName == SearchContext.ACRProductsCollectionName || SearchContext.ACRProductsCollectionName.StartsWith(collectionName))
		//	{
		//		return productArea.OmitfromSearch.Checked || !ActiveStatusFlag() || productClass.OmitfromSearch.Checked ||
		//		       !IsActiveDates() || productType.OmitfromSearch.Checked;
		//	}
		//	else if (collectionName == SearchContext.ACRMeetingsCollectionName || SearchContext.ACRMeetingsCollectionName.StartsWith(collectionName))
		//	{
		//		return !ProductIsMeetingOrCourse() || productArea.OmitfromSearch.Checked || productType.OmitfromSearch.Checked ||
		//		       !ActiveStatusFlag() || productClass.OmitfromSearch.Checked || !IsActiveDates();
		//	}
		//	else
		//	{
		//		return true;
		//	}
		//}

		//private bool ActiveStatusFlag()
		//{
		//	return Status.Text.Equals("A");
		//}

		//private bool IsActiveDates()
		//{
		//	DateTime now = DateTime.Now;
		//	return now >= WebDisplayStartDate.DateTime && (now < WebDisplayEndDate.DateTime || WebDisplayEndDate.DateTime.Year < 1900);
		//}

		//#endregion

		#region IListItem

		public string LiTopic
		{
			get { return string.Empty; }
		}

		public string LiTitle
		{
			get
			{
				//return GetProductDetailTitle();
				return Name.Text;
			}
		}

		public string LiDescription
		{
			get { return ShortDescription.Text; }
		}

		public string LiUrl
		{
			get { return GetProductDetailUrl(); }
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
			get
			{
				PersonifyTaxonomyItem item = ProductClass.Item;
				if (item != null)
				{
					return item.DisplayName.Text;
				}
				return "Product";
			}
		}

		public DateTime LiDate
		{
			get
			{
				DateTime date = MeetingStartDate.DateTime;
				if (date != DateTime.MinValue)
				{
					return date;
				}
				else
				{
					return DateTime.MinValue;
				}
			}
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
				//get our product class so we can try to determine what type of meeting we are
				Item productClass = ProductClass.Item;

				//if our product class is null then we can't determine, just return none
				if (productClass == null)
				{
					return MeetingType.None;
				}

				//if our product class is ACR then return ACR meeting type
				if (ProductIsAcrMeeting())
				{
					return MeetingType.ACR;
				}

				//if our product class is EDCR then return education center meeting type
				if (ProductIsEduCenterMeeting())
				{
					return MeetingType.EducationCenter;
				}

				//we are not a specific meeting type, return none
				return MeetingType.None;
			}
		}

		public string MeetingTitle
		{
			get
			{
				//if we aren't a valid meeting then return empty string
				if (!ProductIsMeetingOrCourse())
				{
					return string.Empty;
				}

				//if we don't have a name then return empty string
				if (Name == null)
				{
					return string.Empty;
				}

				//return our name as our title
				//return GetProductDetailTitle();
				return Name.Text;
			}
		}

		public string MeetingSubtitle
		{
			get
			{
				//our product stub doesn't have a meeting subtitle
				return string.Empty;
			}
		}

		DateTime IMeeting.MeetingStartDate
		{
			get
			{
				//if we aren't a valid meeting then return min value
				if (!ProductIsMeetingOrCourse())
				{
					return DateTime.MinValue;
				}

				//if we don't have a start date then return min value
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
				//if we aren't a valid meeting then return min value
				if (!ProductIsMeetingOrCourse())
				{
					return DateTime.MinValue;
				}

				//if we don't have an end date then return min value
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
				//if we aren't a valid meeting then return empty string
				if (!ProductIsMeetingOrCourse())
				{
					return string.Empty;
				}

				//we will be compiling our meeting location from meeting city and state.
				StringBuilder location = new StringBuilder();

				//if we have a city then add it to our location
				if (MeetingCity != null)
				{
					location.Append(MeetingCity.Text);
				}

				//if we have a state then add it to our location
				if (MeetingState != null)
				{
					//first check if we should add a comma
					if (location.Length > 0)
					{
						location.Append(", ");
					}

					location.Append(MeetingState.Text);
				}

				//return our meeting location
				return location.ToString();
			}
		}

		public string MeetingVenue
		{
			get
			{
				//currently product stubs don't have meeting venue's
				return string.Empty;
			}
		}

		public string MeetingDescription
		{
			get
			{
				//if we aren't a valid meeting then return empty string
				if (!ProductIsMeetingOrCourse())
				{
					return string.Empty;
				}

				//if we don't have a long description then return empty string
				if (LongDescription == null)
				{
					return string.Empty;
				}

				//return our long description
				return LongDescription.Text;
			}
		}

		public string MeetingShortDescription
		{
			get
			{
				//if we aren't a valid meeting then return empty string
				if (!ProductIsMeetingOrCourse())
				{
					return string.Empty;
				}

				//if we don't have a short description then return empty string
				if (ShortDescription == null)
				{
					return string.Empty;
				}
				// 1/31/2012 CMS: Acr wants these suppressed for now, they'll probably change their minds once it's deployed
				return string.Empty;

				//return our short description
				return ShortDescription.Text;
			}
		}

		public string MeetingObjectives
		{
			get
			{
				//product stubs don't have meeting objectives
				return string.Empty;
			}
		}

		public string MeetingTestimonials
		{
			get
			{
				//product stubs don't have meeting testimonials
				return string.Empty;
			}
		}

		public string MeetingImageUrl
		{
			get
			{
				//if we aren't a valid meeting then return empty string
				if (!ProductIsMeetingOrCourse())
				{
					return string.Empty;
				}

				//return our small image url
				return GetSmallImageUrl();
			}
		}

		public string MeetingSummaryUrl
		{
			get
			{
				return GetProductDetailUrl();
			}
		}

		public string MeetingRegisterUrl
		{
			get
			{
				//if we aren't a valid meeting then return empty string
				if (!ProductIsMeetingOrCourse())
				{
					return string.Empty;
				}

				//return our product detail url
				return GetProductDetailUrl(true);
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
				//product stubs don't have an additional website url
				return string.Empty;
			}
		}

		public int MeetingCmeCredit
		{
			get
			{
				//if we aren't a valid meeting then return -1
				if (!ProductIsMeetingOrCourse())
				{
					return -1;
				}

				//if we don't have a cme credit field then return -1
				if (CMECredit == null)
				{
					return -1;
				}

				//get our cme credit
				int cmeCredit;
				if (!int.TryParse(CMECredit.Text, out cmeCredit))
				{
					cmeCredit = -1;
				}

				//return our cme credit
				return cmeCredit;
			}
		}

		public List<IListItem> MeetingDocuments
		{
			get
			{
				//product stubs don't have meeting documents
				return new List<IListItem>(0);
			}
		}

		public List<IMeeting> MeetingOccurrences
		{
			get
			{
				//if we aren't a valid meeting then return empty list
				if (!ProductIsMeetingOrCourse())
				{
					return new List<IMeeting>(0);
				}

				//try to get our roll up page
				CourseMeetingSummaryItem summaryPage = GetCourseRollUpPage();

				//if we don't have a roll up page then return empty list
				if (summaryPage == null)
				{
					return new List<IMeeting>(0);
				}

				//get all our meeting products from the roll up page.
				List<ProductStubItem> meetingProducts = summaryPage.GetMeetingProducts();

				//if we don't have any products then return an empty list
				if (meetingProducts == null || !meetingProducts.Any())
				{
					return new List<IMeeting>(0);
				}

				//remove our current product from the list
				meetingProducts = meetingProducts.Where(i => i.ID.ToString() != ID.ToString()).ToList();

				//order our meeting products
				meetingProducts = meetingProducts.OrderBy(m => m.MeetingStartDate.DateTime).ToList();

				//return our products as IMeeting objects
				return ItemInterfaceFactory.GetItems<IMeeting>(meetingProducts.Select(i => (Item)i).ToList());
			}
		}

		public List<IListItem> MeetingAccommodations
		{
			get
			{
				//product stubs don't have meeting accommodations
				return new List<IListItem>(0);
			}
		}

		public List<IAcrPersonnel> MeetingContacts
		{
			get
			{
				//product stubs don't have meeting contacts
				return new List<IAcrPersonnel>(0);
			}
		}

		public List<Item> MeetingAssociatedItems
		{
			get { return new List<Item>(); } 
		}

		#endregion
	}
}
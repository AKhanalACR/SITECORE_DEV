using System;
using System.Text;
using ACR.Library.ACR.Meetings;
using ACR.Library.Reference;
using ACR.Library.Search.Indices.Meetings;
using ACR.Library.Utils;
using ACR.Library.Utils.ACR;
using ACR.Lucene.Options;
using ACR.Lucene.Util;
using Sitecore.Collections;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.Products
{
	public partial class ProductStubItem
	{
		public enum StockStatusEnum
		{
			InStock,
			SoldOut,
			Available,
			WaitList,
			Full,
			BackOrder,
			NA
		}

		public bool ProductIsMeetingOrCourse()
		{
			Item productArea = this.ProductArea.Item;
			return (productArea != null &&
							(productArea.ID.ToString() == ItemReference.ACR_ProductArea_MTG.Guid));
		}

		private string MeetingTypeString()
		{
            //Please note order is important here. AIRP and RLI items are identified by product class. 
            //They end up classified as subset of ACR or EDU Center Meeting types which are identified by product area
            //So we need to check AIRP and RLI types before ACR and EduCenter, otherwise AIRP and RLI type will 
            //get sorted as either ACR or EDU Center Meeting types
            /*if (ProductIsAirpMeeting())
			{
				return MeetingTypeParameter.AIRPMeetingType;				
			}
			else if (ProductIsRliMeeting())
			{
				return MeetingTypeParameter.RLIMeetingType;								
			}
			else if (ProductIsAcrMeeting())
			{
				return MeetingTypeParameter.ACRMeetingType;
			}
			else if (ProductIsEduCenterMeeting())
			{
				return MeetingTypeParameter.EducationCenterMeetingType;
			}
			else*/
            return "Meeting";
		}

		private bool ProductIsAirpMeeting()
		{
			Item productClass = this.ProductClass.Item;
			return (productClass != null &&
							(productClass.ID.ToString() == ItemReference.ACR_ProductClass_MTG_AIRP.Guid));
		}

		private bool ProductIsRliMeeting()
		{
			Item productClass = this.ProductClass.Item;
			return (productClass != null &&
							(productClass.ID.ToString() == ItemReference.ACR_ProductClass_MTG_RLI.Guid));
		}

		public bool ProductIsAcrMeeting()
		{
			return ProductIsMeetingOrCourse() && !string.IsNullOrEmpty(MeetingRegistrationFormUrl.Text);
		}

		public bool ProductIsEduCenterMeeting()
		{
			return ProductIsMeetingOrCourse() && string.IsNullOrEmpty(MeetingRegistrationFormUrl.Text);
		}

		public CourseMeetingSummaryItem GetCourseRollUpPage()
		{
			//This is only valid for ACR Meetings and Education Center meetings
			if (!ProductIsMeetingOrCourse())
			{
				return null;
			}

			MeetingsIndex index = new MeetingsIndex();
			SafeDictionary<string> filters = new SafeDictionary<string>();
			filters.Add(CourseMeetingSummaryItem.FieldName_Products, this.ID.ToString());
            var item = index.GetMeeting(CourseMeetingSummaryItem.FieldName_Products, this.ID.ToString());
            if (item != null)
            {
                return item;
            }
            /*
            List <LightweightItem> items = index.GetLightweightItems(filters, new SearchOptions());
			if (items.Count > 0)
			{
				return Sitecore.Context.Database.GetItem(items[0].ItemID);
			}*/
			return null;
		}

		private string getMeetingSummaryPageContent()
		{
			CourseMeetingSummaryItem meetingSummary = GetCourseRollUpPage();
			if (meetingSummary != null)
			{
				//Build the indexable content
				StringBuilder content = new StringBuilder();
				content.AppendLine(meetingSummary.MeetingTitle.Text);
				content.AppendLine(meetingSummary.Overview.Text);
				content.AppendLine(meetingSummary.ProgramsandObjectives.Text);
				content.AppendLine(meetingSummary.Testimonials.Text);
				content.AppendLine(meetingSummary.HotelName1.Text);
				content.AppendLine(meetingSummary.HotelName2.Text);
				content.AppendLine(meetingSummary.HotelName3.Text);
				content.AppendLine(meetingSummary.HotelLocation1.Text);
				content.AppendLine(meetingSummary.HotelLocation2.Text);
				content.AppendLine(meetingSummary.HotelLocation3.Text);
				return content.ToString();
			}

			return string.Empty;
		}

		/// <summary>
		/// Gets the product small image url prefixed with the shop.acr.org url path
		/// </summary>
		/// <returns></returns>
		public string GetSmallImageUrl()
		{
			return GetImageUrl(ImageSmallUrl.Text);
		}

		/// <summary>
		/// Gets the product large image url prefixed with the shop.acr.org url path
		/// </summary>
		/// <returns></returns>
		public string GetLargeImageUrl()
		{
			return GetImageUrl(ImageLargeUrl.Text);
		}

		private string GetImageUrl(string imageFieldValue)
		{
			if (string.IsNullOrEmpty(imageFieldValue))
			{
				return string.Empty;
			}

			if (imageFieldValue.StartsWith("http"))
			{
				return imageFieldValue;
			}

			return string.Format("{0}{1}", ACRSettings.AcrProductsProductImageUrlRoot, imageFieldValue);
		}

		public string GetProductDetailTitle()
		{
			return GetProductDetailTitle(false);
		}

		public string GetProductDetailTitle(bool ignoreSummaryPage)
		{
			//In this case, use the roll up page if we are not ignoring the summary page.
			if (ProductIsMeetingOrCourse() && !ignoreSummaryPage)
			{
				CourseMeetingSummaryItem rollUp = GetCourseRollUpPage();
				if (rollUp != null)
				{
					return rollUp.HeaderTitle;
				}
			}

			if (string.IsNullOrEmpty(PersonifyID.Text))
			{
				return string.Empty;
			}

			//All other cases, go to the product detail
			return Name.Text;
		}

		public string GetProductDetailUrl()
		{
			return GetProductDetailUrl(false);
		}

		public string GetProductDetailUrl(bool ignoreSummaryPage)
		{
			//In this case, use the roll up page if we are not ignoring the summary page.
			if (ProductIsMeetingOrCourse() && !ignoreSummaryPage)
			{
				CourseMeetingSummaryItem rollUp = GetCourseRollUpPage();
				if (rollUp != null)
				{
					return LinkUtils.GetItemFullUrl(rollUp);
				}
			}

			if (string.IsNullOrEmpty(PersonifyID.Text))
			{
				return string.Empty;
			}

			if (ProductIsAcrMeeting())
			{
				return MeetingRegistrationFormUrl.Text;
			}
			if (ProductIsEduCenterMeeting())
			{
				return ACRSettings.AcrProductsCourseMeetingUrlRoot + "&ProductId=" + PersonifyID.Text;
			}

			//All other cases, go to the product detail
			return ACRSettings.AcrProductsProductUrlRoot + "&ProductId=" + PersonifyID.Text;
		}

		public string GetStockStatusCssClass()
		{
			string cssClass = String.Empty;

			switch (GetStockStatus())
			{
				case StockStatusEnum.InStock:
				case StockStatusEnum.Available:
					cssClass = " stock";
					break;
				case StockStatusEnum.SoldOut:
				case StockStatusEnum.Full:
					cssClass = " sold";
					break;
				case StockStatusEnum.WaitList:
				case StockStatusEnum.BackOrder:
					cssClass = " waitlist";
					break;
				default:
					break;
			}

			return cssClass;
		}

		public StockStatusEnum GetStockStatus()
		{
			StockStatusEnum stockStatus = StockStatusEnum.NA;

			switch (this.StockStatus.Text.ToLower())
			{
				case "in stock":
				case "in_stock":
				case "instock":
					stockStatus = StockStatusEnum.InStock;
					break;
				case "out of stock":
				case "out_of_stock":
				case "outofstock":
					stockStatus = StockStatusEnum.SoldOut;
					break;
				case "available":
					stockStatus = StockStatusEnum.Available;
					break;
				case "wait list":
				case "wait_list":
				case "waitlist":
					stockStatus = StockStatusEnum.WaitList;
					break;
				case "full":
					stockStatus = StockStatusEnum.Full;
					break;
				case "back_order":
				case "backorder":
				case "back order":
					stockStatus = StockStatusEnum.BackOrder;
					break;
				default:
					stockStatus = StockStatusEnum.NA;
					break;
			}

			return stockStatus;
		}

		public String ReturnStockStatusText(StockStatusEnum sse)
		{
			String stockStatusText = String.Empty;

			switch (sse)
			{
				case StockStatusEnum.Available:
					stockStatusText = "Available";
					break;
				case StockStatusEnum.InStock:
					stockStatusText = "In Stock";
					break;
				case StockStatusEnum.WaitList:
					stockStatusText = "Waitlist";
					break;
				case StockStatusEnum.Full:
					stockStatusText = "Full";
					break;
				case StockStatusEnum.SoldOut:
					stockStatusText = "Sold Out";
					break;
				case StockStatusEnum.BackOrder:
					stockStatusText = "Backordered";
					break;
				default:
					break;
			}

			return stockStatusText;
		}

		/// <summary>
		/// Returns true if WebDisplay is checked and the web display dates are in a valid range
		/// </summary>
		/// <returns></returns>
		public bool WebDisplayValid()
		{
			if (!WebDisplay.Checked)
			{
				return false;
			}
			if (WebDisplayStartDate.DateTime != DateTime.MinValue
				&& WebDisplayStartDate.DateTime >= DateTime.Now)
			{
				return false;
			}
			if (WebDisplayEndDate.DateTime != DateTime.MinValue
				&& WebDisplayEndDate.DateTime <= DateTime.Now)
			{
				return false;
			}
			return true;
		}
	}
}
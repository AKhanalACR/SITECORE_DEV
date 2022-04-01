using System;
using ACR.Library.ACR.Products;
using ACR.Library.Common.Interfaces;
using ACR.Library.CustomItems.ACR.Interface;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.CodingSource
{
	public partial class CodingSourceWideDetailPageItem : IAcrContent
	{
		#region IAcrContent
		public string HeaderTitle
		{
			get
			{
				CodingSourceDetailPageItem thisPage = InnerItem;
				return thisPage.GetIndexPage().BasePage.PageTitle.Text;
			}
		}

		public string ContentTitle
		{
			get { return CodingSourceDetailPage.BasePage.ContentTitle; }
		}

		public string ContentSubTitle
		{
			get { return CodingSourceDetailPage.BasePage.ContentSubTitle; }
		}

		public DateTime ContentDate
		{
			get { return CodingSourceDetailPage.BasePage.ContentDate; }
		}

		public string ContentAuthor
		{
			get { return CodingSourceDetailPage.BasePage.ContentAuthor; }
		}

		public string ContentImageUrl
		{
			get
			{
				return (CodingSourceDetailPage != null && CodingSourceDetailPage.Image.MediaItem != null)
				       	? Sitecore.Resources.Media.MediaManager.GetMediaUrl(CodingSourceDetailPage.Image.MediaItem)
				       	: string.Empty;
			}
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
			get { return CodingSourceDetailPage.BasePage.ContentBodyText; }
		}

		public string ContentAdditionalInformation
		{
			get { return CodingSourceDetailPage.BasePage.ContentAdditionalInformation; }
		}

		public string ContentResourceTitle
		{
			get { return CodingSourceDetailPage.ContentResourceTitle; }
		}

		public IList<IListItem> ContentResourceLinks
		{
			get { return CodingSourceDetailPage.ContentResourceLinks; }
		}

		public string ContentProductsTitle
		{
			get { return CodingSourceDetailPage.ContentProductsTitle; }
		}

		public IList<ProductStubItem> ContentProducts
		{
			get { return CodingSourceDetailPage.ContentProducts; }
		}
		#endregion

		#region ICoveoCrawlable
		public string CoveoTitle(string collectionName)
		{
			return CodingSourceDetailPage.BasePage.HeaderTitle.Text;
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
			return CodingSourceDetailPage.PublicationDate.DateTime;
		}

		public DateTime CoveoCreatedDate(string collectionName)
		{
			return InnerItem.Publishing.PublishDate;
		}

		public string CoveoDisplayDate(string collectionName)
		{
			return CoveoDate(collectionName).ToString(AcrConstants.DateFormats.MonthDayYear);
		}

		public Dictionary<string, string> CoveoAdditionalFields(string collectionName)
		{
			var additionalFields = new Dictionary<string, string>();
			
			//additionalFields.Add(CoveoFields.ContentType.FieldName, "Coding Source");

			return additionalFields;
		}

		public bool CoveoExcludeFromIndex(string collectionName)
		{
            //only allow through general search collection crawlers
            //return collectionName != SearchContext.ACRGeneralCollectionName && !SearchContext.ACRGeneralCollectionName.StartsWith(collectionName);
            return false;
		}
		#endregion
	}
}
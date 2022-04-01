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
	public partial class CodingSourceIndexItem : IAcrContent
	{
		#region IAcrContent
		public string HeaderTitle
		{
			get { return BasePage.HeaderTitle.Text; }
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
			get
			{
				return (Image != null && Image.MediaItem != null) ? Sitecore.Resources.Media.MediaManager.GetMediaUrl(Image.MediaItem) : string.Empty;
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
			get { return BasePage.ContentBodyText; }
		}

		public string ContentAdditionalInformation
		{
			get { return BasePage.ContentAdditionalInformation; }
		}

		public string ContentResourceTitle
		{
			get { return RelatedDocumentsPage.RelatedResourceHeader.Text; }
		}

		public IList<IListItem> ContentResourceLinks
		{
			get { return RelatedDocumentsPage.GetResourceItems(); }
		}

		public string ContentProductsTitle
		{
			get { return RelatedProductsPage.FeaturedProductsHeader.Text; }
		}

		public IList<ProductStubItem> ContentProducts
		{
			get { return RelatedProductsPage.GetProducts(); }
		}
		#endregion
	}
}
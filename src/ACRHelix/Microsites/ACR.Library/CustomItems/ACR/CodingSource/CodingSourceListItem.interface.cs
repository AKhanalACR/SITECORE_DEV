using System;
using ACR.Library.ACR.Products;
using ACR.Library.Common.Interfaces;
using ACR.Library.CustomItems.ACR.Interface;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.CodingSource
{
	public partial class CodingSourceListItem : IAcrContent, INavigationItem
	{
		#region IAcrContent
		public string HeaderTitle
		{
			get { return BasePage.PageTitle.Text; }
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

		#region INavigationItem

		public string NavShortTitle
		{
			get { return BasePage.ShortTitle.Text; }
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
			get { return true; }
		}

		public bool ShowInFooter
		{
			get { return false; }
		}

		public bool ShowInSitemap
		{
			get { return true; }
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
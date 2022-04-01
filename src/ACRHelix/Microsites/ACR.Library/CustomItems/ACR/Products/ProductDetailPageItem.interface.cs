using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.ACR.Education;
using ACR.Library.Common.Interfaces;
using ACR.Library.CustomItems.ACR.Interface;
using ACR.Library.Reference;
using ACR.Library.Utils;
using Sitecore.Collections;
using Sitecore.Data.Items;

namespace ACR.Library.ACR.Products
{
	public partial class ProductDetailPageItem : IAcrContent, INavigationItem, ITaxonomyPage, IMeta
	{
		#region Implementation of IAcrContent

		public string HeaderTitle
		{
			get 
			{ 
				Item edCat = ItemReference.ACR_EducationCatalogLanding.InnerItem;
				return TitleFactory.GetACRHeaderTitle(edCat);
			}
		}

		public string ContentTitle
		{
			get { return this.BasePage.ContentTitle; }
		}

		public string ContentSubTitle
		{
			get { return this.BasePage.ContentSubTitle; }
		}

		public DateTime ContentDate
		{
			get { return this.BasePage.ContentDate; }
		}

		public string ContentAuthor
		{
			get { return this.BasePage.ContentAuthor; }
		}

		public string ContentImageUrl
		{
			get { return this.BasePage.ContentImageUrl; }
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
			get { return this.BasePage.ContentBodyText; }
		}

		public string ContentAdditionalInformation
		{
			get { return this.BasePage.ContentAdditionalInformation; }
		}

		public string ContentResourceTitle
		{
			get { return this.BasePage.ContentResourceTitle; }
		}

		public IList<Common.Interfaces.IListItem> ContentResourceLinks
		{
			get { return this.BasePage.ContentResourceLinks; }
		}

		public string ContentProductsTitle
		{
			get { return RelatedProductsPage.FeaturedProductsHeader.Text; }
		}

		public IList<Library.ACR.Products.ProductStubItem> ContentProducts
		{
			get { return RelatedProductsPage.GetProducts(); }
		}

		#endregion

		#region Implementation of INavigationItem

		public string NavShortTitle
		{
			get
			{
				var stub = GetStubItem(Sitecore.Context.Request);
				if (stub != null)
				{
					return stub.Name.Text;
				}
				return BasePage.NavShortTitle;
			}
		}

		public bool HideBreadcrumb
		{
			get { return BasePage.HideBreadcrumb; }
		}

		public bool ShowInTopNavigation
		{
			get { return BasePage.ShowInTopNavigation;}
		}

		public bool ShowInSideNavigation
		{
			get { return BasePage.ShowInSideNavigation; }
		}

		public bool ShowInFooter
		{
			get { return BasePage.ShowInFooter; }
		}

		public bool ShowInSitemap
		{
			get { return BasePage.ShowInSitemap; }
		}

		public bool HideSideNavigation
		{
			get { return BasePage.HideSideNavigation; }
		}

		public bool HideTextControl
		{
			get { return BasePage.HideTextSizeOption.Checked; }
		}

		public bool HideToolbarControl
		{
			get { return BasePage.HideToolbar.Checked; }
		}

		public string NavUrl
		{
			get
			{
				if (Sitecore.Context.Request != null)
				{
					return Sitecore.Context.Request.ItemPath;
				}
				return string.Empty;
			}
		}

		#endregion

		#region Implementation of ITaxonomyPage

		/// <summary>
		/// Use the product's taxonomy rather than the detail page's taxonomy.
		/// </summary>
		/// <param name="taxonomyType"></param>
		/// <returns></returns>
		public SafeDictionary<string> BuildSafeDictionaryFromItem(string taxonomyType)
		{
			var stub = this.GetStubItem(Sitecore.Context.Request);
			if (stub == null)
			{
				return new SafeDictionary<string>();
			}
			return stub.TaxonomyContent.BuildSafeDictionaryFromItem(taxonomyType);
		}

		#endregion

		#region Implementation of IMeta

		public string MetaTitle
		{
			get { return _productStub.Name.Text; }
		}

		public string MetaDescription
		{
			get { return ""; }
		}

		public string MetaKeywords
		{
			get { return _productStub.Keywords.Text; }
		}

		public string MetaDate
		{
			get { return ""; }
		}

		public string MetaVerify
		{
			get { return ""; }
		}

		#endregion
	}
}

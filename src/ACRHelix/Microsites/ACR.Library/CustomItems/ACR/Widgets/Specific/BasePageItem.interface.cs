using System;
using System.Linq;
using ACR.Library.ACR.Products;
using ACR.Library.ACR.Taxonomy;
using ACR.Library.Common.Interfaces;
using ACR.Library.CustomItems.ACR.Interface;
using ACR.Library.Utils;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.Base
{
	public partial class BasePageItem : IAcrContent, INavigationItem, IMeta, IAcrProtectedContent
	{
		#region Implementation of IAcrContent

		string IAcrContent.HeaderTitle
		{
			get { return TitleFactory.GetACRHeaderTitle(InnerItem); }
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
			get { return BodyText.Text; }
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
			get { return new List<IListItem>(); }
		}

		public string ContentProductsTitle
		{
			get { return string.Empty; }
		}

		public IList<ProductStubItem> ContentProducts
		{
			get { return new List<ProductStubItem>(); }
		}

		#endregion

		#region Implementation of INavigationOptions

		public string NavShortTitle
		{
			get { return ShortTitle.Text; }
		}

		public bool HideBreadcrumb
		{
			get { return NavigationOptions.HideBreadcrumb.Checked; }
		}

		public bool ShowInTopNavigation
		{
			get { return NavigationOptions.ShowinTopNavigation.Checked; }
		}

		public bool ShowInSideNavigation
		{
			get { return NavigationOptions.ShowinSideNavigation.Checked; }
		}

		public bool ShowInFooter
		{
			get { return NavigationOptions.ShowinFooter.Checked; }
		}

		public bool ShowInSitemap
		{
			get { return NavigationOptions.ShowinSitemap.Checked; }
		}

		public bool HideSideNavigation
		{
			get { return NavigationOptions.HideSideNavigation.Checked; }
		}

		public string NavUrl
		{
			get { return LinkManager.GetItemUrl(this); }
		}

		public bool HideTextControl
		{
			get { return HideTextSizeOption.Checked; }
		}

		public bool HideToolbarControl
		{
			get { return HideToolbar.Checked; }
		}

		#endregion

		#region Implementation of IMeta

		public string MetaTitle
		{
			get { return ""; }
		}

		string IMeta.MetaDescription
		{
			get { return this.MetaDescription.Text; }
		}

		string IMeta.MetaKeywords
		{
			get { return this.MetaKeywords.Text; }
		}

		public string MetaDate
		{
			get { return null; }
		}

		public string MetaVerify
		{
			get { return null; }
		}
		#endregion

		#region Implementation of IAcrProtectedContent

		public bool RequiresMembership
		{
			get { return RequiresACRMembership.Checked; }
		}

		private List<ProductStubItem> _requiredProducts; 
		public List<ProductStubItem> RequiresProducts
		{
			get
			{
				if (_requiredProducts == null)
				{
					_requiredProducts = new List<ProductStubItem>();
					if (RequiredProducts.ListItems != null)
					{
						var stubs = RequiredProducts.ListItems
							.Where(p => p.TemplateID.ToString() == ProductStubItem.TemplateId)
							.Select(p => new ProductStubItem(p));
						_requiredProducts.AddRange(stubs);
					}
				}
				return _requiredProducts;
			}
		}

		private List<PersonifyTaxonomyItem> _requiresRoles;
		public List<PersonifyTaxonomyItem> RequiresRoles
		{
			get
			{
				if (_requiresRoles == null)
				{
					_requiresRoles = new List<PersonifyTaxonomyItem>();
					if (RequiredRoles.ListItems != null)
					{
						var roles = RequiredRoles.ListItems
							.Where(p => p.TemplateID.ToString() == PersonifyTaxonomyItem.TemplateId)
							.Select(p => new PersonifyTaxonomyItem(p));
						_requiresRoles.AddRange(roles);
					}
				}
				return _requiresRoles;
			}
		}

		#endregion
	}
}
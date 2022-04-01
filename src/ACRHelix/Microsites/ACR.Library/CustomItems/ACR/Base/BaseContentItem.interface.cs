using System;
using ACR.Library.ACR.Products;
using ACR.Library.ACR.Taxonomy;
using ACR.Library.Common.Interfaces;
using ACR.Library.CustomItems.ACR.Interface;
using ACR.Library.Utils;
using CustomItemGenerator.Fields.SimpleTypes;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.Base
{
	public partial class BaseContentItem : IListItemFeaturedParent, IAcrContent, IAcrProtectedContent
	{
		#region Implementation of IAcrContent

		public string HeaderTitle
		{
			get { return ((IAcrContent)BasePage).HeaderTitle; }
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
						return (HeaderImage != null && HeaderImage.MediaItem != null) ? Sitecore.Resources.Media.MediaManager.GetMediaUrl(HeaderImage.MediaItem) : string.Empty;
	        }
	    }

		public bool ReplacePageTitleBannerWithHeaderImage
		{
			get
			{
				return (HeaderImage != null && HeaderImage.MediaItem != null && ReplaceBannerWithHeaderImage.Checked);
			}
		}

	    public string ContentBodyText
		{
			get { return BasePage.ContentBodyText; }
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

		#region Implementation of IListItemFeaturedParent

		public bool liSuppressParentPageFeature
		{
			get { return SuppressParentPageFeature.Checked; }
		}

		public CustomImageField liParentPageThumbnail
		{
			get { return ParentPageThumbnail; }
		}

		public CustomTextField liParentPageIntroText
		{
			get { return ParentPageIntroText; }
		}

		public CustomTextField liPageTitle
		{
			get { return BasePage.PageTitle; }
		}

		public bool liIsExternal
		{
			get { return false; }
		}

		public string NavUrl
		{
			get { return LinkManager.GetItemUrl(InnerItem); }
		}

		#endregion

		#region Implementation of IAcrProtectedContent

		public bool RequiresMembership
		{
			get { return BasePage.RequiresMembership; }
		}

		public List<ProductStubItem> RequiresProducts
		{
			get { return BasePage.RequiresProducts; }
		}

		public List<PersonifyTaxonomyItem> RequiresRoles
		{
			get { return BasePage.RequiresRoles; }
		}

		#endregion
	}
}
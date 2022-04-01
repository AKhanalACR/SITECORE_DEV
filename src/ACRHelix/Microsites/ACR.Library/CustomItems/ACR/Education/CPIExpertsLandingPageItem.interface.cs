using System;
using ACR.Library.ACR.Products;
using ACR.Library.Common.Interfaces;
using ACR.Library.CustomItems.ACR.Interface;
using CustomItemGenerator.Fields.SimpleTypes;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.Education
{
    public partial class CPIExpertsLandingPageItem : IListItemFeaturedParent, IAcrContent
	{
		#region IListItemFeaturedParent Implementation

		//FeaturedParent Interface
		public bool liSuppressParentPageFeature
		{
			get { return BaseContent.SuppressParentPageFeature.Checked; }
		}

		public CustomImageField liParentPageThumbnail
		{
			get { return BaseContent.ParentPageThumbnail; }
		}

		public CustomTextField liParentPageIntroText
		{
			get { return BaseContent.ParentPageIntroText; }
		}

		public CustomTextField liPageTitle
		{
			get { return BasePage.PageTitle; }
		}

		public string NavUrl
		{
			get { return BasePage.NavUrl; }
		}

		public bool liIsExternal
		{
			get { return false; }
		}

		#endregion

		#region Implementation of IAcrContent

		public string HeaderTitle
		{
			get { return BaseContent.HeaderTitle; }
		}

		public string ContentTitle
		{
			get { return BaseContent.ContentTitle; }
		}

		public string ContentSubTitle
		{
			get { return BaseContent.ContentSubTitle; }
		}

		public DateTime ContentDate
		{
			get { return BaseContent.ContentDate; }
		}

		public string ContentAuthor
		{
			get { return BaseContent.ContentAuthor; }
		}

		public string ContentImageUrl
		{
			get { return BaseContent.ContentImageUrl; }
		}

		public bool ReplacePageTitleBannerWithHeaderImage
		{
			get
			{
				return BaseContent.ReplacePageTitleBannerWithHeaderImage;
			}
		}

		public string ContentBodyText
		{
			get { return BaseContent.ContentBodyText; }
		}

		public string ContentAdditionalInformation
		{
			get { return string.Empty; }
		}

		public string ContentResourceTitle
		{
			get { return String.Empty; }
		}

		public IList<IListItem> ContentResourceLinks
		{
			get { return null; }
		}

		public string ContentProductsTitle
		{
			get { return String.Empty; }
		}

		public IList<ProductStubItem> ContentProducts
		{
			get { return null; }
		}

		#endregion

	}
}
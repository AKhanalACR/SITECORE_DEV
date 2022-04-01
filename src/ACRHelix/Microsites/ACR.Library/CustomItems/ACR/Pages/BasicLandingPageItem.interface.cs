using System;
using ACR.Library.ACR.Products;
using ACR.Library.Common.Interfaces;
using ACR.Library.CustomItems.ACR.Interface;
using ACR.Library.Utils;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.ACR.Pages
{
	public partial class BasicLandingPageItem : IListItemFeaturedParent, INavigationItem, IAcrContent, IAcrEducationCenterFeature
	{
		private string _customWeight = "10";

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
			get { return BaseContent.BasePage.PageTitle; }
		}

		public bool liIsExternal
		{
			get { return false; }
		}

		public string NavShortTitle
		{
			get { return BaseContent.BasePage.ShortTitle.Text; }
		}

		public bool HideBreadcrumb
		{
			get { return BaseContent.BasePage.NavigationOptions.HideBreadcrumb.Checked; }
		}

		public bool ShowInTopNavigation
		{
			get { return BaseContent.BasePage.NavigationOptions.ShowinTopNavigation.Checked; }
		}

		public bool ShowInSideNavigation
		{
			get { return BaseContent.BasePage.NavigationOptions.ShowinSideNavigation.Checked; }
		}

		public bool ShowInFooter
		{
			get { return BaseContent.BasePage.NavigationOptions.ShowinFooter.Checked; }
		}

		public bool ShowInSitemap
		{
			get { return BaseContent.BasePage.NavigationOptions.ShowinSitemap.Checked; }
		}

		public bool HideSideNavigation
		{
			get { return BaseContent.BasePage.NavigationOptions.HideSideNavigation.Checked; }
		}

		public bool HideTextControl
		{
			get { return BaseContent.BasePage.HideTextSizeOption.Checked; }
		}

		public bool HideToolbarControl
		{
			get { return BaseContent.BasePage.HideToolbar.Checked; }
		}

		public string NavUrl
		{
			get { return LinkManager.GetItemUrl(this); }
		}

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
			get { return BaseContent.ReplacePageTitleBannerWithHeaderImage; }
		}

		public string ContentBodyText
		{
			get { return BaseContent.ContentBodyText; }
		}

		public string ContentAdditionalInformation
		{
			get { return BaseContent.ContentAdditionalInformation; }
		}

		public string ContentResourceTitle
		{
			get { return BaseContent.ContentResourceTitle; ; }
		}

		public IList<IListItem> ContentResourceLinks
		{
			get { return BaseContent.ContentResourceLinks; }
		}

		public string ContentProductsTitle
		{
			get { return BaseContent.ContentProductsTitle; }
		}

		public IList<ProductStubItem> ContentProducts
		{
			get { return BaseContent.ContentProducts; }
		}

		#endregion

		//#region ICoveoCrawlable

		//public string CoveoTitle(string collectionName)
		//{
		//	return StringUtil.GetNonEmptyString(BaseContent.BasePage.HeaderTitle.Text, BaseContent.BasePage.ShortTitle.Text, BaseContent.BasePage.PageTitle.Text, BaseContent.BasePage.Name);
		//}

		//public string CoveoOverrideUrl(string collectionName)
		//{
		//	return string.Empty;
		//}

		//public string CoveoDescription(string collectionName)
		//{
		//	return StringUtil.GetNonEmptyString(BaseContent.BasePage.MetaDescription.Text, BaseContent.ParentPageIntroText.Text, BaseContent.ContentBodyText);
		//}

		//public DateTime CoveoDate(string collectionName)
		//{
		//	return BaseContent.BasePage.InnerItem.Statistics.Updated;
		//}

		//public DateTime CoveoCreatedDate(string collectionName)
		//{
		//	return this.InnerItem.Publishing.PublishDate;
		//}

		//public string CoveoDisplayDate(string collectionName)
		//{
		//	return CoveoDate(collectionName).ToString(AcrConstants.DateFormats.MonthDayYear);
		//}

		//public Dictionary<string, string> CoveoAdditionalFields(string collectionName)
		//{
		//	var additionalFields = new Dictionary<string, string>();

		//	additionalFields.Add(CoveoFields.CustomWeight.FieldName, _customWeight);

		//	if (TaxonomyContent != null)
		//	{
		//		additionalFields.Add(CoveoFields.Modality.FieldName, TaxonomyContent.GetTaxonomyForCoveo(TaxonomyContent.RelatedModalities));
		//		additionalFields.Add(CoveoFields.SubSpecialty.FieldName, TaxonomyContent.GetTaxonomyForCoveo(TaxonomyContent.RelatedSubspecialites));
		//		additionalFields.Add(CoveoFields.Interest.FieldName, TaxonomyContent.GetTaxonomyForCoveo(TaxonomyContent.RelatedInterests));
		//		additionalFields.Add(CoveoFields.MetaData.FieldName, MetaUtils.GetMetaKeywordsForCoveo(BaseContent.BasePage.MetaKeywords.Text));
		//	}
			
		//	additionalFields.Add(CoveoFields.ContentType.FieldName, "Content Page");
			
		//	return additionalFields;
		//}

		//public bool CoveoExcludeFromIndex(string collectionName)
		//{
		//	//only allow through general search collection crawlers
		//	return collectionName != SearchContext.ACRGeneralCollectionName && !SearchContext.ACRGeneralCollectionName.StartsWith(collectionName);
		//}

		//#endregion

		#region IAcrEducationCenterFeature

		public string EducationFeatureTitle
		{
			get
			{
				return EducationCenterFeature.FeaturedName.Text;
			}
		}

		public CustomImageField EducationFeatureThumbnail
		{
			get
			{
				return EducationCenterFeature.FeaturedThumbnail;
			}
		}

		public string EducationFeatureUrl
		{
			get
			{
				return LinkUtils.GetItemUrl(InnerItem);
			}
		}

		#endregion
	}
}


using System;
using ACR.Library.ACR.Products;
using ACR.Library.Common.Interfaces;
using ACR.Library.Common.Interfaces.Factory;
using ACR.Library.CustomItems.ACR.Interface;
using ACR.Library.Reference;
using ACR.Library.Utils;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Links;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.CustomItems.ACR.Pages
{
	public partial class BasicContentPageItem : IListItemFeaturedParent, INavigationItem, IAcrContent, IAcrEducationCenterFeature
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
			get { return BasePage.PageTitle; }
		}

		public bool liIsExternal
		{
			get { return false; }
		}

		public string NavShortTitle
		{
			get { return BasePage.ShortTitle.Text; }
		}

		public bool HideBreadcrumb
		{
			get { return BasePage.NavigationOptions.HideBreadcrumb.Checked; }
		}

		public bool ShowInTopNavigation
		{
			get { return BasePage.NavigationOptions.ShowinTopNavigation.Checked; }
		}

		public bool ShowInSideNavigation
		{
			get { return BasePage.NavigationOptions.ShowinSideNavigation.Checked; }
		}

		public bool ShowInFooter
		{
			get { return BasePage.NavigationOptions.ShowinFooter.Checked; }
		}

		public bool ShowInSitemap
		{
			get { return BasePage.NavigationOptions.ShowinSitemap.Checked; }
		}

		public bool HideSideNavigation
		{
			get { return BasePage.NavigationOptions.HideSideNavigation.Checked; }
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

		//#region ICoveoCrawlable

		//public string CoveoTitle(string collectionName)
		//{
		//	return StringUtil.GetNonEmptyString(BasePage.HeaderTitle.Text, BasePage.ShortTitle.Text, BasePage.PageTitle.Text, BasePage.Name);
		//}

		//public string CoveoOverrideUrl(string collectionName)
		//{
		//	return string.Empty;
		//}

		//public string CoveoDescription(string collectionName)
		//{
		//	return StringUtil.GetNonEmptyString(BasePage.MetaDescription.Text, BaseContent.ParentPageIntroText.Text, BaseContent.ContentBodyText);
		//}

		//public DateTime CoveoDate(string collectionName)
		//{
		//	return BasePage.InnerItem.Statistics.Updated;
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
		//		additionalFields.Add(CoveoFields.MetaData.FieldName, MetaUtils.GetMetaKeywordsForCoveo(BasePage.MetaKeywords.Text));
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
using System;
using System.Collections.Generic;

using ACR.Library.Utils;

namespace ACR.Library.ACR.News
{
public partial class NewsandPublicationsLandingItem
{
	private string _customWeight = "10";

	//#region ICoveoCrawlable

	//	public string CoveoTitle(string collectionName)
	//	{
	//		return StringUtil.GetNonEmptyString(BasePage.HeaderTitle.Text, BasePage.ShortTitle.Text, BasePage.PageTitle.Text, BasePage.Name);
	//	}

	//	public string CoveoOverrideUrl(string collectionName)
	//	{
	//		return string.Empty;
	//	}

	//	public string CoveoDescription(string collectionName)
	//	{
	//		return string.Empty;
	//	}

	//	public DateTime CoveoDate(string collectionName)
	//	{
	//		return BasePage.InnerItem.Statistics.Updated;
	//	}

	//public DateTime CoveoCreatedDate(string collectionName)
	//{
	//	return this.InnerItem.Publishing.PublishDate;
	//}

	//public string CoveoDisplayDate(string collectionName)
	//	{
	//		return CoveoDate(collectionName).ToString(AcrConstants.DateFormats.MonthDayYear);
	//	}

	//	public Dictionary<string, string> CoveoAdditionalFields(string collectionName)
	//	{
	//		var additionalFields = new Dictionary<string, string>();

	//		additionalFields.Add(CoveoFields.CustomWeight.FieldName, _customWeight);

	//		if (TaxonomyContent != null)
	//		{
	//			additionalFields.Add(CoveoFields.Modality.FieldName, TaxonomyContent.GetTaxonomyForCoveo(TaxonomyContent.RelatedModalities));
	//			additionalFields.Add(CoveoFields.SubSpecialty.FieldName, TaxonomyContent.GetTaxonomyForCoveo(TaxonomyContent.RelatedSubspecialites));
	//			additionalFields.Add(CoveoFields.Interest.FieldName, TaxonomyContent.GetTaxonomyForCoveo(TaxonomyContent.RelatedInterests));
	//		}

	//		additionalFields.Add(CoveoFields.ContentType.FieldName, "Content Page");
			
	//		return additionalFields;
	//	}

	//	public bool CoveoExcludeFromIndex(string collectionName)
	//	{
	//		//only allow through general search collection crawlers
	//		return collectionName != SearchContext.ACRGeneralCollectionName && !SearchContext.ACRGeneralCollectionName.StartsWith(collectionName);
	//	}
	//#endregion
}
		
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.Utils;

namespace ACR.Library.CustomItems.ACR.Pages
{
	public partial class WFMFormPageItem
	{
		//#region Implementation of ICoveoCrawlable

		//public string CoveoTitle(string collectionName)
		//{
		//	return _BasicContentPageItem.CoveoTitle(collectionName);
		//}

		//public string CoveoOverrideUrl(string collectionName)
		//{
		//	return _BasicContentPageItem.CoveoOverrideUrl(collectionName);
		//}

		//public string CoveoDescription(string collectionName)
		//{
		//	return _BasicContentPageItem.CoveoDescription(collectionName);
		//}

		//public DateTime CoveoDate(string collectionName)
		//{
		//	return _BasicContentPageItem.CoveoDate(collectionName);
		//}

		//public DateTime CoveoCreatedDate(string collectionName)
		//{
		//	return _BasicContentPageItem.CoveoCreatedDate(collectionName);
		//}

		//public string CoveoDisplayDate(string collectionName)
		//{
		//	return _BasicContentPageItem.CoveoDisplayDate(collectionName);
		//}

		//public Dictionary<string, string> CoveoAdditionalFields(string collectionName)
		//{
		//	var additionalFields = new Dictionary<string, string>();

		//	additionalFields.Add(CoveoFields.CustomWeight.FieldName, "10");

		//	if (_BasicContentPageItem.TaxonomyContent != null)
		//	{
		//		additionalFields.Add(CoveoFields.Modality.FieldName, _BasicContentPageItem.TaxonomyContent.GetTaxonomyForCoveo(_BasicContentPageItem.TaxonomyContent.RelatedModalities));
		//		additionalFields.Add(CoveoFields.SubSpecialty.FieldName, _BasicContentPageItem.TaxonomyContent.GetTaxonomyForCoveo(_BasicContentPageItem.TaxonomyContent.RelatedSubspecialites));
		//		additionalFields.Add(CoveoFields.Interest.FieldName, _BasicContentPageItem.TaxonomyContent.GetTaxonomyForCoveo(_BasicContentPageItem.TaxonomyContent.RelatedInterests));
		//		additionalFields.Add(CoveoFields.MetaData.FieldName, MetaUtils.GetMetaKeywordsForCoveo(_BasicContentPageItem.BasePage.MetaKeywords.Text));
		//	}

		//	additionalFields.Add(CoveoFields.ContentType.FieldName, "Content Page");

		//	return additionalFields;
		//}

		//public bool CoveoExcludeFromIndex(string collectionName)
		//{
		//	return _BasicContentPageItem.CoveoExcludeFromIndex(collectionName);
		//}

		//#endregion
	}
}

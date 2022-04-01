using System;
using ACR.Library.CustomItems.ACR.Interface;
using Sitecore.Collections;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.Base
{
	public partial class TaxonomyContentItem : ITaxonomyPage
	{
		#region Implementation of ITaxonomyPage


		/// <summary>
		/// Builds a safe dictionary for lucene querying from the taxonomy filters on this item.
		/// </summary>
		/// <returns></returns>
		public SafeDictionary<string> BuildSafeDictionaryFromItem(string taxonomyType)
		{
			SafeDictionary<string> safeDictionary = new SafeDictionary<string>();

			if (!string.IsNullOrEmpty(RelatedInterests.Raw) && taxonomyType == FieldName_RelatedInterests)
			{
				safeDictionary.Add(TaxonomyContentItem.FieldName_RelatedInterests,
					RelatedInterests.Raw.Replace("|", " "));
			}

			if (!string.IsNullOrEmpty(RelatedModalities.Raw) && taxonomyType == FieldName_RelatedModalities)
			{
				safeDictionary.Add(TaxonomyContentItem.FieldName_RelatedModalities,
					RelatedModalities.Raw.Replace("|", " "));
			}

			if (!string.IsNullOrEmpty(RelatedSubspecialites.Raw) && taxonomyType == FieldName_RelatedSubspecialites)
			{
				safeDictionary.Add(TaxonomyContentItem.FieldName_RelatedSubspecialites,
					RelatedSubspecialites.Raw.Replace("|", " "));
			}

			return safeDictionary;
		}

		#endregion
	}
}
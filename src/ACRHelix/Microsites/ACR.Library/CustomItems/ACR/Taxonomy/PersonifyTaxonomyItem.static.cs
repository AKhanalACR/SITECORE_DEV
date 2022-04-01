using System;
using ACR.Library.ACR.Base;
using ACR.Library.Reference;
using ACR.Library.Search;
using Sitecore.Collections;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.Taxonomy
{
	public partial class PersonifyTaxonomyItem 
	{
		/// <summary>
		/// This method builds a string from a Taxonomy Collection to be used as a safedeictionary for a search.
		/// </summary>
		/// <param name="taxonomyCollection"></param>
		/// <returns>Returns a string that can be used safeDictionary Filters for searches.</returns>
		public static string ReturnRelatedTaxonomyQuery(ICollection<PersonifyTaxonomyItem> taxonomyCollection)
		{
			string relatedTaxonomy = String.Empty;

			foreach (PersonifyTaxonomyItem p in taxonomyCollection)
			{
				relatedTaxonomy += p.ID.ToString() + " ";
			}

			relatedTaxonomy = relatedTaxonomy.Trim();

			return relatedTaxonomy;
		}

	}
}
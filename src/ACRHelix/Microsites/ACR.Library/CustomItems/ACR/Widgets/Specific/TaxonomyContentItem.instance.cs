using System;
using System.Linq;
using ACR.Library.ACR.Taxonomy;
using ACR.Library.Reference;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using Sitecore.Collections;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.Base
{
	public partial class TaxonomyContentItem
	{
		public string GetTaxonomyForCoveo(CustomTreeListField field)
		{
			if (field.ListItems == null || field.ListItems.Count == 0)
			{
				return string.Empty;
			}
			else
			{
				return string.Join("", field.ListItems.Select(i => ((PersonifyTaxonomyItem)i).DisplayName.Text).ToArray());
			}
		}

		public string GetTaxonomyForCoveo(CustomLookupField field)
		{
			if (field.Item == null)
			{
				return string.Empty;
			}
			else
			{
				return ((PersonifyTaxonomyItem) field.Item).DisplayName.Text;
			}
		}

	}
}
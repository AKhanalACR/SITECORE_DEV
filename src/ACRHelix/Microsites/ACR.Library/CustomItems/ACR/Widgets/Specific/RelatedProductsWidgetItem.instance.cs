using System;
using System.Linq;
using ACR.Library.ACR.Base;
using ACR.Library.ACR.Products;
using ACR.Library.CustomItems.ACR.Interface;
using ACR.Library.CustomSitecore.Extensions;
using ACR.Library.Reference;
using ACR.Library.Search.Indices.Product;
using ACR.Library.Utils;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.Widgets.Specific
{
public partial class RelatedProductsWidgetItem 
{
	public bool HasContent()
	{
		if (string.IsNullOrEmpty(TaxonomyType.Text))
		{
			return false;
		}
		var related = ReturnRelatedProducts();
		if (related == null || !related.Any())
		{
			return false;
		}
		return true;
	}

	private List<ProductStubItem> _relatedProducts;

	public List<ProductStubItem> ReturnRelatedProducts()
	{
		if (_relatedProducts == null)
			FetchRelatedProducts();

		return _relatedProducts;
	}

	private void FetchRelatedProducts()
	{
		_relatedProducts = new List<ProductStubItem>();

		if (Sitecore.Context.Item == null
		    || string.IsNullOrEmpty(TaxonomyType.Text))
		{
			return;
		}

		var taxonomy = Sitecore.Context.Item.GetInterfaceItem<ITaxonomyPage>();
		if (taxonomy==null)
		{
			return;
		}
		string taxonomyType = string.Empty;
		switch (TaxonomyType.Text.ToLower())
		{
			case "interest":
				taxonomyType = TaxonomyContentItem.FieldName_RelatedInterests;
				break;
			case "modality":
				taxonomyType = TaxonomyContentItem.FieldName_RelatedModalities;
				break;
			case "subspecialty":
				taxonomyType = TaxonomyContentItem.FieldName_RelatedSubspecialites;
				break;
		}
		if (string.IsNullOrEmpty(taxonomyType))
		{
			return;
		}
		var filters = taxonomy.BuildSafeDictionaryFromItem(taxonomyType);
		// Context item has no taxonomy
		if (!filters.Values.Any())
		{
			return;
		}

		// Get the products
		using (var idx = new ProductIndex())
		{
			var products = idx.GetProductsWebDisplayOnly(filters).Where(p => p != null).ToList();
			if (products.Count >= 3)
			{
				//take 3 random ones.
				products.Shuffle();
				_relatedProducts.AddRange(products.Take(3));
			}
		}
			
	}
}

}
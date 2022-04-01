using System;
using ACR.Library.ACR.Products;
using ACR.Library.Reference;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.Base
{
	public partial class RelatedProductsPageItem 
	{
		public IList<ProductStubItem> GetProducts()
		{
			if (FeaturedProducts == null
			    || FeaturedProducts.ListItems == null
			    || FeaturedProducts.ListItems.Count < 1)
			{
				return new List<ProductStubItem>();
			}
			var products = new List<ProductStubItem>();
			foreach (Item item in FeaturedProducts.ListItems)
			{
				if (BaseTemplateReference.IsValidTemplate(item, ProductStubItem.TemplateId))
				{
					products.Add(item);
				}
			}
			return products;
		}
	}
}
using System;
using ACR.Library.ACR.Home;
using ACR.Library.ACR.Products;
using ACR.Library.Reference;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.Base
{
	public partial class RelatedProductsManualPageItem
	{
		public IList<FeaturedContentManualItem> GetProducts()
		{
			if (FeaturedProductsManual == null
					|| FeaturedProductsManual.ListItems == null
					|| FeaturedProductsManual.ListItems.Count < 1)
			{
				return new List<FeaturedContentManualItem>();
			}
			var products = new List<FeaturedContentManualItem>();
			foreach (Item item in FeaturedProductsManual.ListItems)
			{
				if (BaseTemplateReference.IsValidTemplate(item, FeaturedContentManualItem.TemplateId))
				{
					products.Add(item);
				}
			}
			return products;
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.Search.Indices.Product;
using ACR.Lucene.Options;
using Sitecore.Collections;
using Sitecore.Diagnostics;
using Sitecore.Sites;

namespace ACR.Library.ACR.Products
{
	public partial class ProductDetailPageItem
	{
		private ProductStubItem _productStub;

		public ProductStubItem GetStubItem(SiteRequest contextRequest)
		{
			if (_productStub != null)
			{
				// Already retrieved it.
				return _productStub;
			}

			if (contextRequest == null || string.IsNullOrEmpty(contextRequest.ItemPath))
			{
				return null;
			}

			// Resolve the product
			string path = contextRequest.ItemPath;
			int lastSlash = path.LastIndexOf('/');
			string productId = path.Substring(lastSlash);
			if (string.IsNullOrEmpty(productId))
			{
				Log.Error("No product id found in path. Path: " + path, typeof(ProductDetailPageItem));
				return null;
			}
			ProductIndex index = new ProductIndex();
			SafeDictionary<string> filter = new SafeDictionary<string>();
			filter.Add(ProductStubItem.FieldName_PersonifyID, productId);
			List<ProductStubItem> stubs = index.GetProductsByID(productId);

			if (stubs.Count < 1)
			{
				Log.Error("No product found with id " + productId, typeof(ProductDetailPageItem));
				return null;
			}

			if (stubs.Count > 1)
			{
				Log.Error("Multiple products found with id " + productId, typeof(ProductDetailPageItem));
				return null;
			}
			_productStub = stubs[0];
			return _productStub;
		}
	}
}

using System;
using System.Linq;
using ACR.Library.ACR.Base;
using ACR.Library.ACR.Products;
using ACR.Library.ACR.Taxonomy;
using ACR.Library.Search.Indices.Product;
using ACR.Library.UserServices;
using ACR.Library.Utils;
using Sitecore.Collections;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.Widgets.Personify
{
public partial class RecommendedProductsWidgetItem 
{
	private List<ProductStubItem> _recommendedProducts;

	/// <summary>
	/// Will return if this widget has any content to display.
	/// </summary>
	/// <returns>Flag determining if this widget has content.</returns>
	public bool HasContent()
	{
		if (UserManager.CurrentUserContext.CurrentUser.IsAnonymous || !UserManager.CurrentUserContext.CurrentUser.IsAuthenticated)
			return false;

		if (UserManager.CurrentUserContext.CurrentUser.Profile.Interests.Count == 0 
			&& UserManager.CurrentUserContext.CurrentUser.Profile.Modalities.Count == 0 
			&& UserManager.CurrentUserContext.CurrentUser.Profile.Subspecialities.Count == 0)
			return false;

		return ReturnRecommendedProducts().Any();
	}

	public List<ProductStubItem> ReturnRecommendedProducts()
	{
		if (_recommendedProducts == null)
			FetchRecommendedProducts();

		return _recommendedProducts;
	}

	private List<ProductStubItem> PerformSearch(ICollection<PersonifyTaxonomyItem> taxonomyCollection, String filterField)
	{
		SafeDictionary<string> safeDictionary = new SafeDictionary<string>();

		String relatedTaxonomy = PersonifyTaxonomyItem.ReturnRelatedTaxonomyQuery(taxonomyCollection);

		safeDictionary.Add(filterField, relatedTaxonomy);

		return PerformSearch(safeDictionary);
	}

	private List<ProductStubItem> PerformSearch(SafeDictionary<string> filters)
	{
		List<ProductStubItem> productItems = new List<ProductStubItem>();

		// Get the products
		using (var idx = new ProductIndex())
		{
			var products = idx.GetProductsWebDisplayOnly(filters).Where(p => p != null).ToList();
			if (products.Count >= 3)
			{
				//take 3 random ones.
				products.Shuffle();
				return products.Take(3).ToList();
			}
		}

		return productItems;
	}

	/// <summary>
	/// Performs the a search for related News Articles based upon a users related Taxonomy profile.
	/// It will first try to use Interests. If no matches will fall back upon Modality, then finally subspecialty.
	/// </summary>
	private void FetchRecommendedProducts()
	{
		// Calculate the Taxonomy of the current page
		// Set the _relatedCourses that have the same taxonomy

		_recommendedProducts = new List<ProductStubItem>();
		IAcrProfile acrProfile = UserManager.CurrentUserContext.CurrentUser.Profile;

		if (acrProfile.Interests != null && acrProfile.Interests.Count > 0)
		{
			_recommendedProducts = PerformSearch(acrProfile.Interests, TaxonomyContentItem.FieldName_RelatedInterests);
		}

		if (!_recommendedProducts.Any() && acrProfile.Modalities != null && acrProfile.Modalities.Count > 0)
		{
			_recommendedProducts = PerformSearch(acrProfile.Modalities, TaxonomyContentItem.FieldName_RelatedModalities);
		}

		if (!_recommendedProducts.Any() && acrProfile.Subspecialities != null && acrProfile.Subspecialities.Count > 0)
		{
			_recommendedProducts = PerformSearch(acrProfile.Subspecialities, TaxonomyContentItem.FieldName_RelatedSubspecialites);
		}

	}

}
}
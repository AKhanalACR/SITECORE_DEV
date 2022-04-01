using System;
using System.Linq;
using ACR.Library.ACR.Base;
using ACR.Library.ACR.News;
using ACR.Library.ACR.Products;
using ACR.Library.ACR.Taxonomy;
using ACR.Library.Common.Interfaces.Factory;
using ACR.Library.CustomItems.ACR.Interface;
using ACR.Library.CustomSitecore.Extensions;
using ACR.Library.Reference;
using ACR.Library.Search.Indices.Product;
using ACR.Library.Utils;
using ACR.Lucene.Options;
using Sitecore.Collections;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.Widgets.Specific
{
public partial class RelatedCoursesWidgetItem
{
	private List<ProductStubItem> _relatedCourses;

	/// <summary>
	/// Will return if this widget has any content to display.
	/// </summary>
	/// <returns>Flag determining if this widget has content.</returns>
	public bool HasContent()
	{
		if (ReturnRelatedCourses() != null && ReturnRelatedCourses().Any())
			return true;

		//else return false
		return false;
	}

	public List<ProductStubItem> ReturnRelatedCourses()
	{
		if (_relatedCourses == null)
			FetchRelatedCourses();

		return _relatedCourses;
	}

	private void FetchRelatedCourses()
	{
		// Calculate the Taxonomy of the current page
		// Set the _relatedCourses that have the same taxonomy

		_relatedCourses = new List<ProductStubItem>();

		if (Sitecore.Context.Item == null)
		{
			return;
		}

		var taxonomy = Sitecore.Context.Item.GetInterfaceItem<ITaxonomyPage>();
		if(taxonomy == null)
		{
			return;
		}
		var safeDictionary = taxonomy.BuildSafeDictionaryFromItem(TaxonomyContentItem.FieldName_RelatedInterests);
		
		if(safeDictionary == null || !safeDictionary.Any())
		{
			return;
		}
		using (ProductIndex productIndex = new ProductIndex())
		{
			// get courses only
			safeDictionary.Add(ProductFilters.IsEdcrMeeting, "1");

			var products = productIndex.GetProductsWebDisplayOnly(safeDictionary).Where(p => p.MeetingStartDate.DateTime.CompareTo(DateTime.Today) > 0).ToList();
			
			if (products.Count >= 2)
			{
				//take 2 random ones.
				products.Shuffle();
				_relatedCourses.AddRange(products.Take(2));
			}
		}
			
	}
}
}
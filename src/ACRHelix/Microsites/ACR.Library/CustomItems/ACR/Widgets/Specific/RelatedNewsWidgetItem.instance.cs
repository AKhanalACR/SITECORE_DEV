using System;
using System.Linq;
using ACR.Library.ACR.Base;
using ACR.Library.ACR.News;
using ACR.Library.ACR.Products;
using ACR.Library.ACR.Taxonomy;
using ACR.Library.CustomItems.ACR.Interface;
using ACR.Library.CustomSitecore.Extensions;
using ACR.Library.Reference;
using ACR.Library.Search.Indices.News;
using ACR.Library.UserServices;
using Sitecore.Collections;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.Widgets.Specific
{
public partial class RelatedNewsWidgetItem 
{
	private List<Item> _relatedNews;


	/// <summary>
	/// Will return if this widget has any content to display.
	/// </summary>
	/// <returns>Flag determining if this widget has content.</returns>
	public bool HasContent()
	{
		if (ReturnRelatedNews() != null && ReturnRelatedNews().Any())
			return true;

		//else return false
		return false;
	}

	public List<Item> ReturnRelatedNews()
	{
		if (_relatedNews == null)
			FetchRelatedNews();

		return _relatedNews;
	}

	private void FetchRelatedNews()
	{
		// Calculate the Taxonomy of the current page
		// Set the _relatedCourses that have the same taxonomy

		_relatedNews = new List<Item>();
		if (Sitecore.Context.Item == null)
		{
			return;
		}
		var taxonomy = Sitecore.Context.Item.GetInterfaceItem<ITaxonomyPage>();
		if (taxonomy == null)
		{
			// Item has no taxonomy.
			return;
		}
		SafeDictionary<string> safeDictionary =
			taxonomy.BuildSafeDictionaryFromItem(TaxonomyContentItem.FieldName_RelatedInterests);
			
		if (safeDictionary.Any())
		{
			using (NewsIndex index = new NewsIndex())
			{
				var options = NewsIndex.GetDefaultSort(4);
				foreach (NewsArticleItem p in index.GetNewsArticles(safeDictionary, null, options))
				{
					Item i = p;
					_relatedNews.Add(i);
				}
			}
		}

	}
}
}
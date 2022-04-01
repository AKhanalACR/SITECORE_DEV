using System;
using System.Linq;
using ACR.Library.ACR.News;
using ACR.Library.ACR.Taxonomy;
using ACR.Library.Search.Indices.News;
using Sitecore.Collections;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.Widgets.Specific
{
public partial class LatestNewsWidgetItem 
{
	private List<Item> _relatedNews;

	/// <summary>
	/// Will return if this widget has any content to display.
	/// </summary>
	/// <returns>Flag determining if this widget has content.</returns>
	public bool HasContent()
	{
		// check news index for the type
		if (ReturnRelatedCourses().Any())
			return true;

		//else return false
		return false;
	}

	public List<Item> ReturnRelatedCourses()
	{
		if (_relatedNews == null)
			FetchRelatedCourses();

		return _relatedNews;
	}

	private void FetchRelatedCourses()
	{
		// Calculate the Taxonomy of the current page
		// Set the _relatedCourses that have the same taxonomy

		_relatedNews = new List<Item>();

		if(!String.IsNullOrEmpty(this.NewsCategory.Raw))
		{
			NewsIndex index = new NewsIndex();
			foreach (NewsArticleItem p in index.GetLatestNewsArticles(5, NewsCategory.Raw))
			{
				Item i = p;
				_relatedNews.Add(i);
			}
		}

	}
}
}
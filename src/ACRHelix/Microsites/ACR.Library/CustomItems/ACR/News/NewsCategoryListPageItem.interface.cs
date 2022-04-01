using System;
using System.Web.UI.WebControls;
using ACR.Library.ACR.Globals;
using ACR.Library.ACR.MediaCenter;
using ACR.Library.CustomItems.ACR.Interface;
using ACR.Library.Reference;
using ACR.Library.Search.Indices.News;
using ACR.Library.Search.Indices.PressReleases;
using ACR.Lucene.Indices;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.News
{
	public partial class NewsCategoryListPageItem : IAcrContentListPage
{
	#region IAcrContentListPage

	public BaseIndex ContentIndex
	{
		get { return new NewsIndex(); }
	}

	public string ListHeaderText
	{
		get
		{
			if (ArticleType.Item != null)
			{
				EnumerationItem newsType = ArticleType.Item;
				return string.Format("{0} Articles",newsType.GetName());
			}
			return "News Articles";
		}
	}

	public string ListHeaderTextYearFormat
	{
		get { return "{0} " + ListHeaderText; }
	}

	public string ListDateFieldName
	{
		get { return NewsArticleItem.FieldName_Date; }
	}

	public string ListFilterFieldName
	{
		get { return NewsArticleItem.FieldName_ArticleType; }
	}

	public List<ListItem> ListFilterValues
	{
		get
		{
			// TODO: Get the list of enumerated article types

			List<ListItem> filterValues = new List<ListItem>();
			foreach (Item i in ItemReference.ACR_NewsPublications_NewsArticleTypeLocation.InnerItem.GetChildren())
			{
				filterValues.Add(new ListItem(i.Name, i.ID.ToShortID().ToString()));

			}
			return filterValues;
		}
	}

	#endregion
}
}
using System;
using System.Linq;
using ACR.Library.ACR.Base;
using ACR.Library.ACR.News;
using ACR.Library.ACR.Taxonomy;
using ACR.Library.Search.Indices.News;
using ACR.Library.UserServices;
using Sitecore.Collections;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.Widgets.Personify
{
public partial class PublicationsForYouWidgetItem 
{
	private List<Item> _relatedPublications;

	/// <summary>
	/// Will return if this widget has any content to display.
	/// </summary>
	/// <returns>Flag determining if this widget has content.</returns>
	public bool HasContent()
	{
		if (UserManager.CurrentUserContext.CurrentUser.IsAnonymous || !UserManager.CurrentUserContext.CurrentUser.IsAuthenticated)
			return false;

		if (UserManager.CurrentUserContext.CurrentUser.Profile.Interests.Count > 0 || UserManager.CurrentUserContext.CurrentUser.Profile.Modalities.Count > 0 || UserManager.CurrentUserContext.CurrentUser.Profile.Subspecialities.Count > 0)
			return true;


		//else return false
		return false;
	}

	public List<Item> ReturnRelatedPublications()
	{
		if (_relatedPublications == null)
			FetchRelatedPublications();

		return _relatedPublications;
	}

	private List<Item> PerformSearch(ICollection<PersonifyTaxonomyItem> taxonomyCollection, String filterField)
	{
		SafeDictionary<string> safeDictionary = new SafeDictionary<string>();

		String relatedTaxonomy = ReturnRelatedTaxonomyQuery(taxonomyCollection);

		safeDictionary.Add(filterField, relatedTaxonomy);

		return PerformSearch(safeDictionary);
	}

	private List<Item> PerformSearch(SafeDictionary<string> filters)
	{
		NewsIndex index = new NewsIndex();
		List<Item> newsItems = new List<Item>();

		foreach (NewsArticleItem p in index.GetNewsArticles(filters, NewsIndex.GetDefaultDateParam(), NewsIndex.GetDefaultSort(4)))
		{
			Item i = p;
			newsItems.Add(i);
		}

		return newsItems;
	}

	/// <summary>
	/// This method builds a string from a Taxonomy Collection to be used as a safedeictionary for a search.
	/// </summary>
	/// <param name="taxonomyCollection"></param>
	/// <returns>Returns a string that can be used safeDictionary Filters for searches.</returns>
	private string ReturnRelatedTaxonomyQuery(ICollection<PersonifyTaxonomyItem> taxonomyCollection)
	{
		string relatedTaxonomy = String.Empty;

		foreach (PersonifyTaxonomyItem p in taxonomyCollection)
		{
			relatedTaxonomy += p.ID.ToString() + " ";
		}

		relatedTaxonomy = relatedTaxonomy.Substring(0, relatedTaxonomy.Length - 1);

		return relatedTaxonomy;
	}

	/// <summary>
	/// Performs the a search for related News Articles based upon a users related Taxonomy profile.
	/// It will first try to use Interests. If no matches will fall back upon Modality, then finally subspecialty.
	/// </summary>
	private void FetchRelatedPublications()
	{
		// Calculate the Taxonomy of the current page
		// Set the _relatedCourses that have the same taxonomy

		_relatedPublications = new List<Item>();
		IAcrProfile acrProfile = UserManager.CurrentUserContext.CurrentUser.Profile;

		if (acrProfile.Interests != null && acrProfile.Interests.Count > 0)
		{
			_relatedPublications = PerformSearch(acrProfile.Interests, TaxonomyContentItem.FieldName_RelatedInterests);
		}

		if (!_relatedPublications.Any() && acrProfile.Modalities != null && acrProfile.Modalities.Count > 0)
		{
			_relatedPublications = PerformSearch(acrProfile.Modalities, TaxonomyContentItem.FieldName_RelatedModalities);
		}

		if (!_relatedPublications.Any() && acrProfile.Subspecialities != null && acrProfile.Subspecialities.Count > 0)
		{
			_relatedPublications = PerformSearch(acrProfile.Subspecialities, TaxonomyContentItem.FieldName_RelatedSubspecialites);
		}

	}
}
}
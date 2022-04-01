using System;
using ACR.Library.Common.Interfaces;

using CustomItemGenerator.Fields.SimpleTypes;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Links;

namespace ACR.Library.ACR.Education
{
	public partial class EducationCatalogLandingPageItem : IListItemFeaturedParent
	{
		#region ISearchPage Implementation

		public ICollection<string> CollectionNames
		{
			get { return new List<string>();// { SearchContext.ACRProductsCollectionName }; 
            }
		}

		//public Dictionary<string, Parameter> DefaultParameters
		//{
		//	get
		//	{
		//		var parameters = new Dictionary<string, Parameter>();
		//		parameters.Add(ParameterUtil.GetKey<CatalogTypeParameter>(), new CatalogTypeParameter(string.Empty));
		//		return parameters;
		//	}
		//}

		/*public ICollection<RefineByField> RequiredFacets
		{
			get
			{
				//List<RefineByField> facets = new List<RefineByField>();

				//RefineByField catalogType = new RefineByField();
				//catalogType.Field = CoveoFields.CatalogType.CoveoFormattedFieldName;
				//catalogType.SortBy = SearchContext.DefaultFacetSort;
				//catalogType.Maximum = SearchContext.MaxFacetCount;
				//facets.Add(catalogType);

				//RefineByField modality = new RefineByField();
				//modality.Field = CoveoFields.Modality.CoveoFormattedFieldName;
				//modality.SortBy = SearchContext.DefaultFacetSort;
				//modality.Maximum = SearchContext.MaxFacetCount;
				//facets.Add(modality);

				//RefineByField subSpecialty = new RefineByField();
				//subSpecialty.Field = CoveoFields.SubSpecialty.CoveoFormattedFieldName;
				//subSpecialty.SortBy = SearchContext.DefaultFacetSort;
				//subSpecialty.Maximum = SearchContext.MaxFacetCount;
				//facets.Add(subSpecialty);

				//RefineByField interest = new RefineByField();
				//interest.Field = CoveoFields.Interest.CoveoFormattedFieldName;
				//interest.SortBy = SearchContext.DefaultFacetSort;
				//interest.Maximum = SearchContext.MaxFacetCount;
				//facets.Add(interest);

				//RefineByField topic = new RefineByField();
				//topic.Field = CoveoFields.Topic.CoveoFormattedFieldName;
				//topic.SortBy = SearchContext.DefaultFacetSort;
				//topic.Maximum = SearchContext.MaxFacetCount;
				//facets.Add(topic);

				//RefineByField creditType = new RefineByField();
				//creditType.Field = CoveoFields.CreditType.CoveoFormattedFieldName;
				//creditType.SortBy = SearchContext.DefaultFacetSort;
				//creditType.Maximum = SearchContext.MaxFacetCount;
				//facets.Add(creditType);

				return facets;
			}
		}*/

		//public ICollection<CoveoField> NeededFields
		//{
		//	get { return new List<CoveoField>() { CoveoFields.ItemId }; }
		//}

		public string DefaultSortByField
		{
			get { return string.Empty; }
		}

		//public SortByEnum? DefaultSortType
		//{
		//	get { return null; }
		//}

		#endregion

		public bool liSuppressParentPageFeature
		{
			get { return BaseContent.SuppressParentPageFeature.Checked; }
		}

		public CustomImageField liParentPageThumbnail
		{
			get { return BaseContent.ParentPageThumbnail; }
		}

		public CustomTextField liParentPageIntroText
		{
			get { return BaseContent.ParentPageIntroText; }
		}

		public CustomTextField liPageTitle
		{
			get { return BasePage.PageTitle; }
		}

		public bool liIsExternal
		{
			get { return false; }
		}

		public string NavUrl
		{
			get { return LinkManager.GetItemUrl(this); }
		}
	}
}

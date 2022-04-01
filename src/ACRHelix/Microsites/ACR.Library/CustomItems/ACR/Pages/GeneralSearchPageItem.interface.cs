using System;
using System.Collections.ObjectModel;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.Pages
{
	public partial class GeneralSearchPageItem : ISearchPage
	{
		public ICollection<string> CollectionNames
		{
			get { return new List<string>(){SearchContext.ACRGeneralCollectionName, SearchContext.ACRProductsCollectionName}; }
		}

		public Dictionary<string, Parameter> DefaultParameters
		{
			get
			{
				return new Dictionary<string, Parameter>();
			}
		}

		public ICollection<RefineByField> RequiredFacets
		{
			get
			{
				List<RefineByField> facets = new List<RefineByField>();

				RefineByField contentType = new RefineByField();
				contentType.Field = CoveoFields.ContentType.CoveoFormattedFieldName;
				contentType.SortBy = SearchContext.DefaultFacetSort;
				contentType.Maximum = SearchContext.MaxFacetCount;
				facets.Add(contentType);

				RefineByField subSpecialty = new RefineByField();
				subSpecialty.Field = CoveoFields.SubSpecialty.CoveoFormattedFieldName;
				subSpecialty.SortBy = SearchContext.DefaultFacetSort;
				subSpecialty.Maximum = SearchContext.MaxFacetCount;
				facets.Add(subSpecialty);

				RefineByField interest = new RefineByField();
				interest.Field = CoveoFields.Interest.CoveoFormattedFieldName;
				interest.SortBy = SearchContext.DefaultFacetSort;
				interest.Maximum = SearchContext.MaxFacetCount;
				facets.Add(interest);

				RefineByField modality = new RefineByField();
				modality.Field = CoveoFields.Modality.CoveoFormattedFieldName;
				modality.SortBy = SearchContext.DefaultFacetSort;
				modality.Maximum = SearchContext.MaxFacetCount;
				facets.Add(modality);

				RefineByField topic = new RefineByField();
				topic.Field = CoveoFields.Topic.CoveoFormattedFieldName;
				topic.SortBy = SearchContext.DefaultFacetSort;
				topic.Maximum = SearchContext.MaxFacetCount;
				facets.Add(topic);

				return facets;
			}
		}

		public ICollection<CoveoField> NeededFields
		{
			get { return new List<CoveoField>() { CoveoFields.ItemId, CoveoFields.ContentType, CoveoFields.Date, CoveoFields.Description, CoveoFields.OverrideUrl, CoveoFields.Title, CoveoFields.DisplayDate }; }
		}

		public string DefaultSortByField
		{
			get { return string.Empty; }
		}

		public SortByEnum? DefaultSortType
		{
			get { return null; }
		}
	}
}
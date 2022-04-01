using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.Education
{
public partial class EducationCalendarSearchPageItem: ISearchPage
{
	public ICollection<string> CollectionNames
	{
		get { return new List<string>() { SearchContext.ACRMeetingsCollectionName }; }
	}

	public Dictionary<string, Parameter> DefaultParameters
	{
		get
		{
			var parameters = new Dictionary<string, Parameter>();
			parameters.Add(ParameterUtil.GetKey<MeetingTypeParameter>(),new MeetingTypeParameter(MeetingTypeParameter.EducationCenterMeetingType));
			return parameters;
		}
	}

	public ICollection<RefineByField> RequiredFacets
	{
		get
		{
			List<RefineByField> facets = new List<RefineByField>();

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

			return facets;
		}
	}

	public ICollection<CoveoField> NeededFields
	{
		get { return new List<CoveoField>() { CoveoFields.ItemId, CoveoFields.ContentType, CoveoFields.Date, CoveoFields.Description, CoveoFields.OverrideUrl, CoveoFields.Title, CoveoFields.MeetingType, CoveoFields.DisplayDate }; }
	}

	public string DefaultSortByField
	{
		get { return CoveoFields.Date.CoveoFormattedFieldName; }
	}

	public SortByEnum? DefaultSortType
	{
		get { return SortByEnum.FieldAscending; }
	}
}
}
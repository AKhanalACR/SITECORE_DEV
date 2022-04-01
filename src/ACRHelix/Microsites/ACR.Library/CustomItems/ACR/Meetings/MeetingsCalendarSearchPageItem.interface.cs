using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.Meetings
{
	public partial class MeetingsCalendarSearchPageItem
	{
		public ICollection<string> CollectionNames
		{
			get { return new List<string>(){SearchContext.ACRMeetingsCollectionName}; }
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

				RefineByField meetingType = new RefineByField();
				meetingType.Field = CoveoFields.MeetingType.CoveoFormattedFieldName;
				meetingType.SortBy = SearchContext.DefaultFacetSort;
				meetingType.Maximum = SearchContext.MaxFacetCount;
				facets.Add(meetingType);

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
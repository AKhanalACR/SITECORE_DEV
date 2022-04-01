using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.Cache;
using ACR.Library.Reference;

namespace ACR.Library.ACR.Education
{
	public partial class FacultyLandingPageItem
	{
		private const string FacultyCacheKey = "acrFacultyMembers";

		public static IList<FacultyMemberItem> GetFaculty()
		{
			return ACRCache.GetFromCache(FacultyCacheKey,
			                             () => ItemReference.ACR_Education_FacultyList.InnerItem.Axes.GetDescendants()
			                                   	.Where(
			                                   		f => BaseTemplateReference.IsValidTemplate(f, FacultyMemberItem.TemplateId))
			                                   	.Select(f => new FacultyMemberItem(f)).ToList());

		}
	}
}

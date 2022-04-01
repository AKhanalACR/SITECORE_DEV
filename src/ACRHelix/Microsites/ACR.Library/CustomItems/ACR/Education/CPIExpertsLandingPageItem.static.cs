using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.Cache;
using ACR.Library.Reference;

namespace ACR.Library.ACR.Education
{
    public partial class CPIExpertsLandingPageItem
	{
		private const string ExpertsCacheKey = "acrExpertMembers";
        private const string SpliceExpertsCacheKey = "acrSpliceExpertMembers";

		public static IList<CPIExpertMemberItem> GetCpiExperts()
		{
            return ACRCache.GetFromCache(ExpertsCacheKey,
                                         () => ItemReference.ACR_Education_CpiExpertsList.InnerItem.Axes.GetDescendants()
			                                   	.Where(
                                                    f => BaseTemplateReference.IsValidTemplate(f, CPIExpertMemberItem.TemplateId))
                                                .Select(f => new CPIExpertMemberItem(f)).ToList());

		}


        public static IList<CPIExpertMemberItem> GetCpiSpliceExperts()
        {
            return ACRCache.GetFromCache(SpliceExpertsCacheKey,
                                         () => ItemReference.ACR_Education_CpiSpliceExpertsList.InnerItem.Axes.GetDescendants()
                                                .Where(
                                                    f => BaseTemplateReference.IsValidTemplate(f, CPIExpertMemberItem.TemplateId))
                                                .Select(f => new CPIExpertMemberItem(f)).ToList());

        }
	}
}

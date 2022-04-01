using System;
using System.Linq;
using ACR.Library.Radpac.CustomItems.Radpac.Components;
using ACR.Library.Utils;
using System.Collections.Generic;

namespace ACR.Library.Radpac.CustomItems.Radpac.Pages
{
public partial class KeyContributorsItem 
{
    public IEnumerable<ContributorItem> ContributorItems
    {
        get
        {
            IEnumerable<ContributorItem> contributorItems = InnerItem.Axes.GetDescendants()
                .Where(i => SitecoreUtils.IsValid(ContributorItem.TemplateId, i))
                .Select(i => (ContributorItem)i);
            return contributorItems;
        }
    }
}
}
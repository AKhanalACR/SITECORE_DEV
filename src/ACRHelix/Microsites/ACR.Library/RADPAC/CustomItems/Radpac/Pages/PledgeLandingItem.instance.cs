using System;
using System.Linq;
using ACR.Library.Radpac.CustomItems.Radpac.Base;
using ACR.Library.Utils;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.Radpac.CustomItems.Radpac.Pages
{
public partial class PledgeLandingItem 
{
	public List<PledgeFormItem> GetPledgeFormItems()
	{
		IEnumerable<Item> items = InnerItem.Children.Where(
						i => i != null
						&& SitecoreUtils.IsValid(PledgeFormItem.TemplateId, i)
						);

		return items.Select(i => (PledgeFormItem)i).ToList();
	}
}
}
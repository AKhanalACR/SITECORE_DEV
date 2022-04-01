using System;
using System.Linq;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Base;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Components;
using ACR.Library.Reference;
using ACR.Library.Utils;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ImageWisely.CustomItems.ImageWisely.Pages
{
	public partial class PledgeLandingItem
	{
		public List<PledgeFormItem> GetPledgeFormItems()
		{
			IEnumerable<Item> items = InnerItem.Children.Where(i => i != null && SitecoreUtils.IsValid(PledgeFormItem.TemplateId, i));
			return items.Select(i => (PledgeFormItem) i).ToList();
		}

		public List<PledgeRoleItem> GetPledgeRoleItems()
		{
			Item pledgeRoleFolder = ItemReference.IW_Pledge_RolesFolder.InnerItem;
			IEnumerable<Item> items = pledgeRoleFolder.Children.Where(i => i != null && SitecoreUtils.IsValid(PledgeRoleItem.TemplateId, i));
			return items.Select(i => (PledgeRoleItem)i).ToList();
		}
	}
}
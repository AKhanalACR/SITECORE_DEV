using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.AIRP;
using ACR.Library.AIRP.Pages;
using ACR.Library.Reference;
using ACR.Library.Utils;
using Sitecore.Data.Items;

namespace ACR.layouts.AIRP
{
	public partial class sltBreadcrumb : System.Web.UI.UserControl
	{
		private string _separator;
		protected void Page_Load(object sender, EventArgs e)
		{
			AIRPSiteSettingsItem settingsItem = ItemReference.Airp_GlobalSettings.InnerItem;
			InternalPageItem item = Sitecore.Context.Item;
			if(item == null || settingsItem == null)
			{
				return;
			}
			_separator = settingsItem.BreadcrumbDelimiter.Text;
			List<InternalPageItem> breadcrumbItems = new List<InternalPageItem>();
			breadcrumbItems.Add(item);
			item = item.InnerItem.Parent;
			while(item != null && item.ID != ItemReference.Airp.InnerItem.ID)
			{
				breadcrumbItems.Add(item);
				item = item.InnerItem.Parent;
			}
			breadcrumbItems.Add(ItemReference.Airp.InnerItem);
			breadcrumbItems.Reverse();
			rptBreadcrumb.DataSource = breadcrumbItems;
			rptBreadcrumb.DataBind();
		}

		protected void rptBreadcrumb_OnItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			InternalPageItem breadcrumbItem = (InternalPageItem)e.Item.DataItem;
			var hypBreadcrumbItem = (HyperLink)e.Item.FindControl("hypBreadcrumbItem");
			var litSeparator = (Literal) e.Item.FindControl("litSeparator");

			hypBreadcrumbItem.NavigateUrl = LinkUtils.GetItemUrl(breadcrumbItem);
			hypBreadcrumbItem.Text = TitleFactory.GetAIRPNavTitle(breadcrumbItem);
			if(e.Item.ItemIndex != ((List<InternalPageItem>)rptBreadcrumb.DataSource).Count- 1)
			{
				litSeparator.Text = _separator;
			}
			else
			{
				hypBreadcrumbItem.Enabled = false;
				hypBreadcrumbItem.CssClass += " inactive";
			}
		}

	}
}
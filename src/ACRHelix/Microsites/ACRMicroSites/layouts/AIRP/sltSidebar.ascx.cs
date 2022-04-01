using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.AIRP;
using ACR.Library.AIRP.Base;
using ACR.Library.AIRP.Components;
using ACR.Library.AIRP.Pages;
using ACR.Library.Reference;
using ACR.Library.Utils;
using Sitecore.Data.Items;

namespace ACR.layouts.AIRP
{
	public partial class sltSidebar : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			PageBaseItem item = Sitecore.Context.Item;
			AIRPSiteSettingsItem settingsItem = ItemReference.Airp_GlobalSettings.InnerItem;
			if(item == null || settingsItem == null)
			{
				return;
			}

			rptSidebarButtons.DataSource = item.ActiveButtons.ListItems;
			rptSidebarButtons.DataBind();

			litHotlinksTitle.Text = settingsItem.RelatedLinksTitle.Text;
			if(item.HotLinks.ListItems.Count ==0)
			{
				litHotlinksTitle.Visible = false;
				return;
			}
			rptHotlinks.DataSource = item.HotLinks.ListItems;
			rptHotlinks.DataBind();
		}

		protected void rptSidebarButtons_OnItemDatabound(object sender, RepeaterItemEventArgs e)
		{
			SidebarButtonItem buttonItem = new SidebarButtonItem((Item) e.Item.DataItem);
			var hypSidebarLink = (HyperLink) e.Item.FindControl("hypSidebarLink");
			var imgSidebarImage = (Image) e.Item.FindControl("imgSidebarImage");
			var litLinkText = (Literal) e.Item.FindControl("litLinkText");

			hypSidebarLink.NavigateUrl = LinkUtils.GetLinkFieldUrl(buttonItem.Link.Field);
			hypSidebarLink.Target = buttonItem.Link.Field.Target;
			litLinkText.Text = buttonItem.Title.Text;
			imgSidebarImage.ImageUrl = LinkUtils.GetMediaUrl(buttonItem.Icon.MediaItem);
		}

		protected void rptHotlink_OnItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			LinkItem item = new LinkItem((Item) e.Item.DataItem);
			var hypHotlink = (HyperLink) e.Item.FindControl("hypHotlink");
			hypHotlink.NavigateUrl = LinkUtils.GetLinkFieldUrl(item.LinkDestination.Field);
			hypHotlink.Target = item.LinkDestination.Field.Target;
			hypHotlink.Text = item.LinkName.Text;
		}
	}
}
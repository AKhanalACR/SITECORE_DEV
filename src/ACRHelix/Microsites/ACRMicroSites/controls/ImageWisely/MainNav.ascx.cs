using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ACR.Library.Common.Interfaces.Factory;
using ACR.Library.Common.Interfaces;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Base;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Components;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Pages;
using ACR.Library.ImageWisely.Utils;
using ACR.Library.Reference;
using Sitecore.Data.Items;

namespace ACR.controls.ImageWisely
{
	public partial class MainNav : System.Web.UI.UserControl
	{
		private List<PageSettingsItem> _navItems;
		private string _alternateUrl = "";

		protected void Page_Load(object sender, EventArgs e)
		{
			_navItems = NavUtil.GetMainNavItems(ItemReference.ImageWisely.InnerItem);
			if (_navItems != null && _navItems.Count > 0)
			{
				rptMainNav.DataSource = _navItems;
				rptMainNav.DataBind();
			}
			else
			{
				rptMainNav.Visible = false;
			}
		}

		protected void rptMainNav_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				HtmlGenericControl liMain = (HtmlGenericControl)e.Item.FindControl("liMain");
				HyperLink hlNavItem = (HyperLink)e.Item.FindControl("hlNavItem");
				Repeater rptSubNav = (Repeater)e.Item.FindControl("rptSubNav");
				PageSettingsItem psItem = (PageSettingsItem)e.Item.DataItem;

				//Item ancestor = NavUtil.GetFirstLevelAncestor(Sitecore.Context.Item);
				//if (ancestor != null && ancestor.ID.ToString() == psItem.ID.ToString())
				//{
				//    hlNavItem.CssClass = "selected";
				//}

				IPageItem pageItem = ItemInterfaceFactory.GetItem<IPageItem>(psItem.InnerItem);
				//hlNavItem.Text = pageItem.NavTitle;
				hlNavItem.NavigateUrl = pageItem.NavUrl;
				hlNavItem.CssClass = "xp_menuitem" + (e.Item.ItemIndex + 1);

				//By request the "Manufacturer Resources" item (previously called "Equipment Resources")
				//should display all Vendors as subitems that link to the Manufacturer Resources page
				if (pageItem is EquipmentResourcesItem)
				{
					if (ItemReference.IW_EquipmentResources_Vendors.InnerItem != null)
					{
						_alternateUrl = pageItem.NavUrl;
						IEnumerable<IListItem> vendorItems = ItemReference.IW_EquipmentResources_Vendors
							.InnerItem
							.Axes
							.GetDescendants()
							.Select(i => ItemInterfaceFactory.GetItem<IListItem>(i));

						if (vendorItems.Count() > 0)
						{
							rptSubNav.DataSource = vendorItems;
							rptSubNav.DataBind();
						}
					}
				}
				else
				{
					List<IPageItem> subNavItems = NavUtil.GetMainSubNavItems(psItem.InnerItem);
					if (subNavItems == null || subNavItems.Count > 0)
					{
						rptSubNav.DataSource = subNavItems;
						rptSubNav.DataBind();
					}
				}

				if (e.Item.ItemIndex == _navItems.Count - 1)
				{
					liMain.Attributes["class"] = "last";
				}
			}
		}

		protected void rptSubNav_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				HyperLink hlSubNavItem = (HyperLink)e.Item.FindControl("hlSubNavItem");

				if (e.Item.DataItem is IListItem)
				{
					IListItem listItem = (IListItem)e.Item.DataItem;
					hlSubNavItem.Text = listItem.LiTitle;
					hlSubNavItem.NavigateUrl = _alternateUrl;
				}
				else
				{
					{
						IPageItem pageItem = (IPageItem)e.Item.DataItem;
						if (pageItem is PledgeLandingItem)
						{
							//Exception to the rule. I hate exceptions!!
							hlSubNavItem.Text = "Take the Pledge";
						}
						else
						{
							hlSubNavItem.Text = pageItem.NavTitle;
						}
						
						hlSubNavItem.NavigateUrl = pageItem.NavUrl;
					}

				}
			}
		}
	}
}
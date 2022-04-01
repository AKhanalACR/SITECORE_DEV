using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.Common.Interfaces.Factory;
using ACR.Library.RLI.Base;
using ACR.Library.RLI.Interfaces;
using ACR.Library.RLI.Pages;
using ACR.Library.Reference;
using ACR.Library.Utils;
using Sitecore.Data.Items;

namespace ACR.controls.RLI
{
	public partial class LeftRail : System.Web.UI.UserControl
	{
		private PageBaseItem navItem;
		protected void Page_Load(object sender, EventArgs e)
		{
			navItem = (PageBaseItem)Sitecore.Context.Item;
			RLIHomepageItem homeItem = ItemReference.RLI.InnerItem;
			if(homeItem == null || navItem == null)
			{
				return;
			}

			rptNavLevel1.DataSource =
				homeItem.InnerItem.Children.Select(item => (NavigationBaseItem) item).Where(
                    item => item.IncludeinSideNavigation.Checked && (navItem.ID == item.ID || navItem.InnerItem.Axes.IsDescendantOf(item)));
			rptNavLevel1.DataBind();
		}

		protected void rptNavLevel1_OnItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			List<NavigationBaseItem> children = new List<NavigationBaseItem>();
			NavigationBaseItem item = (NavigationBaseItem) e.Item.DataItem;
			HyperLink hlNavLink1 = (HyperLink) e.Item.FindControl("hlNavLink1");
			hlNavLink1.NavigateUrl = LinkUtils.GetItemUrl(item);
			hlNavLink1.Text = TitleFactory.GetRLINavTitle(item) + hlNavLink1.Text;
			if(navItem.ID == item.ID)
			{
				hlNavLink1.CssClass += " selected";
			}
			if (navItem.InnerItem.Axes.IsDescendantOf(item))
			{ 
				children = item.InnerItem.Children.Select(childItem => (NavigationBaseItem) childItem).Where(
						childItem => childItem.IncludeinSideNavigation.Checked).ToList();
			}
			if (children.Any())
			{	
			Repeater rptNavLevel2 = (Repeater) e.Item.FindControl("rptNavLevel2");
				rptNavLevel2.DataSource = children;
				rptNavLevel2.DataBind();
			}
		}

		protected void rptNavLevel2_OnItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Footer || e.Item.ItemType == ListItemType.Header)
			{
				return;
			}
			NavigationBaseItem item = (NavigationBaseItem)e.Item.DataItem;
			HyperLink hlNavLink2 = (HyperLink)e.Item.FindControl("hlNavLink2");
			hlNavLink2.NavigateUrl = LinkUtils.GetItemUrl(item);
			hlNavLink2.Text = TitleFactory.GetRLINavTitle(item) + hlNavLink2.Text;
			if (navItem.ID == item.ID)
			{
				hlNavLink2.CssClass += " selected";
			}
			if (navItem.InnerItem.Axes.IsDescendantOf(item))
			{
				Repeater rptNavLevel3 = (Repeater) e.Item.FindControl("rptNavLevel3");
				List<NavigationBaseItem> children = item.InnerItem.Children.Select(childItem => (NavigationBaseItem)childItem).Where(
						childItem => childItem.IncludeinSideNavigation.Checked).ToList();
				if (children.Any())
				{
					rptNavLevel3.DataSource = children;
					rptNavLevel3.DataBind();
				}
			}
		}

		protected void rptNavLevel3_OnItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Footer || e.Item.ItemType == ListItemType.Header)
			{
				return;
			}
			NavigationBaseItem item = (NavigationBaseItem)e.Item.DataItem;
			HyperLink hlNavLink3 = (HyperLink)e.Item.FindControl("hlNavLink3");
			hlNavLink3.NavigateUrl = LinkUtils.GetItemUrl(item);
			hlNavLink3.Text = "»" + TitleFactory.GetRLINavTitle(item) + hlNavLink3.Text;
			if (navItem.ID == item.ID)
			{
				hlNavLink3.CssClass += " selected";
			}
		}

		private Item GetParentNavigationItem(Item item)
		{
			if (BaseTemplateReference.IsValidTemplate(item, NavigationBaseItem.TemplateId))
			{
				return item;
			}

			return GetParentNavigationItem(item.Parent);
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.RLI;
using ACR.Library.RLI.Base;
using ACR.Library.RLI.Components;
using ACR.Library.RLI.Pages;
using ACR.Library.Reference;
using ACR.Library.Utils;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;

namespace ACR.controls.RLI.Responsive
{
    public partial class Header : System.Web.UI.UserControl
    {
		protected void Page_Load(object sender, EventArgs e)
		{
			RLISiteSettingsItem settingsItem = ItemReference.RLI_Settings.InnerItem;
			RLIHomepageItem homeItem = ItemReference.RLI.InnerItem;
			if(settingsItem == null)
			{
				return;
			}
            
			if (settingsItem.Logo.MediaItem != null)
			{
				imgLogo.ImageUrl = MediaManager.GetMediaUrl(settingsItem.Logo.MediaItem);
				imgLogo.AlternateText = settingsItem.Logo.MediaItem.Alt;
				imgLogo.Attributes.Add("Title", settingsItem.Logo.MediaItem.Alt);
				hlLogo.NavigateUrl = LinkUtils.GetItemUrl(homeItem);
			}
			else
			{
				hlLogo.Visible = false;
				imgLogo.Visible = false;
			}

			if(!string.IsNullOrEmpty(settingsItem.FacebookURL.Text))
			{
			hlFacebook1.NavigateUrl = hlFacebook.NavigateUrl = LinkUtils.GetExternalUrl(settingsItem.FacebookURL.Text);
			}
			else
			{
        hlFacebook1.Visible = hlFacebook.Visible = false;
			}
			if (!string.IsNullOrEmpty(settingsItem.TwitterURL.Text))
			{
        hlTwitter1.NavigateUrl = hlTwitter.NavigateUrl = LinkUtils.GetExternalUrl(settingsItem.TwitterURL.Text);
			}
			else
			{
			hlTwitter1.Visible = hlTwitter.Visible = false;
			}


			rptMainNav.DataSource =
				homeItem.InnerItem.Children.Select(item => (NavigationBaseItem)item).Where(
					item => item.IncludeinTopNavigation.Checked);
			rptMainNav.DataBind();

			rptTopLinks.DataSource = settingsItem.TopLinks.ListItems;
			rptTopLinks.DataBind();

		}

		protected void rptMainNav_OnItemDataBound(object sender, RepeaterItemEventArgs e)
		{
            if (e.Item == null || e.Item.DataItem == null)
            {
                return;
            }

            NavigationBaseItem navBaseItem = (NavigationBaseItem)e.Item.DataItem;

            if (!SitecoreUtils.IsValid(PageBaseItem.TemplateId, navBaseItem.InnerItem))
            {
                return;
            }

            PageBaseItem item = navBaseItem.InnerItem;
			HyperLink hypMainNavItem = (HyperLink)e.Item.FindControl("hypMainNavItem");
			hypMainNavItem.NavigateUrl = LinkUtils.GetItemUrl(item);
			hypMainNavItem.Text = TitleFactory.GetRLINavTitle(item);
			Repeater rptSubNav = (Repeater)e.Item.FindControl("rptSubNav");
			PlaceHolder plcSubNav = (PlaceHolder)e.Item.FindControl("plcSubNav");
			if (Sitecore.Context.Item != null && item.ID == Sitecore.Context.Item.ID)
			{
				hypMainNavItem.CssClass += " current";
			}

			List<NavigationBaseItem> subnavItems = item.InnerItem.Children.Select(navItem => (NavigationBaseItem)navItem).Where(
					navItem => navItem.IncludeinTopNavigation.Checked).ToList();

			if (subnavItems.Count == 0)
			{
				plcSubNav.Visible = false;
				return;
			}
			rptSubNav.DataSource = subnavItems;

			rptSubNav.DataBind();
		}

		protected void rptSubNav_OnItemDataBound(object sender, RepeaterItemEventArgs e)
		{
            if (e.Item == null || e.Item.DataItem == null)
            {
                return;
            }

            NavigationBaseItem navBaseItem = (NavigationBaseItem)e.Item.DataItem;

            if (!SitecoreUtils.IsValid(PageBaseItem.TemplateId, navBaseItem.InnerItem))
            {
                return;
            }

            PageBaseItem item = navBaseItem.InnerItem;
			HyperLink hypSubNavItem = (HyperLink)e.Item.FindControl("hypSubNavItem");
			hypSubNavItem.NavigateUrl = LinkUtils.GetItemUrl(item);
			hypSubNavItem.Text = TitleFactory.GetRLINavTitle(item);
			if (Sitecore.Context.Item != null && item.ID == Sitecore.Context.Item.ID)
			{
				hypSubNavItem.CssClass += " current";
			}
		}

		protected void rptTopLinks_OnItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item == null || e.Item.DataItem == null)
			{
				return;
			}
			LinkItem linkItem = new LinkItem((Item)e.Item.DataItem);
			HyperLink hlTopLink = (HyperLink)e.Item.FindControl("hlTopLink");
			if(string.IsNullOrEmpty(linkItem.LinkDestination.Url))
			{
				hlTopLink.Visible = false;
				return;
			}
			hlTopLink.NavigateUrl = LinkUtils.GetLinkFieldUrl(linkItem.LinkDestination.Field);
			hlTopLink.Text = linkItem.LinkName.Text;
			hlTopLink.Target = linkItem.LinkDestination.Field.Target;
		}
	}
    }

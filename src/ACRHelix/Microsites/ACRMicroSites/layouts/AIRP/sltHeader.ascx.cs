using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.AIRP;
using ACR.Library.AIRP.Components;
using ACR.Library.AIRP.Pages;
using ACR.Library.Reference;
using ACR.Library.Utils;
using Sitecore.Data.Items;

namespace ACR.layouts.AIRP
{
	public partial class sltHeader : UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			AIRPSiteSettingsItem settingsItem = ItemReference.Airp_GlobalSettings.InnerItem;
			AIRPHomepageItem homeItem = ItemReference.Airp.InnerItem;
			if (settingsItem == null || homeItem == null)
			{
				return;
			}

			hypLogo.NavigateUrl = LinkUtils.GetItemUrl(ItemReference.Airp.InnerItem);
			if (string.IsNullOrEmpty(Sitecore.Resources.Media.MediaManager.GetMediaUrl(settingsItem.HeaderLogo.MediaItem)))
			{
				imgLogo.Visible = false;
			}
			else
			{
				imgLogo.ImageUrl = Sitecore.Resources.Media.MediaManager.GetMediaUrl(settingsItem.HeaderLogo.MediaItem);
				imgLogo.AlternateText = settingsItem.HeaderLogo.MediaItem.Alt;
				imgLogo.Attributes.Add("title", settingsItem.HeaderLogo.MediaItem.Alt);
			}

			rptMainNav.DataSource =
				homeItem.InnerItem.Children.Select(item => (InternalPageItem) item).Where(
					item => item.Navigation != null && item.Navigation.IncludeinNavigation.Checked);
			rptMainNav.DataBind();

			rptTopLinks.DataSource = settingsItem.HeaderTopLinks.ListItems;
			rptTopLinks.DataBind();

			if (string.IsNullOrEmpty(settingsItem.FacebookURL.Text))
			{
				hypFacebook.Visible = false;
			}
			hypFacebook.NavigateUrl = LinkUtils.GetExternalUrl(settingsItem.FacebookURL.Text);
			if (string.IsNullOrEmpty(settingsItem.TwitterURL.Text))
			{
				hypTwitter.Visible = false;
			}
			hypTwitter.NavigateUrl = LinkUtils.GetExternalUrl(settingsItem.TwitterURL.Text);
			if (string.IsNullOrEmpty(settingsItem.YouTubeURL.Text))
			{
				hypYouTube.Visible = false;
			}
			hypYouTube.NavigateUrl = LinkUtils.GetExternalUrl(settingsItem.YouTubeURL.Text);

			litAdScript.Text = homeItem.AdvertisementJavaScript.Raw;
   
      //acrLogoLink.NavigateUrl = LinkUtils.GetExternalUrl(settingsItem.ACRLogoLink.Text);


      //if (string.IsNullOrEmpty(Sitecore.Resources.Media.MediaManager.GetMediaUrl(settingsItem.ACRLogo.MediaItem)))
      //{
      //  acrLogo.Visible = false;
      //}
      //else
      //{
      //  acrLogo.ImageUrl = Sitecore.Resources.Media.MediaManager.GetMediaUrl(settingsItem.ACRLogo.MediaItem);
      //  acrLogo.AlternateText = settingsItem.ACRLogo.MediaItem.Alt;
      //  acrLogo.Attributes.Add("title", settingsItem.ACRLogo.MediaItem.Alt);
      //}

    }


		protected void rptMainNav_OnItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			InternalPageItem item = (InternalPageItem) e.Item.DataItem;
			HyperLink hypMainNavItem = (HyperLink) e.Item.FindControl("hypMainNavItem");
			hypMainNavItem.NavigateUrl = LinkUtils.GetItemUrl(item);
			hypMainNavItem.Text = TitleFactory.GetAIRPNavTitle(item);
			Repeater rptSubNav = (Repeater) e.Item.FindControl("rptSubNav");
			PlaceHolder plcSubNav = (PlaceHolder) e.Item.FindControl("plcSubNav");
			if (Sitecore.Context.Item != null && item.ID == Sitecore.Context.Item.ID)
			{
				hypMainNavItem.CssClass += " current";
			}
			List<InternalPageItem> subnavItems= item.InnerItem.Children.Select(navItem => (InternalPageItem) navItem).Where(
					navItem => navItem.Navigation != null && navItem.Navigation.IncludeinNavigation.Checked).ToList();

			if(subnavItems.Count == 0)
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
			InternalPageItem item = (InternalPageItem) e.Item.DataItem;
			HyperLink hypSubNavItem = (HyperLink) e.Item.FindControl("hypSubNavItem");
			hypSubNavItem.NavigateUrl = LinkUtils.GetItemUrl(item);
			hypSubNavItem.Text = TitleFactory.GetAIRPNavTitle(item);
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
			LinkItem linkItem = new LinkItem((Item) e.Item.DataItem);
			HyperLink hypTopLink = (HyperLink) e.Item.FindControl("hypTopLink");
			hypTopLink.NavigateUrl = linkItem.LinkDestination.Url;
			hypTopLink.Text = linkItem.LinkName.Text;
			hypTopLink.Target = linkItem.LinkDestination.Field.Target;
		}
	}
}

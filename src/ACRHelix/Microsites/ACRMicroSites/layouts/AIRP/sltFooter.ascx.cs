using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.AIRP;
using ACR.Library.AIRP.Components;
using ACR.Library.AIRP.Pages;
using ACR.Library.Common.Utils;
using ACR.Library.Reference;
using ACR.Library.Utils;
using Sitecore.Data.Items;

namespace ACR.layouts.AIRP
{
	public partial class sltFooter : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			AIRPHomepageItem homeItem = ItemReference.Airp.InnerItem;
			AIRPSiteSettingsItem settingsItem = ItemReference.Airp_GlobalSettings.InnerItem;
			if(homeItem == null || settingsItem == null)
			{
				return;
			}

			rptFooterLinkColumns.DataSource =
				homeItem.InnerItem.Children.Select(item => (InternalPageItem)item).Where(
					item => item.Navigation != null && item.Navigation.IncludeinNavigation.Checked);
			rptFooterLinkColumns.DataBind();

			rptFooterSideLinks.DataSource = settingsItem.SideLinks.ListItems;
			rptFooterSideLinks.DataBind();

			hypCopyright.NavigateUrl = LinkUtils.GetLinkFieldUrl(settingsItem.CopyrightLinkUrl.Field);
			hypCopyright.Target = LinkUtils.GetLinkFieldTarget(settingsItem.CopyrightLinkUrl.Field);
			hypCopyright.Text = settingsItem.CopyrightLinkText.Text;
			hypPrivacy.NavigateUrl = LinkUtils.GetLinkFieldUrl(settingsItem.PrivacyPolicyLinkUrl.Field);
			hypPrivacy.Target = LinkUtils.GetLinkFieldTarget(settingsItem.CopyrightLinkUrl.Field);
			hypPrivacy.Text = settingsItem.PrivacyPolicyLinkText.Text;

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

			imgNewsletter.ImageUrl = LinkUtils.GetMediaUrl(settingsItem.BannerImage.MediaItem);
			hypNewsletter.NavigateUrl = LinkUtils.GetLinkFieldUrl(settingsItem.BannerLinkUrl.Field);
			hypNewsletter.Target = settingsItem.BannerLinkUrl.Field.Target;
			hypNewsletter.Text = settingsItem.BannerLinkText.Text;
			litNewsletter.Text = settingsItem.BannerText.Text;

			litDate.Text = System.DateTime.Now.Year.ToString(CultureInfo.InvariantCulture);

			if (Sitecore.Context.Item.TemplateID.ToString() != homeItem.InnerItem.TemplateID.ToString())
			{
				phAdScript.Visible = true;
				litAdScript.Text = homeItem.AdvertisementJavaScript.Raw;
			}
		}

		protected void rptFooterLinkColumns_OnItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			InternalPageItem item = (InternalPageItem)e.Item.DataItem;
			var hypHeaderLink = (HyperLink)e.Item.FindControl("hypHeaderLink");
			hypHeaderLink.NavigateUrl = LinkUtils.GetItemUrl(item);
			hypHeaderLink.Text = TitleFactory.GetAIRPNavTitle(item);
			var rptFooterLinks = (Repeater)e.Item.FindControl("rptFooterLinks");
			rptFooterLinks.DataSource =
				item.InnerItem.Children.Select(subNavItem => (InternalPageItem)subNavItem).Where(
					subNavItem => subNavItem.Navigation != null && subNavItem.Navigation.IncludeinNavigation.Checked);
			rptFooterLinks.DataBind();
		}

		protected void rptFooterLink_OnItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			InternalPageItem item = (InternalPageItem)e.Item.DataItem;
			var hypLink = (HyperLink)e.Item.FindControl("hypLink");
			hypLink.NavigateUrl = LinkUtils.GetItemUrl(item);
			hypLink.Text = TitleFactory.GetAIRPNavTitle(item);
		}

		protected void rptFooterSideLinks_OnItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			LinkItem linkItem = new LinkItem((Item)e.Item.DataItem);
			var hypTopLink = (HyperLink)e.Item.FindControl("hypSideLink");
			hypTopLink.NavigateUrl = linkItem.LinkDestination.Url;
			hypTopLink.Text = linkItem.LinkName.Text;
			hypTopLink.Target = linkItem.LinkDestination.Field.Target;
		}
	}
}
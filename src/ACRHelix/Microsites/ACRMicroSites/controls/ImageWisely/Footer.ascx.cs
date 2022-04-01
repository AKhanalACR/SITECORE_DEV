using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.Common.Interfaces;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Components;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Pages;
using ACR.Library.ImageWisely.Utils;
using ACR.Library.Reference;
using Sitecore.Data.Items;

namespace ACR.controls.ImageWisely
{
	public partial class Footer : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack) return;

			//Only display Share This on home page
			if (Sitecore.Context.Item != null && Sitecore.Context.Item.TemplateID.ToString() == HomePageItem.TemplateId)
				pnlShareThis.Visible = true;

			//Footer links
			List<IPageItem> navItems = NavUtil.GetFooterNavItems(ItemReference.ImageWisely.InnerItem);
			if (navItems.Count > 0)
			{
				RptNavLinks.DataSource = navItems;
				RptNavLinks.DataBind();
			}
			else
			{
				RptNavLinks.Visible = false;
			}

			//Footer rich text content
			if (ItemReference.IW_Global_SiteConfigurationSettings.InnerItem != null)
			{
				SiteConfigurationItem siteConfigItem = ItemReference.IW_Global_SiteConfigurationSettings.InnerItem;
				ltlFooter.Text = siteConfigItem.FooterContent.Rendered;
			}

			//Social Media Links
			if (ItemReference.IW_Global_SocialMediaLinks.InnerItem != null)
			{
				List<SocialMediaLinkItem> socialItems = NavUtil.GetSocialMediaItems(ItemReference.IW_Global_SocialMediaLinks.InnerItem);
				DisplaySocialMediaItems(socialItems);
			}
		}

		protected void RptNavLinks_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				IPageItem pItem = (IPageItem) e.Item.DataItem;
				if (pItem == null) return;

				if (String.IsNullOrEmpty(pItem.NavTitle) || String.IsNullOrEmpty(pItem.NavUrl))
					return;

				HyperLink hlNav = (HyperLink) e.Item.FindControl("hlNav");
				hlNav.Text = pItem.NavTitle;
				hlNav.NavigateUrl = pItem.NavUrl;
				hlNav.Target = pItem.NavTarget;

			}
		}

		protected void DisplaySocialMediaItems(List<SocialMediaLinkItem> socialItems)
		{
			if (socialItems == null || socialItems.Count == 0)
				return;

			foreach (SocialMediaLinkItem socialItem in socialItems)
			{
				if (socialItem.InnerItem.Name == "FaceBook")
				{
					hlFaceBook.NavigateUrl = socialItem.LinkUrl.Text;
				}
				else if (socialItem.InnerItem.Name == "Twitter")
				{
					hlTwitter.NavigateUrl = socialItem.LinkUrl.Text;
				}
			}
		}
	}
}
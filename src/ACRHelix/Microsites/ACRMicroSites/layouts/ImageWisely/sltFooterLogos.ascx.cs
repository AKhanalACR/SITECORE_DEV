using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.CustomSitecore.Extensions;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Components;
using ACR.Library.Reference;
using Sitecore.Data.Items;

namespace ACR.layouts.ImageWisely
{
	public partial class sltFooterLogos : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack)
			{
				return;
			}

			Item currentItem = Sitecore.Context.Item;
			List<Item> footerLogos = new List<Item>();
			Item logoFolder = currentItem.GetChildrenByTemplate(ItemReference.IW_LogoFolder.Guid).Select(i => i).FirstOrDefault();
			if (logoFolder != null && logoFolder.HasChildren)
			{
				footerLogos = logoFolder.GetChildrenByTemplate(FooterLogoItem.TemplateId).Select(i => i).ToList();
			}

			if (footerLogos.Any())
			{
				phFooterLogos.Visible = true;
			}

			rptFooterLogos.DataSource = footerLogos;
			rptFooterLogos.DataBind();
		}

		protected void rptFooterLogos_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				FooterLogoItem footerLogoItem = (Item)e.Item.DataItem;
				if (footerLogoItem == null)
				{
					return;
				}

				ImageButton imgBtn = e.Item.FindControl("imgBtn") as ImageButton;
				if (imgBtn != null)
				{
					imgBtn.ImageUrl = (footerLogoItem.FooterLogo.MediaItem != null) ? Sitecore.Resources.Media.MediaManager.GetMediaUrl(footerLogoItem.FooterLogo.MediaItem) : string.Empty;
					imgBtn.OnClientClick += "window.open('" + footerLogoItem.FooterLogoLink.Url + "');";
				}
			}
		}
	}
}
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace ACR.controls.MammographySavesLives {
	public partial class Header : System.Web.UI.UserControl {

		//TODO Get rid of all these weakly named fields and use GUIDs instead. I suspect this has been done in more than just this file.
		//TODO Custom Item Generator is sorely needed.

		protected Item[] socialItems;
		protected Item[] headerItems;
		protected void Page_Load(object sender, EventArgs e) {
		//start item
		Item RootItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath);
		scCHeaderLogo.Item = RootItem;
		//Utility Nav Sort
			MultilistField headerLinks = RootItem.Fields["Utility Navigation"];
			if (headerLinks != null) {
				headerItems = headerLinks.GetItems();
				if (headerItems != null && headerItems.Count() > 0) {
					HeaderLinksRepeater.ItemDataBound += new RepeaterItemEventHandler(HeaderLinksRepeater_ItemDataBound);
					HeaderLinksRepeater.DataSource = headerItems;
					HeaderLinksRepeater.DataBind();
				}
			}
			//Social Media Sort
			MultilistField socialLinks = RootItem.Fields["Header Social Media Icons"];
			if (socialLinks != null) {
				socialItems = socialLinks.GetItems();
				if (socialItems != null && socialItems.Count() > 0) {
					SocialLinksRepeater.ItemDataBound += new RepeaterItemEventHandler(SocialLinksRepeater_ItemDataBound);
					SocialLinksRepeater.DataSource = socialItems;
					SocialLinksRepeater.DataBind();
					
				}
			}
		}
		void SocialLinksRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e) {
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
				RepeaterItem item = e.Item;
				Item currentItem = (Item)item.DataItem;

				if (currentItem.TemplateName == "Social Media Link") {
					HtmlAnchor socialLink = (HtmlAnchor)item.FindControl("socialLink");
					HtmlImage socialImage = (HtmlImage)item.FindControl("socialImage");

					if (currentItem.Fields["Logo"] != null) {
						MediaItem mediaItem = ((Sitecore.Data.Fields.ImageField)currentItem.Fields["Logo"]).MediaItem;
						if (mediaItem != null)
						{
							socialImage.Src = Sitecore.Resources.Media.MediaManager.GetMediaUrl(mediaItem);
							socialImage.Alt = mediaItem.Alt;
						}
					}
					if (currentItem.Fields["Link"] != null) {
						socialLink.HRef = ((LinkField)currentItem.Fields["Link"]).Url;
					}
				}
			}
		}

		void HeaderLinksRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e) {
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
				RepeaterItem item = e.Item;
				Item currentItem = (Item)item.DataItem;

				HtmlAnchor headerLink = (HtmlAnchor)item.FindControl("headerLink");
				headerLink.HRef = Sitecore.Links.LinkManager.GetItemUrl(currentItem);
				headerLink.InnerHtml = currentItem.Name;
			}
		}
	}
}
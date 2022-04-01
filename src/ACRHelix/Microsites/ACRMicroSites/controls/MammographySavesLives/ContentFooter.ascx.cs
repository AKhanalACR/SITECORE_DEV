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
using Sitecore.Data.Items;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.controls.MammographySavesLives {
	public partial class ContentFooter : System.Web.UI.UserControl {

		//TODO Get rid of all these weakly named fields and use GUIDs instead. I suspect this has been done in more than just this file.
		//TODO Custom Item Generator is sorely needed.

		protected Item[] socialItems;
		protected Item[] footerItems;
		protected void Page_Load(object sender, EventArgs e) {
			// Get home item
			Item RootItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath);

			// Get the footer nav
			MultilistField footerLinks = RootItem.Fields["Footer Navigation"];
			if (footerLinks != null) {
				footerItems = footerLinks.GetItems();
				if (footerItems != null && footerItems.Count() > 0) {
					rptFooterLinks.ItemDataBound += new RepeaterItemEventHandler(rptFooterLinks_ItemDataBound);
					rptFooterLinks.DataSource = footerItems;
					rptFooterLinks.DataBind();
				}
			}

			// Get the footer social
			MultilistField socialLinks = RootItem.Fields["Footer Social Media Icons"];
			if (socialLinks != null) {
				socialItems = socialLinks.GetItems();
				if (socialItems != null && socialItems.Count() > 0) {
					rptSocialLinks.ItemDataBound += new RepeaterItemEventHandler(rptSocialLinks_ItemDataBound);
					rptSocialLinks.DataSource = socialItems;
					rptSocialLinks.DataBind();
				}
			}
		}

		void rptSocialLinks_ItemDataBound(object sender, RepeaterItemEventArgs e) {
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
				RepeaterItem item = e.Item;
				Item currentItem = (Item)item.DataItem;
				
				if (currentItem.TemplateName == "Social Media Link") {
					HtmlAnchor socialLink = (HtmlAnchor)item.FindControl("socialLink");
					FieldRenderer socialImage = (FieldRenderer)item.FindControl("socialImage");
					socialImage.Item = currentItem;

					if (currentItem.Fields["Link"] != null) {
						socialLink.HRef = ((LinkField)currentItem.Fields["Link"]).Url;
					}
				}
			}
		}

		void rptFooterLinks_ItemDataBound(object sender, RepeaterItemEventArgs e) {
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
				RepeaterItem item = e.Item;
				Item currentItem = (Item)item.DataItem;

				HtmlAnchor footerLink = (HtmlAnchor)item.FindControl("footerLink");
				footerLink.HRef = Sitecore.Links.LinkManager.GetItemUrl(currentItem);
				footerLink.InnerHtml = currentItem.Fields["Breadcrumb Title"].Value;
			}
		}
	}
}
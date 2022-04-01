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
using Sitecore.Web.UI.WebControls;

namespace ACR.controls.MammographySavesLives {
	public partial class Footer : System.Web.UI.UserControl {
		protected void Page_Load(object sender, EventArgs e) {
			// Get home item
			Item RootItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath);
			// Make sure fieldrenderers are looking at the home item
			scCopyrightIntro.Item = RootItem;
			scCopyrightNotice.Item = RootItem;
			// Get the footer images
			MultilistField footerImageLinks = RootItem.Fields["Footer Image Links"];
			if (footerImageLinks != null) {
				Item[] footerItems = footerImageLinks.GetItems();
				if (footerItems != null && footerItems.Count() > 0) {
					footerLogos.ItemDataBound += new RepeaterItemEventHandler(footerLogos_ItemDataBound);
					footerLogos.DataSource = footerItems;
					footerLogos.DataBind();
				}
			}
		}

		void footerLogos_ItemDataBound(object sender, RepeaterItemEventArgs e) {
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
				RepeaterItem item = e.Item;
				Item currentItem = (Item)item.DataItem;
				if (currentItem.TemplateName == "Footer Logos") {
					HtmlAnchor logoLink = (HtmlAnchor)item.FindControl("logoLink");
					FieldRenderer logoImage = (FieldRenderer)item.FindControl("logoImage");
					logoImage.Item = currentItem;
					
					if (currentItem.Fields["Footer Logo Link"] != null) {
						logoLink.HRef = ((LinkField)currentItem.Fields["Footer Logo Link"]).Url;
					}
				}
			}
		}
	}
}
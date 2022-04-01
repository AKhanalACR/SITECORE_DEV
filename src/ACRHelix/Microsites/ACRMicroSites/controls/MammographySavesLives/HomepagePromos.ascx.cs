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
	public partial class HomepagePromos : System.Web.UI.UserControl {
		protected void Page_Load(object sender, EventArgs e) {
			Item currentItem = Sitecore.Context.Item;

			MultilistField promoField = currentItem.Fields["Promotional Items"];
			if (promoField != null) {
				Item[] promoItems = promoField.GetItems();
				if (promoItems != null && promoItems.Count() > 0) {
					rptPromos.ItemDataBound += new RepeaterItemEventHandler(rptPromos_ItemDataBound);
					rptPromos.DataSource = promoItems;
					rptPromos.DataBind();
				}
			}

		}
		void rptPromos_ItemDataBound(object sender, RepeaterItemEventArgs e) {
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
				RepeaterItem item = e.Item;
				Item currentItem = (Item)item.DataItem;

				if (currentItem.TemplateName == "Promos") {
					FieldRenderer calloutTitle = (FieldRenderer)item.FindControl("calloutTitle");
					HtmlAnchor calloutAction = (HtmlAnchor)item.FindControl("calloutAction");
					FieldRenderer calloutDesc = (FieldRenderer)item.FindControl("calloutDesc");
					FieldRenderer calloutImage = (FieldRenderer)item.FindControl("calloutImage");
					calloutDesc.Item = calloutImage.Item = calloutTitle.Item = currentItem;
					
					if(currentItem.Fields["Promo Link"] != null && currentItem.Fields["Promo Link Title"] != null) {
						calloutAction.HRef = ((LinkField)currentItem.Fields["Promo Link"]).Url;
						calloutAction.Attributes["class"] += " " + ((LinkField)currentItem.Fields["Promo Link"]).Class;
						calloutAction.InnerHtml = currentItem.Fields["Promo Link Title"].Value;
						calloutAction.Visible = true;
					}
				}
			}
		}
	}
}
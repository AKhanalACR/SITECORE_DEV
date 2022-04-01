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


namespace ACR.controls.MammographySavesLives {
	public partial class RightRail_Promos : System.Web.UI.UserControl {
		protected void Page_Load(object sender, EventArgs e) {
			Item currentItem = Sitecore.Context.Item;

			MultilistField promoField = currentItem.Fields["Promotional Items"];
			if (promoField != null) {
				Item[] promoItems = promoField.GetItems();
				if (promoItems != null && promoItems.Count() > 0) {
					rptRightRailPromos.ItemDataBound += new RepeaterItemEventHandler(rptRightRailPromos_ItemDataBound);
					rptRightRailPromos.DataSource = promoItems;
					rptRightRailPromos.DataBind();
				}
			}
		}
        string getFullUrl(LinkField lf)
        {
            switch (lf.LinkType.ToLower())
            {
                case "internal":
                    // Use LinkMananger for internal links, if link is not empty
                    return lf.TargetItem != null ? Sitecore.Links.LinkManager.GetItemUrl(lf.TargetItem) : string.Empty;
                case "media":
                    // Use MediaManager for media links, if link is not empty
                    return lf.TargetItem != null
                               ? Sitecore.Resources.Media.MediaManager.GetMediaUrl(lf.TargetItem)
                               : string.Empty;
                case "external":
                    // Just return external links
                    return lf.Url;
                case "anchor":
                    // Prefix anchor link with # if link if not empty
                    return !string.IsNullOrEmpty(lf.Anchor) ? "#" + lf.Anchor : string.Empty;
                case "mailto":
                    // Just return mailto link
                    return lf.Url;
                case "javascript":
                    // Just return javascript
                    return lf.Url;
                default:
                    // Just please the compiler, this
                    // condition will never be met
                    return lf.Url;
            }
        }

	    void rptRightRailPromos_ItemDataBound(object sender, RepeaterItemEventArgs e) {
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
				RepeaterItem item = e.Item;
				Item currentItem = (Item)item.DataItem;

				if (currentItem.TemplateName == "Promos") {
					HtmlAnchor calloutTitle = (HtmlAnchor)item.FindControl("calloutTitle");
					HtmlAnchor calloutAction = (HtmlAnchor)item.FindControl("calloutAction");
					HtmlGenericControl calloutDesc = (HtmlGenericControl)item.FindControl("calloutDesc");
					HtmlImage calloutImage = (HtmlImage)item.FindControl("calloutImage");

					if (currentItem.Fields["Promo Image"] != null) {
						MediaItem mediaItem = ((Sitecore.Data.Fields.ImageField)currentItem.Fields["Promo Image"]).MediaItem;
						if (mediaItem != null)
						{
							calloutImage.Src = Sitecore.Resources.Media.MediaManager.GetMediaUrl(mediaItem);
							calloutImage.Alt = mediaItem.Alt;
						}
					}
					if (currentItem.Fields["Promo Title"] != null) {
						calloutTitle.InnerHtml = currentItem.Fields["Promo Title"].Value;

					}
					if (currentItem.Fields["Promo Teaser"] != null) {
						calloutDesc.InnerHtml = currentItem.Fields["Promo Teaser"].Value;
						calloutDesc.Visible = true;
					}
					if (currentItem.Fields["Promo Link"] != null && currentItem.Fields["Promo Link Title"] != null) {
						calloutAction.HRef = getFullUrl((LinkField)currentItem.Fields["Promo Link"]);
						calloutAction.Attributes["class"] += " " + ((LinkField)currentItem.Fields["Promo Link"]).Class;
						calloutAction.InnerHtml = currentItem.Fields["Promo Link Title"].Value;
						calloutAction.Visible = true;
					}
				}
			}
		}
	}
}
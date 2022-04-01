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
	public partial class ContentBoxFeaturedVideos : System.Web.UI.UserControl {
		protected void Page_Load(object sender, EventArgs e) {
			Item item = Sitecore.Context.Item;

			InternalLinkField featVid = ((InternalLinkField)item.Fields["Featured Video"]);
			if (featVid != null && featVid.TargetItem!=null) {
				leadVidTitle.Item = leadVidTeaser.Item = featVid.TargetItem;
				if (featVid.TargetItem.Fields["Video ID"].HasValue)
					StraightTalkVideo.VideoID = featVid.TargetItem.Fields["Video ID"].Value;
			}

			MultilistField videosField = item.Fields["Secondary Videos"];
			if (videosField != null) {
				Item[] videos = videosField.GetItems();
				if (videos != null && videos.Count() > 0) {
					rptCBVideos.ItemDataBound += new RepeaterItemEventHandler(rptCBVideos_ItemDataBound);
					rptCBVideos.DataSource = videos;
					rptCBVideos.DataBind();
				}
			}
		}

		void rptCBVideos_ItemDataBound(object sender, RepeaterItemEventArgs e) {
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
				RepeaterItem item = e.Item;
				Item currentItem = (Item)item.DataItem;
				if (currentItem.TemplateName == "Video Promo") {
					FieldRenderer vidImg = (FieldRenderer)item.FindControl("vidImg");
					FieldRenderer vidTitle = (FieldRenderer)item.FindControl("vidTitle");
					vidTitle.Item = vidImg.Item = currentItem;

					LinkField promoLink = (LinkField)currentItem.Fields["Promo Link"];
					if (promoLink != null) {
						HtmlAnchor vidImgLink = (HtmlAnchor)item.FindControl("vidImgLink");
						HtmlAnchor vidTextLink = (HtmlAnchor)item.FindControl("vidTextLink");
						vidImgLink.HRef = vidTextLink.HRef = promoLink.Url;
					}
				}
			}
		}
	}
}
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
	public partial class Carousel : System.Web.UI.UserControl {
		protected void Page_Load(object sender, EventArgs e) {
			Item currentItem = Sitecore.Context.Item;

			MultilistField slidesField = currentItem.Fields["Slides"];
			if (slidesField != null) {
				Item[] slideItems = slidesField.GetItems();
				if (slideItems != null && slideItems.Count() > 0) {

					rptCarousel.ItemDataBound += new RepeaterItemEventHandler(rptCarousel_ItemDataBound);
					rptCarousel.DataSource = slideItems;
					rptCarousel.DataBind();
				}
			}

			Control carouselScripts = Page.ParseControl(@"
<script type=""text/javascript"" src=""/js/MammographySavesLives/jquery.cycle.all.2.88.min.js""></script>
<script type=""text/javascript"" src=""/js/MammographySavesLives/rotator.js""></script>");
			Page.FindControl("phInjectScripts").Controls.Add(carouselScripts);

		}

		void rptCarousel_ItemDataBound(object sender, RepeaterItemEventArgs e) {
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
				RepeaterItem item = e.Item;
				Item currentItem = (Item)item.DataItem;

				if (currentItem.TemplateName == "Slide") {
					FieldRenderer slideText = (FieldRenderer)item.FindControl("slideText");
					FieldRenderer slideImage = (FieldRenderer)item.FindControl("slideImage");
					slideText.Item = slideImage.Item = currentItem;
				}
			}
		}
	}
}
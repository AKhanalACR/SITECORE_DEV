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
	public partial class Facts : System.Web.UI.UserControl {
		protected void Page_Load(object sender, EventArgs e) {
			Item item = Sitecore.Context.Item;
			Field leadFact = item.Fields["Lead Fact"];
			if (leadFact != null && ((InternalLinkField)leadFact).TargetItem!= null)
				leadFactImage.Item = leadFactText.Item = ((InternalLinkField)leadFact).TargetItem;

			MultilistField factsField = item.Fields["Featured Facts"];
			if (factsField != null) {
				Item[] facts = factsField.GetItems();
				if (facts != null && facts.Count() > 0) {

					rptFacts.ItemDataBound += new RepeaterItemEventHandler(rptFacts_ItemDataBound);
					rptFacts.DataSource = facts;
					rptFacts.DataBind();
				}
			}
		}

		void rptFacts_ItemDataBound(object sender, RepeaterItemEventArgs e) {
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
				RepeaterItem item = e.Item;
				Item currentItem = (Item)item.DataItem;
				if (currentItem.TemplateName == "Fact") {
					FieldRenderer factImage = (FieldRenderer)item.FindControl("factImage");
					FieldRenderer factDescription = (FieldRenderer)item.FindControl("factDescription");
					factImage.Item = factDescription.Item = currentItem;
				}
			}
		}
	}
}
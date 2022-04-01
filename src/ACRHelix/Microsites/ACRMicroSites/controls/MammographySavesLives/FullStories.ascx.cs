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
	public partial class FullStories : System.Web.UI.UserControl {
		protected void Page_Load(object sender, EventArgs e) {

			Item current = Sitecore.Context.Item;

			MultilistField storyList = current.Fields["Full Shared Stories"];
			if (storyList != null) {
				Item[] stories = storyList.GetItems();
				if (stories != null && stories.Count() > 0) {

					Repeater1.ItemDataBound += new RepeaterItemEventHandler(Repeater1_ItemDataBound);
					Repeater1.DataSource = stories;
					Repeater1.DataBind();
				}
			}
		
					Control storyScripts = Page.ParseControl(@"
<script type=""text/javascript"" src=""/js/MammographySavesLives/jquery.truncator.js""></script>");
			Page.FindControl("phStoryScripts").Controls.Add(storyScripts);
		
		}
		
		void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e) {
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
				RepeaterItem item = e.Item;
				Item currentItem = (Item)item.DataItem;
				if (currentItem.TemplateName == "Stories") {
					FieldRenderer storyThumbnail = (FieldRenderer)item.FindControl("storyThumbnail");
					FieldRenderer storyTitle = (FieldRenderer)item.FindControl("storyTitle");
					FieldRenderer storyDescription = (FieldRenderer)item.FindControl("storyDescription");
					HtmlGenericControl storyTeaserDiv = (HtmlGenericControl)item.FindControl("storyTeaserDiv");
					storyTeaserDiv.Attributes["class"] += " " + currentItem.ID.ToShortID().ToString();
					//moreLink.HRef = "~/more stories.aspx" + "?story=" + currentItem.ID;

					storyThumbnail.Item = storyTitle.Item = storyDescription.Item = currentItem;			
				}
			}
		}
	}
}
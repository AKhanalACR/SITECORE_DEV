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
	public partial class YourStories_Mini : System.Web.UI.UserControl {
		protected void Page_Load(object sender, EventArgs e) {
			Item current = Sitecore.Context.Item;

			MultilistField storyList = current.Fields["Mini Shared Stories"]; 
				if (storyList != null) {
				Item[] stories = storyList.GetItems();
				if (stories != null && stories.Count() > 0) {

					StoryRepeater.ItemDataBound += new RepeaterItemEventHandler(StoryRepeater_ItemDataBound);
					StoryRepeater.DataSource = stories;
					StoryRepeater.DataBind();
				}
			}
		}
		void StoryRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e) {
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
				RepeaterItem item = e.Item;
				Item currentItem = (Item)item.DataItem;
				if (currentItem.TemplateName == "Stories") {
					FieldRenderer storyThumbnail = (FieldRenderer)item.FindControl("storyThumbnail");
					FieldRenderer storyTitle = (FieldRenderer)item.FindControl("storyTitle");
					FieldRenderer storyTeaser = (FieldRenderer)item.FindControl("storyTeaser");
					FieldRenderer storyMoreLink = (FieldRenderer)item.FindControl("storyMoreLink");

					if (e.Item.ItemType != ListItemType.AlternatingItem) {
						HtmlGenericControl ClearStory = (HtmlGenericControl)item.FindControl("divClear");
						ClearStory.Visible = false;
					}

					// Set Story Title Link
					HtmlAnchor titleLink = (HtmlAnchor)item.FindControl("titleLink");
					titleLink.HRef = "~/survivor stories/more stories.aspx" + "?story=" + currentItem.ID.ToShortID().ToString();
					//titleLink.HRef = Sitecore.Links.LinkManager.GetItemUrl(currentItem)+"?story=" + currentItem.ID;
										
					// Set Story More Link
					HtmlAnchor moreLink = (HtmlAnchor)item.FindControl("moreLink");
					moreLink.HRef = "~/survivor stories/more stories.aspx" + "?story=" + currentItem.ID.ToShortID().ToString();
					
					storyThumbnail.Item = storyTitle.Item = storyTeaser.Item = storyMoreLink.Item = currentItem;
				}
			}
		}
	}
  }
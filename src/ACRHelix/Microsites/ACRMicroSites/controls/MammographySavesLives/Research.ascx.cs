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
	public partial class Research : System.Web.UI.UserControl {
		protected void Page_Load(object sender, EventArgs e) {

			Item current = Sitecore.Context.Item;

			//Get Researh Items
			MultilistField researchList = current.Fields["Research Items"];
			if (researchList != null) {
				Item[] research = researchList.GetItems();
				if (research != null && research.Count() > 0) {

					researchRepeater.ItemDataBound += new RepeaterItemEventHandler(researchRepeater_ItemDataBound);
					researchRepeater.DataSource = research;
					researchRepeater.DataBind();
				}
			}
		}
		//Bind the Repeater
		void researchRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e) {
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
				RepeaterItem item = e.Item;
				Item currentItem = (Item)item.DataItem;

				if (currentItem.TemplateName == "Research Item") {
					FieldRenderer researchTitle = (FieldRenderer)item.FindControl("researchTitle");
					FieldRenderer researchAuthor = (FieldRenderer)item.FindControl("researchAuthor");
					researchTitle.Item = currentItem;
					researchAuthor.Item = currentItem;

					//Set Research Item Title Link
					HtmlAnchor researchLink = (HtmlAnchor)item.FindControl("researchLink");
					FileField researchFile = ((FileField)currentItem.Fields["Research File"]);

                    if (((LinkField)currentItem.Fields["Research Link"]).IsMediaLink)
                    {
                        researchLink.HRef =
                            Sitecore.Resources.Media.MediaManager.GetMediaUrl(
                                ((LinkField)currentItem.Fields["Research Link"]).TargetItem);
                    }
                    else
                    {
                        researchLink.HRef = ((LinkField) currentItem.Fields["Research Link"]).Url;
                    }
				    if (researchFile != null && researchFile.MediaItem != null) {
						MediaItem mediaItem = researchFile.MediaItem;
						researchLink.HRef = Sitecore.Resources.Media.MediaManager.GetMediaUrl((mediaItem));
					}

					if (currentItem.Fields["Research Icon"] != null) {
					
					HtmlGenericControl itemDiv = (HtmlGenericControl)item.FindControl("itemDiv");
					//itemDiv.Attributes["class"] += " " + currentItem.InnerData.ToString;
					itemDiv.Attributes["class"] += " " + currentItem.Fields["Research Icon"].Value;
					//itemDiv.Attributes["class"] += " " + currentItem.Fields["Icon Select"].Value;
					}
					
					if (e.Item.ItemType != ListItemType.AlternatingItem) {
						HtmlGenericControl ClearDiv = (HtmlGenericControl)item.FindControl("itemClear");
						ClearDiv.Visible = false;
					}
				}
			}
		}
	}
}
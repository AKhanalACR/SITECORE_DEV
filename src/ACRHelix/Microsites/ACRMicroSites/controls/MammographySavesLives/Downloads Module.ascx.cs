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
	public partial class Downloads_Module : System.Web.UI.UserControl {
		protected void Page_Load(object sender, EventArgs e) {

			//Item current = Sitecore.Context.Item;

			////Get Downloads
			//MultilistField downloadList = current.Fields["Download Videos"];
			//if (downloadList != null) {
			//    Item[] downloads = downloadList.GetItems();
			//    if (downloads != null && downloads.Count() > 0) {

			//        downloadRepeater.ItemDataBound += new RepeaterItemEventHandler(downloadRepeater_ItemDataBound);
			//        downloadRepeater.DataSource = downloads;
			//        downloadRepeater.DataBind();
				}
			}
		}

//        //Bind the Repeater
//        void downloadRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e) {
//            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
//                RepeaterItem item = e.Item;
//                Item currentItem = (Item)item.DataItem;

//                if (currentItem.TemplateName == "News Release") {
//                    FieldRenderer downloadTitle = (FieldRenderer)item.FindControl("downloadTitle");
//                    downloadTitle.Item = currentItem;

//                    //Set Story Title Link
//                    HtmlAnchor downloadLink = (HtmlAnchor)item.FindControl("downloadlink");
//                    FileField downloadFile = ((FileField)currentItem.Fields["Download File"]);
					
//                    downloadLink.HRef = ((LinkField)currentItem.Fields["Download Link"]).Url;
					
//                    if  (downloadFile != null) {
//                        MediaItem mediaItem = downloadFile.MediaItem;
//                        downloadLink.HRef = Sitecore.StringUtil.EnsurePrefix('/', Sitecore.Resources.Media.MediaManager.GetMediaUrl((mediaItem)));
//                        }
//                }
//            }
//        }
//    }
//}
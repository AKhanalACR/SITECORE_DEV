using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ACR.Library.MammographySavesLives.DataTemplates;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace ACR.controls.MammographySavesLives.Homepage
{
	public partial class HomepageStartAt40OnTv : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			_hasStartAt40OnTvModuleItem currentItem = Sitecore.Context.Item;

			if (!string.IsNullOrEmpty(currentItem.StartAt40Title.Raw))
			{
				litComponentTitle.Text = currentItem.StartAt40Title.Text;
			}

			MultilistField videosField = currentItem.StartAt40Videos.Field;

			if (videosField != null)
			{
				Item[] videos = videosField.GetItems().Take(2).ToArray();
				if (videos != null && videos.Count() > 0)
				{
					rptVideos.ItemDataBound += new RepeaterItemEventHandler(rptVideos_ItemDataBound);
					rptVideos.DataSource = videos;
					rptVideos.DataBind();
				}
			}

			litStartAt40Intro.Text = currentItem.StartAt40Intro.Rendered.Replace("<p></p>", string.Empty);
		}

		private void rptVideos_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				RepeaterItem item = e.Item;
				Item currentItem = (Item) item.DataItem;
				if (currentItem.TemplateName == "Video Promo")
				{
					if (!string.IsNullOrEmpty(currentItem.Fields["Video ID"].Value))
					{
						YouTubeVideo video = (YouTubeVideo) item.FindControl("acrVideo");
						video.VideoID = currentItem.Fields["Video ID"].Value;
						string videoUrl = string.Format("http://www.youtube.com/watch?v={0}", video.VideoID);

						HyperLink hlVideoTitle = (HyperLink)item.FindControl("hlVideoTitle");
						hlVideoTitle.NavigateUrl = videoUrl;
						hlVideoTitle.Text = currentItem.Fields["Video Title"].Value;

						Literal litVideoDetail = (Literal)item.FindControl("litVideoDetail");
						litVideoDetail.Text = currentItem.Fields["Video Detail"].Value;

						Panel pnlShareThis = (Panel) item.FindControl("pnlShareThis");
						pnlShareThis.Attributes["addthis:url"] = videoUrl;
						pnlShareThis.Attributes["addthis:title"] = currentItem.Fields["Video Title"].Value;
						pnlShareThis.Attributes["addthis:description"] = currentItem.Fields["Video Detail"].Value;

						HtmlAnchor videoArrowLink = (HtmlAnchor) item.FindControl("videoArrowLink");
						videoArrowLink.HRef = videoUrl;
					}
				}
			}
		}
	}
}
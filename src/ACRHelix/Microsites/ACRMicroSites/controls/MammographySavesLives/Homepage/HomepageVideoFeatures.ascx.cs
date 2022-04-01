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
using ACR.Library.MammographySavesLives.DataTemplates;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using ACR.Library.Utils;

namespace ACR.controls.MammographySavesLives.Homepage
{
	public partial class HomepageVideoFeatures : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			_hasPodcastVideosItem currentItem = Sitecore.Context.Item;

			if (!string.IsNullOrEmpty(currentItem.PodcastVideosTitle.Raw))
			{
				litComponentTitle.Text = currentItem.PodcastVideosTitle.Text;
			}

			MultilistField videosField = currentItem.PodcastVideos.Field;
			if (videosField != null)
			{
				Item[] videos = videosField.GetItems();
				if (videos != null && videos.Count() > 0)
				{
					rptVideos.ItemDataBound += new RepeaterItemEventHandler(rptVideos_ItemDataBound);
					rptVideos.DataSource = videos;
					rptVideos.DataBind();
				}
			}

			litPodcastVideosIntro.Text = currentItem.PodcastVideosIntro.Rendered.Replace("<p></p>", string.Empty);
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
						pnlShareThis.Attributes["addthis:url"] = string.Format("http://www.youtube.com/watch?v={0}", video.VideoID);
						pnlShareThis.Attributes["addthis:title"] = currentItem.Fields["Video Title"].Value;
						pnlShareThis.Attributes["addthis:description"] = currentItem.Fields["Video Detail"].Value;

						HtmlAnchor videoArrowLink = (HtmlAnchor)item.FindControl("videoArrowLink");
						videoArrowLink.HRef = videoUrl;
					}
				}
			}
		}
	}
}
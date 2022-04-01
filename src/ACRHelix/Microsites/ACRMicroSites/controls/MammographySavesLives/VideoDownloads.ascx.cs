using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ACR.Library.MammographySavesLives.DataTemplates;
using ACR.Library.Utils;
using Sitecore.Common;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;

namespace ACR.controls.MammographySavesLives
{
	public partial class VideoDownloads : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			_hasVideoDownloadsModuleItem currentItem = Sitecore.Context.Item;
			MultilistField videosField = currentItem.VideoDownloads.Field;

			if (!string.IsNullOrEmpty(currentItem.VideoDownloadsTitle.Raw))
			{
				litComponentTitle.Text = currentItem.VideoDownloadsTitle.Text;
			}

			if (videosField != null)
			{
				Item[] videos = videosField.GetItems().Where(v => !string.IsNullOrEmpty(v.Fields["Video ID"].Value)).ToArray();
				if (videos.Count() > 0)
				{
					List<List<Item>> videoItems = new List<List<Item>>();
					int videoCount = 0;
					int videosLeft = videos.Count();

					while (videosLeft > 0)
					{
						List<Item> items = videos.Skip(videoCount).Take(3).ToList();
						videoItems.Add(items);
						videoCount += 3;
						videosLeft -= 3;
					}

					rptVideosDiv.DataSource = videoItems;
					rptVideosDiv.DataBind();
				}
			}
		}

		protected void rptVideosDiv_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				RepeaterItem item = e.Item;
				List<Item> currentItems = (List<Item>)item.DataItem;

				if (currentItems != null)
				{
					Repeater rptVideos = (Repeater)item.FindControl("rptVideos");

					if (rptVideos != null)
					{
						rptVideos.DataSource = currentItems;
						rptVideos.DataBind();
					}
				}
			}
		}

		protected void rptVideos_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				RepeaterItem item = e.Item;
				Item currentItem = (Item)item.DataItem;

				if (currentItem.TemplateName == "Video Promo")
				{
					Literal litVideoDetail = (Literal)item.FindControl("litVideoDetail");
					HyperLink hlVideoTitle = (HyperLink)item.FindControl("hlVideoTitle");

					if (!string.IsNullOrEmpty(currentItem.Fields["Video ID"].Value))
					{
						YouTubeVideo video = (YouTubeVideo)item.FindControl("acrVideo");
						video.VideoID = currentItem.Fields["Video ID"].Value;
						string videoUrl = string.Format("http://www.youtube.com/watch?v={0}", video.VideoID);

						hlVideoTitle.NavigateUrl = videoUrl;
						hlVideoTitle.Text = currentItem.Fields["Video Title"].Value;
						litVideoDetail.Text = currentItem.Fields["Video Detail"].Value;

						HtmlAnchor videoArrowLink = (HtmlAnchor) item.FindControl("videoArrowLink");
						videoArrowLink.HRef = videoUrl;
					}
				}
			}
		}
	}
}
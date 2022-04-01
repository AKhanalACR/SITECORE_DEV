using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.RLI.Components;
using ACR.Library.RLI.Pages;
using ACR.Library.Reference;
using ACR.Library.Utils;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;

namespace ACR.controls.RLI
{
	public partial class Carousel : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			RLIHomepageItem homeItem = ItemReference.RLI.InnerItem;
			if(homeItem == null)
			{
				Visible = false;
				return;
			}

			rptCarousel.DataSource = homeItem.SlideshowItems.ListItems;
			rptCarousel.DataBind();
		}

		protected void rptCarousel_OnItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			HomepageSliderImageItem item = new HomepageSliderImageItem((Item) e.Item.DataItem);
			HyperLink hlSlideLink = (HyperLink)e.Item.FindControl("hlSlideLink");
			Literal litSlideTitle = (Literal) e.Item.FindControl("litSlideTitle");
			Literal litSlideText = (Literal) e.Item.FindControl("litSlideText");
			Image litSlideImage = (Image) e.Item.FindControl("imgSlideImage");
			if(string.IsNullOrEmpty(MediaManager.GetMediaUrl(item.Image.MediaItem)))
			{
				e.Item.Visible = false;
				return;
			}

			litSlideImage.ImageUrl = MediaManager.GetMediaUrl(item.Image.MediaItem);// +"?w=1680&h=476&as=1&bc=white";

			if(string.IsNullOrEmpty(item.Body.Text) && string.IsNullOrEmpty(item.Title.Text))
			{
				PlaceHolder plcContent = (PlaceHolder) e.Item.FindControl("plcContent");
				plcContent.Visible = false;
				return;
			}
			litSlideText.Text = item.Body.Text;
			litSlideTitle.Text = item.Title.Text;
			if(item.Link.Field == null)
			{
				hlSlideLink.Enabled = false;
				return;
			}
			hlSlideLink.NavigateUrl = LinkUtils.GetLinkFieldUrl(item.Link.Field);
			hlSlideLink.Target = item.Link.Field.Target;

		}
	}
}
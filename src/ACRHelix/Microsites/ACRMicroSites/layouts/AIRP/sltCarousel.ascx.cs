using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.AIRP;
using ACR.Library.AIRP.Components;
using ACR.Library.Common.Interfaces.Factory;
using Sitecore.Data.Items;
using ACR.Library.AIRP.Pages;

namespace ACR.layouts.AIRP
{
	public partial class sltCarousel : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			AIRPHomepageItem item = Sitecore.Context.Item;
			if(item == null || item.ActiveItems == null)
			{
				return;
			}
			List<Item> images = item.ActiveItems.ListItems;
			if(images.Count == 1 || images.Count == 0)
			{
				spnPagerButton.Visible = false;
			}
			rptCarousel.DataSource = images;
			rptCarousel.DataBind();
		}

		protected void rptCarousel_OnItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			var item = new HomepageSliderImageItem((Item)e.Item.DataItem);
			var hlCarouselImage = (Image) e.Item.FindControl("imgCarouselImage");
			if (!string.IsNullOrEmpty(Sitecore.Resources.Media.MediaManager.GetMediaUrl(item.Image.MediaItem)))
			{
				hlCarouselImage.ImageUrl = Sitecore.Resources.Media.MediaManager.GetMediaUrl(item.Image.MediaItem);
			}
			else
			{
				hlCarouselImage.Visible = false;
			}
			var litHeader = (Literal) e.Item.FindControl("litImageHeader");
			litHeader.Text = item.Title.Text;
			var litText = (Literal) e.Item.FindControl("litImageText");
			litText.Text = item.Description.Text;
            if(item.ImageLink != null && !string.IsNullOrEmpty(item.ImageLink.Url))
            {
                var hlImageLink = (HyperLink) e.Item.FindControl("hlCarouselImageLink");
                hlImageLink.NavigateUrl = item.ImageLink.Url;
            }
		}
	}
}
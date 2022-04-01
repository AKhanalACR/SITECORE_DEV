using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ACR.Library.Common.Interfaces.Factory;
using ACR.Library.CustomSitecore.Extensions;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Base;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Components;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Pages;
using ACR.Library.Reference;
using ACR.Library.Utils;
using Sitecore.Data.Items;
using Sitecore.StringExtensions;

namespace ACR.layouts.ImageWisely
{
	public partial class sltRotatingCarousel : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack)
			{
				return;
			}

			List<Item> carouselItems = new List<Item>();
			Item carouselItemFolder = ItemReference.IW_HomepageRotatingCarouselFolder.InnerItem;
			if (carouselItemFolder != null && carouselItemFolder.HasChildren)
			{
				carouselItems = carouselItemFolder.GetChildrenByTemplate(RotatingCarouselImageItem.TemplateId).Select(i => i).ToList();
			}

			if (!carouselItems.Any())
			{
				rptHomeSlider.Visible = false;
				return;
			}

			rptHomeSlider.DataSource = carouselItems;
			rptHomeSlider.DataBind();
		}

		protected void rptHomeSlider_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				RotatingCarouselImageItem carouselItem = (Item)e.Item.DataItem;
				if (carouselItem == null)
				{
					return;
				}

				Image img = e.Item.FindControl("img") as Image;
				Literal litTitle = e.Item.FindControl("litTitle") as Literal;
				Literal litDesc = e.Item.FindControl("litDesc") as Literal;
				HyperLink hlLink = e.Item.FindControl("hlLink") as HyperLink;
				PlaceHolder phButton = e.Item.FindControl("phButton") as PlaceHolder;
				Literal litButtonLabel = e.Item.FindControl("litButtonLabel") as Literal;
				if (img != null)
				{
					litTitle.Text = carouselItem.Title.Rendered;
					litDesc.Text = carouselItem.Details.Rendered;

					string buttonLabel = carouselItem.ButtonLabel.Rendered;
					if (!buttonLabel.IsNullOrEmpty())
					{
						phButton.Visible = true;
						litButtonLabel.Text = buttonLabel;
					}

					hlLink.NavigateUrl = carouselItem.Link.Url;
					hlLink.Target = "_blank";
					img.ImageUrl = Sitecore.Resources.Media.MediaManager.GetMediaUrl(carouselItem.Image.MediaItem);
				}
			}
		}
	}
}
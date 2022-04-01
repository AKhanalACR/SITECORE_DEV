using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.AIRP.Pages;

namespace ACR.layouts.AIRP
{
	public partial class sltBanner : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{

			InternalPageItem item = Sitecore.Context.Item;
			if (item == null)
			{
				return;
			}
			if (item.HeaderImage != null && item.HeaderImage.MediaItem!= null && !string.IsNullOrEmpty(Sitecore.Resources.Media.MediaManager.GetMediaUrl(item.HeaderImage.MediaItem)))
			{
				imgBanner.ImageUrl = Sitecore.Resources.Media.MediaManager.GetMediaUrl(item.HeaderImage.MediaItem);
				if(!string.IsNullOrEmpty(item.HeaderImage.MediaItem.Alt))
				{
					imgBanner.AlternateText = item.HeaderImage.MediaItem.Alt;
					imgBanner.Attributes.Add("title", item.HeaderImage.MediaItem.Alt);

				}
				return;
			}
				imgBanner.Visible = false;
		}
	}
}
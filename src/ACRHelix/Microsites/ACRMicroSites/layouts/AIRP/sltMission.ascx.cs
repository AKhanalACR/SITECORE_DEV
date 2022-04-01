using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.AIRP;
using ACR.Library.AIRP.Pages;
using ACR.Library.Reference;
using ACR.Library.Utils;

namespace ACR.layouts.AIRP
{
	public partial class sltMission : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			AIRPHomepageItem homepageItem = ItemReference.Airp.InnerItem;
			if(homepageItem == null)
			{
				return;
			}
			litMissionText.Text = homepageItem.HomeMissionStatementText.Rendered;
			imgMissionImage.ImageUrl = LinkUtils.GetMediaUrl(homepageItem.HomeMissionStatementImage.MediaItem);
			//litAdScript.Text = homepageItem.AdvertisementJavaScript.Raw;
		}
	}
}
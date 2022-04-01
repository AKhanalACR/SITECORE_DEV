using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.AIRP.Pages;
using ACR.Library.Reference;
using Sitecore.Data.Items;
using ACR.Library.Utils;

namespace ACR.layouts.AIRP
{
	public partial class sltHomeFeaturedContent : System.Web.UI.UserControl
	{
		private const int CUTTOFF_TEXT_LIMIT = 300;

		protected void Page_Load(object sender, EventArgs e)
		{
			AIRPHomepageItem homeItem = ItemReference.Airp.InnerItem;
			if (homeItem == null)
			{
				return;
			}
			rptHomeFeatures.DataSource = homeItem.FeaturedContent.ListItems.Take(4);
			rptHomeFeatures.DataBind();
		}

		protected void rptHomeFeatures_OnItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			InternalPageItem item = new InternalPageItem((Item) e.Item.DataItem);
			Literal litContent = (Literal) e.Item.FindControl("litContent");
			HyperLink hypContentTitle = (HyperLink) e.Item.FindControl("hypContentTitle");
			hypContentTitle.Text = item.Title.Text;
			hypContentTitle.NavigateUrl = LinkUtils.GetItemUrl(item);

			litContent.Text = item.Blurb.Rendered;

		}
	}
}

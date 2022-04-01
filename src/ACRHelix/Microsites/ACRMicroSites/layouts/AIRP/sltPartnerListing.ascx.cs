using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.AIRP.Components;
using ACR.Library.AIRP.Pages;
using ACR.Library.Utils;
using Sitecore.Data.Items;

namespace ACR.layouts.AIRP
{
	public partial class PartnerListing : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			PartnerListingPageItem item = Sitecore.Context.Item;
			if(item == null)
			{
				return;
			}
			rptPartners.DataSource = item.InnerItem.Children;
			rptPartners.DataBind();
		}

		protected void rtpPartners_OnItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if(e.Item == null || e.Item.DataItem == null)
			{
				return;
			}
			PartnerListItem partner = new PartnerListItem((Item)e.Item.DataItem);
			HyperLink hypPartnerImageLink = (HyperLink)e.Item.FindControl("hypPartnerImageLink");
			Image imgPartnerimage = (Image) e.Item.FindControl("imgPartnerImage");
			HyperLink hypPartnerLink = (HyperLink) e.Item.FindControl("hypPartnerLink");
			Literal litPartnerName = (Literal) e.Item.FindControl("litPartnerName");
			Literal litPartnerLocation = (Literal) e.Item.FindControl("litPartnerLocation");
			Literal litEventDates = (Literal) e.Item.FindControl("litEventDates");
			Literal litCourseOrgs = (Literal) e.Item.FindControl("litCourseOrgs");

			hypPartnerImageLink.NavigateUrl = LinkUtils.GetExternalUrl(partner.Website.Text);

			if (partner.Icon.MediaItem != null && !string.IsNullOrEmpty(Sitecore.Resources.Media.MediaManager.GetMediaUrl(partner.Icon.MediaItem)))
			{
				imgPartnerimage.ImageUrl = Sitecore.Resources.Media.MediaManager.GetMediaUrl(partner.Icon.MediaItem);
				imgPartnerimage.AlternateText = partner.Icon.MediaItem.Alt;
				imgPartnerimage.Attributes.Add("title", partner.Icon.MediaItem.Alt);
			}
			else
			{
				imgPartnerimage.Visible = false;
			}

			hypPartnerLink.NavigateUrl = LinkUtils.GetExternalUrl(partner.Website.Text);
			hypPartnerLink.Text = partner.Website.Text;
			litPartnerName.Text = partner.Name.Text;
			litPartnerLocation.Text = partner.Location.Text;
			litEventDates.Text = partner.EventDate.Text;
			litCourseOrgs.Text = partner.CourseOrganizers.Text;
		}
	}
}
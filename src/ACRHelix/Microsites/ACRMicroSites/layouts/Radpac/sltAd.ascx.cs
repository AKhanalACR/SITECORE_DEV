using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.controls.Common;
using ACR.Library.Radpac.CustomItems.Radpac.Base;
using ACR.Library.Radpac.CustomItems.Radpac.Components;
using ACR.Library.Radpac.CustomItems.Radpac.Pages;
using ACR.Library.Reference;
using ACR.Library.Utils;

namespace ACR.layouts.Radpac
{
    public partial class sltAd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (ItemReference.IW_MediaRoom.InnerItem != null)
            //{
            //    newsLink.NavigateUrl = ItemReference.IW_MediaRoom.Url;
            //}

            if (ItemReference.Radpac_Global_HomePageAds.InnerItem != null)
            {
                List<AdItem> _adItems = ItemReference.Radpac_Global_HomePageAds.InnerItem.Children.
        Where(
        i => i.TemplateID.ToString() == AdItem.TemplateId).Select(
        i => (AdItem)i).ToList();

                if (_adItems.Count > 0)
                {
                    rptAdItem.DataSource = _adItems;
                    rptAdItem.DataBind();
                }
                else
                {
                    rptAdItem.Visible = false;
                }
            }
        }


        protected void rptAdItem_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            AdItem item = (AdItem)e.Item.DataItem;

            if (item != null && item.AdImage != null)
            {
                Literal ltlLink = (Literal)e.Item.FindControl("ltlLink");
                Literal ltlLinkEnd = (Literal)e.Item.FindControl("ltlLinkEnd");
                SitecoreImage adImage = (SitecoreImage)e.Item.FindControl("adImage");

                if (item.AdImage.MediaItem != null)
                    adImage.Initialize(item.AdImage.MediaItem,500, 261);
                else
                    adImage.Visible = false;

                if (!String.IsNullOrEmpty(item.AdURL.Url))
                {
                    ltlLink.Text = String.Format("<a href=\"{0}\" target=\"{1}\">", item.AdURL.Url,
                        (String.IsNullOrEmpty(item.AdURL.Field.Target)) ? "_blank" : item.AdURL.Field.Target);
                    ltlLinkEnd.Text = "</a>";
                }
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ACR.Library.Radpac.CustomItems.Radpac.Base;
using ACR.Library.Radpac.CustomItems.Radpac.Components;
using ACR.Library.Utils;
using Sitecore.Data.Items;


namespace ACR.layouts.Radpac
{
    public partial class sltRightModules : System.Web.UI.UserControl
    {

        private int counter = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SitecoreUtils.IsValid(ContentPageItem.TemplateId, Sitecore.Context.Item))
            {
                ContentPageItem contentPageItem = Sitecore.Context.Item;

                if (contentPageItem == null)
                {
                    return;
                }

                List<RightColumnModuleItem> _rightModules = contentPageItem.RightColumnModules.ListItems.Where(
                    i => i.TemplateID.ToString() == RightColumnModuleItem.TemplateId).Select(
                        i => (RightColumnModuleItem)i).ToList();

                if (_rightModules.Count > 0)
                {
                    rptRightModule.DataSource = _rightModules;
                    counter = _rightModules.Count - 1;
                    rptRightModule.DataBind();
                }
                else
                {
                    rptRightModule.Visible = false;
                }

            }
        }

        protected void rptRightModule_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                RightColumnModuleItem item = (RightColumnModuleItem)e.Item.DataItem;

                Image image = (Image)e.Item.FindControl("image");
                image.ImageUrl = (item != null && item.Thumbnail.MediaItem != null) ? Sitecore.Resources.Media.MediaManager.GetMediaUrl(item.Thumbnail.MediaItem) : string.Empty;

                if (!String.IsNullOrEmpty(item.ThumbnailURL.Url))
                {
                    Literal ltlLink = (Literal)e.Item.FindControl("ltlLink");
                    Literal ltlLinkEnd = (Literal)e.Item.FindControl("ltlLinkEnd"); 
                    ltlLink.Text = String.Format("<a href=\"{0}\" target=\"{1}\">", item.ThumbnailURL.Url  ,"_blank");
                        //. (String.IsNullOrEmpty(item.AdURL.Field.Target)) );
                    ltlLinkEnd.Text = "</a>";
                }

                Literal title = (Literal)e.Item.FindControl("title");
                title.Text = item.Title.Rendered;

                Literal body = (Literal)e.Item.FindControl("body");
                body.Text = item.Body.Rendered;

                // we need to style the last item differently, so attach a css classname to it.
                if (e.Item.ItemIndex == counter)
                {
                    HtmlGenericControl liMod = (HtmlGenericControl)e.Item.FindControl(("liMod"));
                    liMod.Attributes.Add("class", "last");
                }

            }

        }
    }


}
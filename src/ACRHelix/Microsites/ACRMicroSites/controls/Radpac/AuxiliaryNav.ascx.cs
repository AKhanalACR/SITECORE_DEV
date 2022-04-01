using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ACR.Library;

using ACR.Library.Common.Interfaces;
using ACR.Library.Radpac.CustomItems.Radpac.Base;
using ACR.Library.Radpac.CustomItems.Radpac.Components;
using ACR.Library.Radpac.Utils;
using ACR.Library.Reference;
using ACR.Library.Utils;
using Sitecore.Data.Items;

namespace ACR.controls.Radpac
{
    public partial class AuxiliaryNav : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

			if (ItemReference.Radpac_Global_SocialMediaLinks.InnerItem != null)
            {
				List<SocialMediaLinkItem> socialItems = NavUtil.GetSocialMediaItems(ItemReference.Radpac_Global_SocialMediaLinks.InnerItem);
                DisplaySocialMediaItems(socialItems);
            }

            List<IPageItem> navItems = NavUtil.GetAuxNavItems(ItemReference.Radpac.InnerItem);
            if (navItems.Count > 0)
            {
                RptNavLinks.DataSource = navItems;
                RptNavLinks.DataBind();
            }
            else
            {
                RptNavLinks.Visible = false;
            }
        }

        protected void RptNavLinks_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                IPageItem pItem = (IPageItem)e.Item.DataItem;
                if (pItem == null) return;

                if (String.IsNullOrEmpty(pItem.NavTitle) || String.IsNullOrEmpty(pItem.NavUrl))
                    return;

                HyperLink hlNav = (HyperLink)e.Item.FindControl("hlNav");
                hlNav.Text = pItem.NavTitle.ToUpper();
                hlNav.NavigateUrl = pItem.NavUrl;
                hlNav.Target = pItem.NavTarget;

            }
        }

        protected void DisplaySocialMediaItems(List<SocialMediaLinkItem> socialItems)
        {
            if (socialItems == null || socialItems.Count == 0)
                return;

            foreach(SocialMediaLinkItem socialItem in socialItems)
            {
                if(socialItem.InnerItem.Name == "FaceBook")
                {
                    hlFaceBook.NavigateUrl = socialItem.LinkUrl.Text;
                }
                else if (socialItem.InnerItem.Name == "Twitter")
                {
                    hlTwitter.NavigateUrl = socialItem.LinkUrl.Text;
                }
                else if (socialItem.InnerItem.Name == "LinkedIn")
                {
                    hlLinkedIn.NavigateUrl = socialItem.LinkUrl.Text;
                }
                else if (socialItem.InnerItem.Name == "YouTube")
                {
                    hlYoutube.NavigateUrl = socialItem.LinkUrl.Text;
                }
            }
        }
    }
}
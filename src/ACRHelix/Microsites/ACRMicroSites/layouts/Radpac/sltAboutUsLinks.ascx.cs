using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.Common.CustomItems;
using ACR.Library.Radpac.CustomItems.Radpac.Pages;
using ACR.Library.Reference;
using ACR.Library.Utils;

namespace ACR.layouts.Radpac
{
    public partial class sltAboutUsLinks : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (ItemReference.Radpac_AboutUs_TaskForce.InnerItem == null
            //            && ItemReference.Radpac_AboutUs_KeyContributors.InnerItem == null)
            //{
            //    phKeyCont.Visible = false;
            //    return;
            //}

            //if (ItemReference.Radpac_AboutUs_TaskForce.InnerItem == null)
            //{
            //    hlTaskForce.Visible = false;
            //}
            //else
            //{
            //    hlTaskForce.NavigateUrl = ItemReference.Radpac_AboutUs_TaskForce.Url;
            //}

            if (ItemReference.Radpac_AboutUs_KeyContributors.InnerItem == null)
            {
                hlKeyCont.Visible = false;
            }
            else
            {
                hlKeyCont.NavigateUrl = ItemReference.Radpac_AboutUs_KeyContributors.Url;
            }

            if (Sitecore.Context.Item.TemplateID.ToString() == AboutUsItem.TemplateId)
            {
                AboutUsItem aboutUsItem = Sitecore.Context.Item;
                ltlKCTitle.Text = aboutUsItem.KeyContributorsTitle.Rendered;
                ltlKCText.Text = aboutUsItem.KeyContributorsText.Rendered;
            }
        }
    }
}
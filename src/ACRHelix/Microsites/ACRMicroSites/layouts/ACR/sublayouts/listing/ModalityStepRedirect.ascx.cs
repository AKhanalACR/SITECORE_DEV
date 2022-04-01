using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACRAccreditationInformaticsLibrary;
using Sitecore.Data.Items;

namespace ACR.layouts.ACR.sublayouts.listing
{
    public partial class ModalityStepRedirect : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Item parent = Sitecore.Context.Item.Parent;

            Item[] children = parent.Axes.GetDescendants();

            string hash = "";

            for (int i = 0; i < children.Length; i++)
            {
                if (children[i].ID == Sitecore.Context.Item.ID)
                {
                    hash = "#s" + (i + 1).ToString();
                    break;
                }
            }

            Response.Redirect(ItemHelper.GetExtensionlessUrl(parent) + hash);

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ImCmp=ACR.Library.ImageWisely.CustomItems.ImageWisely.Components ;
namespace ACR.layouts.ImageWisely
{
    public partial class sltListItem : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Sitecore.Context.Item.TemplateID.ToString() != ImCmp.ListItem.TemplateId)
                    return;

                ImCmp.ListItem listItem = Sitecore.Context.Item;
                if (listItem.ListItemUrl.Url != "")
                    Response.Redirect(listItem.ListItemUrl.Url);
            }
        }
    }
}
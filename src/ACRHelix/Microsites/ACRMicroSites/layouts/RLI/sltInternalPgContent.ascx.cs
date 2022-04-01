using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.RLI.Pages;
using ACR.Library.Utils;
using Sitecore.Data.Items;

namespace ACR.layouts.RLI
{
    public partial class sltInternalPgContent : System.Web.UI.UserControl
    {
        Item item = Sitecore.Context.Item;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                return;
            }

            if (!SitecoreUtils.IsValid(InternalPageItem.TemplateId, item))
            {
                return;
            }

            InternalPageItem internalPageItem = item;

            ltlSubheader.Text = internalPageItem.Subheader.Rendered;
            ltlBody.Text = internalPageItem.InternalPageBase.Body.Rendered;

        }
    }
}
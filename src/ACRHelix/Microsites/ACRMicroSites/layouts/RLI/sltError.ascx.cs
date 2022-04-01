using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.RLI.Pages;
using ACR.Library.Utils;

namespace ACR.layouts.RLI
{
    public partial class sltError : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }

            if (!SitecoreUtils.IsValid(ErrorPageItem.TemplateId, Sitecore.Context.Item))
            {
                return;
            }

            ErrorPageItem pageItem = Sitecore.Context.Item;

            ltlErrorMsg.Text = pageItem.ErrorMessage.Rendered;
        }
    }
}
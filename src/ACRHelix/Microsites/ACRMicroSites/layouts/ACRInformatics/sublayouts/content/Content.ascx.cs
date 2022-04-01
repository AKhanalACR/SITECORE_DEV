using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ACR.layouts.ACRInformatics.sublayouts.content
{
    public partial class Content : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            link.Item = pageText.Item = pageTitle.Item = Sitecore.Context.Item;
            pageTitle.Field = "Page Title";
            pageText.Field = "Page Text";

            link.Field = "Form Link";

        }
    }
}
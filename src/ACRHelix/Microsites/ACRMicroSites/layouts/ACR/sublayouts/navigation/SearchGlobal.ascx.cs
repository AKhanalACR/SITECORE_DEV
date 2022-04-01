using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Constants;

namespace ACR.layouts.ACR.sublayouts.navigation
{
    public partial class SearchGlobal : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Page.ClientScript.GetPostBackEventReference(globalSearchPhrase, string.Empty);
        }

        protected void globalSearchBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect(Types.ItemUrls.SearchResults +
                              System.Web.HttpUtility.UrlEncode(globalSearchPhrase.Text.Trim()));
        }
    }
}
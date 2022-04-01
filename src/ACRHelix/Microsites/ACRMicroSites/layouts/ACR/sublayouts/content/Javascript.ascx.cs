using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Constants;

namespace ACR.layouts.ACR.sublayouts.content
{
    public partial class Javascript : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string jsFiles = Sitecore.Context.Item[Types.Fields.JavascriptInclude];
            string jsCode = Sitecore.Context.Item[Types.Fields.Javascript];

            javascriptPlacholder.Controls.Add(new LiteralControl(jsFiles));
            javascriptPlacholder.Controls.Add(new LiteralControl(jsCode));

        }
    }
}
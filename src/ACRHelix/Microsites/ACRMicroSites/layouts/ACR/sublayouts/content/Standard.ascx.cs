using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Constants;

namespace ACR.layouts.ACR.sublayouts.content
{
    public partial class Standard : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            mainContent.FieldName = Types.Fields.MainContent;
            contentTitle.Field = Types.Fields.Headline;
        }
    }
}
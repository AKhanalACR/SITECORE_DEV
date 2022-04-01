using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ACR.layouts.ACRInformatics.sublayouts.content
{
    public partial class InformationLinks : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            column1.Item = column2.Item = column3.Item = column4.Item = column5.Item = Sitecore.Context.Item;
            column1.Field = "Column1";
            column2.Field = "Column2";
            column3.Field = "Column3";
            column4.Field = "Column4";
            column5.Field = "Column5";
        }
    }
}
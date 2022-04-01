using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Constants;

namespace ACR.layouts.ACR.sublayouts.content
{
    public partial class TwoColumn : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            contentTitle.Field = Types.Fields.Headline;
            column1.FieldName = Types.Fields.ColumnOne;
            column2.FieldName = Types.Fields.ColumnTwo;

        }
    }
}
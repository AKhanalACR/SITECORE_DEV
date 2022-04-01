using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Constants;
using Sitecore.Data.Items;

namespace ACR.layouts.ACR.sublayouts.navigation
{
    public partial class Utility : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Item unav = Sitecore.Context.Database.GetItem(Types.Items.UtilityNav);
            utilityFieldRenderer.FieldName = Types.Fields.Utility;
            utilityFieldRenderer.Item = unav;
        }
    }
}
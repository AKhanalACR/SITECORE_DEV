using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACRAccreditationInformaticsLibrary;
using ACRInformatics.Constants;
using Sitecore.Data.Items;

namespace ACR.layouts.ACRInformatics.sublayouts.content
{
    public partial class Footer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Item item = Utilities.GetItemByGuid(InformaticsTypes.Items.Footer);
            if (item != null)
            {
                footerContent.Item = item;
                footerContent.Field = "Footer Content";
            }
        }
    }
}
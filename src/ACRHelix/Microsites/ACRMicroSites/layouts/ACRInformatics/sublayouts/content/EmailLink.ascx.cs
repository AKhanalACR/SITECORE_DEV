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
    public partial class EmailLink : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Item home = Utilities.GetItemByGuid(InformaticsTypes.Items.Home);
            if (home != null)
            {
                string mailTo = "mailto:{0}?subject={1}";
                string email = home.Fields["Email Address"].Value;
                string subject = Server.UrlEncode(home.Fields["Email Subject"].Value);

                mailToLink.NavigateUrl = string.Format(mailTo, email, subject);
            }


        }
    }
}
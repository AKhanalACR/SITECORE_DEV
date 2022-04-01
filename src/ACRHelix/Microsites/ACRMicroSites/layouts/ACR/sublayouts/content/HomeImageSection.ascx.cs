using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Constants;

namespace ACR.layouts.ACR.sublayouts.content
{
    public partial class HomeImageSection : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imageContent.Item = imageGentlyHeader.Item = homeImageContent.Item = homeImageContent.Item = Sitecore.Context.Item;

            imageGentlyHeader.Field = Types.Fields.HomeImageHeader;
            homeImageIntro.Field = Types.Fields.HomeImageIntro;
            homeImageContent.Field = Types.Fields.HomeImageContent;
            imageContent.FieldName = Types.Fields.HomeImageWiselyGently;

        }
    }
}
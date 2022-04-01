using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Constants;

namespace ACR.layouts.ACR.sublayouts.content
{
    public partial class HomeAwards : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            homeAwardContent.Item = homeAwardHeader.Item = homeAwardIntro.Item = awardSectionImages.Item = Sitecore.Context.Item;

            homeAwardHeader.Field = Types.Fields.HomeAwardsHeader;
            homeAwardIntro.Field = Types.Fields.HomeAwardsIntro;
            homeAwardContent.Field = Types.Fields.HomeAwardsContent;
            awardSectionImages.Field = Types.Fields.HomeAwardsImages;


        }
    }
}
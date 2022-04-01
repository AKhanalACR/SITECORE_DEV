using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Constants;
using Sitecore.Data.Items;

namespace ACR.layouts.ACR.sublayouts.widgets
{
    public partial class carousel : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            carouselHeaderMain.Item = carouselHeaderMain.Item = Sitecore.Context.Item;


            carouselHeaderMain.Field = carouselHeaderMobile.Field = Types.Fields.HomeCarouselHeader;
            carouselContent.Field = Types.Fields.HomeCarouselContent;


            string link = Sitecore.Context.Item[Types.Fields.HomeCarouselLink];

            if (!string.IsNullOrWhiteSpace(link))
            {
                clink.Field = Types.Fields.HomeCarouselLink;
                clink.Text = Sitecore.Context.Item[Types.Fields.HomeCarouselLinkText];
            }
            else
            {
                clink.Visible = false;
            }


            Item carouselFolder = Sitecore.Context.Database.GetItem("{B54AF1F9-2C4D-4C4C-8462-75F446DCAEC8}");
            if (carouselFolder != null)
            {
                Item[] images = carouselFolder.Axes.GetDescendants();
                carouselRepeater.DataSource = images;
                carouselRepeater.DataBind();
            }
        }


        public static string GetMediaUrl(Item item)
        {
            string mediaUrl = Sitecore.Resources.Media.MediaManager.GetMediaUrl(item);
            return mediaUrl;
        }
    }
}
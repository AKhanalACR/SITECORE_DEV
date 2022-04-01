using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACRAccreditationInformaticsLibrary;
using Sitecore.Data.Items;

namespace ACR.layouts.ACRInformatics.sublayouts.content
{
    public partial class Carousel : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] slides = Sitecore.Context.Item.Fields["Slides"].Value.Split(new char[] { '|' });

            List<Item> slideItems = new List<Item>();
            foreach (string s in slides)
            {
                Item sld = Utilities.GetItemByGuid(s);
                if (sld != null)
                {
                    slideItems.Add(sld);
                }
            }

            carouselRepeater.DataSource = slideItems;
            carouselRepeater.DataBind();


        }

        protected void carouselRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Item item = (Item)e.Item.DataItem;
            HyperLink link = (HyperLink)e.Item.FindControl("link");
            Sitecore.Web.UI.WebControls.Image image = (Sitecore.Web.UI.WebControls.Image)e.Item.FindControl("image");

            link.NavigateUrl = item.Fields["Link URL"].Value;
            if (item.Fields["New Window"].Value == "1")
            {
                link.Target = "_blank";
            }

            image.Item = item;
            image.Field = "Image";



        }
    }
}
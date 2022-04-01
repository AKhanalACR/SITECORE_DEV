using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACRAccreditationInformaticsLibrary;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using SImage = Sitecore.Web.UI.WebControls.Image;

namespace ACR.layouts.ACRInformatics.sublayouts.content
{
    public partial class Products : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] slides = Sitecore.Context.Item.Fields["Products"].Value.Split(new char[] { '|' });

            List<Item> products = new List<Item>();
            foreach (string s in slides)
            {
                Item sld = Utilities.GetItemByGuid(s);
                if (sld != null)
                {
                    products.Add(sld);
                }
            }

            productRepeater.DataSource = products;
            productRepeater.DataBind();
        }

        protected void productRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Item item = (Item)e.Item.DataItem;
            SImage image = (SImage)e.Item.FindControl("image");
            image.Item = item;
            image.Field = "Logo";

            Text text = (Text)e.Item.FindControl("text");
            Text title = (Text)e.Item.FindControl("title");

            text.Item = title.Item = item;
            text.Field = "Intro Copy";
            title.Field = "Title";

            Link link = (Link)e.Item.FindControl("link");
            link.Field = "Link";
            link.Item = item;



            Link ilink = (Link)e.Item.FindControl("imageLink");
            ilink.Field = "Link";
            ilink.Item = item;



        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACRAccreditationInformaticsLibrary;
using ACRInformatics.Constants;
using Sitecore.Data.Items;
using SImage = Sitecore.Web.UI.WebControls.Image;

namespace ACR.layouts.ACRInformatics.sublayouts.navigation
{
    public partial class Breadcrumbs : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Item> crumbs = new List<Item>();

            Item item = GetFirstMainContentItem();
            crumbs.Add(item);

            breadcrumbRepeater.DataSource = crumbs;
            breadcrumbRepeater.DataBind();
        }

        private Item GetFirstMainContentItem()
        {
            Item item = Sitecore.Context.Item;
            while (item.Parent.TemplateID.ToString() != InformaticsTypes.Templates.Home)
            {
                item = item.Parent;
            }
            return item;
        }

        protected void breadcrumbRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HyperLink link = (HyperLink)e.Item.FindControl("link");
            SImage image = (SImage)e.Item.FindControl("logo");

            Item item = (Item)e.Item.DataItem;
            if (item.ID != Sitecore.Context.Item.ID)
            {
                link.NavigateUrl = ItemHelper.GetExtensionlessUrl(item);
            }
            image.Item = item;
            image.Alt = ItemHelper.GetFieldValueOrItemName(item, "Name Override");
            image.Field = "Logo";
        }
    }
}
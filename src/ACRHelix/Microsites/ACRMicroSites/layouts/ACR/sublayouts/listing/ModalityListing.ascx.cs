using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Constants;
using Sitecore.Data.Items;

namespace ACR.layouts.ACR.sublayouts.listing
{
    public partial class ModalityListing : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Item> modalityItems = Sitecore.Context.Item.Children.Where(x => x.TemplateID.ToString() == Types.Templates.Modality).ToList();
            modalityList.DataSource = modalityItems;
            modalityList.DataBind();
        }

        protected void modalityList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Item modalItem = e.Item.DataItem as Item;
            Sitecore.Web.UI.WebControls.Image imageControl = e.Item.FindControl("modalImage") as Sitecore.Web.UI.WebControls.Image;
            imageControl.Item = modalItem;
            imageControl.Field = Types.Fields.ModalityFullCircleIcon;

            

        }
    }
}
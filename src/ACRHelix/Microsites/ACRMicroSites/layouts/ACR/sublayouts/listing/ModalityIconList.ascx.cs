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
    public partial class ModalityIconList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Item currentItem = Sitecore.Context.Database.GetItem(Types.Items.Modality);
            if (currentItem == null)
            {
                currentItem = Sitecore.Context.Item;
            }
            modalitySectionTitle.Item = Sitecore.Context.Item;
            modalitySectionTitle.Field = Types.Fields.HomeModalityHeader;

            List<Item> modalityItems = currentItem.Axes.GetDescendants().Where(x => x.TemplateID.ToString() == Types.Templates.Modality).ToList();
            if (modalityItems != null)
            {
                modalityIconList.DataSource = modalityItems;
                modalityIconList.DataBind();

            }

        }

        protected void modalityIconList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Item modalItem = e.Item.DataItem as Item;
            Sitecore.Web.UI.WebControls.Image imageControl = e.Item.FindControl("modalityIcon") as Sitecore.Web.UI.WebControls.Image;
            imageControl.Item = modalItem;
            imageControl.Field = Types.Fields.ModalityHalfCircleIcon;
        }
    }
}
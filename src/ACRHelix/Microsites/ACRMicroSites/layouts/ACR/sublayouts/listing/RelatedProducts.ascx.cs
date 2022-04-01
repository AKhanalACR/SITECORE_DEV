using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Constants;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;

namespace ACR.layouts.ACR.sublayouts.listing
{
    public partial class RelatedProducts : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var related = (Sitecore.Data.Fields.MultilistField)Sitecore.Context.Item.Fields[Types.Fields.ModalityRelatedProducts];
            if (related.Count > 0)
            {
                relatedProductRepeater.DataSource = related.GetItems();
                relatedProductRepeater.DataBind();

            }
            else
            {
                this.Visible = false;
            }
        }

        protected void relatedProductRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Item product = e.Item.DataItem as Item;

            Sitecore.Web.UI.WebControls.Image imageControl = e.Item.FindControl("productImage") as Sitecore.Web.UI.WebControls.Image;
            Link link = e.Item.FindControl("productLink") as Link;
            Link link1 = e.Item.FindControl("productImageLink") as Link;
            Link link2 = e.Item.FindControl("titleLink") as Link;
            Text text = e.Item.FindControl("titleText") as Text;

            imageControl.Item = link1.Item = link.Item = text.Item = link2.Item = product;

            imageControl.Field = Types.Fields.RelatedProductImage;
            link2.Field = link.Field = link1.Field = Types.Fields.RelatedProductLink;
            text.Field = Types.Fields.RelatedProductTitle;
        }
    }
}
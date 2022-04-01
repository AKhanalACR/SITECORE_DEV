using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Constants;
using Sitecore.Web.UI.WebControls;
using SCImage = Sitecore.Web.UI.WebControls.Image;

namespace ACR.layouts.ACR.sublayouts.widgets
{
    public partial class FacilitySeals : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            sealTitle.Field = Types.Fields.SealTitle;
            sealContent.Field = Types.Fields.SealContent;

            var seals = Sitecore.Context.Item.Axes.GetDescendants().Where(x => x.TemplateID.ToString() == Types.Templates.FacilitySeal).ToList();
            if (seals != null)
            {
                sealRepeater.DataSource = seals;
                sealRepeater.DataBind();
            }
        }

        protected void sealRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            SCImage image = e.Item.FindControl("sealImage") as SCImage;
            image.Item = (Sitecore.Data.Items.Item)e.Item.DataItem;
            image.Field = Types.Fields.FacilitySealImage;

            Text content = e.Item.FindControl("sealContent") as Text;
            content.Item = (Sitecore.Data.Items.Item)e.Item.DataItem;
            content.Field = Types.Fields.FacilitySealContent;
        }
    }
}
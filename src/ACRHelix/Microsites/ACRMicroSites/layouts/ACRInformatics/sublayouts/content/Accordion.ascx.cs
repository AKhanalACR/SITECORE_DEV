using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACRInformatics.Constants;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;

namespace ACR.layouts.ACRInformatics.sublayouts.content
{
    public partial class Accordion : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Item> items = Sitecore.Context.Item.GetChildren().Where(x => x.TemplateID.ToString() == InformaticsTypes.Templates.AccordionGroup).ToList();
            groupRepeater.DataSource = items;
            groupRepeater.DataBind();

        }

        protected void accordionRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Item item = (Item)e.Item.DataItem;

            Text title = (Text)e.Item.FindControl("title");
            Text subtitle = (Text)e.Item.FindControl("subTitle");
            Text text = (Text)e.Item.FindControl("text");
            Link link = (Link)e.Item.FindControl("link");

            title.Item = subtitle.Item = text.Item = link.Item = item;

            title.Field = "Section Title";
            subtitle.Field = "Section Subtitle";
            text.Field = "Section Content";
            link.Field = "Download URL";

            List<Item> children = item.GetChildren().Where(x => x.TemplateID.ToString() == InformaticsTypes.Templates.AccordionSection).ToList();
            if (children.Count > 0)
            {
                Repeater nested = (Repeater)e.Item.FindControl("nestedAccordion");
                nested.DataSource = children;
                nested.DataBind();
            }


        }

        protected void groupRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Item item = (Item)e.Item.DataItem;

            Text text = (Text)e.Item.FindControl("groupTitle");
            text.Field = "Title";
            text.Item = item;

            Repeater accordionRepeater = (Repeater)e.Item.FindControl("accordionRepeater");
            List<Item> items = item.GetChildren().Where(x => x.TemplateID.ToString() == InformaticsTypes.Templates.AccordionSection).ToList();
            accordionRepeater.DataSource = items;
            accordionRepeater.DataBind();

            Text groupText = (Text)e.Item.FindControl("groupText");
            groupText.Item = item;
            groupText.Field = "Text";
        }
    }
}
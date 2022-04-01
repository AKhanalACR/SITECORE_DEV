using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACRAccreditationInformaticsLibrary;
using ACRInformatics.Constants;
using Sitecore.Data.Items;

namespace ACR.layouts.ACRInformatics.sublayouts.navigation
{
    public partial class SideNavigation : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Item item = GetFirstMainContentItem();


            image.Item = item;
            image.Field = "Logo";
            logoLink.NavigateUrl = ItemHelper.GetExtensionlessUrl(item);

            sideNavTitle.Text = ItemHelper.GetFieldValueOrItemName(item, InformaticsTypes.Fields.NameOverride);


            displaySideNav();

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


        private bool ChildPagesAccordionGroups()
        {
            bool groups = false;

            List<Item> children = Sitecore.Context.Item.GetChildren().ToList();
            foreach (Item i in children)
            {
                if (i.TemplateID.ToString() == InformaticsTypes.Templates.AccordionGroup)
                {
                    groups = true;
                    break;
                }
            }
            return groups;
        }

        private void displaySideNav()
        {
            Item root = GetFirstMainContentItem();

            StringBuilder sb = new StringBuilder();
            List<Item> items = root.GetChildren().ToList();

            bool childPage = ChildPagesAccordionGroups();

            if (items != null)
            {

                foreach (Item c in items)
                {
                    if (c.TemplateID.ToString() == InformaticsTypes.Templates.MainContent && c.Fields[InformaticsTypes.Fields.HideFromNavigation].Value != "1")
                    {
                        sb.AppendLine("<li><a href=\"" + ItemHelper.GetExtensionlessUrl(c) + "\">" + ItemHelper.GetFieldValueOrItemName(c, InformaticsTypes.Fields.NameOverride) + "</a></li>");
                    }

                    //if current page display child items
                    if (c.ID == Sitecore.Context.Item.ID)
                    {
                        sb.AppendLine("<ul>");
                        List<Item> groups = c.GetChildren().ToList();
                        int count = 0;
                        foreach (Item g in groups)
                        {
                            if (g.TemplateID.ToString() == InformaticsTypes.Templates.AccordionGroup)
                            {
                                sb.AppendLine("<li><a href=\"#s" + count + "\">" + ItemHelper.GetFieldValueOrItemName(g, InformaticsTypes.Fields.NameOverride) + "</a></li>");
                                count++;
                            }
                        }
                        sb.AppendLine("</ul>");
                    }
                    /*
                    else if (c.TemplateID.ToString() == InformaticsTypes.Templates.AccordionGroup)
                    {
                        sb.AppendLine("<li><a href=\"#s" + count + "\">" + ItemHelper.GetFieldValueOrItemName(c, InformaticsTypes.Fields.NameOverride) + "</a></li>");
                        count++;
                    } */
                }
            }
            sideNav.Controls.Add(new LiteralControl(sb.ToString()));
        }
    }
}
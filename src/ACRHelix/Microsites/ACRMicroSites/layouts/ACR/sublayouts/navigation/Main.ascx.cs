using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Constants;
using ACRAccreditationInformaticsLibrary;
using Sitecore.Data.Items;

namespace ACR.layouts.ACR.sublayouts.navigation
{
    public partial class Main : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //get the home item
            Item home = Sitecore.Context.Database.GetItem(Types.Items.Home);

            //get all children from home using Sitecore API
            Item[] children = home.Children.ToArray();

            BindNavigation(children);
        }

        private void BindNavigation(IEnumerable<Item> children)
        {
            var results = (from i in children
                           where (i.TemplateID.ToString() == Types.Templates.Section || i.TemplateID.ToString() == Types.Templates.FacilitySearch) && i.Fields[Types.Fields.NavHidden].Value != "1"
                           select i);

            TopNav.DataSource = results;
            TopNav.DataBind();
        }

        protected void TopNavItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var parent = (Item)e.Item.DataItem;

                var supportingLinks = (Literal)e.Item.FindControl("NavSupportingLinks");
                var selectedItems = (Sitecore.Data.Fields.MultilistField)parent.Fields[Types.Fields.NavigationLinks];
                var supportingContent = (Literal)e.Item.FindControl("NavContent");

                supportingContent.Text = ItemHelper.GetFieldValue(parent, Types.Fields.NavigationContent);

                //set the content for the mobile only bottom section nav
                if (parent.ID.ToString() == Types.Items.Modality)
                {
                    NavContent.Text = supportingContent.Text;
                }

                RenderSupportingLinks(selectedItems.GetItems(), supportingLinks);

                if (parent.HasChildren)
                {
                    var allowedItems = GetSubLists(parent.Children.ToArray());
                    var flyout = (Repeater)e.Item.FindControl("Flyout");
                    BindSubLists(allowedItems, flyout);
                }
            }
        }

        private void RenderSupportingLinks(IEnumerable<Item> links, Literal linkList)
        {
            if (links.Count() > 0)
            {
                linkList.Text = "<ul>";

                foreach (Item linkItem in links)
                {
                    linkList.Text += "<li><a href=\"" +
                         ItemHelper.GetExtensionlessUrl(linkItem) +
                         "\">" +
                         ItemHelper.GetFieldValueOrItemName(linkItem, Types.Fields.NavNameOverride) +
                         "</a></li>";
                }

                linkList.Text += "</ul>";
            }
        }

        private IEnumerable<Item> GetSubLists(IEnumerable<Item> children)
        {
            var results = (from i in children
                           where ((i.TemplateID.ToString() == Types.Templates.Standard) ||
                           (i.TemplateID.ToString() == Types.Templates.Modality) ||
                           (i.TemplateID.ToString() == Types.Templates.ModalityStep) ||
                           (i.TemplateID.ToString() == Types.Templates.TwoColumn) ||
                           (i.TemplateID.ToString() == Types.Templates.FacilitySearch)) && i.Fields[Types.Fields.NavHidden].Value != "1"
                           select i);

            return results;
        }

        private void BindSubLists(IEnumerable<Item> allowedItems, Repeater flyout)
        {
            flyout.DataSource = allowedItems;
            flyout.DataBind();
        }

        protected void Flyout_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var parent = (Item)e.Item.DataItem;

                if (parent.HasChildren)
                {
                    var allowedItems = GetSubLists(parent.Children.ToArray());
                    var flyout = (Repeater)e.Item.FindControl("Flyout");
                    BindSubLists(allowedItems, flyout);
                }
            }
        }
    }
}
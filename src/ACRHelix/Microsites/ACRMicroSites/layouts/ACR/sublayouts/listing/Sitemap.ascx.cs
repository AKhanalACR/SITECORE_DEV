using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Constants;
using ACRAccreditationInformaticsLibrary;
using Sitecore.Data.Items;

namespace ACR.layouts.ACR.sublayouts.listing
{
    public partial class Sitemap : System.Web.UI.UserControl
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
                           where (i.TemplateID.ToString() == Types.Templates.Section)
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
                var supportingTitle = (Literal)e.Item.FindControl("NavContentTitle");

                supportingTitle.Text = ItemHelper.GetFieldValue(parent, Types.Fields.NavigationContentTitle);
                RenderSupportingLinks(selectedItems.GetItems(), supportingLinks);


                if (parent.HasChildren)
                {
                    var allowedItems = GetSubLists(parent.Children.ToArray());
                    var flyout = (Repeater)e.Item.FindControl("Nested");
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
                           (i.TemplateID.ToString() == Types.Templates.FacilitySearch))
                           select i);

            return results;
        }

        private void BindSubLists(IEnumerable<Item> allowedItems, Repeater flyout)
        {
            flyout.DataSource = allowedItems;
            flyout.DataBind();
        }

        protected void Nested_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var parent = (Item)e.Item.DataItem;

                if (parent.HasChildren)
                {
                    var allowedItems = GetSubLists(parent.Children.ToArray());
                    var flyout = (Repeater)e.Item.FindControl("Nested");
                    BindSubLists(allowedItems, flyout);
                }
            }
        }
    }
}
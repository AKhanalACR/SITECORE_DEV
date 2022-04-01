using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;

namespace ACR.controls.MammographySavesLives {
    public partial class HeaderNavigation : System.Web.UI.UserControl {

		protected void Page_Load(object sender, EventArgs e) {
			Item RootItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath);

			List<Item> navItems = RootItem.Children.Where(i => i.Fields["Show in Menu"] != null && ((CheckboxField)i.Fields["Show in Menu"]).Checked).ToList();
			navItems.Insert(0, RootItem);
			rptNav.DataSource = navItems;
			rptNav.ItemDataBound += new RepeaterItemEventHandler(rptNav_ItemDataBound);
			rptNav.DataBind();
		}

		void rptNav_ItemDataBound(object sender, RepeaterItemEventArgs e) {
			Item cItem = Sitecore.Context.Item;
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
				RepeaterItem item = e.Item;
				Item currentItem = (Item)item.DataItem;

				// Set title
				FieldRenderer navTitle = (FieldRenderer)item.FindControl("navTitle");
				navTitle.Item = currentItem;

				// Set Link
				HtmlAnchor navLink = (HtmlAnchor)item.FindControl("navLink");
				navLink.HRef = Sitecore.Links.LinkManager.GetItemUrl(currentItem);

				//Determine if it is selected
				string id = currentItem.ID.ToString();
				
				Item RootItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath);
				
				if (currentItem.ID.ToString() == RootItem.ID.ToString()) {
					
					if (cItem.ID.ToString() == RootItem.ID.ToString()) {		
					
						HtmlGenericControl listItem = (HtmlGenericControl)item.FindControl("listItem");
						listItem.Attributes["class"] += " main-nav-selected";

						}
					}
						else if (currentItem.Axes.IsAncestorOf(cItem) || (id == cItem.ID.ToString())) {
						HtmlGenericControl listItem = (HtmlGenericControl)item.FindControl("listItem");
						listItem.Attributes["class"] += " main-nav-selected";
					
					}
				}
			}
		}

	}

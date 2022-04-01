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
using ACR.Library.CustomItems.MammographySavesLives.DataTemplates;
using ACR.Library.MammographySavesLives.ContentItems;
using ACR.Library.MammographySavesLives.DataTemplates;
using Sitecore.Data.Items;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.controls.MammographySavesLives
{
	public partial class OnlineProviderResources : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			_hasOnlineProviderResourcesModuleItem currentItem = Sitecore.Context.Item;

			if (!string.IsNullOrEmpty(currentItem.OnlineProviderResourcesTitle.Raw))
			{
				litComponentTitle.Text = currentItem.OnlineProviderResourcesTitle.Text;
			}

			MultilistField onlineProviderResourcesList = currentItem.OnlineProviderResources.Field;
			if (onlineProviderResourcesList != null)
			{
				Item[] onlineProviderResources = onlineProviderResourcesList.GetItems();
				if (onlineProviderResources != null && onlineProviderResources.Count() > 0)
				{
					onlineProviderResourcesRepeater.ItemDataBound += new RepeaterItemEventHandler(onlineProviderResourcesRepeater_ItemDataBound);
					onlineProviderResourcesRepeater.DataSource = onlineProviderResources;
					onlineProviderResourcesRepeater.DataBind();
				}
			}
		}

		private void onlineProviderResourcesRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				RepeaterItem item = e.Item;
				Item currentItem = (Item) item.DataItem;

				if (currentItem.TemplateName == "Online Provider Resource")
				{
					OnlineProviderResourceItem onlineProviderResourceItem = currentItem;
					HyperLink hlOnlineProviderResourcesLink = (HyperLink) item.FindControl("hlOnlineProviderResourcesLink");
					hlOnlineProviderResourcesLink.NavigateUrl = onlineProviderResourceItem.Link.Url;
					hlOnlineProviderResourcesLink.Text = onlineProviderResourceItem.LinkText.Text;
				}
			}
		}
	}
}
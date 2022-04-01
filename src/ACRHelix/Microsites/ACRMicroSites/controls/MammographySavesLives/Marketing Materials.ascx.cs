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
using ACR.Library.MammographySavesLives.DataTemplates;
using Sitecore.Data.Items;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.controls.MammographySavesLives
{
	public partial class Marketing_Materials : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			_hasMarketingMaterialsModuleItem marketingMaterialsModuleItem = Sitecore.Context.Item;

			MultilistField marketingMaterialsList = marketingMaterialsModuleItem.MarketingMaterialsItems.Field;
			if (marketingMaterialsList != null)
			{
				Item[] marketingMaterials = marketingMaterialsList.GetItems();
				if (marketingMaterials != null && marketingMaterials.Count() > 0)
				{
					marketingMaterialsRepeater.ItemDataBound += new RepeaterItemEventHandler(marketingMaterialsRepeater_ItemDataBound);
					marketingMaterialsRepeater.DataSource = marketingMaterials;
					marketingMaterialsRepeater.DataBind();
				}
			}
		}

		private void marketingMaterialsRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				RepeaterItem item = e.Item;
				Item currentItem = (Item) item.DataItem;
				if (currentItem.TemplateName == "Physicians Media")
				{
					FieldRenderer marketingMaterialsTitle = (FieldRenderer) item.FindControl("marketingMaterialsTitle");
					FieldRenderer lowresTitle = (FieldRenderer) item.FindControl("lowresTitle");
					FieldRenderer highresTitle = (FieldRenderer) item.FindControl("highresTitle");

					marketingMaterialsTitle.Item = lowresTitle.Item = highresTitle.Item = currentItem;

					//Set Physicians Title Link1
					HtmlAnchor mediaLink1 = (HtmlAnchor) item.FindControl("mediaLink1");
					mediaLink1.HRef = Sitecore.Links.LinkManager.GetItemUrl(currentItem);

					//Set Physicians Title Link2
					HtmlAnchor mediaLink2 = (HtmlAnchor) item.FindControl("mediaLink2");
					mediaLink2.HRef = Sitecore.Links.LinkManager.GetItemUrl(currentItem);

					FileField lowresFile = ((FileField) currentItem.Fields["Low Res File"]);
					FileField hiresFile = ((FileField) currentItem.Fields["Hi Res File"]);

					if (lowresFile != null && lowresFile.MediaItem != null)
					{
						MediaItem mediaItem = lowresFile.MediaItem;
						mediaLink1.HRef = Sitecore.Resources.Media.MediaManager.GetMediaUrl((mediaItem));
					}

					if (hiresFile != null && hiresFile.MediaItem != null)
					{
						MediaItem mediaItem = hiresFile.MediaItem;
						mediaLink2.HRef = Sitecore.Resources.Media.MediaManager.GetMediaUrl((mediaItem));
					}
				}
			}
		}
	}
}
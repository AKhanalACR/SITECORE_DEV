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
using ACR.Library.MammographySavesLives.DataTemplates;
using Sitecore.Data.Items;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.controls.MammographySavesLives
{
	public partial class News_Releases : System.Web.UI.UserControl
	{
		private bool _twoColumn;

		protected void Page_Load(object sender, EventArgs e)
		{
			_hasNewsReleasesItem currentItem = Sitecore.Context.Item;

			if (currentItem.TwoColumn.Checked)
			{
				_twoColumn = true;
			}

			if (!string.IsNullOrEmpty(currentItem.NewsReleasesTitle.Raw))
			{
				litComponentTitle.Text = currentItem.NewsReleasesTitle.Text;
			}

			//Get News Releases
			MultilistField newsreleasesList = currentItem.NewsReleases.Field;
			if (newsreleasesList != null)
			{
				Item[] releases = newsreleasesList.GetItems();
				if (releases != null && releases.Count() > 0)
				{
					NewsReleaseRepeater.ItemDataBound += new RepeaterItemEventHandler(NewsReleaseRepeater_ItemDataBound);
					NewsReleaseRepeater.DataSource = releases;
					NewsReleaseRepeater.DataBind();
				}
			}

			if (_twoColumn)
			{
				divBody.Attributes["class"] = divBody.Attributes["class"].Replace("single-column", "").Trim();
		}
		}

		//Bind the Repeater
		private void NewsReleaseRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				RepeaterItem item = e.Item;
				Item currentItem = (Item) item.DataItem;

				if (currentItem.TemplateName == "News Release")
				{
					FieldRenderer newsTitle = (FieldRenderer) item.FindControl("newsTitle");
					newsTitle.Item = currentItem;

					//Set Story Title Link
					HtmlAnchor releaseLink = (HtmlAnchor) item.FindControl("releaseLink");
					FileField releaseFile = ((FileField) currentItem.Fields["News Release File"]);

					releaseLink.HRef = ((LinkField) currentItem.Fields["News Release Link"]).Url;

					if (releaseFile != null && releaseFile.MediaItem != null)
					{
						MediaItem mediaItem = releaseFile.MediaItem;
						releaseLink.HRef = Sitecore.Resources.Media.MediaManager.GetMediaUrl((mediaItem));
						}

					if (currentItem.Fields["Icon Select"] != null)
					{
						HtmlGenericControl releaseDiv = (HtmlGenericControl)item.FindControl("releaseDiv");
						releaseDiv.Attributes["class"] += " " + currentItem.Fields["Icon Select"].Value;
					}

					if (_twoColumn && e.Item.ItemType == ListItemType.AlternatingItem)
					{
						HtmlGenericControl ClearDiv = (HtmlGenericControl)item.FindControl("itemClear");
						ClearDiv.Visible = true;
				}
			}
		}
	}
	}
}

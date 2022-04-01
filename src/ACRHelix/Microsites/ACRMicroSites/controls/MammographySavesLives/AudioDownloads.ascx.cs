using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ACR.Library.Common.Utils;
using ACR.Library.MammographySavesLives.ContentItems;
using ACR.Library.MammographySavesLives.DataTemplates;
using ACR.Library.Radpac.CustomItems.Radpac.Components;
using ACR.Library.Utils;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;

namespace ACR.controls.MammographySavesLives
{
	public partial class AudioDownloads : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			_hasAudioDownloadsModuleItem audioDownloadsModuleItem = Sitecore.Context.Item;

			if (!string.IsNullOrEmpty(audioDownloadsModuleItem.AudioDownloadsModuleTitle.Raw))
			{
				litComponentTitle.Text = audioDownloadsModuleItem.AudioDownloadsModuleTitle.Text;
			}

			MultilistField audioDownloadsList = audioDownloadsModuleItem.AudioDownloadsModuleItems.Field;
			if (audioDownloadsList != null)
			{
				Item[] audioDownloads = audioDownloadsList.GetItems();
				if (audioDownloads != null && audioDownloads.Count() > 0)
				{
					rptAudioDownloadsRepeater.ItemDataBound += new RepeaterItemEventHandler(rptAudioDownloadsRepeater_ItemDataBound);
					rptAudioDownloadsRepeater.DataSource = audioDownloads;
					rptAudioDownloadsRepeater.DataBind();
				}
			}
		}

		private void rptAudioDownloadsRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				RepeaterItem item = e.Item;
				Item currentItem = (Item)item.DataItem;
				if (currentItem.TemplateName == "Audio Download")
				{
					FieldRenderer frAudioDownloadTitle = (FieldRenderer)item.FindControl("frAudioDownloadTitle");
					Repeater rptAudioDownloadFileRepeater = (Repeater) item.FindControl("rptAudioDownloadFileRepeater");

					frAudioDownloadTitle.Item = currentItem;

					List<Item> audioDownloadFileItems = currentItem.GetChildren().Where(i => i != null && SitecoreUtils.IsValid(AudioDownloadFileItem.TemplateId, i)).ToList();
					if (audioDownloadFileItems.Count() > 0)
					{
						rptAudioDownloadFileRepeater.ItemDataBound += new RepeaterItemEventHandler(rptAudioDownloadFileRepeater_ItemDataBound);
						rptAudioDownloadFileRepeater.DataSource = audioDownloadFileItems;
						rptAudioDownloadFileRepeater.DataBind();
					}
				}
			}
		}

		private void rptAudioDownloadFileRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				RepeaterItem item = e.Item;
				AudioDownloadFileItem currentItem = (Item)item.DataItem;

				if (currentItem.InnerItem.TemplateName == "Audio Download File")
				{
					HyperLink hlAudioDownloadFile = (HyperLink)item.FindControl("hlAudioDownloadFile");

					hlAudioDownloadFile.Text = currentItem.AudioDownloadFileFormat.Text;
					hlAudioDownloadFile.NavigateUrl = LinkUtil.GetLinkFieldUrl(currentItem.AudioDownloadFile.Field);
				}
			}
		}
	}
}
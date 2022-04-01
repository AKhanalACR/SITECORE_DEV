using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using ACR.controls.Common;
using ACR.Library.Common.Interfaces.Factory;
using ACR.Library.Common.Interfaces;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Pages;
using Common.Logging;

namespace ACR.layouts.ImageWisely
{
	public partial class sltListWithLogosHoriz : System.Web.UI.UserControl
	{
		private IEnumerable<IListItem> _allListItems;
		private IEnumerable<String> _allTopics;

		private static ILog _logger;

		private static ILog Logger
		{
			get
			{
				_logger = _logger ?? LogManager.GetLogger(typeof(sltListWithLogosCollapsible));
				return _logger;
			}
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				IListPage listPageItem = ItemInterfaceFactory.GetItem<IListPage>(Sitecore.Context.Item);
				_allListItems = listPageItem.ListItems;
				_allTopics = listPageItem.HeaderTitles;

			}
			catch (Exception ex)
			{
				Logger.Error("sltListWithLogosCollapsible.apsx.cs: The context item may not implement the IListPage interface.", ex);
			}

			if (_allTopics != null)
			{
				rptTopics.DataSource = _allTopics;
				rptTopics.DataBind();
			}

		}

		protected void RptTopicsItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				String listHeaderTitle = (String)e.Item.DataItem;
				var phTopic = (PlaceHolder)e.Item.FindControl("phTopic");
				if (listHeaderTitle == null)
				{
					phTopic.Visible = false;
					return;
				}

				Literal ltlHeadingTitle = (Literal)e.Item.FindControl("ltlHeadingTitle");
				ltlHeadingTitle.Text = listHeaderTitle.ToUpper();

				if (_allListItems != null && _allListItems.Count() > 0)
				{
					Repeater rptLogos = (Repeater)e.Item.FindControl("rptLogos");
					rptLogos.DataSource = _allListItems.Where(i => i.LiTopic == listHeaderTitle);
					rptLogos.DataBind();
					Repeater rptList = (Repeater)e.Item.FindControl("rptList");
					rptList.DataSource = _allListItems.Where(i => i.LiTopic == listHeaderTitle);
					rptList.DataBind();
				}
				else
				{
					phTopic.Visible = true;
				}

				if (Sitecore.Context.Item.TemplateID.ToString() == EquipmentResourcesItem.TemplateId)
				{
					Literal ltlDisclaimer = (Literal)e.Item.FindControl("ltlDisclaimer");
					ltlDisclaimer.Text = "<p class=\"disclaimer\">*These links to manufacturers' web sites contain information regarding dose settings for their specific equipment models. These links do not constitute ACR or Image Wisely endorsement of that manufacturer or equipment, and the ACR and Image Wisely are not responsible for the accuracy of any information on the manufacturers' sites.</p>";
				}
			}
		}

		protected void RptLogosDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				IListItem listItem = (IListItem)e.Item.DataItem;
				if (listItem == null) return;
				if (String.IsNullOrEmpty(listItem.LiTitle) || String.IsNullOrEmpty(listItem.LiUrl)) return;

				HyperLink hlListItem = (HyperLink)e.Item.FindControl("hlListItem");
				SitecoreImage imgListItem = (SitecoreImage)e.Item.FindControl("imgListItem");
				imgListItem.ID = "imgListItem";
				imgListItem.CssClass = "titleimg";
				imgListItem.Initialize(listItem.LiImage, 300, 103);
				hlListItem.NavigateUrl = listItem.LiUrl;
				hlListItem.Target = listItem.LiLinkTarget;
				hlListItem.Attributes.Add("title", listItem.LiDescription);
				hlListItem.ToolTip = listItem.LiDescription;
			}
		}
		protected void RptListItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				IListItem listItem = (IListItem)e.Item.DataItem;
				if (listItem == null) return;
				if (String.IsNullOrEmpty(listItem.LiTitle) || String.IsNullOrEmpty(listItem.LiUrl)) return;

				HyperLink hltxtListItem = (HyperLink)e.Item.FindControl("hltxtListItem");
				hltxtListItem.NavigateUrl = listItem.LiUrl;
				hltxtListItem.Target = listItem.LiLinkTarget;
				hltxtListItem.Text = listItem.LiTitle;
			}
		}
	}
}
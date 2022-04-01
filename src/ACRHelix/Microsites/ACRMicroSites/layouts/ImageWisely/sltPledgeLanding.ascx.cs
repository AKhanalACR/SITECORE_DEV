using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Components;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Pages;
using Sitecore.Data;
using Sitecore.Data.Items;
using ListItem = System.Web.UI.WebControls.ListItem;

namespace ACR.layouts.ImageWisely
{
	public partial class sltPledgeLanding : System.Web.UI.UserControl
	{
		Database database = Sitecore.Context.Database;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack)
			{
				return;
			}

			if (Sitecore.Context.Item.TemplateID.ToString() != PledgeLandingItem.TemplateId)
			{
				return;
			}

			PledgeLandingItem pledgeLandingItem = Sitecore.Context.Item;
			List<PledgeRoleItem> pledgeRoleItems = pledgeLandingItem.GetPledgeRoleItems();
			rptPledge.DataSource = pledgeRoleItems;
			rptPledge.DataBind();

			ltlBttmText.Text = pledgeLandingItem.TextBeneathPledgeOptions.Text;
		}

		protected void rptPledge_ItemBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				PledgeRoleItem pledgeRoleItem = e.Item.DataItem as PledgeRoleItem;
				if (pledgeRoleItem == null
							|| string.IsNullOrEmpty(pledgeRoleItem.PledgePrefixText.Raw)
							|| string.IsNullOrEmpty(pledgeRoleItem.PledgeRoleName.Raw)
							|| string.IsNullOrEmpty(pledgeRoleItem.PledgeRoleForm.Raw)
							|| string.IsNullOrEmpty(pledgeRoleItem.PledgeSuffixText.Raw))
				{
					return;
				}

				Literal litPledge = e.Item.FindControl("litPledge") as Literal;
				if (litPledge != null)
				{
					litPledge.Text = string.Format("{0} <span>{1}</span><br />{2}", pledgeRoleItem.PledgePrefixText.Rendered,
					                               pledgeRoleItem.PledgeRoleName.Rendered.ToLower(),
					                               pledgeRoleItem.PledgeSuffixText.Rendered);
				}

				HyperLink hlBtnPledge = e.Item.FindControl("hlBtnPledge") as HyperLink;
				if (hlBtnPledge != null)
				{
					PledgeFormItem pledgeForm = database.GetItem(new ID(pledgeRoleItem.PledgeRoleForm.Raw));
					hlBtnPledge.Text = "Pledge";
					hlBtnPledge.ImageUrl = "/images/ImageWisely/btn_Pledge.png";
					hlBtnPledge.NavigateUrl = pledgeForm.NavUrl;
				}

				HyperLink hlHelp = e.Item.FindControl("hlHelp") as HyperLink;
				if (hlHelp != null)
				{
					hlHelp.Attributes["rel"] = "tooltip";
					hlHelp.Attributes["title"] = pledgeRoleItem.HelpText.Rendered;
				}
			}
		}
	}
}
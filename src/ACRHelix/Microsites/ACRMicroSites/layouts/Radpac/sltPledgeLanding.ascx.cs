using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.Radpac.CustomItems.Radpac.Components;
using ACR.Library.Radpac.CustomItems.Radpac.Pages;
using Sitecore.Data.Items;
using ListItem = System.Web.UI.WebControls.ListItem;

namespace ACR.layouts.Radpac
{
    public partial class sltPledgeLanding : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            if (Sitecore.Context.Item.TemplateID.ToString() != PledgeLandingItem.TemplateId)
                return;

            PledgeLandingItem pledgeLandingItem = Sitecore.Context.Item;
            List<PledgeFormItem> pledgeFormItems = pledgeLandingItem.GetPledgeFormItems();

            ltlBttmText.Text = pledgeLandingItem.TextBeneathPledgeOptions.Text;

            ddlPledgeItems.Items.Add(new ListItem("-- Select --", String.Empty));
            foreach (PledgeFormItem p in pledgeFormItems)
            {
                if (String.IsNullOrEmpty(p.NavUrl) || p.PledgeFormType.Item == null)
                    continue;

                PledgeTypeItem pledgeTypeItem = p.PledgeFormType.Item;
                string description = String.IsNullOrEmpty(pledgeTypeItem.DisplayName) ?
                    pledgeTypeItem.Name : pledgeTypeItem.DisplayName;

                ddlPledgeItems.Items.Add(new ListItem(description, p.NavUrl));
            }

        }
        protected void ddlPledgeItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            string url = ddlPledgeItems.SelectedValue;
            if (url != String.Empty)
                Response.Redirect(url);
        }
    }
}
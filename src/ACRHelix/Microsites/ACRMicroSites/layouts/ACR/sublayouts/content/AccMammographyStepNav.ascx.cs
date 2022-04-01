namespace ACRMicroSites.layouts.ACR.sublayouts.content
{
    using Sitecore.Data.Items;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Web.UI.WebControls;
    using global::ACR.Constants;
    using Sitecore.Data;

    public partial class AccMammographyStepNav : System.Web.UI.UserControl
    {
        private const string StepNavItem = "{62C6D8D0-AFB1-428B-9BE0-5E56F75EF77E}";
        private void Page_Load(object sender, EventArgs e)
        {
            // Put user code to initialize the page here
            var item = GetDatasourceItem();
            if (item != null)
            {
                contentTitle.Item =
                headerImage.Item = item;
                contentTitle.Field = "Title";
                headerImage.Field = "Header Image";
                socialLinks.Text = item.Fields["Social Links"].Value;

                if (string.IsNullOrWhiteSpace(item.Fields["Header Image"].Value))
                {
                    imageSection.Visible = false;
                }


                BindList(item.Axes.GetDescendants());
            }
            
        }

        private void BindList(IEnumerable<Item> children)
        {
            var results = GetSubLists(children, StepNavItem);
            BindRepeater(results, StepNav);
        }

        private void BindRepeater(IEnumerable<Item> allowedItems, Repeater list)
        {
            list.DataSource = allowedItems;
            list.DataBind();
        }

        private IEnumerable<Item> GetSubLists(IEnumerable<Item> children, string allowedTemplates)
        {
            var results = (from i in children
                           where (allowedTemplates.Contains(i.TemplateID.ToString()))
                           select i);

            return results;
        }

        private Item GetDatasourceItem()
        {
            var sublayout = this.Parent as Sitecore.Web.UI.WebControls.Sublayout;
            if (sublayout != null)
            {
                Guid dataSourceId;
                Sitecore.Data.Items.Item dataSource;
                if (Guid.TryParse(sublayout.DataSource, out dataSourceId))
                {
                    dataSource = Sitecore.Context.Database.GetItem(new ID(dataSourceId));
                }
                else
                {
                    dataSource = Sitecore.Context.Database.GetItem(sublayout.DataSource);
                }
                return dataSource;
                //TODO set any other FieldRenderers here
            }
            return null;
        }

        protected void StepNav_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Literal currentNumber = (Literal)e.Item.FindControl("stepNumber");
            if (currentNumber != null)
            {
                int stepNumber = e.Item.ItemIndex + 1;
                currentNumber.Text = stepNumber > 9 ? "<u>" + stepNumber + "</u>" : "0<u>" + stepNumber + "</u>";
            }
        }
    }
}
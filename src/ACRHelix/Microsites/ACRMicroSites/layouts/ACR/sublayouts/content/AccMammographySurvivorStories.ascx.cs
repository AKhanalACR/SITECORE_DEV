namespace ACRMicroSites.layouts.ACR.sublayouts.content
{
    using System;
    using Sitecore.Data.Items;
    using System.Linq;
    using System.Collections.Generic;
    using System.Web.UI.WebControls;
    using Sitecore.Data;

    public partial class AccMammographySurvivorStories : System.Web.UI.UserControl
    {
        private const string SSItem = "{F86F77B8-2A67-47C9-B2BF-5EFBDAA1DB91}";
        private void Page_Load(object sender, EventArgs e)
        {
            // Put user code to initialize the page here
            var item = GetDatasourceItem();
            if (item != null)
            {
                sectionTitle.Item = item;
                sectionTitle.Field = "Title";
                BindList(item.Axes.GetDescendants());
            }
        }

        private void BindList(IEnumerable<Item> children)
        {
            var results = GetSubLists(children, SSItem);
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

        protected void SS_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //Literal currentNumber = (Literal)e.Item.FindControl("stepNumber");
            //if (currentNumber != null)
            //{
            //    int stepNumber = e.Item.ItemIndex + 1;
            //    currentNumber.Text = stepNumber > 9 ? "<u>" + stepNumber + "</u>" : "0<u>" + stepNumber + "</u>";
            //}
        }


    }
}
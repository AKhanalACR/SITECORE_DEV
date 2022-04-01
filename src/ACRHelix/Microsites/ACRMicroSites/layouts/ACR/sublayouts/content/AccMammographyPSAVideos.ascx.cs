namespace ACRMicroSites.layouts.ACR.sublayouts.content
{
    using Sitecore.Data;
    using Sitecore.Data.Items;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI.WebControls;

    public partial class AccMammographyPSAVideos : System.Web.UI.UserControl
    {
        private const string PSAVideoItem = "{33BBF04B-8B61-40AB-9835-AA583A278F22}";
        
        private void Page_Load(object sender, EventArgs e)
        {
            // Put user code to initialize the page here
            var item = GetDatasourceItem();
            if (item != null)
            {
                Title.Item =
                subTitle.Item =
                richText.Item = item;

                Title.Field = "Title";
                subTitle.Field = "Sub Title";
                richText.Field = "Rich Text";

                if (string.IsNullOrWhiteSpace(item.Fields["Title"].Value))
                    header.Visible = false;

                if (string.IsNullOrWhiteSpace(item.Fields["Sub Title"].Value))
                    paraSubTitle.Visible = false;
                
                BindList(item.Axes.GetDescendants());
            }
        }

        private void BindList(IEnumerable<Item> children)
        {
            var results = GetSubLists(children, PSAVideoItem);
            BindRepeater(results, PSAVideos);
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

        protected void PSA_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
           
        }
    }
}
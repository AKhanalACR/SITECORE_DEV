namespace ACRMicroSites.layouts.ACR.sublayouts.content
{
    using Sitecore.Data;
    using Sitecore.Data.Items;
    using System;

    public partial class AccMammographyRichTextSection : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            // Put user code to initialize the page here
            var item = GetDatasourceItem();
            if (item != null)
            {
                sectionTitle.Item =
                richText.Item = item;
                sectionTitle.Field = "Title";
                richText.Field = "Rich Text";

                if (string.IsNullOrWhiteSpace(item.Fields["Title"].Value))
                {
                    header.Visible = false;
                }
            }
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
            }
            return null;
        }
    }
}
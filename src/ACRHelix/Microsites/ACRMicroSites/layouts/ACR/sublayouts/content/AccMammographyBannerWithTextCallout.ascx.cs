namespace ACRMicroSites.layouts.ACR.sublayouts.content
{
    using Sitecore.Data;
    using Sitecore.Data.Items;
    using System;

    public partial class AccMammographyBannerWithTextCallout : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            // Put user code to initialize the page here
            var item = GetDatasourceItem();
            if (item != null)
            {
                BannerBackground.Item =
                LeftText.Item =
                CenterText.Item =
                RightText.Item = item;

                BannerBackground.Field = "Banner Background";
                LeftText.Field = "Left Text";
                CenterText.Field = "Center Text";
                RightText.Field = "Right Text";               
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
                //TODO set any other FieldRenderers here
            }
            return null;
        }
    }
}
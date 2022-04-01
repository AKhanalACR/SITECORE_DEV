namespace ACRMicroSites.layouts.ACR.sublayouts.content
{
    using Sitecore.Data;
    using Sitecore.Data.Items;
    using System;

    public partial class AccMammographyHero : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            // Put user code to initialize the page here
            var item = Sitecore.Context.Item;
            if (item != null)
            {
                heroBackground.Item =
                heroHeader.Item = item;

                heroBackground.Field = "Hero Image";
                heroHeader.Field = "Hero Headline";
                
            }
        }        
    }
}
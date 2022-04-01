using System;
using ACR.Library.Common.Interfaces;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using ACR.Library.RLI.Interfaces;

namespace ACR.Library.RLI.Pages
{
    public partial class RLIHomepageItem : IFeaturedWidgetsPage
{
	
    #region Implementation of IFeaturedWidgetsPage
    public List<Item> FeaturedWidgetItems
    {
        get { return this.FeaturedWidgets.ListItems; }
    }
    public int MaxNumberOfWidgets
    {
        get { return 2; }
    }
    #endregion  
}
}
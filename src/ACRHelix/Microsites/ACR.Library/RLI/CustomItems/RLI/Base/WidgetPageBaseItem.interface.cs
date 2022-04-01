using System;
using ACR.Library.Common.Interfaces;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.RLI.Base
{
    public partial class WidgetPageBaseItem : IWidgetPage
    {
        public List<Item> WidgetItems
        {
            get { return this.RightRailWidgets.ListItems; }
        }
    }
}
using System;
using ACR.Library.Common.Interfaces;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.Widgets
{
    public partial class WidgetBaseItem : IWidgetItem
    {
        public Item WidgetSublayout
        {
            get { return AssociatedSublayout.Item; }
        }

        public Item WidgetDisplayWhen
        {
            get { return DisplayWhen.Item; }
        }
    }
}
using System;
using System.Collections.Generic;
using ACR.Library.Common.Interfaces;
using Sitecore.Data.Items;

namespace ACR.Library.ACR.Base
{
    public partial class WidgetPageItem : IWidgetPage
    {
        public List<Item> WidgetItems
        {
            get { return Widgets.ListItems; }
        }
    }
}
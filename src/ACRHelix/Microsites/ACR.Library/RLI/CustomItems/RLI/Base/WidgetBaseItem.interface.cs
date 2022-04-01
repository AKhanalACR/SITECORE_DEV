using System;
using ACR.Library.Common.Interfaces;
using ACR.Library.RLI.Interfaces;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.RLI.Base
{
    public partial class WidgetBaseItem : IWidgetItem
    {
        #region Implementation of IWidgetItem
        public Item WidgetSublayout
        {
            get { return AssociatedSublayout.Item; }
        }

        public Item WidgetDisplayWhen
        {
            get { return null; }
        }
        #endregion

    }
}
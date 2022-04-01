using System;
using ACR.Library.RLI.Interfaces;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.RLI.Base
{
    public partial class NavigationBaseItem : IRLINav
    {
        public string NavTitle
        {
            get { return this.NavigationTitle.Rendered;  }
        }

        public bool IncludeInNav
        {
            get { return this.IncludeinTopNavigation.Checked; }
        }
    }
}
using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.Radpac.CustomItems.Radpac.Base
{
    public partial class PageSettingsItem
    {
    #region Implementation of IAcrProtectedContent

    public bool RequiresUserLogin
    {
        get { return RequiresLogin.Checked; }
    }
    #endregion
}
}
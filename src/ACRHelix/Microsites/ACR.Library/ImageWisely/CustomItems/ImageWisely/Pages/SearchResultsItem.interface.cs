using System;
using ACR.Library.Common.Interfaces;
using ACR.Library.Utils;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ImageWisely.CustomItems.ImageWisely.Pages
{
    public partial class SearchResultsItem : IPageItem
    {
        public string PageTitle
        {
            get { return this._PageSettingsItem.PageTitle.Text; }
        }

        public string NavTitle
        {
            get { return this._PageSettingsItem.NavigationTitle.Text; }
        }

        public string NavUrl
        {
            get { return CustomItemUtils.GetItemUrl(this); }
        }

        public string NavTarget
        {
            get { return "_self"; }
        }

    }
}
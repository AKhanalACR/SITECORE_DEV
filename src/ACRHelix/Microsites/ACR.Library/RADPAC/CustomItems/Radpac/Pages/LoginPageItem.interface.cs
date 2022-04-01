using System;
using System.Linq;

using ACR.Library.Common.Interfaces;
using ACR.Library.Common.Interfaces.Factory;
using ACR.Library.Radpac.CustomItems.Radpac.Components;
using ACR.Library.Utils;
using System.Collections.Generic;
namespace ACR.Library.Radpac.CustomItems.Radpac.Pages
{
    public partial class LoginPageItem :   IMeta
    {
        #region IPageItem implementation
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
        #endregion

       

        /* IMeta */
        #region IMeta implementation
        public string MetaTitle
        {
            get { return this._MetadataItem.MetaTitle.Raw; }
        }

        public string MetaDescription
        {
            get { return MetaUtils.StripBadGSACharacters(this._MetadataItem.MetaDescription.Raw); }
        }

        public string MetaKeywords
        {
            get { return MetaUtils.StripBadGSACharacters(this._MetadataItem.MetaKeywords.Raw); }
        }

        public string MetaDate
        {
            get { return MetaUtils.GetDate(InnerItem); }
        }

        public string MetaVerify
        {
            get { return null; }
        }
        #endregion
    }
}
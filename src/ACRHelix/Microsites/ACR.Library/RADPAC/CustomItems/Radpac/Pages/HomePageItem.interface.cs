using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.Common.Interfaces;
using ACR.Library.Utils;

namespace ACR.Library.Radpac.CustomItems.Radpac.Pages
{
    public partial class HomePageItem : IPageItem, IMeta
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

        /* IMeta */
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
    }
}

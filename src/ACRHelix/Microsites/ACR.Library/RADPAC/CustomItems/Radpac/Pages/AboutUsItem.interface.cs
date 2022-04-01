using System;
using System.Linq;

using ACR.Library.Common.Interfaces;
using ACR.Library.Common.Interfaces.Factory;
using ACR.Library.Reference;
using ACR.Library.Utils;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.Radpac.CustomItems.Radpac.Pages
{
    public partial class AboutUsItem : IPageItem, IListPage, IMeta
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

        /* IListPage - implemented to list out Participating Organizations*/
        public IEnumerable<IListItem> ListItems
        {
            get
            {
                if(ItemReference.Radpac_AboutUs_ParticipatingOrganizations.InnerItem != null)
                {
                    return
												ItemReference.Radpac_AboutUs_ParticipatingOrganizations.InnerItem.Axes.GetDescendants().Select(
														i => ItemInterfaceFactory.GetItem<IListItem>(i));
                }
                return new List<IListItem>();
            }
        }

        public IEnumerable<string> HeaderTitles
        {
            get { return (ListItems.Select(i => i.LiTopic).Distinct()).OrderByDescending(i => i); }
        }

        public bool DisplayHeaderBookmarks
        {
            get { return false; }
        }
    }

}
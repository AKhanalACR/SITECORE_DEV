using System;
using System.Linq;
using ACR.Library.Common.Interfaces;
using ACR.Library.Common.Interfaces.Factory;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Components;
using ACR.Library.Utils;
using System.Collections.Generic;
namespace ACR.Library.ImageWisely.CustomItems.ImageWisely.Pages
{
    public partial class ListPageItem : IPageItem, IListPage, IMeta
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

        /* IListPage*/
        #region IListPage implmentation
        public IEnumerable<IListItem> ListItems
        {
            get
            {

                IEnumerable<IListItem> listItems = InnerItem.Axes.GetDescendants()
                    .Where(i => SitecoreUtils.IsValid(ListItem.TemplateId, i))
										.Select(i => ItemInterfaceFactory.GetItem<IListItem>(i));
                return listItems;
            }
        }
        public IEnumerable<String> HeaderTitles
        {
            get
            {

                IEnumerable<String> titles = InnerItem.Children
                    .Where(i => SitecoreUtils.IsValid(ListHeaderItem.TemplateId, i))
                    .Select(i => ((ListHeaderItem)i).Title.Text);
                return titles;
            }
        }

        public bool DisplayHeaderBookmarks
        {
            get { return this.DisplayTopicLinks.Checked; }
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
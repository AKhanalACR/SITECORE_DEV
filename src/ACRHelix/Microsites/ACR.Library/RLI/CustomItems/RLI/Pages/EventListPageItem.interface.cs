using System;
using ACR.Library.RLI.Interfaces;
using ACR.Library.Utils;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.RLI.Pages
{
    public partial class EventListPageItem : IFeatured
    {
        #region Implementation of IFeatured
        public string FeaturedTitle
        {
            get { return PageBase.Title.Rendered; }
        }

        public string FeaturedSubheader
        {
            get { return String.Empty; }
        }

        public string FeaturedDescription
        {
            get { return String.Empty; }
        }

        public string FeaturedUrl
        {
            get { return LinkUtils.GetItemUrl(this); }
        }
        #endregion
    }
}
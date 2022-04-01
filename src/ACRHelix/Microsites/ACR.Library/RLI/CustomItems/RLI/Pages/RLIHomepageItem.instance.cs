using System;
using System.Linq;
using ACR.Library.RLI.Components;
using ACR.Library.Utils;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.RLI.Pages
{
    public partial class RLIHomepageItem 
    {
        public IList<HomeFeaturedItem> Features
        {
            get
            {
                IList<HomeFeaturedItem> features = this.FeaturedContent.ListItems
                    .Where(i => SitecoreUtils.IsValid(HomeFeaturedItem.TemplateId, i))
                    .Select(i => (HomeFeaturedItem)i).ToList();
                return features;
            }
        }
    }
}
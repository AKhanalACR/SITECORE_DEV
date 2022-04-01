using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.Common.Interfaces;
using ACR.Library.Common.Interfaces.Factory;
using ACR.Library.Utils;
using Sitecore;
using Sitecore.Data.Items;

namespace ACR.Library.Common
{
    public class StandardBreadcrumb
    {
        private IList<IPageItem> _breadcrumbLinks;

        public IList<IPageItem> BreadcrumbLinks
        {
            get { return _breadcrumbLinks; }
        }

        public StandardBreadcrumb(Item item)
        {
            _breadcrumbLinks = GetLinkItems(GetStandardBreadcrumb(item));
        }

        private List<Item> GetStandardBreadcrumb(Item root)
        {
            if (root == null) return new List<Item>();

            List<Item> crumb = new List<Item>();
            if (root.ID.ToString() != SiteUtils.GetHomeItemBySite(SiteNames.ImageWisely).ID.ToString())
            {
                crumb.AddRange(GetStandardBreadcrumb(root.Parent));
            }
            if (SitecoreUtils.IsViewable(root))
            {
                crumb.Add(root);
            }
            return crumb;
        }

        public static List<IPageItem> GetLinkItems(List<Item> items)
        {
            List<IPageItem> linkItems = new List<IPageItem>();
            foreach (Item item in items)
            {
							IPageItem pageItem = ItemInterfaceFactory.GetItem<IPageItem>(item);
                if (pageItem != null && !string.IsNullOrEmpty(pageItem.NavUrl) && !string.IsNullOrEmpty(pageItem.NavTitle))
                    linkItems.Add(pageItem);
            }
            return linkItems;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Data.Items;
using Sitecore.Links;
using Velir.SitecoreLibrary.Utilities;

namespace ACR.Library.Reference.Wrappers
{
    public class ItemReferenceObject
    {
        private string _itemGuid;
        private Item _item;

        public ItemReferenceObject(string itemGuid)
        {
            _itemGuid = itemGuid;
						_item = DatabaseReference.Context.GetItem(_itemGuid);
        }

        public string Name
        {
            get
            {
                return _item.Name;
            }
        }

        public string Path
        {
            get
            {
                return _item.Paths.Path;
            }
        }

        public string Guid
        {
            get
            {
                return _itemGuid;
            }
        }

        public string Url
        {
            get
            {
                UrlOptions opts = UrlOptions.DefaultOptions;
                opts.AlwaysIncludeServerUrl = true;
                return LinkManager.GetItemUrl(_item, opts);
            }
        }

        public Item InnerItem
        {
            get
            {
                return _item;
            }
        }
    }

}

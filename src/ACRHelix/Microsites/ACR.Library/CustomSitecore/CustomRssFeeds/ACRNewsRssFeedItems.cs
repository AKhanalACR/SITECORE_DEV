using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using CustomItemGenerator.Fields;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Collections;
using Sitecore.Rules;

namespace Sitecore.SharedSource.Syndication 
{
    public class FilterRssFeed : Sitecore.Syndication.PublicFeed
    {
        public override IEnumerable<Item> GetSourceItems()
        {
            ////Get the unfiltered items from the RSS feed 
            var unfilteredItems = base.GetSourceItems();
            IEnumerable<Item> filteredItems = null;
            MultilistField includeItems= FeedItem.Fields["Include Data Templates"];
            if (includeItems == null || includeItems.List.Count<=0)
                return filteredItems;

            filteredItems = unfilteredItems.Where(a =>includeItems.Contains(a.TemplateID.ToString()));

            return filteredItems;                   
        }
     
    }
}

using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Foundation.SitecoreExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.RhecContent.ComputedFields
{
  public class Topics : AbstractComputedIndexField
  {
    private static ID topicFieldID = new ID("{26FA29EA-7C0E-405C-BBEA-4BEA5D5A8E6A}");
    private static ID tpictemplateID = new ID("{7B3080EA-9EEC-44BA-9D6B-917640A995A4}");
    public override object ComputeFieldValue(IIndexable indexable)
    {
      // item is currently being indexed.
      Item item = indexable as SitecoreIndexableItem;
      // null check on item
      if (item != null)
      {
        if (item.IsDerived(tpictemplateID))
        {
          MultilistField tags = item.Fields[topicFieldID];
          if (tags != null)
          {
            var multilist = tags.GetItems();
            if (multilist == null || multilist.Length == 0)
              return null;
            List<string> list = new List<string>();
            foreach(var cat in multilist)
            {
              list.Add(cat.Name);
            }
            return list;
          //  return string.Join("|", multilist.Select(t => t.Name));
          }
          //return tags;
        }
      }
      return null;
    }
  }
}
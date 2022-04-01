using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Foundation.SitecoreExtensions.Extensions;

namespace ACRHelix.Foundation.Tags.ComputedFields
{
  public class TagContent : AbstractComputedIndexField
  {
   
    private static ID tagFieldID = new ID("{A2083C12-9657-4DCD-AF8E-F339C97D46D1}");
    public override object ComputeFieldValue(IIndexable indexable)
    {
      // item is currently being indexed.
      Item item = indexable as SitecoreIndexableItem;
      // null check on item
      if (item != null)
      {
        if (item.IsDerived(TagConstants.TagTemplateID))
        {
          var tags = item.Fields[tagFieldID];
          return tags;
        }
      }
      return null;
    }
  }
}
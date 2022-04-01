using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Foundation.SitecoreExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Foundation.Tags.ComputedFields
{
  public class PersonifyInterests : AbstractComputedIndexField
  {
    private static ID tagFieldID = new ID("{04A02384-9FA2-4F31-9119-DEF72149A072}");
    public override object ComputeFieldValue(IIndexable indexable)
    {
      // item is currently being indexed.
      Item item = indexable as SitecoreIndexableItem;
      // null check on item
      if (item != null)
      {
        if (item.IsDerived(TagConstants.PersonifyTagTemplateID))
        {
          var tags = item.Fields[tagFieldID];
          return tags;
        }
      }
      return null;
    }
  }
}
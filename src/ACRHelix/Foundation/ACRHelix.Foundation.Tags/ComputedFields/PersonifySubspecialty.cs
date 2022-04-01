using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Foundation.SitecoreExtensions.Extensions;

namespace ACRHelix.Foundation.Tags.ComputedFields
{
  public class PersonifySubspecialty : AbstractComputedIndexField
  {
    private static ID tagFieldID = new ID("{E751A12E-0D46-458F-A4B6-7378C0808CC9}");
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
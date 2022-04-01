using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Foundation.SitecoreExtensions.Extensions;

namespace ACRHelix.Foundation.CustomCoveo.ComputedFields.Content
{
  public class DisplayInSearchResults : IComputedIndexField
  {
    public string FieldName { get; set; }
    public string ReturnType
    {
      get
      {
        return CoveoConstants.CoveoFieldTypes.CoveoString;
      }
      set
      {

      }
    }

    public object ComputeFieldValue(IIndexable indexable)
    {
      SitecoreIndexableItem indexableItem = indexable as SitecoreIndexableItem;
      if (indexableItem.Item.IsDerived(SitecoreConstants.Templates.AccessandEntitlements.TemplateID))
      {
        string value = indexableItem.Item.Fields[SitecoreConstants.Templates.AccessandEntitlements.Fields.DisplaySearchResults].Value;
        if (value != "1")
        {
          return "0";
        }
      }
            if (indexableItem.Item.IsDerived(SitecoreConstants.Templates.IdeasHasPageContent.TemplateID))
            {
                string value = indexableItem.Item.Fields[SitecoreConstants.Templates.IdeasHasPageContent.Fields.IdeasDisplaySearchResults].Value;
                if (value != "1")
                {
                    return "0";
                }
            }
            return "1";
    }
  }
}
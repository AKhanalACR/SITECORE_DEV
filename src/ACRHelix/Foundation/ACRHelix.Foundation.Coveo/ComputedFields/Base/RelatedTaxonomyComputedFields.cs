using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.ContentSearch;
using Sitecore.Foundation.SitecoreExtensions.Extensions;
using ACR.Foundation.Personify.Models.Taxonomy;
using ACR.Foundation.Personify.Models.Base;
using Glass.Mapper.Sc;
using Sitecore.Data;

namespace ACRHelix.Foundation.CustomCoveo.ComputedFields.Base
{
  public class RelatedTaxonomyComputedFields : IBaseComputedField
  {
    public ID FieldID { get; set; }
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

    public object ComputeFieldValue(IIndexable p_Indexable)
    {
      SitecoreIndexableItem indexableItem = p_Indexable as SitecoreIndexableItem;
      if (indexableItem != null)
      {

        if (indexableItem.Item.IsDerived(PersonifyTags.TemplateID))
        {
          List<string> names = new List<string>();

          IIndexableDataField dataField = indexableItem.GetFieldById(FieldID);
          string value = dataField.Value.ToString();

          string[] ids = value.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
          foreach (string id in ids)
          {
            string name = TaxonomyFieldCache.GetTaxonomyName(id);
            if (!string.IsNullOrWhiteSpace(name))
            {
              names.Add(name);
            }
          }
          if (names.Count > 0)
          {
            return string.Join(";", names);
          }
        }
      }
      return null;
    }
  }
}
using System.Collections.Generic;
using System.Linq;
using Sitecore.ContentSearch;
using Sitecore.Data.Fields;
using ACR.Foundation.Personify.Models.Products;
using ACR.Foundation.Personify.Models.Taxonomy.RLI;
using ACRHelix.Foundation.Repository;
using Glass.Mapper.Sc;
using ACR.Foundation.Personify.Helpers;
using System;
using Sitecore.Data;

namespace ACRHelix.Foundation.CustomCoveo.ComputedFields.Base.RLI
{
  public class RLITaxonomyField : IBaseComputedField
  {
    public ID FieldID { get; set; }

    public string FieldName
    {
      get; set;
    }

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
        if (indexableItem.Item.TemplateID.ToString() == ProductStubItem.TemplateID)
        {
          CheckboxField isRli = indexableItem.Item.Fields[SitecoreConstants.Templates.ProductStub.Fields.IsRLICheckBox];
          if (isRli.Checked)
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
      }
      return null;
    }
  }
}
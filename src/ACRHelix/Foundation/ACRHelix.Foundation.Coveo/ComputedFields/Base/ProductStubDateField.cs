using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.ContentSearch;
using ACR.Foundation.Personify.Models.Products;
using Glass.Mapper.Sc;
using Sitecore.Data;
using Sitecore;

namespace ACRHelix.Foundation.CustomCoveo.ComputedFields.Base
{
  public class ProductStubDateField : IBaseDateComputedField
  {
    public ID FieldID { get; set; }
    public bool ConvertMaxDate { get; set; }
    public string FieldName { get; set; }
    public string ReturnType
    {
      get
      {
        return CoveoConstants.CoveoFieldTypes.CoveoDateTime;
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
          IIndexableDataField dataField = indexableItem.GetFieldById(FieldID);

          DateTime defaultValue = DateTime.MinValue;
          if (ConvertMaxDate)
          {
            defaultValue = DateTime.MaxValue;
          }

          DateTime dt = DateUtil.ParseDateTime(dataField.Value.ToString(), defaultValue);
          if (ConvertMaxDate)
          {
            if (dt.CompareTo(DateTime.UtcNow.AddYears(-500)) < 0)
            {
              dt = DateTime.MaxValue;
            }
          }
          if (dt.Kind != DateTimeKind.Utc)
          {
            dt = dt.ToUniversalTime();
          }
          return dt.ToString(CoveoConstants.CoveoFormats.CoveoIndexDateFormat);
        }
      }
      return null;
    }
  }
}
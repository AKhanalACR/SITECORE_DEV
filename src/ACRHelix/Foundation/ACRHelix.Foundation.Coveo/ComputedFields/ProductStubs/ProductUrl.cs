using Sitecore.ContentSearch.ComputedFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.ContentSearch;
using ACR.Foundation.Personify.Models.Products;
using ACRHelix.Foundation.CustomCoveo.Services;
using ACR.Foundation.Personify.Helpers;

namespace ACRHelix.Foundation.CustomCoveo.ComputedFields.ProductStubs
{
  public class ProductUrl : IComputedIndexField
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
      if (indexableItem != null)
      {
        if (indexableItem.Item.TemplateID.ToString() == ProductStubItem.TemplateID)
        {
          try
          {
            var productStub = CoveoSitecoreService.Service.Cast<ProductStubItem>(indexableItem.Item);
            if (productStub != null)
            {
              return productStub.GetProductDetailUrl();
            }
          }
          catch (Exception ex)
          {
            Sitecore.Diagnostics.Log.Error(string.Format("error setting product url for item: {0}", indexableItem.Item.ID.ToString()), ex, this);
          }
        }
      }
      return null;
    }
  }
}
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
  public class ProductBuyNow : IComputedIndexField
  {
    public string FieldName { get; set; }
    public string ReturnType
    {
      get
      {
        return CoveoConstants.CoveoFieldTypes.CoveoInteger;
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

          var productStub = CoveoSitecoreService.Service.Cast<ProductStubItem>(indexableItem.Item);
          if (productStub != null)
          {
            return Convert.ToInt32(productStub.ProductBuyNow());
          }
        }
      }
      return null;
    }
  }
}
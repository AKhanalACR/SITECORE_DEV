using ACR.Foundation.Personify.Helpers;
using ACR.Foundation.Personify.Models.Products;
using Glass.Mapper.Sc;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data;

namespace ACRHelix.Foundation.CustomCoveo.ComputedFields.ProductStubs
{
  public class ProductLargeImageUrl : IComputedIndexField
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
          var product = indexableItem.GetFieldById(new ID(SitecoreConstants.Templates.ProductStub.Fields.LargeImageUrl));
          return ProductHelper.BuildProductImageUrl(product.Value.ToString());
        }
      }
      return null;
    }
  }
}

using ACRHelix.Foundation.CustomCoveo.ComputedFields.Base;
using Sitecore.ContentSearch.ComputedFields;

namespace ACRHelix.Foundation.CustomCoveo.ComputedFields.ProductStubs
{
  public class ProductWebDisplayStartDate : ProductStubDateField, IComputedIndexField
  {
    public ProductWebDisplayStartDate()
    {
      FieldID = new Sitecore.Data.ID(SitecoreConstants.Templates.ProductStub.Fields.WebDisplayStartDate);
      //DatePropertyName = "WebDisplayStartDate";
    }
  }
}

using ACRHelix.Foundation.CustomCoveo.ComputedFields.Base;
using Sitecore.ContentSearch.ComputedFields;

namespace ACRHelix.Foundation.CustomCoveo.ComputedFields.ProductStubs
{
  public class ProductWebDisplayEndDate : ProductStubDateField, IComputedIndexField
  {
    public ProductWebDisplayEndDate()
    {
      FieldID = new Sitecore.Data.ID(SitecoreConstants.Templates.ProductStub.Fields.WebDisplayEndDate);
      ConvertMaxDate = true;
    }
  }
}

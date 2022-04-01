using ACRHelix.Foundation.CustomCoveo.ComputedFields.Base;
using Sitecore.ContentSearch.ComputedFields;

namespace ACRHelix.Foundation.CustomCoveo.ComputedFields.ProductStubs
{
  public class DeliveryMethod : ProductStubComputedField, IComputedIndexField
  {
    public DeliveryMethod()
    {
      FieldID = new Sitecore.Data.ID(SitecoreConstants.Templates.ProductStub.Fields.DeliveryMethod);
    }
  }
}

using ACRHelix.Foundation.CustomCoveo.ComputedFields.Base;
using Sitecore.ContentSearch.ComputedFields;

namespace ACRHelix.Foundation.CustomCoveo.ComputedFields.ProductStubs
{
  public class CreditType : ProductStubComputedField, IComputedIndexField
  {
    public CreditType()
    {
      FieldID = new Sitecore.Data.ID(SitecoreConstants.Templates.ProductStub.Fields.CreditType);
    }
  }
}
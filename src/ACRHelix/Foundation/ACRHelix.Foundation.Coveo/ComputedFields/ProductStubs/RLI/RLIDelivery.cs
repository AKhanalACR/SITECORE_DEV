using ACRHelix.Foundation.CustomCoveo.ComputedFields.Base.RLI;
using Sitecore.ContentSearch.ComputedFields;

namespace ACRHelix.Foundation.CustomCoveo.ComputedFields.ProductStubs.RLI
{
  public class RLIDelivery : RLITaxonomyField, IComputedIndexField
  {
    public RLIDelivery()
    {
      FieldID = new Sitecore.Data.ID("{6FDD0E4D-A1EC-48A9-B27C-54EE319C6651}");
    }
  }
}

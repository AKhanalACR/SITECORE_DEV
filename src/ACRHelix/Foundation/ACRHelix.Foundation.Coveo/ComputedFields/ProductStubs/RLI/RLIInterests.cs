using ACRHelix.Foundation.CustomCoveo.ComputedFields.Base.RLI;
using Sitecore.ContentSearch.ComputedFields;

namespace ACRHelix.Foundation.CustomCoveo.ComputedFields.ProductStubs.RLI
{
  public class RLIInterests : RLITaxonomyField, IComputedIndexField
  {
    public RLIInterests()
    {
      FieldID = new Sitecore.Data.ID("{E5F9E862-9DCC-42B9-A1A3-ED8A7484E5B4}");
    }
  }
}

using ACRHelix.Foundation.CustomCoveo.ComputedFields.Base;
using Sitecore.ContentSearch.ComputedFields;

namespace ACRHelix.Foundation.CustomCoveo.ComputedFields.Taxonomy
{
  public class ModalityField : RelatedTaxonomyComputedFields, IComputedIndexField
  {
    public ModalityField()
    {
      FieldID = new Sitecore.Data.ID(SitecoreConstants.Templates.Taxonomy.Fields.Modailities);
    }
  }
}
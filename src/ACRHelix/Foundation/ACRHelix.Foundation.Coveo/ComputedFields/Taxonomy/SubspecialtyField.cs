using ACRHelix.Foundation.CustomCoveo.ComputedFields.Base;
using Sitecore.ContentSearch.ComputedFields;

namespace ACRHelix.Foundation.CustomCoveo.ComputedFields.Taxonomy
{
  public class SubspecialtyField : RelatedTaxonomyComputedFields, IComputedIndexField
  {
    public SubspecialtyField()
    {
      FieldID = new Sitecore.Data.ID(SitecoreConstants.Templates.Taxonomy.Fields.Subspecialities);
    }
  }
}
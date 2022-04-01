using ACRHelix.Foundation.CustomCoveo.ComputedFields.Base;
using Sitecore.ContentSearch.ComputedFields;

namespace ACRHelix.Foundation.CustomCoveo.ComputedFields.Taxonomy
{
  public class InterestField : RelatedTaxonomyComputedFields, IComputedIndexField
  {
    public InterestField()
    {
      FieldID = new Sitecore.Data.ID(SitecoreConstants.Templates.Taxonomy.Fields.Interests);
    }
  }
}
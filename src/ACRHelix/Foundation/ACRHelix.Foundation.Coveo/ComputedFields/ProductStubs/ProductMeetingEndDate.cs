using ACRHelix.Foundation.CustomCoveo.ComputedFields.Base;
using Sitecore.ContentSearch.ComputedFields;

namespace ACRHelix.Foundation.CustomCoveo.ComputedFields.ProductStubs
{
  public class ProductMeetingEndDate : ProductStubDateField, IComputedIndexField
  {
    public ProductMeetingEndDate()
    {
      FieldID = new Sitecore.Data.ID(SitecoreConstants.Templates.ProductStub.Fields.MeetingEndDate);
      ConvertMaxDate = true;
    }
  }
}
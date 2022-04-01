using ACRHelix.Foundation.CustomCoveo.ComputedFields.Base;
using Sitecore.ContentSearch.ComputedFields;

namespace ACRHelix.Foundation.CustomCoveo.ComputedFields.ProductStubs
{
  public class ProductMeetingStartDate : ProductStubDateField, IComputedIndexField
  {
    public ProductMeetingStartDate()
    {
      FieldID = new Sitecore.Data.ID(SitecoreConstants.Templates.ProductStub.Fields.MeetingStartDate);// "MeetingStartDate";
      ConvertMaxDate = true;
    }
  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACR.Foundation.Personify.Models.Products;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Fields;
using ACRHelix.Foundation.CustomCoveo.Services;
using ACR.Foundation.Personify.Helpers;

namespace ACRHelix.Foundation.CustomCoveo.ComputedFields.Meetings
{
  public class MeetingStartDate : IComputedIndexField
  {
    public string FieldName { get; set; }
    public string ReturnType
    {
      get
      {
        return CoveoConstants.CoveoFieldTypes.CoveoDateTime;
      }
      set
      {

      }
    }


    public object ComputeFieldValue(IIndexable indexable)
    {
      SitecoreIndexableItem indexableItem = indexable as SitecoreIndexableItem;
      if (indexableItem != null)
      {
        string templateId = indexableItem.Item.TemplateID.ToString();
        if (templateId == SitecoreConstants.Templates.ChapterMeeting.TemplateID || templateId == SitecoreConstants.Templates.SocietyMeeting.TemplateID)
        {
          DateField startDate = indexableItem.Item.Fields[SitecoreConstants.Templates.ChapterMeeting.Fields.StartDate];
          DateTime dt = startDate.DateTime;
          return dt.ToString(CoveoConstants.CoveoFormats.CoveoIndexDateFormat);
        }
        if (templateId == SitecoreConstants.Templates.MeetingNoProductStub.TemplateID)
        {
          DateField startDate = indexableItem.Item.Fields[SitecoreConstants.Templates.MeetingNoProductStub.Fields.MeetingStartDate];
          DateTime dt = startDate.DateTime;
          return dt.ToString(CoveoConstants.CoveoFormats.CoveoIndexDateFormat);
        }
        if (templateId == ProductStubItem.TemplateID)
        {
          var productStub = CoveoSitecoreService.Service.Cast<ProductStubItem>(indexableItem.Item);
          if (productStub != null)
          {
            if (productStub.ProductIsMeetingOrCourse())
            {
              return productStub.MeetingStartDate.ToString(CoveoConstants.CoveoFormats.CoveoIndexDateFormat);
            }
          }
        }
      }
      return null;
    }
  }
}
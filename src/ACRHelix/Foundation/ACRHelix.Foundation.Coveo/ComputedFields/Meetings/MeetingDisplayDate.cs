using ACR.Foundation.Personify.Helpers;
using ACR.Foundation.Personify.Models.Products;
using ACRHelix.Foundation.CustomCoveo.Services;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Foundation.CustomCoveo.ComputedFields.Meetings
{
  public class MeetingDisplayDate : IComputedIndexField
  {
    public string FieldName
    {
      get; set;
    }

    public string ReturnType
    {
      get
      {
        return CoveoConstants.CoveoFieldTypes.CoveoString;
      }
      set
      {

      }
    }

    public object ComputeFieldValue(IIndexable p_Indexable)
    {
      SitecoreIndexableItem indexableItem = p_Indexable as SitecoreIndexableItem;
      if (indexableItem != null)
      {
        string templateId = indexableItem.Item.TemplateID.ToString();
        if (templateId == SitecoreConstants.Templates.ChapterMeeting.TemplateID || templateId == SitecoreConstants.Templates.SocietyMeeting.TemplateID)
        {
          DateField startDate = indexableItem.Item.Fields[SitecoreConstants.Templates.ChapterMeeting.Fields.StartDate];
          DateTime dt = startDate.DateTime;

          DateField endDate = indexableItem.Item.Fields[SitecoreConstants.Templates.ChapterMeeting.Fields.EndDate];
          DateTime dt1 = endDate.DateTime;
          return DisplayDate(dt, dt1);
        }
        if (templateId == SitecoreConstants.Templates.MeetingNoProductStub.TemplateID)
        {
          DateField endDate = indexableItem.Item.Fields[SitecoreConstants.Templates.MeetingNoProductStub.Fields.MeetingEndDate];
          DateTime dt2 = endDate.DateTime;

          DateField startDate = indexableItem.Item.Fields[SitecoreConstants.Templates.MeetingNoProductStub.Fields.MeetingStartDate];
          DateTime dt1 = startDate.DateTime;

          return DisplayDate(dt1, dt2);

        }
        if (templateId == ProductStubItem.TemplateID)
        {
          var productStub = CoveoSitecoreService.Service.Cast<ProductStubItem>(indexableItem.Item);
          if (productStub != null)
          {
            if (productStub.ProductIsMeetingOrCourse())
            {
              return DisplayDate(productStub.MeetingStartDate, productStub.MeetingEndDate);
            }
          }
        }
      }
      return null;
    }

    public static string DisplayDate(DateTime dt1, DateTime dt2)
    {
      string result = dt1.ToString("MMMM d, yyyy");

      dt1 = dt1.Date;
      dt2 = dt2.Date;

      if (dt2 > dt1)
      {
        if (dt2.Year != dt1.Year)
        {
          result = dt1.ToString("MMMM d, yyyy") + " - " + dt2.ToString("MMMM d, yyyy");
        }
        else if (dt2.Month != dt1.Month)
        {
          result = dt1.ToString("MMMM d") + " - " + dt2.ToString("MMMM d") + ", " + dt1.ToString("yyyy");
        }
        else
        {
          result = dt1.ToString("MMMM d") + "-" + dt2.ToString("d, yyyy");
        }
      }

      return result;
    }
  }
}
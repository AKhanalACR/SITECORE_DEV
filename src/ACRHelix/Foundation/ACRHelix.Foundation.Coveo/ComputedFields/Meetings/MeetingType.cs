using Sitecore.ContentSearch.ComputedFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.ContentSearch;
using ACR.Foundation.Personify.Models.Products;
using ACRHelix.Foundation.CustomCoveo.Services;
using ACR.Foundation.Personify.Helpers;


namespace ACRHelix.Foundation.CustomCoveo.ComputedFields.Meetings
{
  public class MeetingType : IComputedIndexField
  {
    public string FieldName { get; set; }
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

    public object ComputeFieldValue(IIndexable indexable)
    {
      SitecoreIndexableItem indexableItem = indexable as SitecoreIndexableItem;
      if (indexableItem != null)
      {
        string templateId = indexableItem.Item.TemplateID.ToString();
        if (templateId == SitecoreConstants.Templates.ChapterMeeting.TemplateID)
        {
          return "Chapter Meeting";
        }

        if (templateId == SitecoreConstants.Templates.SocietyMeeting.TemplateID)
        {
          return "Society Meeting";
        }

        if (templateId == SitecoreConstants.Templates.MeetingNoProductStub.TemplateID)
        {
          string type = indexableItem.Item.Fields[SitecoreConstants.Templates.MeetingNoProductStub.Fields.MeetingType].Value;
          switch (type)
          {
            case "ACR":
              type = "ACR Meeting";
              break;
            case "Education Center":
              type = "Education Center Course";
              break;
            default:
              break;

          }
          return type;
        }

        if (templateId == ProductStubItem.TemplateID)
        {
          var productStub = CoveoSitecoreService.Service.Cast<ProductStubItem>(indexableItem.Item);
          if (productStub != null)
          {
            if (productStub.ProductIsMeetingOrCourse())
            {
              return productStub.GetProductMeetingType();
            }
          }
        }
      }
      return null;
    }
  }
}
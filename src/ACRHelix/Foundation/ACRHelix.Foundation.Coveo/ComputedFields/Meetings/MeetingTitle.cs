using ACR.Foundation.Personify.Models.Products;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Foundation.CustomCoveo.ComputedFields.Meetings
{
  public class MeetingTitle : IComputedIndexField
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
        if (templateId == SitecoreConstants.Templates.ChapterMeeting.TemplateID || templateId == SitecoreConstants.Templates.SocietyMeeting.TemplateID)
        {
          return indexableItem.Item.Fields[SitecoreConstants.Templates.ChapterMeeting.Fields.MeetingTitle].Value;
        }
        if (templateId == SitecoreConstants.Templates.MeetingNoProductStub.TemplateID)
        {
          return indexableItem.Item.Fields["Title"].Value;
        }
        if (templateId == ProductStubItem.TemplateID)
        {
          return indexableItem.Item.Fields[SitecoreConstants.Templates.ProductStub.Fields.LongName].Value;
        }
      }
      return null;
    }
  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACR.Foundation.Personify.Models.Products;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;

namespace ACRHelix.Foundation.CustomCoveo.ComputedFields.Meetings
{
  public class MeetingShortDescription : IComputedIndexField
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
        if (templateId == SitecoreConstants.Templates.SocietyMeeting.TemplateID)
        {
          return indexableItem.Item.Fields[SitecoreConstants.Templates.SocietyMeeting.Fields.SocietyName].Value;
        }
        if (templateId == SitecoreConstants.Templates.ChapterMeeting.TemplateID)
        {
          return indexableItem.Item.Parent.Parent.Fields["Title"].Value;
        }
        if (templateId == SitecoreConstants.Templates.MeetingNoProductStub.TemplateID)
        {
          return indexableItem.Item.Fields["MetaDescription"].Value;
        }
        if (templateId == ProductStubItem.TemplateID)
        {
          return indexableItem.Item.Fields[SitecoreConstants.Templates.ProductStub.Fields.ShortDescription].Value;
        }
      }
      return null;
    }
  }
}
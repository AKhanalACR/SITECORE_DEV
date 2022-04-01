using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Fields;

namespace ACRHelix.Foundation.CustomCoveo.ComputedFields.Content
{
  public class ContentDisplayDate : IComputedIndexField
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
        //string templateId = indexableItem.Item.TemplateID.ToString();
        Meetings.MeetingDisplayDate meetingDate = new Meetings.MeetingDisplayDate();
        object mDate = meetingDate.ComputeFieldValue(indexable);
        if (mDate != null)
        {
          return (string)mDate;
        }
        //if not meeting get other date
        if (indexableItem != null)
        {
          DateField date = indexableItem.Item.Fields["Date"];
          if (date != null)
          {
            DateTime d = date.DateTime;
            return d.ToString("MMMM d, yyyy");
          }
          return indexableItem.Item.Statistics.Updated.ToString("MMMM d, yyyy");
        }     
      return null;
    }
  }
}
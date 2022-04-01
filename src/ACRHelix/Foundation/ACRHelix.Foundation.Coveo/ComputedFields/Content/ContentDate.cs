using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Fields;

namespace ACRHelix.Foundation.CustomCoveo.ComputedFields.Content
{
  public class ContentDate : IComputedIndexField
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
  
      //if meeting get meeting date
      /*
      Meetings.MeetingStartDate meetingDate = new Meetings.MeetingStartDate();
      object mDate = meetingDate.ComputeFieldValue(indexable);
      if (mDate != null)
      {
        return (string)mDate;
      }*/
      //if not meeting get other date
      SitecoreIndexableItem indexableItem = indexable as SitecoreIndexableItem;
      if (indexableItem != null)
      {
          DateField date = indexableItem.Item.Fields["Date"];
          if (date != null)
          {
            DateTime d = date.DateTime;
          if (d > DateTime.Now.AddYears(-50)) //make sure date is valid
          {
            return d.ToString(CoveoConstants.CoveoFormats.CoveoIndexDateFormat);
          }
          }
          return indexableItem.Item.Statistics.Updated.ToString(CoveoConstants.CoveoFormats.CoveoIndexDateFormat);
      }
      return null;
    }
  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Foundation.SitecoreExtensions.Extensions;
using Sitecore.Data.Items;

namespace ACRHelix.Foundation.CustomCoveo.ComputedFields.Content
{
  public class ContentTitle : IComputedIndexField
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

      Meetings.MeetingTitle meetingTitle = new Meetings.MeetingTitle();
      object mtitle = meetingTitle.ComputeFieldValue(indexable);
      if (mtitle != null)
      {
        return (string)mtitle;
      }

      if (indexableItem != null)
      {
        if (indexableItem.Item.IsDerived(SitecoreConstants.Templates.HasPageContent.TemplateID))
        {
          string title = indexableItem.Item.Fields[SitecoreConstants.Templates.HasPageContent.Fields.Title].Value;
          if (!string.IsNullOrWhiteSpace(title))
          {
            return title;
          }
        }
        string tid = indexableItem.Item.TemplateID.ToString();
        if (tid == SitecoreConstants.Templates.ChapterMeeting.TemplateID || tid == SitecoreConstants.Templates.SocietyMeeting.TemplateID)
        {
          return indexableItem.Item.Fields[SitecoreConstants.Templates.ChapterMeeting.Fields.MeetingTitle];
        }

        //media titles other items
        var titleField = indexableItem.Item.Fields["Title"];
        if (titleField != null) {
          string mediaTitle = titleField.Value;
          if (!string.IsNullOrWhiteSpace(mediaTitle))
          {
            return mediaTitle;
          }
        }
         if (indexableItem.Item.TemplateID.ToString() == SitecoreConstants.Templates.IdeasYoutubeVideoResources.TemplateID)
                {
                    string title = indexableItem.Item.Fields[SitecoreConstants.Templates.IdeasYoutubeVideoResources.Fields.Title].Value;
                    if (!string.IsNullOrWhiteSpace(title))
                    {
                        return title;
                    }
                }
                //if (indexableItem.Item.TemplateID.ToString() == SitecoreConstants.Templates.IdeasOtherVideoResources.TemplateID)
                //{
                //    string title = indexableItem.Item.Fields[SitecoreConstants.Templates.IdeasOtherVideoResources.Fields.Title].Value;
                //    if (!string.IsNullOrWhiteSpace(title))
                //    {
                //        return title;
                //    }
                //}
        var sectionField = indexableItem.Item.Fields["Section Title"];
        if (sectionField != null) {
          string sectionTitle = sectionField.Value;
          if (!string.IsNullOrWhiteSpace(sectionTitle))
          {
            return sectionTitle;
          }
        }

        return indexableItem.Item.DisplayName;
      }
      return null;
    }
  }
}
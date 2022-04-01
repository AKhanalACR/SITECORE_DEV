using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Foundation.SitecoreExtensions.Extensions;
using Sitecore.Sites;

namespace ACRHelix.Foundation.CustomCoveo.ComputedFields.Content
{
  public class SiteName : IComputedIndexField
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
      try
      {
        SitecoreIndexableItem indexableItem = indexable as SitecoreIndexableItem;

          if (indexableItem.Item.IsDerived("{777F0C76-D712-46EA-9F40-371ACDA18A1C}")) //unversioned document
          {
              var folderName = indexableItem.Item.Paths.MediaPath.TrimStart('/').Split('/')[0];
              if (folderName != null)
              {
                  return folderName;
              }
              else
              {
                  return "";
              }
          }

          if (indexableItem.Item.IsDerived("{2A130D0C-A2A9-4443-B418-917F857BF6C9}")) //versioned document
          {
              var folderName = indexableItem.Item.Paths.MediaPath.TrimStart('/').Split('/')[0];
              if (folderName != null)
              {
                  return folderName;
              }
              else
              {
                  return "";
              }
          }
          if (indexableItem.Item.IsDerived("{962B53C4-F93B-4DF9-9821-415C867B8903}")) //unversioned file
          {
              var folderName = indexableItem.Item.Paths.MediaPath.TrimStart('/').Split('/')[0];
              if (folderName != null)
              {
                  return folderName;
              }
              else
              {
                  return "";
              }
          }

          if (indexableItem.Item.IsDerived("{611933AC-CE0C-4DDC-9683-F830232DB150}")) //versioned file
          {
              var folderName = indexableItem.Item.Paths.MediaPath.TrimStart('/').Split('/')[0];
              if (folderName != null)
              {
                  return folderName;
              }
              else
              {
                  return "";
              }
          }

          var siteInfo = SiteContextFactory.Sites.Where(s => !string.IsNullOrWhiteSpace(s.RootPath) && indexableItem.Item.Paths.Path.StartsWith(s.RootPath, StringComparison.OrdinalIgnoreCase)).OrderByDescending(s => s.RootPath.Length).FirstOrDefault();
          if (siteInfo != null)
          {
              return siteInfo.Name;
          }
          else
          {
              return "";
          }
      }
      catch (Exception)
      {
        return "";
      }
    }
  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Foundation.SitecoreExtensions.Extensions;
using ACR.Foundation.Personify.Models.Products;
using System.Text.RegularExpressions;

namespace ACRHelix.Foundation.CustomCoveo.ComputedFields.Content
{
  public class ContentDescription : IComputedIndexField
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
        if (indexableItem.Item.IsDerived(SitecoreConstants.Templates.MetaData.TemplateID))
        {
          string metaDescription = indexableItem.Item.Fields[SitecoreConstants.Templates.MetaData.Fields.MetaDescription].Value;
          if (!string.IsNullOrWhiteSpace(metaDescription))
          {
            return metaDescription;
          }
        }
        if (indexableItem.Item.IsDerived(SitecoreConstants.Templates.TileContent.TemplateID))
        {
          string tiletext = indexableItem.Item.Fields[SitecoreConstants.Templates.TileContent.Fields.TileText].Value;
          if (!string.IsNullOrWhiteSpace(tiletext))
          {
            return tiletext;
          }
        }
        if (indexableItem.Item.IsDerived(SitecoreConstants.Templates.HasPageContent.TemplateID))
        {
          string subTitle = indexableItem.Item.Fields[SitecoreConstants.Templates.HasPageContent.Fields.SubTitle].Value;
          if (!string.IsNullOrWhiteSpace(subTitle))
          {
            return subTitle;
          }
        }
        if (indexableItem.Item.IsDerived(SitecoreConstants.Templates.IdeasHasPageContent.TemplateID))
                {
                    string subTitle = Regex.Replace(indexableItem.Item.Fields[SitecoreConstants.Templates.IdeasHasPageContent.Fields.SubTitle].Value, "<.*?>", String.Empty);
                    if (!string.IsNullOrWhiteSpace(subTitle))
                    {
                        return subTitle;
                    }
                }
        if (templateId == ProductStubItem.TemplateID)
        {
          string sd = indexableItem.Item.Fields[SitecoreConstants.Templates.ProductStub.Fields.ShortDescription].Value;
          if (!string.IsNullOrWhiteSpace(sd))
          {
            return sd;
          }
        }
                if (templateId == SitecoreConstants.Templates.IdeasYoutubeVideoResources.TemplateID)
                {
                    string subTitle = indexableItem.Item.Fields[SitecoreConstants.Templates.IdeasYoutubeVideoResources.Fields.SubTitle].Value;
                    if (!string.IsNullOrWhiteSpace(subTitle))
                    {
                        return subTitle;
                    }
                }
                //if (templateId == SitecoreConstants.Templates.IdeasOtherVideoResources.TemplateID)
                //{
                //    string subTitle = indexableItem.Item.Fields[SitecoreConstants.Templates.IdeasOtherVideoResources.Fields.SubTitle].Value;
                //    if (!string.IsNullOrWhiteSpace(subTitle))
                //    {
                //        return subTitle;
                //    }
                //}

            }
            return null;
    }
  }
}
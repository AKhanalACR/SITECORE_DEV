using ACR.Foundation.Personify.Constants;
using ACR.Foundation.Personify.Helpers;
using ACR.Foundation.Personify.Models.Taxonomy;
using ACR.Foundation.Personify.Services;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Foundation.CustomCoveo.Logger;

namespace ACRHelix.Foundation.CustomCoveo.ComputedFields
{
  public static class TaxonomyFieldCache
  {

    private static DateTime? _lastRebuild;
    private static Dictionary<string, string> TaxonomyValues;
    private static object _dictionaryLock = new object();

    public static string GetTaxonomyName(string id)
    {
      lock (_dictionaryLock)
      {
        if (!_lastRebuild.HasValue)
        {
          RebuildDictionary();
        }    

        if (TaxonomyValues.ContainsKey(id))
        {
          return TaxonomyValues[id];
        }
        else
        {
          RebuildDictionary();
          if (TaxonomyValues.ContainsKey(id))
          {
            return TaxonomyValues[id];
          }
          else
          {
            CustomCoveoLogger.Logger.Error(string.Format("Error, could not look up taxonomy name for ID:{0}", id));
          }
        }
      }
      return null;
    }

    public static void RebuildDictionary()
    {
        TaxonomyValues = new Dictionary<string, string>();
        SitecoreContentService contentService = new SitecoreContentService("web");
        List<TaxonomyFolder> folders = new List<TaxonomyFolder>();
        folders.Add(contentService.GetTaxonomyFolder(ItemConstants.TaxonomyFolders.ABRCodes));
        folders.Add(contentService.GetTaxonomyFolder(ItemConstants.TaxonomyFolders.CreditTypes));
        folders.Add(contentService.GetTaxonomyFolder(ItemConstants.TaxonomyFolders.DeliveryMethods));
        folders.Add(contentService.GetTaxonomyFolder(ItemConstants.TaxonomyFolders.Interests));
        folders.Add(contentService.GetTaxonomyFolder(ItemConstants.TaxonomyFolders.Modalities));
        folders.Add(contentService.GetTaxonomyFolder(ItemConstants.TaxonomyFolders.ProductArea));
        folders.Add(contentService.GetTaxonomyFolder(ItemConstants.TaxonomyFolders.ProductClass));
        folders.Add(contentService.GetTaxonomyFolder(ItemConstants.TaxonomyFolders.ProductTypes));
        folders.Add(contentService.GetTaxonomyFolder(ItemConstants.TaxonomyFolders.Roles));
        folders.Add(contentService.GetTaxonomyFolder(ItemConstants.TaxonomyFolders.Subspecialties));
        folders.Add(contentService.GetTaxonomyFolder(ItemConstants.TaxonomyFolders.Topics));

        foreach (var folder in folders)
        {
          foreach (var taxonomy in folder.TaxonomyItems)
          {
            TaxonomyValues.Add(taxonomy.ID.ToString(), taxonomy.DisplayName);
          }
        }
        var rli = contentService.GetRLIPersonifyFolder(ItemConstants.TaxonomyFolders.RLIPersonifyFolder);
        foreach (var code in rli.RLICodes)
        {
          foreach (var subcode in code.RLISubCodes)
          {
            TaxonomyValues.Add(subcode.ID.ToString(), subcode.GetRLISubCode());
          }
        }
      _lastRebuild = DateTime.UtcNow;
    }
  }
}
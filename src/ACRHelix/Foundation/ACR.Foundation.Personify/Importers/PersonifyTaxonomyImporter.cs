using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACR.Foundation.Personify.Logger;
using ACR.Foundation.Personify.PersonifyService;
using ACR.Foundation.Personify.Services;
using ACR.Foundation.Personify.Models.Taxonomy;
using Sitecore.Data;
using static ACR.Foundation.Personify.Constants.PersonifyConstants;
using static ACR.Foundation.Personify.Constants.ItemConstants;
using ACR.Foundation.Personify.Models.Taxonomy.RLI.Data;
using ACR.Foundation.Personify.Models.Taxonomy.RLI;
using ACR.Foundation.Personify.Settings;

namespace ACR.Foundation.Personify.Importers
{
  public class PersonifyTaxonomyImporter
  {
    private SitecoreContentService ContentService;
    private PersonifyEntitiesACR PersonifySvc;
    private PersonifySitecoreService SitecoreService;

    public PersonifyTaxonomyImporter()
    {
      ContentService = new SitecoreContentService("master");
      PersonifySvc = new PersonifyEntitiesACR();
      SitecoreService = new PersonifySitecoreService("master");
    }


    public List<string> ImportItems()
    {
      string result = "Personify Taxonomy Items Imported.";

      List<string> importResults = new List<string>();
      try
      {

        PersonifyLogger.Logger.Info("Starting Personify Taxonomy Import CollectItems()");

        #region ImportItemsSitecore

        //List<string> importResults = new List<string>();

        importResults.Add(ImportRoleItems());
        importResults.Add(ImportProductAreas());
        importResults.Add(ImportClassesandTypes());
        importResults.Add(ImportCreditTypes());
        importResults.Add(ImportACRSubCodes());
        importResults.Add(ImportSubCodes());
        importResults.Add(ImportRLITaxonomy());
        importResults.Add(ImportCommitteeList());
        importResults.Add(ImportChapterList());

        #endregion
        PersonifyLogger.Logger.Info("Ending Personify Taxonomy Import CollectItems()");
        //results.Add(productTask.re);

        PersonifyLogger.Logger.Info("Starting Publish Taxonomy Items");
        Publisher.SmartPublishItems(TaxonomyFolders.TaxonomyRoot);
        PersonifyLogger.Logger.Info("Ending Publish Taxonomy Items");

      }
      catch (Exception ex)
      {
        result = "Error importing Personify Taxonomy Items";
        PersonifyLogger.Logger.Error("Error importing Personify Taxonomy Items", ex);
      }
      importResults.Add(result);

      return importResults;
    }


    private string ImportCommitteeList()
    {
      int committeesImported = 0;
      string status = "{0} commiteees imported";
      try
      {
        var committees = PersonifySvc.GetCommitteeList();
        var committeeFolder = ContentService.GetTaxonomyFolder(TaxonomyFolders.CommitteeRoot);
        foreach (var comm in committees)
        {
          var existing = committeeFolder.TaxonomyItems.FirstOrDefault(x => x.PersonifyID == comm.MASTER_CUSTOMER_ID);
          if (existing == null)
          {
            existing = new PersonifyTaxonomyItem();
            existing.ID = ID.Null;
            existing.PersonifyID = comm.MASTER_CUSTOMER_ID;
            existing.Parent = committeeFolder;
          }
          existing.Name = existing.DisplayName = comm.COMMITTEENAME;
          existing.FriendlyName = comm.COMMITEETYPE;
          SitecoreService.CreateUpdateItem(existing);
          committeesImported++;
        }
      }
      catch (Exception ex)
      {
        PersonifyLogger.Logger.Error("Error importing Committees", ex);
      }
      string results = string.Format(status, committeesImported);
      PersonifyLogger.Logger.Info(results);
      return results;

    }

    private string ImportChapterList()
    {
      int chaptersImported = 0;
      string status = "{0} commiteees imported";
      try
      {
        var chapters = PersonifySvc.GetChapterList();
        var chapterFolder = ContentService.GetTaxonomyFolder(TaxonomyFolders.ChaptersRoot);
        foreach (var comm in chapters)
        {
          var existing = chapterFolder.TaxonomyItems.FirstOrDefault(x => x.PersonifyID == comm.ChapterID);
          if (existing == null)
          {
            existing = new PersonifyTaxonomyItem();
            existing.ID = ID.Null;
            existing.PersonifyID = comm.ChapterID;
            existing.Parent = chapterFolder;
          }
          existing.Name = existing.DisplayName = comm.ChapterName;
          existing.FriendlyName = comm.ChapterName;
          SitecoreService.CreateUpdateItem(existing);
          chaptersImported++;
        }

      }
      catch (Exception ex)
      {
        PersonifyLogger.Logger.Error("Error importing chapters", ex);
      }
      string results = string.Format(status, chaptersImported);
      PersonifyLogger.Logger.Info(results);
      return results;

    }

    private string ImportRLITaxonomy()
    {
      int RLICodesImported = 0;
      int RLISubCodesImported = 0;
      string status = "{0} RLI Taxonomy Codes Imported, {1} RLI Taxonomy SubCodes Imported";
      try
      {
        List<PersonifyDS.PdsApplicationCode> RLICodes = PersonifySvc.GetRLIProductCodes();

        var RLIPersonifyFolder = ContentService.GetRLIPersonifyFolder(TaxonomyFolders.RLIPersonifyFolder);
        if (RLIPersonifyFolder != null)
        {
          DateTime importStartTime = DateTime.Now.AddSeconds(-3);

          //import RLI Codes
          var allCodes = RLIPersonifyFolder.RLICodes.ToList();
          foreach (var rliCode in RLICodes)
          {
            try
            {
              Code code = new Code(rliCode);

              var existingCode = allCodes.FirstOrDefault(x => x.Code == code.CodeName);
              if (existingCode == null)
              {
                existingCode = new RLIPersonifyCode();
                existingCode.ID = ID.Null;
                existingCode.Parent = RLIPersonifyFolder;
              }
              existingCode.Active = code.Active;
              existingCode.AvailableToWeb = code.AvailableToWeb;
              existingCode.Name = existingCode.Code = code.CodeName;
              existingCode.Description = code.Description;
              existingCode.DisplayOrder = code.DisplayOrder;
              existingCode.HelpText = code.HelpText;
              existingCode.Option2 = code.Option2;
              existingCode.Updated = DateTime.UtcNow;

              SitecoreService.CreateUpdateItem(existingCode);
              RLICodesImported++;
            }
            catch (Exception ex)
            {
              PersonifyLogger.Logger.Error(string.Format("Error, could not create / update RLI personifyCode: {0}", rliCode.Code), ex);
            }
          }
          //delete old codes
          RLIPersonifyFolder = ContentService.GetRLIPersonifyFolder(TaxonomyFolders.RLIPersonifyFolder);
          foreach (var code in RLIPersonifyFolder.RLICodes)
          {
            try
            {
              if (code.Updated < importStartTime)
              {
                SitecoreService.DeleteItem(code);
              }
            }
            catch (Exception del)
            {
              PersonifyLogger.Logger.Error(string.Format("Error deleting RLI Personify Code: {0}", code.Code), del);
            }
          }

          //import RLI Subcodes
          var personifySubCodes = PersonifySvc.GetRLIProductSubCodes();
          RLIPersonifyFolder = ContentService.GetRLIPersonifyFolder(TaxonomyFolders.RLIPersonifyFolder);
          foreach (var psubCode in personifySubCodes)
          {
            try
            {
              SubCode subCode = new SubCode(psubCode);
              var code = RLIPersonifyFolder.RLICodes.FirstOrDefault(x => x.Code == subCode.CodeName);
              if (code != null)
              {
                var existingSubCode = code.RLISubCodes.FirstOrDefault(x => x.SubCode == subCode.SubCodeName);
                if (existingSubCode == null)
                {
                  existingSubCode = new RLIPersonifySubCode();
                  existingSubCode.ID = ID.Null;
                  existingSubCode.Parent = code;
                }
                existingSubCode.SubCode = existingSubCode.Name = subCode.SubCodeName;
                existingSubCode.Active = subCode.Active;
                existingSubCode.AvailableToWeb = subCode.AvailableToWeb;
                existingSubCode.Code = subCode.CodeName;
                existingSubCode.Description = subCode.Description;
                existingSubCode.DisplayOrder = subCode.DisplayOrder;
                existingSubCode.Option1 = subCode.Option1;
                existingSubCode.Option2 = subCode.Option2;
                existingSubCode.Updated = DateTime.UtcNow;

                existingSubCode = SitecoreService.CreateUpdateItem<RLIPersonifySubCode>(existingSubCode);
                RLISubCodesImported++;
              }
              else
              {
                PersonifyLogger.Logger.Error(string.Format("Code does not exist for Subcode: {0}, missing code: {1}", subCode.SubCodeName, subCode.CodeName));
              }

            }
            catch (Exception ex)
            {
              PersonifyLogger.Logger.Error(string.Format("Error, could not create / update RLI personifySubCode: {0}", psubCode.Code), ex);
            }
          }
          RLIPersonifyFolder = ContentService.GetRLIPersonifyFolder(TaxonomyFolders.RLIPersonifyFolder);
          foreach (var code in RLIPersonifyFolder.RLICodes)
          {
            foreach (var subCode in code.RLISubCodes)
            {
              if (subCode.Updated < importStartTime)
              {
                SitecoreService.DeleteItem(subCode);
              }
            }
          }

        }
        else
        {
          PersonifyLogger.Logger.Error(string.Format("Error, could not find RLI Personify Folder with ID: {0}, aborting RLI taxonomy import", TaxonomyFolders.RLIPersonifyFolder.ToString()));
        }
      }
      catch (Exception ex)
      {
        PersonifyLogger.Logger.Error("Error importing RLI Taxonomy", ex);
      }
      string results = string.Format(status, RLICodesImported, RLISubCodesImported);
      PersonifyLogger.Logger.Info(results);
      return results;

    }

    private string ImportCreditTypes()
    {
      int creditTypesImported = 0;
      string status = "{0} Credit Types Imported!";

      try
      {
        var ctypes = PersonifySvc.GetCreditTypes();

        var parentItem = ContentService.GetTaxonomyFolder(TaxonomyFolders.CreditTypes);
        var existingItems = parentItem.TaxonomyItems.ToList();
        foreach (var ctype in ctypes)
        {
          //bool update = true;
          var ctypeItem = existingItems.FirstOrDefault(x => x.PersonifyID == ctype.Subcode);
          try
          {
            if (ctypeItem == null)
            {
              ctypeItem = new PersonifyTaxonomyItem();
              ctypeItem.ID = ID.Null;
              ctypeItem.Parent = parentItem;
              //update = false;
            }
            ctypeItem.Name = ctypeItem.DisplayName = ctype.Description;
            ctypeItem.OmitFromSearch = ctype.AvailableToWebFlag.HasValue && !ctype.AvailableToWebFlag.Value;
            ctypeItem.PersonifyID = ctype.Subcode;

            ctypeItem = SitecoreService.CreateUpdateItem(ctypeItem);
            creditTypesImported++;
            if (existingItems.FirstOrDefault(x => x.PersonifyID == ctypeItem.PersonifyID) == null)
            {
              existingItems.Add(ctypeItem);
            }
          }
          catch (Exception ex)
          {
            PersonifyLogger.Logger.Error("Error Creating Personify Credit Types: " + ctype.Description, ex);
          }

        }
      }
      catch (Exception ex)
      {
        status = "Personify Credit Types Items Import FAILED, {0}";
        PersonifyLogger.Logger.Error("Error Importing Personify Credit Types ", ex);
      }
      string results = string.Format(status, creditTypesImported);
      PersonifyLogger.Logger.Info(results);
      return results;
    }

    private string ImportACRSubCodes()
    {
      int acrSubCodesImported = 0;
      string status = "{0} ACRSubcodes Imported!";

      PersonifyLogger.Logger.Info(string.Format("Starting import {0} taxonomy Items", "Personify ACRSubCodes"));

      try
      {
        var acrSubcodes = PersonifySvc.GetModalitySubspecialty();

        foreach (var subCode in acrSubcodes)
        {
          try
          {
            TaxonomyFolder folder = GetTaxonomyFolder(subCode.Code);
            if (folder != null)
            {
              var item = folder.TaxonomyItems.FirstOrDefault(x => x.PersonifyID == subCode.Subcode);

              if (item == null)
              {
                item = new PersonifyTaxonomyItem();
                item.ID = ID.Null;
                item.Parent = folder;
              }

              item.DisplayName = item.Name = subCode.Description;
              item.PersonifyID = subCode.Subcode;
              item.OmitFromSearch = subCode.AvailableToWebFlag.HasValue && !subCode.AvailableToWebFlag.Value;

              item = SitecoreService.CreateUpdateItem(item);
              acrSubCodesImported++;
            }
            else
            {
              PersonifyLogger.Logger.Debug(string.Format("Product acrsubcode was not of interesting type. Code: {0}, Name: {1}, Type: {2}, Subcode {3}", subCode.Code, subCode.Description, subCode.Type, subCode.Subcode));

            }
          }
          catch (Exception ex)
          {
            PersonifyLogger.Logger.Error(string.Format("Error creating acarsubcode item, peronsifyID: {0}", subCode.Subcode), ex);
          }
        }
      }
      catch (Exception ex)
      {
        status = "ACRSubcodes  import failed, {0} imported";
        PersonifyLogger.Logger.Error("Error importing ACRSubcodes", ex);
      }

      string results = string.Format(status, acrSubCodesImported);
      PersonifyLogger.Logger.Info(results);
      return results;
    }

    private string ImportSubCodes()
    {
      int subCodesImported = 0;
      string status = "{0} Personify SubCodes Imported!";
      PersonifyLogger.Logger.Info(string.Format("Starting import {0} taxonomy Items", "Personify SubCodes"));

      try
      {
        var subCodes = PersonifySvc.GetProductSubCodes();

        var excludeList = ACRSettings.PersonifyExclude.Split(',');

        foreach (var subCode in subCodes)
        {
          try
          {
            TaxonomyFolder folder = GetTaxonomyFolder(subCode.Code);
            if (folder != null)
            {
              var item = folder.TaxonomyItems.FirstOrDefault(x => x.PersonifyID == subCode.Subcode);

              if (!excludeList.Contains(subCode.Subcode))
              {
                if (item == null)
                {
                  item = new PersonifyTaxonomyItem();
                  item.ID = ID.Null;
                  item.Parent = folder;
                }

                item.DisplayName = item.Name = subCode.Description;
                item.PersonifyID = subCode.Subcode;
                item.OmitFromSearch = subCode.AvailableToWebFlag.HasValue && !subCode.AvailableToWebFlag.Value;

                item = SitecoreService.CreateUpdateItem(item);
                subCodesImported++;
              }
            }
            else
            {
              PersonifyLogger.Logger.Debug(string.Format("Product Subcode was not of interesting type. Code: {0}, Name: {1}, Type: {2}, Subcode {3}", subCode.Code, subCode.Description, subCode.Type, subCode.Subcode));
            }
          }
          catch (Exception ex)
          {
            PersonifyLogger.Logger.Error(string.Format("Error creating subcode item, peronsifyID: {0}", subCode.Subcode), ex);
          }
        }
      }
      catch (Exception ex)
      {
        status = "Subcode import failed, {0} imported";
        PersonifyLogger.Logger.Error("Error importing subcodes", ex);
      }
      string results = string.Format(status, subCodesImported);
      PersonifyLogger.Logger.Info(results);
      return results;
    }

    private string ImportProductAreas()
    {
      string status = "{0} Personify Product Areas Imported!";
      int areasImported = 0;

      PersonifyLogger.Logger.Info(string.Format("Starting import {0} taxonomy Items", "Personify Product Areas"));

      try
      {
        var areas = PersonifySvc.GetProductAreas();

        var parentItem = ContentService.GetTaxonomyFolder(TaxonomyFolders.ProductArea);
        var existingItems = parentItem.TaxonomyItems.ToList();

        foreach (var area in areas)
        {
          //bool update = true;
          var areaItem = existingItems.FirstOrDefault(x => x.PersonifyID == area.Code);
          try
          {
            if (areaItem == null)
            {
              areaItem = new PersonifyTaxonomyItem();
              areaItem.ID = ID.Null;
              areaItem.Parent = parentItem;
              //update = false;
            }
            areaItem.Name = areaItem.DisplayName = area.Description;
            areaItem.OmitFromSearch = area.AvailableToWebFlag.HasValue && !area.AvailableToWebFlag.Value;
            areaItem.PersonifyID = area.Code;

            areaItem = SitecoreService.CreateUpdateItem(areaItem);
            areasImported++;
            //add new item to existing items to prevent duplication of personify Ids
            if (existingItems.FirstOrDefault(x => x.PersonifyID == areaItem.PersonifyID) == null)
            {
              existingItems.Add(areaItem);
            }
          }
          catch (Exception ex)
          {
            PersonifyLogger.Logger.Error("Error Creating Personify Product Area Item: " + area.Description, ex);
          }
        }
      }
      catch (Exception ex)
      {
        status = "Personify Product Areas Import FAILED, {0}";
        PersonifyLogger.Logger.Error("Error Importing Personify Product Areas", ex);
        //return status;
      }
      PersonifyLogger.Logger.Info("Importing  Personify Product Areas taxonomy items complete");

      string results = string.Format(status, areasImported);
      PersonifyLogger.Logger.Info(results);
      return results;
    }




    private string ImportRoleItems()
    {
      string status = "{0} Role Items Imported";
      int rolesImported = 0;

      PersonifyLogger.Logger.Info(string.Format("Starting import {0} taxonomy Items", "Personify Roles"));


      try
      {
        var roles = PersonifySvc.GetCustomerRoles();

        var parentItem = ContentService.GetTaxonomyFolder(TaxonomyFolders.Roles);
        var existingItems = parentItem.TaxonomyItems.ToList();
        foreach (var role in roles)
        {
          //bool update = true;
          var roleItem = existingItems.FirstOrDefault(x => x.PersonifyID == role.Code);
          try
          {
            if (roleItem == null)
            {
              roleItem = new PersonifyTaxonomyItem();
              roleItem.ID = ID.Null;
              roleItem.Parent = parentItem;
              //update = false;
            }
            roleItem.Name = roleItem.DisplayName = role.Description;
            roleItem.OmitFromSearch = role.AvailableToWebFlag.HasValue && !role.AvailableToWebFlag.Value;
            roleItem.PersonifyID = role.Code;

            roleItem = SitecoreService.CreateUpdateItem(roleItem);
            rolesImported++;
            if (existingItems.FirstOrDefault(x => x.PersonifyID == roleItem.PersonifyID) == null)
            {
              existingItems.Add(roleItem);
            }
          }
          catch (Exception ex)
          {
            PersonifyLogger.Logger.Error("Error Creating Personify Role Item: " + role.Description, ex);
          }

        }
      }
      catch (Exception ex)
      {
        status = "Personify Role Items Import FAILED, {0}";
        PersonifyLogger.Logger.Error("Error Importing Personify Roles ", ex);
      }
      PersonifyLogger.Logger.Info(string.Format("Importing Personify Roles taxonomy items complete"));

      string results = string.Format(status, rolesImported);
      PersonifyLogger.Logger.Info(results);
      return results;
    }

    private string ImportClassesandTypes()
    {
      string status = "{0} Classes and Types Import Complete";
      int classTypesImported = 0;

      try
      {
        var pCodes = PersonifySvc.GetProductCodes();

        foreach (var pCode in pCodes)
        {
          TaxonomyFolder folder = GetTaxonomyFolder(pCode.Type);
          if (folder != null)
          {
            string personifyId = GetPersonifyID(pCode);

            var existingItem = folder.TaxonomyItems.FirstOrDefault(x => x.PersonifyID == personifyId);
            try
            {
              if (existingItem == null)
              {
                existingItem = new PersonifyTaxonomyItem();
                existingItem.ID = ID.Null;
                existingItem.Parent = folder;
              }
              existingItem.DisplayName = existingItem.Name = pCode.Description;
              existingItem.PersonifyID = personifyId;
              existingItem.OmitFromSearch = pCode.AvailableToWebFlag.HasValue && !pCode.AvailableToWebFlag.Value;

              existingItem = SitecoreService.CreateUpdateItem(existingItem);
              classTypesImported++;
            }
            catch (Exception ex)
            {
              PersonifyLogger.Logger.Error("Error Creating Personify Class / Type Item: " + pCode.Description, ex);
            }
          }
          else
          {
            PersonifyLogger.Logger.Debug(string.Format("Product Code was not of interesting type. Code: {0}, Name: {1}, Type: {2}", pCode.Code, pCode.Description, pCode.Type));
          }
        }
      }
      catch (Exception ex)
      {
        PersonifyLogger.Logger.Error("Error Creating Personify Class / Type Items ", ex);
        status = "Personify Class / Types Items Import FAILED, imported: {0}";
      }
      string results = string.Format(status, classTypesImported);
      PersonifyLogger.Logger.Info(results);
      return results;
    }

    private string GetPersonifyID(PersonifyDS.PdsApplicationCode pCode)
    {
      string personifyId;
      if (String.IsNullOrEmpty(pCode.SubsystemString))
      {
        personifyId = pCode.Code;
      }
      else
      {
        personifyId = pCode.GetSitecorePersonifyId();
      }
      return personifyId;
    }

    private TaxonomyFolder GetTaxonomyFolder(string codeType)
    {
      TaxonomyFolder taxonomy = null;

      switch (codeType)
      {
        case PdsConstants.TYPE_PRODUCTCLASS:
          taxonomy = ContentService.GetTaxonomyFolder(TaxonomyFolders.ProductClass);
          break;
        case PdsConstants.TYPE_PRODUCTTYPE:
          taxonomy = ContentService.GetTaxonomyFolder(TaxonomyFolders.ProductTypes);
          break;
        case PdsConstants.SUBCODE_MODALITY:
          taxonomy = ContentService.GetTaxonomyFolder(TaxonomyFolders.Modalities);
          break;
        case PdsConstants.SUBCODE_SUBSPECIALTY:
          taxonomy = ContentService.GetTaxonomyFolder(TaxonomyFolders.Subspecialties);
          break;
        case PdsConstants.SUBCODE_INTERESTS:
          taxonomy = ContentService.GetTaxonomyFolder(TaxonomyFolders.Interests);
          break;
        case PdsConstants.SUBCODE_DELIVERY:
          taxonomy = ContentService.GetTaxonomyFolder(TaxonomyFolders.DeliveryMethods);
          break;
        case PdsConstants.SUBCODE_ABRCODE:
          taxonomy = ContentService.GetTaxonomyFolder(TaxonomyFolders.ABRCodes);
          break;
        case PdsConstants.SUBCODE_TOPICS:
          taxonomy = ContentService.GetTaxonomyFolder(TaxonomyFolders.Topics);
          break;
        case PdsConstants.TYPE_ROLES:
          taxonomy = ContentService.GetTaxonomyFolder(TaxonomyFolders.Roles);
          break;
        default:
          break;
      }
      return taxonomy;
    }
  }
}
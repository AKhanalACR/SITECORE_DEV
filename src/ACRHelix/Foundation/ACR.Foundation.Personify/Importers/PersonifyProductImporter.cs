using ACR.Foundation.Personify.PersonifyService;
using ACR.Foundation.Personify.Services;
using ACR.Foundation.Personify.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using ACR.Foundation.Personify.Models.Products;
using static ACR.Foundation.Personify.Constants.ItemConstants;
using Sitecore.Data.Items;
using Sitecore.Data;
using ACR.Foundation.Personify.Models.Taxonomy;
using static ACR.Foundation.Personify.Constants.PersonifyConstants;
using ACR.Foundation.Personify.ProductSearch;
using ACR.Foundation.Personify.Models.Taxonomy.RLI;

namespace ACR.Foundation.Personify.Importers
{
  public class PersonifyProductImporter
  {
    private SitecoreContentService ContentService;
    private PersonifySitecoreService SitecoreService;
    private PersonifyEntitiesACR PersonifySvc;
    private ProductSearchManager productSearchManager;

    public PersonifyProductImporter()
    {
      SitecoreService = new PersonifySitecoreService("master");
      ContentService = new SitecoreContentService("master");
      PersonifySvc = new PersonifyEntitiesACR();
      productSearchManager = new ProductSearchManager(ProductSearchManager.IndexEnum.Master);
    }

    public List<string> ExecuteProductImport(bool updateAll)
    {
      string productResult = ImportProducts(updateAll);

      Publisher.SmartPublishItems(ProductFolders.ProductRoot);

      string rliProductResult = UpdateRLIProducts(updateAll);

      Publisher.SmartPublishItems(ProductFolders.ProductRoot);

      return new List<string> {productResult, rliProductResult };
    }

    private string ImportProducts()
    {
      return ImportProducts(false);
    }

    private string ImportProducts(bool importAll)
    {
      string importResults = "{0} Personify Products Imported!";
      int productsImported = 0;
      //int loops = 0;

      //if not imported all products, then just get products updated in the last day
      DateTime productDate;
      productDate = importAll ? DateTime.Now.AddYears(-20) : DateTime.Now.AddDays(-1);

      var products = GetPersonifyProducts(productDate);

      List<PersonifyDS.PdsApplicationCode> productCodes = PersonifySvc.GetProductCodes();
      List<PersonifyDS.PdsApplicationCode> productAreas = PersonifySvc.GetProductAreas();

      //int maxImport = 20;

      foreach (var product in products)
      {
        //loops++;
        //if (loops >= maxImport)
        //{
        //  break;
        //}
        try
        {
          PersonifyLogger.Logger.Info(string.Format("Starting import for Personify Product, name: {0}, id: {1}",product.ShortName,product.ProductId.ToString()));
            
          string subsytem = product.Subsystem;
          string productClass = product.ProductClassCode;

          var productSubsytemFolder = GetCreateProductSubsytemFolder(subsytem);
          if (productSubsytemFolder != null)
          {
            var productClassFolder = GetCreateProductClassFolder(productClass, productSubsytemFolder);
            if (productClassFolder != null)
            {
              string personifyID = product.ProductId.ToString();

              var existingProduct = productClassFolder.ProductStubs.FirstOrDefault(x => x.PersonifyID == personifyID);
              if (existingProduct == null)
              {
                existingProduct = new ProductStubItem();
                existingProduct.ID = ID.Null;
                existingProduct.Parent = productClassFolder;
              }
              existingProduct.Name = product.ShortName;
              existingProduct.PName = product.ShortName;
              existingProduct.PersonifyID = personifyID;
              existingProduct.LongName = product.LongName;
              existingProduct.Status = product.ProductStatusCode;
              existingProduct.WebDisplay = product.EcommerceFlag.HasValue && product.EcommerceFlag.Value ? true : false;
              if (product.EcommerceBeginDate.HasValue)
              {
                existingProduct.WebDisplayStartDate = product.EcommerceBeginDate.Value;
              }
              if (product.EcommerceEndDate.HasValue)
              {
                existingProduct.WebDisplayEndDate = product.EcommerceEndDate.Value;
              }
              if (product.LastUpdateDate.HasValue)
              {
                existingProduct.DateModified = product.LastUpdateDate.Value;
              }
           
              existingProduct.StockStatus = product.StockStatus;
              existingProduct.ListPrice = GetPriceValue(product.Listprice);
              existingProduct.MITPrice = GetPriceValue(product.Mitprice);
              existingProduct.MemberPrice = GetPriceValue(product.Memberprice);
              existingProduct.TechnologistsPrice = GetPriceValue(product.TechPrice);
              existingProduct.ImageLargeUrl = product.LargeImageFileName;
              existingProduct.ImageSmallUrl = product.SmallImageFileName;
              existingProduct.ShortDescription_Raw = product.WebShortDescription;
              existingProduct.LongDescription_Raw = product.WebLongDescription;
              existingProduct.ProductUrl = product.ProductUrl;

              //Taxonomy info
              List<PersonifyDS.PdsProductSubCategory> productTaxonomy = PersonifySvc.PdsProductSubCategories.Where(k => k.ProductId == product.ProductId).ToList();


              //modalities
              /*
              var modalityItems = new List<PersonifyTaxonomyItem>();
              var modality = productTaxonomy.Where(x => x.Category == PersonifyConstants.PdsConstants.SUBCODE_MODALITY).ToList();
              foreach (var m in modality)
              {
                //var name = m.SubCategoryDescription;
                var pid = m.SubscriptionCategory;
                var modalityItem = ContentService.GetTaxonomyFolder(ItemConstants.TaxonomyFolders.Modalities).TaxonomyItems.FirstOrDefault(x => x.PersonifyID == pid);
                if (modalityItem != null)
                {
                  modalityItems.Add(modalityItem);
                }
              }
              existingProduct.RelatedModalities = modalityItems;
              */

              existingProduct.RelatedModalities = GetSitecoreTaxonomyItems(PdsConstants.SUBCODE_MODALITY, TaxonomyFolders.Modalities, productTaxonomy);
              existingProduct.RelatedSubspecialites = GetSitecoreTaxonomyItems(PdsConstants.SUBCODE_SUBSPECIALTY, TaxonomyFolders.Subspecialties, productTaxonomy);
              existingProduct.RelatedInterests = GetSitecoreTaxonomyItems(PdsConstants.SUBCODE_INTERESTS, TaxonomyFolders.Interests, productTaxonomy);
              existingProduct.ABRCodes = GetSitecoreTaxonomyItems(PdsConstants.SUBCODE_ABRCODE, TaxonomyFolders.ABRCodes, productTaxonomy);
              existingProduct.RelatedTopics = GetSitecoreTaxonomyItems(PdsConstants.SUBCODE_TOPICS, TaxonomyFolders.Topics, productTaxonomy);
              existingProduct.DeliveryMethods = GetSitecoreTaxonomyItems(PdsConstants.SUBCODE_DELIVERY, TaxonomyFolders.DeliveryMethods, productTaxonomy);
              existingProduct.CreditTypes = GetSitecoreTaxonomyItems(PdsConstants.CREDIT_TYPES, TaxonomyFolders.CreditTypes, productTaxonomy);

              var keywords = PersonifySvc.PdsProductKeywords.Where(x => x.ProductId == product.ProductId).ToList();
              existingProduct.Keywords = string.Join(",", keywords.Select(k => k.Keyword).Distinct());

              //product class
              var pClass = productCodes.FirstOrDefault(x => x.Type == PdsConstants.TYPE_PRODUCTCLASS && x.Code == product.ProductClassCode && x.SubsystemString == product.Subsystem);
              if (pClass != null)
              {
                existingProduct.ProductClass = GetSitecoreTaxonomyItem(TaxonomyFolders.ProductClass, pClass);
              }

              //productType
              var pType = productCodes.FirstOrDefault(p => p.Type == PdsConstants.TYPE_PRODUCTTYPE
                && p.Code == product.ProductTypeCode
                && p.SubsystemString == product.Subsystem);

              if (pType != null)
              {
                existingProduct.ProductType = GetSitecoreTaxonomyItem(TaxonomyFolders.ProductTypes, pType);
              }

              var pArea = productAreas.FirstOrDefault(p => p.Code == product.Subsystem);
              if (pArea != null)
              {
                existingProduct.ProductArea = GetSitecoreTaxonomyItem(TaxonomyFolders.ProductArea, pArea.Code);
              }

              //meeting fields
              if (product.MeetingStartDate.HasValue)
              {
                existingProduct.MeetingStartDate = product.MeetingStartDate.Value;
              }
              if (product.MeetingEndDate.HasValue)
              {
                existingProduct.MeetingEndDate = product.MeetingEndDate.Value;
              }
              if (product.MeetingLastRegistrationDate.HasValue)
              {
                existingProduct.MeetingLastRegistrationDate = product.MeetingLastRegistrationDate.Value;
              }
              existingProduct.MeetingCity = product.MeetingCity;
              existingProduct.MeetingState = product.MeetingState;
              existingProduct.MeetingFacilityName = product.MeetingFacilityName;
              existingProduct.MeetingLabelName = product.MeetingLabelName;
              existingProduct.CMECredit = GetProductCMECredit(product.Cmecredit);
              existingProduct.MeetingRegistrationFormUrl = product.MeetingURL;

              existingProduct = SitecoreService.CreateUpdateItem(existingProduct);

              DeleteOtherPersonifyProducts(existingProduct);

              productsImported++;
              PersonifyLogger.Logger.Info(string.Format("Completed import for Personify Product, name: {0}, id: {1}", product.ShortName, product.ProductId.ToString()));
            }
            else
            {
              PersonifyLogger.Logger.Error(string.Format("Error, no product class: {0} for productID: {1}", productClass, product.ProductId));
            }
          }
          else
          {
            PersonifyLogger.Logger.Error(string.Format("Error, no product subsystem: {0} for productID: {1}", subsytem, product.ProductId));
          }
        }
        catch (Exception ex)
        {
          PersonifyLogger.Logger.Error(string.Format("Error creating product with PersonifyID: {0}", product.ProductId), ex);
        }

      }
      return string.Format(importResults, productsImported);
    }

    private string UpdateRLIProducts(bool updateAll)
    {
      string result = "{0} RLI Products Updated";
      int rliCount = 0;

      updateAll = true; // fix this later, it should be false but for now lets just do all RLI products

      PersonifyLogger.Logger.Info("Starting RLI Product Update");
      try
      {

        if (updateAll)
        {
          ClearRLIProducts();
        }

        List<PersonifyDS.PdsProduct> rliProducts = GetRLIProductsFromPersonify(true);

        foreach (var rliProduct in rliProducts)
        {
          ProductSearchResult psr = GetProductsByPersonifyID(rliProduct.ProductId.ToString()).FirstOrDefault();

          if (psr != null)
          {
            ProductStubItem productStub = ContentService.GetProductStub(psr.ItemId);
            if (productStub != null)
            {
              //update RLI fields
              List<PersonifyDS.PdsProductSubCategory> productTaxonomy = PersonifySvc.PdsProductSubCategories.Where(k => k.ProductId == rliProduct.ProductId).ToList();

              foreach (var ptax in productTaxonomy)
              {
                string code = ptax.Category;
                string subCode = ptax.SubscriptionCategory;

                RLIPersonifyCode rliCode = ContentService.GetRLIPersonifyFolder(TaxonomyFolders.RLIPersonifyFolder).RLICodes.FirstOrDefault(x => x.Code == code);
                if (rliCode != null)
                {
                  RLIPersonifySubCode rliSubCode = rliCode.RLISubCodes.FirstOrDefault(x => x.SubCode == subCode);

                  switch (code)
                  {
                    case "RLI":
                      {
                        if (subCode == "RLI")
                        {
                          productStub.HasRLI = true;                      
                        }
                      }
                      break;                
                    //treelist fields
                    case "CREDIT":
                      if (rliSubCode != null)
                      {
                        productStub.Credit = AddSubCodeToList(productStub.Credit,rliSubCode);                     
                      }
                      else
                      {
                        PersonifyLogger.Logger.Error(string.Format("Error setting taxonomy info -- productID: {0} -- subcode item is null, code: {1} -- subcode: {2}", rliProduct.ProductId.ToString(), code, subCode));
                      }
                      break;
                    case "DELIVERY":
                      if (rliSubCode != null)
                      {
                        productStub.Delivery = AddSubCodeToList(productStub.Delivery, rliSubCode);                       
                      }
                      else
                      {
                        PersonifyLogger.Logger.Error(string.Format("Error setting taxonomy info -- productID: {0} -- subcode item is null, code: {1} -- subcode: {2}", rliProduct.ProductId.ToString(), code, subCode));
                      }
                      break;
                    case "DOMAIN":
                      if (rliSubCode != null)
                      {
                        productStub.Domain = AddSubCodeToList(productStub.Domain, rliSubCode);
                       
                      }
                      else
                      {
                        PersonifyLogger.Logger.Error(string.Format("Error setting taxonomy info -- productID: {0} -- subcode item is null, code: {1} -- subcode: {2}", rliProduct.ProductId.ToString(), code, subCode));
                      }
                      break;

                    case "INTERESTS":
                      if (rliSubCode != null)
                      {
                        productStub.Interests = AddSubCodeToList(productStub.Interests, rliSubCode);
                       
                      }
                      else
                      {
                        PersonifyLogger.Logger.Error(string.Format("Error setting taxonomy info -- productID: {0} -- subcode item is null, code: {1} -- subcode: {2}", rliProduct.ProductId.ToString(), code, subCode));
                      }
                      break;

                    case "LEVEL":
                      if (rliSubCode != null)
                      {
                        productStub.Level = AddSubCodeToList(productStub.Level, rliSubCode);                      
                      }
                      else
                      {
                        PersonifyLogger.Logger.Error(string.Format("Error setting taxonomy info -- productID: {0} -- subcode item is null, code: {1} -- subcode: {2}", rliProduct.ProductId.ToString(), code, subCode));
                      }
                      break;

                    case "TOPIC":
                      if (rliSubCode != null)
                      {
                        productStub.Topic = AddSubCodeToList(productStub.Topic, rliSubCode);
                      }
                      else
                      {
                        PersonifyLogger.Logger.Error(string.Format("Error setting taxonomy info -- productID: {0} -- subcode item is null, code: {1} -- subcode: {2}", rliProduct.ProductId.ToString(), code, subCode));
                      }
                      break;
                    default:
                      //PersonifyLogger.Logger.Error(string.Format("Error setting taxonomy info -- productID: {0} -- code: {1} -- subcode: {2}", rliProduct.ProductId.ToString(), code, subCode));
                      PersonifyLogger.Logger.Error(string.Format("CODE not in import SWITCH ---- Error setting taxonomy info -- productID: {0} -- code: {1} -- subcode: {2}", rliProduct.ProductId.ToString(), code, subCode));
                      break;
                  }
                }
              }
              productStub.IsMeeting = IsRLiProductMeeting(productStub);
              rliCount++;
              SitecoreService.CreateUpdateItem(productStub);
            }
            else
            {
              PersonifyLogger.Logger.Error(string.Format("Error, could not find RLI product in Sitecore, personify id: {0}; product exists in index but not in master database id: {1}", rliProduct.ProductId.ToString(), psr.ItemId.ToString()));
            }
          }
          else
          {
            PersonifyLogger.Logger.Error(string.Format("Error, could not find RLI product in Sitecore, personify id: {0}",rliProduct.ProductId.ToString()));
          }
        }
      }
      catch (Exception ex)
      {
        result = "ERROR updating RLI Products. {0} imported.";
        PersonifyLogger.Logger.Error("Error during RLI product import", ex);
      }
      return string.Format(result,rliCount);
    }

    private List<RLIPersonifySubCode> AddSubCodeToList(IEnumerable<RLIPersonifySubCode> list, RLIPersonifySubCode subCode)
    {
      List<RLIPersonifySubCode> subCodelist;
      if (list == null)
      {
       subCodelist = new List<RLIPersonifySubCode>();
      }
      else
      {
        subCodelist = list.ToList();
      }
      if (!subCodelist.Contains(subCode))
      {
        subCodelist.Add(subCode);
      }
      return subCodelist;
    }

    private void ClearRLIProducts()
    {
      var rliProducts = productSearchManager.GetRLIProducts();
      foreach (var rliProd in rliProducts)
      {
       var productStub = ContentService.GetProductStub(rliProd.ItemId);
        if (productStub != null)
        {
          productStub.HasRLI = false;
          productStub.IsMeeting = false;
          productStub.Credit = productStub.Domain = productStub.Interests = productStub.Topic = productStub.Delivery = productStub.Level = new List<RLIPersonifySubCode>();

          SitecoreService.CreateUpdateItem(productStub);
        }
      }
    }

    private List<PersonifyDS.PdsProduct> GetRLIProductsFromPersonify(bool updateAllProducts)
    {
      List<long> RLIIDs = new List<long>();
      List<PersonifyDS.PdsProduct> RLIProducts = new List<PersonifyDS.PdsProduct>();

      var RLITaxes = PersonifySvc.PdsProductSubCategories.Where(x => x.Category == "RLI" && x.SubscriptionCategory == "RLI").ToList();
      foreach (var rli in RLITaxes)
      {
        RLIIDs.Add(rli.ProductId);
      }
      RLIIDs = RLIIDs.Distinct().ToList();
      foreach (var rid in RLIIDs)
      {
        PersonifyDS.PdsProduct product = PersonifySvc.PdsProducts.Where(x => x.ProductId == rid).First();
        if (!updateAllProducts)
        {
          if (product.LastUpdateDate >= DateTime.Now.AddHours(-24)) //only update products from last day
          {
            RLIProducts.Add(product);
          }
        }
        else
        {
          RLIProducts.Add(product);
        }
      }
      return RLIProducts;
    }

    private bool IsRLiProductMeeting(ProductStubItem rliProduct)
    {
      bool ismeeting = false;

      if (rliProduct.ProductArea.PersonifyID == "MTG")
      {
        ismeeting = true;
      }
      return ismeeting;
    }


    private void DeleteOtherPersonifyProducts(ProductStubItem product)
    {
      var otherProducts = GetProductsByPersonifyID(product.PersonifyID);
      var deleteProducts = otherProducts.Where(x => x.ItemId != product.ID);
      foreach (var deleteProd in deleteProducts)
      {
        var productStub = ContentService.GetProductStub(deleteProd.ItemId);
        if (productStub != null)
        {
          SitecoreService.DeleteItem(productStub);
        }
      }
    }

    private IEnumerable<ProductSearchResult> GetProductsByPersonifyID(string personifyId)
    {
      return productSearchManager.GetProducts(personifyId);     
    }

    private string GetProductCMECredit(decimal? cmecredit)
    {
      string cme = string.Empty;
      if (cmecredit.HasValue)
      {
        if (cmecredit > 0)
        {
          cme = cmecredit.ToString();
        }
      }
      return cme;
    }

    private PersonifyTaxonomyItem GetSitecoreTaxonomyItem(ID taxonomyRoot, string personifyId)
    {
      return ContentService.GetTaxonomyFolder(taxonomyRoot).TaxonomyItems.FirstOrDefault(x => x.PersonifyID == personifyId);
    }

    private PersonifyTaxonomyItem GetSitecoreTaxonomyItem(ID taxonomyRoot, PersonifyDS.PdsApplicationCode personifyCode)
    {
      string personifyId = personifyCode.GetSitecorePersonifyId();
      return ContentService.GetTaxonomyFolder(taxonomyRoot).TaxonomyItems.FirstOrDefault(x => x.PersonifyID == personifyId);
    }

    private IEnumerable<PersonifyTaxonomyItem> GetSitecoreTaxonomyItems(string subCodeConstant, ID taxonomyRoot, IEnumerable<PersonifyDS.PdsProductSubCategory> productTaxonomy)
    {
      var taxonomyItems = new List<PersonifyTaxonomyItem>();
      var personifyTaxonomy = productTaxonomy.Where(x => x.Category == subCodeConstant).ToList();
      foreach (var tax in personifyTaxonomy)
      {
        //var name = m.SubCategoryDescription;
        var pid = tax.SubscriptionCategory;
        var taxonomyItem = ContentService.GetTaxonomyFolder(taxonomyRoot).TaxonomyItems.FirstOrDefault(x => x.PersonifyID == pid);
        if (taxonomyItem != null)
        {
          taxonomyItems.Add(taxonomyItem);
        }
        else
        {
          PersonifyLogger.Logger.Error(string.Format("Could not find taxonomy item for product.  PersonifyID {0} . Description {1}", pid, tax.SubCategoryDescription));
        }
      }
      return taxonomyItems;
    }


    private string GetPriceValue(decimal? price)
    {
      string prc = string.Empty;
      if (price.HasValue)
      {
        if (price >= 0)
        {
          prc = price.ToString();
        }
      }
      return prc;
    }

    //private ProductStubItem FindExistingProduct

    private ProductClassFolder GetCreateProductClassFolder(string productClass, ProductSubsytemFolder parentSubSytem)
    {
      string name = ItemUtil.ProposeValidItemName(productClass);

      var productClassItem = parentSubSytem.ProductClasses.FirstOrDefault(x => x.Name == name);
      if (productClassItem != null)
      {
        return productClassItem;
      }
      else
      {
        productClassItem = new ProductClassFolder();
        productClassItem.Parent = parentSubSytem;
        productClassItem.Name = name;
        productClassItem.ID = ID.Null;

        return SitecoreService.CreateUpdateItem(productClassItem);
      }
    }

    private ProductSubsytemFolder GetCreateProductSubsytemFolder(string subsystem)
    {
      var productRootFolder = ContentService.GetProductRootFolder(ProductFolders.ProductRoot);
      if (productRootFolder != null)
      {
        var name = ItemUtil.ProposeValidItemName(subsystem);

        var productSubsytem = productRootFolder.ProductSubsytemFolders.FirstOrDefault(x => x.Name == name);
        if (productSubsytem != null)
        {
          return productSubsytem;
        }
        else
        {
          productSubsytem = new ProductSubsytemFolder();
          productSubsytem.ID = ID.Null;
          productSubsytem.Parent = productRootFolder;
          productSubsytem.Name = name;

          return SitecoreService.CreateUpdateItem(productSubsytem);
        }
      }
      else
      {
        PersonifyLogger.Logger.Error("Product root folder is null, product import will not continue");
        return null;
      }
    }


    private List<PersonifyDS.PdsProduct> GetPersonifyProducts(DateTime date)
    {
      var products = new List<PersonifyDS.PdsProduct>();
      try
      {
        products = PersonifySvc.PdsProducts.Where(x => x.LastUpdateDate >= date).ToList();
      }
      catch (Exception ex)
      {
        PersonifyLogger.Logger.Error("Could not retrieve personify products from PersonifyDS service", ex);
      }
      return products;
    }

  }
}
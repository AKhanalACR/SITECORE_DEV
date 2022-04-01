using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using ACR.Foundation.Personify.Cache;
using ACR.Foundation.Personify.PersonifyDS;
using ACR.Foundation.Personify.Settings;
using log4net;
using Sitecore.Diagnostics;
using ACR.Foundation.Personify.Logger;
using static ACR.Foundation.Personify.Constants.PersonifyConstants;
using ACR.Foundation.Personify.Models.Members;
using System.Xml.Linq;
using System.Data.Services.Client;
using Newtonsoft.Json;
using System.IO;
using ACR.Foundation.Personify.Models.Committees;
using ACR.Foundation.Personify.Models.Chapters;
using ACR.Foundation.Personify.Models.Informz;

namespace ACR.Foundation.Personify.PersonifyService
{
  public class PersonifyEntitiesACR : PersonifyDS.PersonifyEntitiesACR
  {
    public PersonifyEntitiesACR() : base(new Uri(ACRSettings.PersonifyServiceUrl))
    {
      NetworkCredential credential = new NetworkCredential(ACRSettings.PersonifyServiceUser, ACRSettings.PersonifyServicePass);
      this.Credentials = credential;

      ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
    }

    private const string KEY_PRODUCTAREAS = "96999fd4-33f3-4f04-84c8-6c28cdfd2e4c";
    private const string KEY_PRODUCTCODES = "e84f2193-6697-41da-ac13-9d45e20e2f64";
    private const string KEY_PRODUCTSUBCODES = "08e882d1-0a27-46fe-b590-0bede9bef550";
    private const string KEY_MODSUBSPEC = "321f2190-03d3-49dd-96af-f3c1c087d2dc";
    private const string KEY_ROLES = "d04b57e2-ba88-4eda-8a1e-fbd1ac8f3524";
    private const string KEY_CREDIT_TYPES = "581595bb-f8d2-4470-8270-81e1952a8432";

    /// <summary>
    /// Retrieves the product codes taxonomy and caches it for 30 minutes.
    /// </summary>
    /// <returns></returns>
    public List<PdsApplicationCode> GetProductCodes()
    {
      return ACRCache.GetFromCache<List<PdsApplicationCode>>(
        KEY_PRODUCTCODES, new TimeSpan(0, 30, 0),
        () => PdsApplicationCodes
          .Where(p => p.Type == PdsConstants.TYPE_PRODUCTCLASS || p.Type == PdsConstants.TYPE_PRODUCTTYPE)
          .ToList());
    }

    public List<PdsApplicationCode> GetRLIProductCodes()
    {
      return PdsApplicationCodes.Where(p => p.Type == PdsConstants.TYPE_PRODUCT_CATEGORY && p.Option2 == "RLI").ToList();
    }

    public List<PdsApplicationSubcode> GetRLIProductSubCodes()
    {
      return PdsApplicationSubcodes.Where(p => p.Type == PdsConstants.TYPE_PRODUCT_CATEGORY && p.Option2 == "RLI").ToList();
    }


    public List<PdsApplicationCode> GetCustomerRoles()
    {
      return ACRCache.GetFromCache<List<PdsApplicationCode>>(
        KEY_ROLES, new TimeSpan(0, 30, 0),
        () => PdsApplicationCodes
          .Where(p => p.Type == PdsConstants.TYPE_ROLES)
          .ToList());
    }
    /// <summary>
    /// Returns all product subcategories where the catagory is credit.
    /// </summary>
    public List<PdsApplicationSubcode> GetCreditTypes()
    {
      return ACRCache.GetFromCache<List<PdsApplicationSubcode>>(
        KEY_CREDIT_TYPES, new TimeSpan(0, 30, 0),
        () => PdsApplicationSubcodes
          .Where(p => p.Code == PdsConstants.CREDIT_TYPES)
          .ToList());
    }

    /// <summary>
    /// Retrieves product subsystems taxonomy and caches it for 30 minutes.
    /// </summary>
    /// <returns></returns>
    public List<PdsApplicationCode> GetProductAreas()
    {
      return ACRCache.GetFromCache<List<PdsApplicationCode>>(
        KEY_PRODUCTAREAS, new TimeSpan(0, 30, 0),
        () => PdsApplicationCodes
          .Where(p => p.Type == PdsConstants.TYPE_SUBSYSTEM && p.SubsystemString == PdsConstants.SUBSYSTEM_STRING_USER)
          .ToList());
    }

    /// <summary>
    /// Retrieves product application subcodes taxonomy and caches it for 30 minutes.
    /// </summary>
    /// <returns></returns>
    public List<PdsApplicationSubcode> GetProductSubCodes()
    {
      return ACRCache.GetFromCache<List<PdsApplicationSubcode>>(
        KEY_PRODUCTSUBCODES, new TimeSpan(0, 30, 0),
        () => PdsApplicationSubcodes.Where(
          p => p.Code == PdsConstants.SUBCODE_ABRCODE
          || p.Code == PdsConstants.SUBCODE_DELIVERY
          || p.Code == PdsConstants.SUBCODE_INTERESTS
          || p.Code == PdsConstants.SUBCODE_TOPICS)
          .ToList());
    }


    public List<PdsACRApplicationSubcode> GetModalitySubspecialty()
    {
      return ACRCache.GetFromCache(
        KEY_MODSUBSPEC, new TimeSpan(0, 30, 0),
        () => PdsACRApplicationSubcodes
          .Where(p => p.Type == PdsConstants.TYPE_PRODUCT_CATEGORY
          && (p.Code == PdsConstants.SUBCODE_MODALITY || p.Code == PdsConstants.SUBCODE_SUBSPECIALTY))).ToList();
    }


    public bool AddToCart(string pMasterCustomerId, string pSubCustomerId, string pProductId, bool pIsAuthenticated, string productSubsystem, bool saveForLater = false)
    {
      int productId;
      if (!int.TryParse(pProductId, out productId))
      {
        PersonifyLogger.Logger.Error("AddToCart: The product's PersonifyID could not be converted to an integer.");
        return false;
      }

      int subCustId;
      if (!int.TryParse(pSubCustomerId, out subCustId))
      {
        subCustId = 0;
      }

      string nl = System.Environment.NewLine;
      var errorParams = "BillMasterCustomerId = " + pMasterCustomerId
                        + nl + "BillSubCustomerId = " + subCustId
                        + nl + "ProductId = " + productId
                        + nl + "Quantity = 1"
                        + nl + "ShipMasterCustomerId = " + ((pIsAuthenticated) ? pMasterCustomerId : "")
                        + nl + "ShipSubCustomerId = " + subCustId
                        + nl + "RateStructure = "
                        + nl + "RateCode = "
                        + nl + "UserDefinedField1 = "
                        + nl + "UserDefinedField2 = "
                        + nl + "UserDefinedField3 = "
                        + nl + "MarketCode = ";

      try
      {
        WebShoppingCartItem cartItem = SvcClient.Create<WebShoppingCartItem>();
        cartItem.MasterCustomerId = ((pIsAuthenticated) ? pMasterCustomerId : "");
        cartItem.AnonymousUserId = ((pIsAuthenticated) ? "" : pMasterCustomerId);
        cartItem.ProductId = productId;
        cartItem.Quantity = 1;
        cartItem.RateCode = "";
        cartItem.RateStructure = "";
        cartItem.ShipMasterCustomerId = ((pIsAuthenticated) ? pMasterCustomerId : "");
        cartItem.ShipSubCustomerId = subCustId;
        cartItem.SubCustomerId = subCustId;
        cartItem.MarketCode = "";
        cartItem.Subsystem = productSubsystem;
        if (saveForLater)
        {
          cartItem.WishListFlag = true;
        }

        var result = SvcClient.Save<WebShoppingCartItem>(cartItem);



        return result != null;
      }
      catch (Exception exc)
      {
        PersonifyLogger.Logger.Error("AddMainProductToCart: Exception was thrown by web service method. " + nl + errorParams, exc);
        //Elmah.ErrorSignal.FromCurrentContext().Raise(exc);
        return false;
      }
      return true;
    }

    public int GetCartProductCount(string pMasterCustomerId, string pSubCustomerId)
    {
      int subCustId;
      if (!int.TryParse(pSubCustomerId, out subCustId))
      {
        subCustId = 0;
      }

      try
      {
        var inputs = WebShoppingCartItems.Where(input => (input.AnonymousUserId == pMasterCustomerId || input.MasterCustomerId == pMasterCustomerId) && input.WorkflowId == null && input.WishListFlag == false && input.RelatedWebShoppingCartItemId == 0).ToList();
        return inputs.Count;
      }
      catch (Exception exc)
      {
        PersonifyLogger.Logger.Error("GetShoppingCartSummary: Exception was thrown by web service method.", exc);
        //Elmah.ErrorSignal.FromCurrentContext().Raise(exc);
        return 0;
      }

    }

    public List<string> GetCartProductIds(string pMasterCustomerId, string pSubCustomerId)
    {
      List<string> productIds = new List<string>();
      var cartItems = WebShoppingCartItems.Where(input => input.MasterCustomerId == pMasterCustomerId).ToList();

      productIds.AddRange(cartItems.Select(cartInfo => cartInfo.ProductId.ToString()));
      return productIds;
    }

    public bool TransferCart(string pMasterCustomerId, string pSubCustomerId, string pAnonymousUserId)
    {
      int subCustId;
      if (!int.TryParse(pSubCustomerId, out subCustId))
      {
        subCustId = 0;
      }

      try
      {
        TransferCartInput cartInput = new TransferCartInput()
        {
          GUID = pAnonymousUserId,
          InternalKey = "",
          MasterCustomerId = pMasterCustomerId,
          NavigationKey = "",
          SubCustomerId = subCustId
        };

        var result = SvcClient.Post<TransferCartOutput>("TransferCart", cartInput, "JSON");
        Log.Info(string.Format("LOGIN AUDIT: TransferCartOutputResult: {0}.", result), this);

        return result != null;
      }
      catch (Exception exc)
      {
        PersonifyLogger.Logger.Error("TransferShoppingCart: Exception was thrown by web service method.", exc);
        //Elmah.ErrorSignal.FromCurrentContext().Raise(exc);
        return false;
      }
      return true;
    }

    public List<PersonifyChapter> GetChapterList()
    {
      List<PersonifyChapter> chapters = new List<PersonifyChapter>();

      try
      {
        var procedureParams = new DataServiceCollection<StoredProcedureParameter>(null, TrackingMode.None);
        //procedureParams.Add(new StoredProcedureParameter { Name = "CustomerId", Value = customerId, Direction = 1 });
        var request = new StoredProcedureRequest
        {
          StoredProcedureName = "USR_PDS_ACR_CHAPTERS_SP",
          IsUserDefinedFunction = false,
          SPParameterList = procedureParams

        };
        var response = SvcClient.Post<StoredProcedureOutput>("GetStoredProcedureDataXML", request);

        if (!string.IsNullOrEmpty(response.Data))
        {
          //PersonifyLogger.Logger.Error("Commitee Response Data: " + response.Data);
          XDocument xmlDoc = XDocument.Parse(response.Data);

          //File.WriteAllText(HttpContext.Current.Server.MapPath("/App_Data/Personify/chapter-list.xml"), xmlDoc.ToString());

          var comms = xmlDoc.Descendants().Where(x => x.Name.LocalName == "Table").ToList();
          foreach (var c in comms)
          {
            string display = c.Descendants().FirstOrDefault(x => x.Name.LocalName == "DISPLAYONWEB").Value;
            if (display == "Y")
            {

              //DateTime lastUpdate = DateTime.MinValue;
              //DateTime.TryParse(c.Descendants().FirstOrDefault(x => x.Name.LocalName == "LASTUPDATEDATE").Value, out lastUpdate);

              chapters.Add(new PersonifyChapter()
              {
                ChapterID = c.Descendants().FirstOrDefault(x => x.Name.LocalName == "CHAPTER_ID").Value,
                ChapterName = c.Descendants().FirstOrDefault(x => x.Name.LocalName == "CHAPTER_NAME").Value
              });
            }
          }
          return chapters;
        }
      }
      catch (Exception ex)
      {
        PersonifyLogger.Logger.Error("Get Committeee Data Eror:" + ex.Message, ex);
      }
      return null;
    }

    public List<PersonifyCommittee> GetCommitteeList()
    {

      List<PersonifyCommittee> committees = new List<PersonifyCommittee>();

      try
      {
        var procedureParams = new DataServiceCollection<StoredProcedureParameter>(null, TrackingMode.None);
        //procedureParams.Add(new StoredProcedureParameter { Name = "CustomerId", Value = customerId, Direction = 1 });
        var request = new StoredProcedureRequest
        {
          StoredProcedureName = "USR_PDS_ACR_COMMITTEEINFO_SP",
          IsUserDefinedFunction = false,
          SPParameterList = procedureParams

        };
        var response = SvcClient.Post<StoredProcedureOutput>("GetStoredProcedureDataXML", request);

        if (!string.IsNullOrEmpty(response.Data))
        {
          //PersonifyLogger.Logger.Error("Commitee Response Data: " + response.Data);
          XDocument xmlDoc = XDocument.Parse(response.Data);

          //File.WriteAllText(HttpContext.Current.Server.MapPath("/App_Data/Personify/committee-list.xml"), xmlDoc.ToString());

          var comms = xmlDoc.Descendants().Where(x => x.Name.LocalName == "Table").ToList();
          foreach (var c in comms)
          {
            string type = c.Descendants().FirstOrDefault(x => x.Name.LocalName == "COMMITEETYPE").Value;
            string display = c.Descendants().FirstOrDefault(x => x.Name.LocalName == "DISPLAYONWEB").Value;
            if (display == "Y" && type != "CHAPTER")
            {

              //DateTime lastUpdate = DateTime.MinValue;
              //DateTime.TryParse(c.Descendants().FirstOrDefault(x => x.Name.LocalName == "LASTUPDATEDATE").Value, out lastUpdate);

              committees.Add(new PersonifyCommittee()
              {
                COMMITTEENAME = c.Descendants().FirstOrDefault(x => x.Name.LocalName == "COMMITTEENAME").Value,
                COMMITEETYPE = c.Descendants().FirstOrDefault(x => x.Name.LocalName == "COMMITEETYPE").Value,
                //LASTUPDATEDATE = lastUpdate,
                SUB_CUSTOMER_ID = c.Descendants().FirstOrDefault(x => x.Name.LocalName == "SUB_CUSTOMER_ID").Value,
                MASTER_CUSTOMER_ID = c.Descendants().FirstOrDefault(x => x.Name.LocalName == "MASTER_CUSTOMER_ID").Value
              });
            }
          }

          //File.WriteAllText(HttpContext.Current.Server.MapPath("/App_Data/Personify/committee-list.xml"), xmlDoc.ToString());

          return committees;
        }
      }
      catch (Exception ex)
      {
        PersonifyLogger.Logger.Error("Get Committeee Data Eror:" + ex.Message, ex);
      }
      return null;
    }

    /*
    public void GetCommitteePositions()
    {
      try
      {
        var procedureParams = new DataServiceCollection<StoredProcedureParameter>(null, TrackingMode.None);
        //procedureParams.Add(new StoredProcedureParameter { Name = "chapterId", Value = chapterId, Direction = 1 });
        var request = new StoredProcedureRequest
        {
          StoredProcedureName = "USR_PDS_ACR_COMMITTEEPOSITIONS_SP",
          IsUserDefinedFunction = false,
          SPParameterList = procedureParams
        };
        var response = SvcClient.Post<StoredProcedureOutput>("GetStoredProcedureDataXML", request);

        if (!string.IsNullOrEmpty(response.Data))
        {
          File.WriteAllText(HttpContext.Current.Server.MapPath("/App_Data/Personify") + "/positions.xml", response.Data);
        }

      }
      catch (Exception ex)
      {
        PersonifyLogger.Logger.Error("Chapter Members Data Eror:" + ex.Message, ex);
      }
    }*/

    public bool UnsubscribeAllNewsletters(string customerId)
    {
      bool success = false;

      try
      {
        var procedureParams = new DataServiceCollection<StoredProcedureParameter>(null, TrackingMode.None);
        procedureParams.Add(new StoredProcedureParameter { Name = "@CustomerID", Value = customerId, Direction = 1 });

        var request = new StoredProcedureRequest
        {
          StoredProcedureName = "USR_PDS_ACR_INFORMZ_UNSUBSCRIBE_SP",
          IsUserDefinedFunction = false,
          SPParameterList = procedureParams
        };
        var response = SvcClient.Post<StoredProcedureOutput>("GetStoredProcedureDataXML", request);
        if (response.Data != null)
        {
          if (response.Data.Trim().ToLower() == "success")
          {
            success = true;
          }
          success = true;
          //File.WriteAllText(HttpContext.Current.Server.MapPath("/App_Data/Personify") + "/opt-in-result.xml", response.Data);
        }

      }
      catch (Exception ex)
      {
        PersonifyLogger.Logger.Error("Error unsubscribing user form all newsletters:" + ex.Message, ex);
      }

      return success;
    }

    public List<ChapterMember> GetChapterMembers(string chapterId)
    {
      List<ChapterMember> chapterMembers = new List<ChapterMember>();
      try
      {
        var procedureParams = new DataServiceCollection<StoredProcedureParameter>(null, TrackingMode.None);
        procedureParams.Add(new StoredProcedureParameter { Name = "@chapterId", Value = chapterId, Direction = 1 });
        var request = new StoredProcedureRequest
        {
          StoredProcedureName = "USR_PDS_ACR_CHAPTEROFFICERS_SP",
          IsUserDefinedFunction = false,
          SPParameterList = procedureParams

        };
        var response = SvcClient.Post<StoredProcedureOutput>("GetStoredProcedureDataXML", request);

        if (!string.IsNullOrEmpty(response.Data))
        {
          //File.WriteAllText(HttpContext.Current.Server.MapPath("/App_Data/Personify") + "/chapter-Member" + chapterId + ".xml", response.Data);
          //PersonifyLogger.Logger.Error("Commitee Response Data: " + response.Data);
          XDocument xmlDoc = XDocument.Parse(response.Data);

          var members = xmlDoc.Descendants().Where(x => x.Name.LocalName == "Table").ToList();

          foreach (var member in members)
          {
            chapterMembers.Add(new ChapterMember()
            {
              MemberName = member.Descendants().FirstOrDefault(x => x.Name.LocalName == "MEMBER_NAME").Value,
              Position = member.Descendants().FirstOrDefault(x => x.Name.LocalName == "POSITION_DESCRIPTION").Value,
              LastName = member.Descendants().FirstOrDefault(x => x.Name.LocalName == "LAST_NAME").Value
            });
          }
          return chapterMembers;

        }
      }
      catch (Exception ex)
      {
        PersonifyLogger.Logger.Error("Chapter Members Data Eror:" + ex.Message, ex);
      }


      return null;
    }


    public List<Models.Committees.CommitteeMember> GetCommiteeMembers(string masterCustomerId)
    {
      List<Models.Committees.CommitteeMember> members = new List<Models.Committees.CommitteeMember>();

      try
      {
        var procedureParams = new DataServiceCollection<StoredProcedureParameter>(null, TrackingMode.None);
        procedureParams.Add(new StoredProcedureParameter { Name = "@MastercustomerID", Value = masterCustomerId, Direction = 1 });
        procedureParams.Add(new StoredProcedureParameter { Name = "@subcustomerid", Value = "0", Direction = 1 });

        var request = new StoredProcedureRequest
        {
          StoredProcedureName = "USR_PDS_ACR_COMMITTEEMEMBERS_SP",
          IsUserDefinedFunction = false,
          SPParameterList = procedureParams

        };
        var response = SvcClient.Post<StoredProcedureOutput>("GetStoredProcedureDataXML", request);

        if (!string.IsNullOrEmpty(response.Data))
        {
          //PersonifyLogger.Logger.Error("Commitee Response Data: " + response.Data);
          XDocument xmlDoc = XDocument.Parse(response.Data);

          var allMembers = xmlDoc.Descendants().Where(x => x.Name.LocalName == "Table").ToList();

          foreach (var member in allMembers)
          {
            members.Add(new Models.Committees.CommitteeMember()
            {
              Name = member.Descendants().FirstOrDefault(x => x.Name.LocalName == "LABEL_NAME").Value,
              Position = member.Descendants().FirstOrDefault(x => x.Name.LocalName == "POSITIONDESCRIPTION").Value,
              SearchName = member.Descendants().FirstOrDefault(x => x.Name.LocalName == "SEARCH_NAME").Value,
            });
          }

          //File.WriteAllText(HttpContext.Current.Server.MapPath("/App_Data/Personify") + "/committee-members-" + masterCustomerId + ".xml", xmlDoc.ToString());

          return members;
        }
      }
      catch (Exception ex)
      {
        PersonifyLogger.Logger.Error("Committee Members Data Eror:" + ex.Message, ex);
      }
      return null;
    }


    public XDocument GetACRCMECreditsXml(string customerId)
    {
      //customerId = "05045598";
      try
      {
        var procedureParams = new DataServiceCollection<StoredProcedureParameter>(null, TrackingMode.None);
        procedureParams.Add(new StoredProcedureParameter { Name = "@CustomerId", Value = customerId, Direction = 1 });
        var request = new StoredProcedureRequest
        {
          StoredProcedureName = "USR_ACR_CME_GATEWAY_CREDIT_DETAILS_SP",
          IsUserDefinedFunction = false,
          SPParameterList = procedureParams

        };
        var response = SvcClient.Post<StoredProcedureOutput>("GetStoredProcedureDataXML", request);

        if (!string.IsNullOrEmpty(response.Data))
        {
          //PersonifyLogger.Logger.Error("CME Response Data: " + response.Data);
          XDocument xmlDoc = XDocument.Parse(response.Data);

          return xmlDoc;
        }
      }
      catch (Exception ex)
      {
        PersonifyLogger.Logger.Error("CME Response Data Eror:" + ex.Message, ex);
      }

      return null;
    }

    public KeyValuePair<bool, double> GetACRCMECredits(string customerId)
    {
      KeyValuePair<bool, double> cmeCredits = new KeyValuePair<bool, double>(false, 0);
      try
      {
        XDocument xdoc = GetACRCMECreditsXml(customerId);

        string json = JsonConvert.SerializeXNode(xdoc);
        dynamic cme = JsonConvert.DeserializeObject(json);

        if (cme.NewDataSet.Table.DISPLAY.Value == "Y")
        {
          cmeCredits = new KeyValuePair<bool, double>(true, 0);
        }
        var table1 = cme.NewDataSet.Table1;

        //List<string> credits = new List<string>();

        //foreach (var row in table1)
        //{
        //  credits.Add(row.CREDIT.Value);
        //}
        double totalCredits = 0;
        //foreach (var c in credits)
        //{
        //  try
        //  {
        //    double cc = Convert.ToDouble(c);
        //    totalCredits += cc;
        //  }
        //  catch (Exception) { }
        //}

        var creditNodes = xdoc.Descendants().Where(x => x.Name.LocalName == "CREDIT");
        foreach (var c in creditNodes)
        {
          try
          {
            double cc = Convert.ToDouble(c.Value);
            totalCredits += cc;
          }
          catch (Exception exc)
          {
            PersonifyLogger.Logger.Error("Error converting credits to double. value = " + c.Value, exc);
          }
        }

        cmeCredits = new KeyValuePair<bool, double>(cmeCredits.Key, totalCredits);

      }
      catch (Exception ex)
      {
        PersonifyLogger.Logger.Error("Error reading XML / dynamic json object for CME Credits:" + ex.Message, ex);
      }
      return cmeCredits;
    }

    public CreateCustomerResult CreateCustomer(string first, string last, string email, string address, string address2, string city, string state, string country, string postalCode, string optin)
    {
      CreateCustomerResult result = new CreateCustomerResult();

      try
      {
        var procedureParams = new DataServiceCollection<StoredProcedureParameter>(null, TrackingMode.None);
        procedureParams.Add(new StoredProcedureParameter { Name = "@FIRSTNAME", Value = first, Direction = 1 });
        procedureParams.Add(new StoredProcedureParameter { Name = "@LASTNAME", Value = last, Direction = 1 });
        procedureParams.Add(new StoredProcedureParameter { Name = "@EMAIL", Value = email, Direction = 1 });
        procedureParams.Add(new StoredProcedureParameter { Name = "@CITY", Value = city, Direction = 1 });
        procedureParams.Add(new StoredProcedureParameter { Name = "@STATE", Value = state, Direction = 1 });
        procedureParams.Add(new StoredProcedureParameter { Name = "@COUNTRY", Value = country, Direction = 1 });
        procedureParams.Add(new StoredProcedureParameter { Name = "@ADDRESS1", Value = address, Direction = 1 });
        procedureParams.Add(new StoredProcedureParameter { Name = "@ADDRESS2", Value = address2, Direction = 1 });
        procedureParams.Add(new StoredProcedureParameter { Name = "@ADDRESS3", Value = "", Direction = 1 });
        procedureParams.Add(new StoredProcedureParameter { Name = "@POSTALCODE", Value = postalCode, Direction = 1 });
        procedureParams.Add(new StoredProcedureParameter { Name = "@OPTINCODE", Value = optin, Direction = 1 });
        var request = new StoredProcedureRequest
        {
          StoredProcedureName = "USR_PDS_ACR_INFORMZ_CREATE_CUSTOMER_SP",
          IsUserDefinedFunction = false,
          SPParameterList = procedureParams

        };
        var response = SvcClient.Post<StoredProcedureOutput>("GetStoredProcedureDataXML", request);
        if (!string.IsNullOrEmpty(response.Data))
        {

          //File.WriteAllText(HttpContext.Current.Server.MapPath("/App_Data/Personify") + "/create-customer-result.xml", response.Data);

          XDocument xmlDoc = XDocument.Parse(response.Data);

          var customerId = xmlDoc.Descendants().FirstOrDefault(x => x.Name.LocalName == "CustomerId");
          var recordType = xmlDoc.Descendants().FirstOrDefault(x => x.Name.LocalName == "Record_Type");
          var userName = xmlDoc.Descendants().FirstOrDefault(x => x.Name.LocalName == "UserName");

          if (customerId != null)
          {
            result.CustomerId = customerId.Value.Trim();
          }
          if (recordType != null)
          {
            result.Record_Type = customerId.Value.Trim();
          }
          if (userName != null)
          {
            result.UserName = userName.Value.Trim();
            result.Email = email;
          }

        }
      }
      catch (Exception ex)
      {
        PersonifyLogger.Logger.Error("Error createing customer:" + ex.Message, ex);
      }

      return result;


    }

    public bool CustomerOptInNewsletters(string customerId, string optInCodes)
    {
      bool success = false;

      try
      {
        var procedureParams = new DataServiceCollection<StoredProcedureParameter>(null, TrackingMode.None);
        procedureParams.Add(new StoredProcedureParameter { Name = "@CustomerID", Value = customerId, Direction = 1 });
        procedureParams.Add(new StoredProcedureParameter { Name = "@OptInCode", Value = optInCodes, Direction = 1 });

        var request = new StoredProcedureRequest
        {
          StoredProcedureName = "USR_PDS_ACR_INFORMZ_OPT_IN_SP",
          IsUserDefinedFunction = false,
          SPParameterList = procedureParams

        };
        var response = SvcClient.Post<StoredProcedureOutput>("GetStoredProcedureDataXML", request);
        if (response.Data != null)
        {
          if (response.Data.Trim().ToLower() == "success")
          {
            success = true;
          }
          success = true;
          //File.WriteAllText(HttpContext.Current.Server.MapPath("/App_Data/Personify") + "/opt-in-result.xml", response.Data);
        }

      }
      catch (Exception ex)
      {
        PersonifyLogger.Logger.Error("Error opting in:" + ex.Message, ex);
      }

      return success;
    }

    public bool CustomerOptOutNewsletters(string customerId, string optOutCodes)
    {
      bool success = false;

      try
      {
        var procedureParams = new DataServiceCollection<StoredProcedureParameter>(null, TrackingMode.None);
        procedureParams.Add(new StoredProcedureParameter { Name = "@CustomerID", Value = customerId, Direction = 1 });
        procedureParams.Add(new StoredProcedureParameter { Name = "@OptOutCode", Value = optOutCodes, Direction = 1 });

        var request = new StoredProcedureRequest
        {
          StoredProcedureName = "USR_PDS_ACR_INFORMZ_OPT_OUT_SP",
          IsUserDefinedFunction = false,
          SPParameterList = procedureParams

        };
        var response = SvcClient.Post<StoredProcedureOutput>("GetStoredProcedureDataXML", request);
        if (response.Data != null)
        {
          if (response.Data.Trim().ToLower() == "success")
          {
            success = true;
          }
          success = true;
          //File.WriteAllText(HttpContext.Current.Server.MapPath("/App_Data/Personify") + "/opt-out-result.xml", response.Data);
        }

      }
      catch (Exception ex)
      {
        PersonifyLogger.Logger.Error("Error opting out:" + ex.Message, ex);
      }

      return success;
    }

    public InformzCustomerExists CustomerExists(string firstname, string lastname, string city, string zip)
    {
      InformzCustomerExists exists = new InformzCustomerExists();
      try
      {
        var procedureParams = new DataServiceCollection<StoredProcedureParameter>(null, TrackingMode.None);
        procedureParams.Add(new StoredProcedureParameter { Name = "@FIRSTNAME", Value = firstname, Direction = 1 });
        procedureParams.Add(new StoredProcedureParameter { Name = "@LASTNAME", Value = lastname, Direction = 1 });
        procedureParams.Add(new StoredProcedureParameter { Name = "@CITY", Value = city, Direction = 1 });
        procedureParams.Add(new StoredProcedureParameter { Name = "@POSTALCODE", Value = zip, Direction = 1 });
        var request = new StoredProcedureRequest
        {
          StoredProcedureName = "USR_PDS_ACR_INFORMZ_DUPLICATE_CHECK_SP",
          IsUserDefinedFunction = false,
          SPParameterList = procedureParams

        };
        var response = SvcClient.Post<StoredProcedureOutput>("GetStoredProcedureDataXML", request);

        //File.WriteAllText(HttpContext.Current.Server.MapPath("/App_Data/Personify") + "/customer-exists.xml", response.Data);

        if (response.Data == "No data found")
        {
          exists.Exists = false;
        }
        else if (!string.IsNullOrEmpty(response.Data))
        {

          XDocument xmlDoc = XDocument.Parse(response.Data);
          var name = xmlDoc.Descendants().FirstOrDefault(x => x.Name.LocalName == "Name");
          var email = xmlDoc.Descendants().FirstOrDefault(x => x.Name.LocalName == "EMAIL");

          if (name != null && email != null)
          {
            exists.Exists = true;
            exists.Emails.Add(email.Value);
            exists.Name.Add(name.Value);
          }
        }
      }
      catch (Exception ex)
      {
        PersonifyLogger.Logger.Error("Error checking if customer exists:" + ex.Message, ex);
      }
      return exists;
    }



    public InformzCustomerData GetInformzCustomerData(string email)
    {
      try
      {
        var procedureParams = new DataServiceCollection<StoredProcedureParameter>(null, TrackingMode.None);
        procedureParams.Add(new StoredProcedureParameter { Name = "@EMAIL", Value = email, Direction = 1 });
        var request = new StoredProcedureRequest
        {
          StoredProcedureName = "USR_PDS_ACR_INFORMZ_CHECK_EMAIL_EXISTS_SP",
          IsUserDefinedFunction = false,
          SPParameterList = procedureParams

        };
        var response = SvcClient.Post<StoredProcedureOutput>("GetStoredProcedureDataXML", request);
        if (!string.IsNullOrEmpty(response.Data))
        {
          XDocument xmlDoc = XDocument.Parse(response.Data);

          //File.WriteAllText(HttpContext.Current.Server.MapPath("/App_Data/Personify") + "/InformzCustomerData.xml", response.Data);

          InformzCustomerData data = new InformzCustomerData();
          data.EmailExists = false;

          var emailStatus = xmlDoc.Descendants().FirstOrDefault(x => x.Name.LocalName == "EmailStatus");
          if (emailStatus != null)
          {
            if (emailStatus.Value.Trim() == "Y")
            {
              data.EmailExists = true;

              var custId = xmlDoc.Descendants().FirstOrDefault(x => x.Name.LocalName == "CUSTOMERID");
              if (custId != null)
              {
                data.CustomerID = custId.Value.Trim();
              }

              var isMember = xmlDoc.Descendants().FirstOrDefault(x => x.Name.LocalName == "ISMEMBER");
              if(isMember != null && isMember.Value.Trim() == "Y")
              {
                  data.IsMember = true;
              } 
                            
              List<string> opts = new List<string>();
              var optIn = xmlDoc.Descendants().Where(x => x.Name.LocalName == "OPTINCODE");
              foreach (var o in optIn)
              {
                if (o != null)
                {
                  opts.Add(o.Value.Trim());
                }
              }
              data.OptInCodes = string.Join("|", opts);
            }
          }
          return data;
        }
      }
      catch (Exception ex)
      {
        PersonifyLogger.Logger.Error("Error checking informz customer exists:" + ex.Message, ex);
      }
      return null;
    }


    public List<Member> GetMembershipData(string[] paramListValue)
    {
      string[] paramName = new string[] { "@LastName", "@FirstName", "@City", "@State", "@ZipCode", "@Country" };
      var procedureParams = new DataServiceCollection<StoredProcedureParameter>(null, TrackingMode.None);
      for (int i = 0; i < paramListValue.Length; i++)
      {
        procedureParams.Add(new StoredProcedureParameter { Name = paramName[i], Value = paramListValue[i], Direction = 1 });
      }

      var request = new StoredProcedureRequest
      {
        StoredProcedureName = "acr_sc_membership_dir_Get",
        IsUserDefinedFunction = false,
        SPParameterList = procedureParams
      };

      var response = SvcClient.Post<StoredProcedureOutput>("GetStoredProcedureDataXML", request);

      if (!string.IsNullOrEmpty(response.Data))
      {
        XDocument xmlDoc = XDocument.Parse(response.Data);
        var objs = from el in xmlDoc.Descendants("NewDataSet").Descendants("Table")
                   select new Member
                   {
                     MasterCustomerId = GetValue(el.Element("master_customer_id")),
                     SortName = GetValue(el.Element("Sort_Name")),
                     Attn = GetValue(el.Element("attn")),
                     LabelName = GetValue(el.Element("labelname")),
                     City = GetValue(el.Element("City")),
                     State = GetValue(el.Element("State")),
                     Zip = GetValue(el.Element("Zip")),
                     BusinessPhone = GetValue(el.Element("businessphone")),
                     BusinessFax = GetValue(el.Element("businessfax")),
                     Email = GetValue(el.Element("email")),
                     Address1 = GetValue(el.Element("address1")),
                     Address2 = GetValue(el.Element("address2")),
                     CityStreetZip = GetValue(el.Element("citystzip")),
                     Country = GetValue(el.Element("country")),
                     MemberSince = ToDateTime(GetValue(el.Element("MemberSince")))
                   };
        if (objs != null)
        {
          List<Member> r = objs.ToList();
          return r;
        }
      }
      return null;
    }

    public Member GetCustomerInfo(string customerId, string subCustomerId)
    {
      try
      {
        var procedureParams = new DataServiceCollection<StoredProcedureParameter>(null, TrackingMode.None);
        procedureParams.Add(new StoredProcedureParameter { Name = "@MASTER_CUSTOMER_ID", Value = customerId, Direction = 1 });
        procedureParams.Add(new StoredProcedureParameter { Name = "@SUB_CUSTOMER_ID", Value = subCustomerId, Direction = 1 });

        var request = new StoredProcedureRequest
        {
          StoredProcedureName = "ACR_GET_CUSTOMER_SP",
          IsUserDefinedFunction = false,
          SPParameterList = procedureParams

        };
        var response = SvcClient.Post<StoredProcedureOutput>("GetStoredProcedureDataXML", request);
        if (!string.IsNullOrEmpty(response.Data))
        {
          XDocument xmlDoc = XDocument.Parse(response.Data);
          var objs = from el in xmlDoc.Descendants("NewDataSet").Descendants("Table")
                     select new Member
                     {
                       LabelName = GetValue(el.Element("LabelName")),
                       Email = GetValue(el.Element("PrimaryEmail")),

                     };
          if (objs != null)
          {
            return objs.ToList().FirstOrDefault<Member>();
          }
        }

      }
      catch (Exception ex)
      {
        PersonifyLogger.Logger.Error("Error getting customer info (Email): " + ex.Message, ex);
      }
      return null;
    }

    private static string GetValue(XElement e)
    {
      if (e != null)
        return e.Value;
      return null;
    }
    private static DateTime? ToDateTime(string datetime)
    {
      DateTime d;
      if (DateTime.TryParse(datetime, out d))
      {
        return d;
      }
      return null;
    }
  }

  public static class PersonifyEntitiesACRExtensions
  {
    /// <summary>
    /// Returns the formated unique ID of subsystem and code for the given Application Code.
    /// EX: MTG_ACR (Meeting Subsystem, ACR Product Class)
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public static string GetSitecorePersonifyId(this PdsApplicationCode code)
    {
      if (string.IsNullOrEmpty(code.SubsystemString))
      {
        return code.Code;
      }
      return string.Format("{0}_{1}", code.SubsystemString, code.Code);
    }
  }
  /*
  public class PdsConstants
  {
    public const string TYPE_PRODUCTCLASS = "PRODUCT_CLASS";
    public const string TYPE_PRODUCTTYPE = "PRODUCT_TYPE";
    public const string TYPE_SUBSYSTEM = "SUBSYSTEM";
    public const string TYPE_CUS_SPECIALITY = "CUS_SPECIALTY";
    public const string TYPE_PRODUCT_CATEGORY = "PRODUCT_CATEGORY";
    public const string TYPE_ROLES = "ROLES";
    public const string SUBSYSTEM_STRING_USER = "USR";
    public const string CREDIT_TYPES = "CREDIT";

    public const string SUBCODE_MODALITY = "MODALITY";
    public const string SUBCODE_SUBSPECIALTY = "SUBSPECIALTY";
    public const string SUBCODE_INTERESTS = "INTERESTS";
    public const string SUBCODE_DELIVERY = "DELIVERY";
    public const string SUBCODE_ABRCODE = "ABR_CODE";
    public const string SUBCODE_TOPICS = "OTHER";
  }*/
}
using ACRHelix.Feature.Toolkits.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Toolkits.DAL
{
  public class ToolkitsRepository : IToolkitsRepository
  {
    private ToolkitsContext _context;
    public ToolkitsRepository()
    {
      _context = new ToolkitsContext();
    }

    public IEnumerable<FacetItem> GetFacets()
    {
      var query = "EXEC USR_USP_PFCC_GETFACETS";
      var response = _context.Database.SqlQuery<FacetItem>(query).ToList();
      return response;
    }

    public string ChechCustomerType(string customerId)
    {
      var query = "EXEC [dbo].[USR_ACR_PFCC_CHECK_CUSTOMER_TYPE] @MASTER_CUSTOMER_ID = {0}, @SUB_CUSTOMER_ID = {1} ";
      var response = _context.Database.SqlQuery<int>(query, customerId, 0).FirstOrDefault(); 
      
      if (response == 1)
        return "reviewer";
      else if(response == 2)
        return "admin";

      return "";
    }
    public string CheckMesoCustomerType(string customerId)
    {
      var query = "EXEC [dbo].[USR_ACR_MESO_CHECK_CUSTOMER_TYPE] @MASTER_CUSTOMER_ID = {0}, @SUB_CUSTOMER_ID = {1} ";
      var response = _context.Database.SqlQuery<int>(query, customerId, 0).FirstOrDefault();

      if (response == 1)
        return "reviewer";
      else if (response == 2)
        return "admin";

      return "";
    }
    public IEnumerable<Resource> GetResources(string csetting, string ctype, string rtype, string kword, int sindex, int count)
    {
      var query = "EXEC [dbo].[USR_ACR_PFCC_GET_TOOLS_FOR_GUEST] @CARE_SETTINGS = {0}, @CONTENT_TYPES = {1}, @RESOURCE_TYPES = {2}, @KEYWORDS = {3}, @START_INDEX = {4}, @COUNT = {5} ";
      var response = _context.Database.SqlQuery<Resource>(query, csetting, ctype, rtype, kword, sindex, count).ToList();
      return response;
    }

    public IEnumerable<Resource> GetAdminAreaResources(string csetting, string ctype, string rtype, string kword, string customerId, int sindex, int count)
    {
      var query = "EXEC [dbo].[USR_ACR_PFCC_GET_TOOLS_FOR_ADMIN_AREA] @CARE_SETTINGS = {0}, @CONTENT_TYPES = {1}, @RESOURCE_TYPES = {2}, @KEYWORDS = {3}, @MASTER_CUSTOMER_ID = {4}, @SUB_CUSTOMER_ID = {5}, @START_INDEX = {6}, @COUNT = {7} ";
      var response = _context.Database.SqlQuery<Resource>(query, csetting, ctype, rtype, kword, customerId, 0, sindex, count).ToList();
      return response;
    }

    public bool AddNewResource(ResourceFormData resource)
    {
      var query = "[dbo].[USR_PFCC_FORM_SP] @ID = {0}, @FNAME = {1}, @LNAME = {2}, @EMAIL = {3}, @ADDRESS1 = {4}, "
                  + "@ADDRESS2 = {5}, @CITY = {6}, @STATE = {7}, @POSTALCODE = {8}, @COUNTRY = {9}, " 
                  + "@PHONE_AREA = {10}, @PHONE_NUMBER = {11}, @COMMENTS = {12}, @KEYWORDS = {13}, "
                  + "@ATTACHEMENT_URL = {14}, @FILE_NAME = {15}, @ADDOPER = {16}, @TITLE = {17}, @CARE_SETTINGS = {18}, "
                  + "@CONTENT_TYPE = {19}, @RESOURCE_TYPE = {20}, @DESCRIPTION = {21}, @URL = {22}, "
                  + "@STATUS = {23}, @USER_MASTER_CUSTOMER_ID = {24}, @USER_SUB_CUSTOMER_ID = {25} ";

      var response = _context.Database.ExecuteSqlCommand(query, "0", resource.FirstName, resource.LastName,
                                                          resource.Email, null,null, null, 
                                                          null, null, null, null, null, null, 
                                                          resource.Keyword, resource.AttachementUrl, resource.FileName, "Guest", 
                                                          resource.Title, resource.PracticeSetting, resource.ContentType,
                                                          resource.ResourceType, resource.Description, resource.Url, "HIDE", null, null);

      Sitecore.Diagnostics.Log.Info("-- insert response: " + response, this);
      return true;
    }

    public ReviewFormData GetResourceByID(int toolId, int flag, string customerId)
    {
      _context.Database.Initialize(force: false);

      // Create a SQL command to execute the sproc
      var cmd = _context.Database.Connection.CreateCommand();
      cmd.CommandText = "[dbo].[USR_ACR_PFCC_GET_TOOL_INFO]";
      cmd.CommandType = CommandType.StoredProcedure;

      cmd.Parameters.Add(new SqlParameter("@TOOL_ID", toolId));
      cmd.Parameters.Add(new SqlParameter("@IS_ADMIN", flag));
      cmd.Parameters.Add(new SqlParameter("@USER_MASTER_CUSTOMER_ID", customerId));
      cmd.Parameters.Add(new SqlParameter("@USER_SUB_CUSTOMER_ID", (object)0));

      try
      {
        _context.Database.Connection.Open();

        // Run the sproc
        var reader = cmd.ExecuteReader();
        
        // Read Review data from the first result set
        var reviewData = ((IObjectContextAdapter)_context)
            .ObjectContext
            .Translate<ReviewFormData>(reader).FirstOrDefault(); 

        // Move to second result set and read Practice setting
        reader.NextResult();
        var practiceSetting = ((IObjectContextAdapter)_context)
            .ObjectContext
            .Translate<string>(reader).Single(); 

        var revData = new ReviewFormData();
        revData = reviewData;
        revData.PracticeSetting = practiceSetting;
        return revData;

      }
      catch(Exception ex)
      {
        Sitecore.Diagnostics.Log.Error("-- PFCC error trying to get review form data " + ex.Message, this);
      }
      finally
      {
        _context.Database.Connection.Close();
      }

      //var query = "[dbo].[USR_ACR_PFCC_GET_TOOL_INFO] @TOOL_ID = {0}, @IS_ADMIN = {1}, @USER_MASTER_CUSTOMER_ID = {2}, @USER_SUB_CUSTOMER_ID = {3}";
      //var response = _context.Database.SqlQuery<ReviewFormData>(query, toolId, flag, customerId, 0).FirstOrDefault();
      return null;
    }

    public IEnumerable<Reviewer> GetReviewers()
    {
      var query = "[dbo].[USR_ACR_PFCC_GET_REVIEWERS]";
      var response = _context.Database.SqlQuery<Reviewer>(query).ToList();
      return response;
    }

    public bool SubmitResourceReview(ReviewFormData resource)
    {
      var query = "[dbo].[USR_PFCC_FORM_SP] @ID = {0}, @FNAME = {1}, @LNAME = {2}, @EMAIL = {3}, @ADDRESS1 = {4}, "
                  + "@ADDRESS2 = {5}, @CITY = {6}, @STATE = {7}, @POSTALCODE = {8}, @COUNTRY = {9}, "
                  + "@PHONE_AREA = {10}, @PHONE_NUMBER = {11}, @COMMENTS = {12}, @KEYWORDS = {13}, "
                  + "@ATTACHEMENT_URL = {14}, @FILE_NAME = {15}, @ADDOPER = {16}, @TITLE = {17}, @CARE_SETTINGS = {18}, "
                  + "@CONTENT_TYPE = {19}, @RESOURCE_TYPE = {20}, @DESCRIPTION = {21}, @URL = {22}, "
                  + "@STATUS = {23}, @USER_MASTER_CUSTOMER_ID = {24}, @USER_SUB_CUSTOMER_ID = {25} ";

      var response = _context.Database.ExecuteSqlCommand(query, resource.ToolId, resource.FirstName, resource.LastName,
                                                          resource.Email, resource.Address1, resource.Address2, resource.City,
                                                          resource.State, resource.ZipCode, null, resource.PhoneArea, resource.Phone, resource.Comments,
                                                          resource.Keywords, "", resource.FileName, "Guest", resource.Title, 
                                                          resource.PracticeSetting, resource.ContentType, resource.ResourceType, 
                                                          resource.Description, resource.Url, resource.Status, null, null);

      Sitecore.Diagnostics.Log.Info("-- review response: " + response, this);
      return true;
    }

    public bool SetReviewer(Int64 toolId, string demographicid, string customerId)
    {
      var query = "[dbo].[USR_ACR_PFCC_SET_TOOL_REVIEWER] @TOOL_ID = {0}, @DEMOGRAPHIC_REVIEWER_ID = {1}, " 
                  + "@USER_MASTER_CUSTOMER_ID = {2}, @USER_SUB_CUSTOMER_ID = {3} ";

      var response = _context.Database.ExecuteSqlCommand(query, toolId, demographicid, customerId, 0);

      Sitecore.Diagnostics.Log.Info("-- update reviewer response: " + response, this);
      return true;
    }

    public bool SetStatus(Int64 toolId, string status, string customerId)
    {
      var query = "[dbo].[USR_ACR_PFCC_SET_TOOL_STATUS] @TOOL_ID = {0}, @STATUS = {1}, "
                  + "@MASTER_CUSTOMER_ID = {2}, @SUB_CUSTOMER_ID = {3} ";

      var response = _context.Database.ExecuteSqlCommand(query, toolId, status, customerId, 0);

      Sitecore.Diagnostics.Log.Info("-- update status response: " + response, this);
      return true;
    }

    public IEnumerable<FacetItem> GetMesoFacets()
    {
      var query = "EXEC USR_USP_MESO_GETFACETS";
      var response = _context.Database.SqlQuery<FacetItem>(query).ToList();
      return response;
    }

    public IEnumerable<MesoResource> GetMesoResources(string tgtype, string cktype, string asctype, string rtype, string kword, int sindex, int count)
    {
      var query = "EXEC [dbo].[USR_ACR_MESO_GET_TOOLS_FOR_GUEST] @TARGET_GROUP_SETTINGS = {0}, @CORE_KNOWLEDGE_SETTINGS = {1}, @ANATOMY_SUBCATEGORY_SETTINGS = {2}, @RESOURCE_TYPES = {3}, @KEYWORDS = {4}, @START_INDEX = {5}, @COUNT = {6} ";
      var response = _context.Database.SqlQuery<MesoResource>(query, tgtype, cktype, asctype, rtype, kword, sindex, count).ToList();
      return response;
    }

    public IEnumerable<MesoResource> GetAdminAreaMesoResources(string tgtype, string cktype, string asctype, string rtype, string kword, string customerId, int sindex, int count)
    {
      var query = "EXEC [dbo].[USR_ACR_MESO_GET_TOOLS_FOR_ADMIN_AREA] @TARGET_GROUP_SETTINGS = {0}, @CORE_KNOWLEDGE_SETTINGS = {1}, @ANATOMY_SUBCATEGORY_SETTINGS = {2}, @RESOURCE_TYPES = {3}, @KEYWORDS = {4}, @MASTER_CUSTOMER_ID = {5}, @SUB_CUSTOMER_ID = {6}, @START_INDEX = {7}, @COUNT = {8} ";
      var response = _context.Database.SqlQuery<MesoResource>(query, tgtype, cktype, asctype, rtype, kword, customerId, 0, sindex, count).ToList();
      return response;
    }

    public bool AddNewMesoData(MesoFormData data)
    {
      var query = "[dbo].[USR_MESO_FORM_SP] @ID = {0}, @FNAME = {1}, @LNAME = {2}, @EMAIL = {3}, @ADDRESS1 = {4}, "
                  + "@ADDRESS2 = {5}, @CITY = {6}, @STATE = {7}, @POSTALCODE = {8}, @COUNTRY = {9}, "
                  + "@PHONE_AREA = {10}, @PHONE_NUMBER = {11}, @COMMENTS = {12}, @KEYWORDS = {13}, "
                  + "@ATTACHEMENT_URL = {14}, @FILE_NAME = {15}, @ADDOPER = {16}, @TITLE = {17}, @CARE_SETTINGS = {18}, "
                  + "@CONTENT_TYPE = {19}, @RESOURCE_TYPE = {20}, @DESCRIPTION = {21}, @URL = {22}, "
                  + "@STATUS = {23}, @USER_MASTER_CUSTOMER_ID = {24}, @USER_SUB_CUSTOMER_ID = {25}, @RESOURCE_FORMAT = {26} ";

      var response = _context.Database.ExecuteSqlCommand(query, "0", data.FirstName, data.LastName,
                                                          data.Email, null, null, null, null, null, null, null, null, null, 
                                                          data.Keyword, data.AttachementUrl, data.FileName, "Guest",
                                                          data.Title, data.TargetAudience, data.CoreKnowledge,
                                                          data.AnatomySubcategory, data.Description, data.Url, "HIDE", null, null, data.ResourceType);

      Sitecore.Diagnostics.Log.Info("-- MESO insert data response: " + response, this);
      return true;
    }

    public MesoReviewFormData GetMesoResourceByID(int toolId, int flag, string customerId)
    {
      _context.Database.Initialize(force: false);

      // Create a SQL command to execute the sproc
      var cmd = _context.Database.Connection.CreateCommand();
      cmd.CommandText = "[dbo].[USR_ACR_MESO_GET_TOOL_INFO]";
      cmd.CommandType = CommandType.StoredProcedure;

      cmd.Parameters.Add(new SqlParameter("@TOOL_ID", toolId));
      cmd.Parameters.Add(new SqlParameter("@IS_ADMIN", flag));
      cmd.Parameters.Add(new SqlParameter("@USER_MASTER_CUSTOMER_ID", customerId));
      cmd.Parameters.Add(new SqlParameter("@USER_SUB_CUSTOMER_ID", (object)0));

      try
      {
        _context.Database.Connection.Open();

        // Run the sproc
        var reader = cmd.ExecuteReader();

        // Read Review data from the first result set
        var reviewData = ((IObjectContextAdapter)_context)
            .ObjectContext
            .Translate<MesoReviewFormData>(reader).FirstOrDefault();

        // Move to second result set and read Practice setting
        reader.NextResult();
        var practiceSetting = ((IObjectContextAdapter)_context)
            .ObjectContext
            .Translate<string>(reader).Single();

        var revData = new MesoReviewFormData();
        revData = reviewData;
        revData.PracticeSetting = practiceSetting;
        return revData;

      }
      catch (Exception ex)
      {
        Sitecore.Diagnostics.Log.Error("-- MESO error trying to get review form data " + ex.Message, this);
      }
      finally
      {
        _context.Database.Connection.Close();
      }
      return null;
    }

    public IEnumerable<Reviewer> GetMesoReviewers()
    {
      var query = "[dbo].[USR_ACR_MESO_GET_REVIEWERS]";
      var response = _context.Database.SqlQuery<Reviewer>(query).ToList();
      return response;
    }
    public bool SetMesoReviewer(Int64 toolId, string demographicid, string customerId)
    {
      var query = "[dbo].[USR_ACR_MESO_SET_TOOL_REVIEWER] @TOOL_ID = {0}, @DEMOGRAPHIC_REVIEWER_ID = {1}, "
                  + "@USER_MASTER_CUSTOMER_ID = {2}, @USER_SUB_CUSTOMER_ID = {3} ";

      var response = _context.Database.ExecuteSqlCommand(query, toolId, demographicid, customerId, 0);

      Sitecore.Diagnostics.Log.Info("-- update reviewer response: " + response, this);
      return true;
    }

    public bool SetMesoStatus(Int64 toolId, string status, string customerId)
    {
      var query = "[dbo].[USR_ACR_MESO_SET_TOOL_STATUS] @TOOL_ID = {0}, @STATUS = {1}, "
                  + "@MASTER_CUSTOMER_ID = {2}, @SUB_CUSTOMER_ID = {3} ";

      var response = _context.Database.ExecuteSqlCommand(query, toolId, status, customerId, 0);

      Sitecore.Diagnostics.Log.Info("-- update status response: " + response, this);
      return true;
    }

    public bool SubmitMesoResourceReview(MesoReviewFormData resource)
    {
      var query = "[dbo].[USR_MESO_FORM_SP] @ID = {0}, @FNAME = {1}, @LNAME = {2}, @EMAIL = {3}, @ADDRESS1 = {4}, "
                  + "@ADDRESS2 = {5}, @CITY = {6}, @STATE = {7}, @POSTALCODE = {8}, @COUNTRY = {9}, "
                  + "@PHONE_AREA = {10}, @PHONE_NUMBER = {11}, @COMMENTS = {12}, @KEYWORDS = {13}, "
                  + "@ATTACHEMENT_URL = {14}, @FILE_NAME = {15}, @ADDOPER = {16}, @TITLE = {17}, @CARE_SETTINGS = {18}, "
                  + "@CONTENT_TYPE = {19}, @RESOURCE_TYPE = {20}, @DESCRIPTION = {21}, @URL = {22}, "
                  + "@STATUS = {23}, @USER_MASTER_CUSTOMER_ID = {24}, @USER_SUB_CUSTOMER_ID = {25}, @RESOURCE_FORMAT = {26} ";

      var response = _context.Database.ExecuteSqlCommand(query, resource.ToolId, resource.FirstName, resource.LastName,
                                                          resource.Email, resource.Address1, resource.Address2, resource.City,
                                                          resource.State, resource.ZipCode, null, resource.PhoneArea, resource.Phone, null,
                                                          resource.Keywords, "", resource.FileName, "Guest", resource.Title,
                                                          resource.PracticeSetting, resource.ContentType, resource.ResourceType,
                                                          resource.Description, resource.Url, resource.Status, null, null, resource.ResourceFormat);

      Sitecore.Diagnostics.Log.Info("-- MESO review response: " + response, this);
      return true;
    }

    private bool disposed = false;
    protected virtual void Dispose(bool disposing)
    {
      if (!this.disposed)
      {
        if (disposing)
        {
          _context.Dispose();
        }
      }
      this.disposed = true;
    }
    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

  }
}
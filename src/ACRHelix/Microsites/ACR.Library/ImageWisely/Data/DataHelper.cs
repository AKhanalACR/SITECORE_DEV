using ACR.Library.Common;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Components;
using ACR.Library.Reference;
using Common.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;


namespace ACR.Library.ImageWisely.Data
{
  public static class DataHelper
  {
    private static ILog _logger;

    private static ILog Logger
    {
      get
      {
        _logger = _logger ?? LogManager.GetLogger(typeof(DataHelper));
        return _logger;
      }
    }

    private const string ConnectionStringName = "ACR.Library.Properties.Settings.ACR_WebsiteFormSubmissionsConnectionString";

    private static string ConvertToCsv(DataTable dataTableToExport)
    {
      Deliminator deliminator = new Deliminator(",");

      String csv = deliminator.Deliminate(dataTableToExport);

      return csv;
    }

    private static DataTable LinqToDataTable<T>(IEnumerable<T> varlist)
    {
      DataTable dtReturn = new DataTable();
      // column names 
      PropertyInfo[] oProps = null;
      if (varlist == null) return dtReturn;

      foreach (T rec in varlist)
      {
        // Use reflection to get property names, to create table, Only first time, others will follow 
        if (oProps == null)
        {
          oProps = ((Type)rec.GetType()).GetProperties();
          foreach (PropertyInfo pi in oProps)
          {
            Type colType = pi.PropertyType;

            if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
            {
              colType = colType.GetGenericArguments()[0];
            }
            if (colType == typeof(DateTime))
              colType = typeof(String);
            dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
          }
        }

        DataRow dr = dtReturn.NewRow();

        foreach (PropertyInfo pi in oProps)
        {
          if (pi.PropertyType == typeof(DateTime))
          {
            try
            {
              DateTime dttm = Convert.ToDateTime(pi.GetValue(rec, null));
              dr[pi.Name] = dttm.ToShortDateString() + " " + dttm.ToString("hh:mm tt");
            }
            catch
            {
              dr[pi.Name] = String.Empty;
            }
          }
          else
          {
            dr[pi.Name] = pi.GetValue(rec, null) ?? DBNull.Value;
          }

        }

        dtReturn.Rows.Add(dr);
      }
      return dtReturn;
    }

    public static DataTable ToDataTable<T>(List<T> data)
    {
      PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
      DataTable table = new DataTable();
      int propCount = props.Count - 6; //clearing out sitecore only properties
      for (int i = 0; i < propCount; i++)
      {
        PropertyDescriptor prop = props[i];
        table.Columns.Add(prop.Name, prop.PropertyType);
      }
      object[] values = new object[propCount];
      foreach (T item in data)
      {
        for (int i = 0; i < values.Length; i++)
        {
          values[i] = props[i].GetValue(item);
        }
        table.Rows.Add(values);
      }
      return table;
    }

    public static string GetPledgeSubmissions()
    {
      DataTable dataTableToExport;
      Logger.Info("Start getting Pledge Submissions");
      try
      {
        using (PledgeSubmissionsDataContext db = new PledgeSubmissionsDataContext())
        {
          Logger.Info("Data Context connection string: " + db.Connection.ConnectionString);
          var results = from p in db.PledgeSubmissions
                        select new
                        {
                          p.ID,
                          p.First_Name,
                          p.Last_Name,
                          p.Email,
                          p.Profession_Role,
                          p.Primary_Institution,
                          p.Country_of_Practice,
                          p.Primary_Practice_Type,
                          p.How_Learned_About_Image_Wisely,
                          p.Contact_With_Updates,
                          p.Participate_in_Follow_Up_Survey,
                          p.SubmissionEmailedTo,
                          p.TimeSubmitted,
                          p.Status
                        };
          dataTableToExport = LinqToDataTable(results);
        }
      }
      catch (Exception ex)
      {
        Logger.Error("Could not get PledgeSubmissionsDataContext, or the table PledgeSubmissions from that context.", ex);
        return "";
      }
      Logger.Info("End getting Pledge Submissions");
      return ConvertToCsv(dataTableToExport);
    }

    public static string GetReferringPractitionerPledgeSubmissions()
    {
      DataTable dataTableToExport;
      Logger.Info("Start getting Referring Practitioner Pledge Submissions");
      try
      {
        using (PledgeSubmissionsDataContext db = new PledgeSubmissionsDataContext())
        {
          Logger.Info("Data Context connection string: " + db.Connection.ConnectionString);
          var results = from p in db.ReferringPractitionerPledgeSubmissions
                        select new
                        {
                          p.ID,
                          p.First_Name,
                          p.Last_Name,
                          p.Email,
                          p.Profession_Role,
                          p.Primary_Institution,
                          p.Country_of_Practice,
                          p.Primary_Practice_Type,
                          p.How_Learned_About_Image_Wisely,
                          p.Contact_With_Updates,
                          p.Participate_in_Follow_Up_Survey,
                          p.SubmissionEmailedTo,
                          p.TimeSubmitted,
                          p.Status
                        };
          dataTableToExport = LinqToDataTable(results);
        }
      }
      catch (Exception ex)
      {
        Logger.Error("Could not get PledgeSubmissionsDataContext, or the table ReferringPractitionerPledgeSubmissions from that context.", ex);
        return "";
      }
      Logger.Info("End getting Referring Practitioner Pledge Submissions");
      return ConvertToCsv(dataTableToExport);
    }

    public static string GetAssociationPledgeSubmissions()
    {
      DataTable dataTableToExport;
      Logger.Info("Start getting Association Pledge Submissions");
      try
      {
        using (PledgeSubmissionsDataContext db = new PledgeSubmissionsDataContext())
        {
          Logger.Info("Data Context connection string: " + db.Connection.ConnectionString);
          var results = from p in db.AssociationPledgeSubmissions
                        select new
                        {
                          p.ID,
                          p.Association,
                          p.City,
                          p.State,
                          p.Country,
                          p.First_Name,
                          p.Last_Name,
                          p.Title,
                          p.Email,
                          p.TimeSubmitted,
                          p.SubmissionEmailedTo,
                          p.Status
                        };
          dataTableToExport = LinqToDataTable(results);
        }
      }
      catch (Exception ex)
      {
        Logger.Error("Could not get PledgeSubmissionsDataContext, or the table AssociationPledgeSubmissions from that context.", ex);
        return "";
      }
      Logger.Info("End getting Association Pledge Submissions");
      return ConvertToCsv(dataTableToExport);
    }

    public static string GetFacilityPledgeSubmissions()
    {
      DataTable dataTableToExport;
      Logger.Info("Start getting Facility Pledge Submissions");
      try
      {
        using (PledgeSubmissionsDataContext db = new PledgeSubmissionsDataContext())
        {
          Logger.Info("Data Context connection string: " + db.Connection.ConnectionString);
          var results = from p in db.FacilityPledgeSubmissions
                        select new
                        {
                          p.ID,
                          p.Facility,
                          p.City,
                          p.State,
                          p.Country,
                          p.First_Name,
                          p.Last_Name,
                          p.Title,
                          p.Email,
                          p.TimeSubmitted,
                          p.SubmissionEmailedTo,
                          p.Status,
                          p.Level1,
                          p.Level2,
                          p.Level3
                        };
          dataTableToExport = LinqToDataTable(results);
        }
      }
      catch (Exception ex)
      {
        Logger.Error("Could not get PledgeSubmissionsDataContext, or the table FacilityPledgeSubmissions from that context.", ex);
        return "";
      }
      Logger.Info("End getting Facility Pledge Submissions");
      return ConvertToCsv(dataTableToExport);
    }

    public static IList<Pledge> GetAssociationHonorRollPledges()
    {
      using (PledgeSubmissionsDataContext db = new PledgeSubmissionsDataContext())
      {
        //Modified by addis on 01/02/2017
        var assocPledges = from p in db.AssociationPledgeSubmissions
                           where p.DisplayOnHonorRoll == 1 && p.TimeSubmitted.Year == DateTime.Now.Year
                           orderby p.Association
                           select MapAssociationToPledge(p);
        return assocPledges.ToList();
      }

    }

    private static Pledge MapAssociationToPledge(AssociationPledgeSubmission assocPledge)
    {
      Pledge pledge = new Pledge();
      if (assocPledge != null)
      {
        pledge.Institution = assocPledge.Association;
        pledge.City = assocPledge.City;
        pledge.StateProvince = assocPledge.State;
        pledge.Country = assocPledge.Country;
        pledge.FirstName = assocPledge.First_Name;
        pledge.LastName = assocPledge.Last_Name;
        pledge.Profession = assocPledge.Title;
        pledge.EmailAddress = assocPledge.Email;
        pledge.DisplayOnHonorRoll = assocPledge.DisplayOnHonorRoll;
        pledge.TimeSubmitted = assocPledge.TimeSubmitted;
      }
      return pledge;
    }

    public static IList<Pledge> GetFacilityHonorRollPledges()
    {
      using (PledgeSubmissionsDataContext db = new PledgeSubmissionsDataContext())
      {
        var facilityPledges = from p in db.FacilityPledgeSubmissions
                              where p.DisplayOnHonorRoll == 1
                              orderby p.Facility
                              select MapFacilityToPledge(p);
        return facilityPledges.ToList();

      }

    }

    private static Pledge MapFacilityToPledge(FacilityPledgeSubmission facilityPledge)
    {
      Pledge pledge = new Pledge();
      if (facilityPledge != null)
      {
        pledge.Institution = facilityPledge.Facility;
        pledge.City = facilityPledge.City;
        pledge.StateProvince = facilityPledge.State;
        pledge.Country = facilityPledge.Country;
        pledge.FirstName = facilityPledge.First_Name;
        pledge.LastName = facilityPledge.Last_Name;
        pledge.Profession = facilityPledge.Title;
        pledge.EmailAddress = facilityPledge.Email;

        #region changes made by Navamani

        if (facilityPledge.Level1 != null)
        {
          pledge.Level1 = (byte)facilityPledge.Level1;
        }
        else
        {
          pledge.Level1 = 0;
        }

        if (facilityPledge.Level2 != null)
        {
          pledge.Level2 = (byte)facilityPledge.Level2;
        }
        else
        {
          pledge.Level2 = 0;
        }

        if (facilityPledge.Level3 != null)
        {
          pledge.Level3 = (byte)facilityPledge.Level3;
        }
        else
        {
          pledge.Level3 = 0;
        }

        #endregion
        pledge.DisplayOnHonorRoll = facilityPledge.DisplayOnHonorRoll;
        pledge.TimeSubmitted = facilityPledge.TimeSubmitted;
      }
      return pledge;
    }

    public static int GetPledgeCount()
    {
      Logger.Info("Start getting Pledge Count");
      int pledgeCount = 0;
      try
      {
        using (PledgeSubmissionsDataContext db = new PledgeSubmissionsDataContext())
        {
          Logger.Info("Data Context connection string: " + db.Connection.ConnectionString);
          //pledgeCount = db.PledgeSubmissions.Count();

          //added by Addis on 12/02/2016
          pledgeCount = db.PledgeSubmissions.Where(p => p.TimeSubmitted.Year == DateTime.Now.Year).Count();
        }
      }
      catch (Exception ex)
      {
        Logger.Error("Could not get PledgeSubmissionsDataContext, or the table PledgeSubmissions from that context.", ex);
        return 0;
      }
      Logger.Info("End getting Pledge Count");
      return pledgeCount;
    }


    public static List<InternationalFacility> GetInternationalFacilityHonorRoll(int year)
    {
      string internationalFacilityHonorRollQuery = "Select Country, City, Facility from FacilityPledgeSubmissions where DATEPART(yy,TimeSubmitted) = {0} and Country != 'United States' and DisplayOnHonorRoll = 1 order by Country, City";
      if (year == 0)
      {
        internationalFacilityHonorRollQuery = string.Format(internationalFacilityHonorRollQuery, DateTime.Now.Year);
      }
      else
      {
        internationalFacilityHonorRollQuery = string.Format(internationalFacilityHonorRollQuery, year);
      }

      List<InternationalFacility> facilities = new List<InternationalFacility>();

      var connString = System.Configuration.ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;

      if (!string.IsNullOrWhiteSpace(connString))
      {

        using (SqlConnection conn = new SqlConnection(connString))
        {
          SqlCommand command = new SqlCommand(internationalFacilityHonorRollQuery, conn);
          conn.Open();

          SqlDataReader reader = command.ExecuteReader();

          if (reader.HasRows)
          {
            var ordinals = new
            {
              Facility = reader.GetOrdinal("Facility"),
              Country = reader.GetOrdinal("Country"),
              City = reader.GetOrdinal("City")
            };

            while (reader.Read())
            {
              facilities.Add(new InternationalFacility()
              {
                //get all lowercase so we can match and sort accordingly
                Facility = reader.GetString(ordinals.Facility).ToLower(),
                City = reader.GetString(ordinals.City).ToLower(),
                Country = reader.GetString(ordinals.Country).ToLower()
              });
            }
          }
          reader.Close();
        }
      }
      else
      {
        Logger.Error(string.Format("Connection string does not exist for {0}", ConnectionStringName));
      }

      return facilities;




    }

    public static bool IsDuplicateSubmission(string emailAddr, PledgeTypeItem pledgeTypeItem)
    {
      string typeId = pledgeTypeItem.ID.ToString();
      using (PledgeSubmissionsDataContext db = new PledgeSubmissionsDataContext())
      {
        if (ItemReference.IW_Global_PledgeFormType_Association != null &&
            typeId == ItemReference.IW_Global_PledgeFormType_Association.Guid)
        {
          //Association table
          AssociationPledgeSubmission pledgeSubmission =
          db.AssociationPledgeSubmissions.Where(p => p.Email == emailAddr).FirstOrDefault();
          return (pledgeSubmission != null);
        }
        else if (ItemReference.IW_Global_PledgeFormType_Facility != null &&
                 typeId == ItemReference.IW_Global_PledgeFormType_Facility.Guid)
        {
          //Facility
          FacilityPledgeSubmission pledgeSubmission =
          db.FacilityPledgeSubmissions.Where(p => p.Email == emailAddr).FirstOrDefault();
          return (pledgeSubmission != null);
        }
        else if (ItemReference.IW_Global_PledgeFormType_ReferringProvider != null &&
                 typeId == ItemReference.IW_Global_PledgeFormType_ReferringProvider.Guid)
        {
          //Referring Provider/Practitioner - added by Addis on 12/02/2016
          ReferringPractitionerPledgeSubmission pledgeSubmission =
          db.ReferringPractitionerPledgeSubmissions.Where(p => p.Email == emailAddr && p.TimeSubmitted.Year == DateTime.Now.Year).FirstOrDefault();
          return (pledgeSubmission != null);

          //ReferringPractitionerPledgeSubmission pledgeSubmission =
          //db.ReferringPractitionerPledgeSubmissions.Where(p => p.Email == emailAddr).FirstOrDefault();
          //return (pledgeSubmission != null);
        }
        else
        {
          //Imaging Professional - added by Addis on 12/02/2016
          PledgeSubmission pledgeSubmission =
          db.PledgeSubmissions.Where(p => p.Email == emailAddr && p.TimeSubmitted.Year == DateTime.Now.Year).FirstOrDefault();
          return (pledgeSubmission != null);

          //PledgeSubmission pledgeSubmission =
          //db.PledgeSubmissions.Where(p => p.Email == emailAddr).FirstOrDefault();
          //return (pledgeSubmission != null);
        }


      }
    }

    public static int GetImagingProfessionalsPledgeCount()
    {
      int count = 0;
      Logger.Info("Start getting Imageing Professionals Pledge count");
      try
      {
        using (PledgeSubmissionsDataContext db = new PledgeSubmissionsDataContext())
        {
          Logger.Info("Data Context connection string: " + db.Connection.ConnectionString);
          var result = (from p in db.PledgeSubmissions
                        where p.TimeSubmitted.Year == DateTime.Today.Year
                        select p).Count();
          count = result;
        }
      }
      catch (Exception ex)
      {
        Logger.Error("Could not get PledgeSubmissionsDataContext, or the table PledgeSubmissions from that context.", ex);
        return 0;
      }
      Logger.Info("End getting Imaging Professionals Pledge Count");
      return count;
    }

    public static int GetReferingPractitionersPledgeCount()
    {
      int count = 0;
      Logger.Info("Start getting Referring Practitioners Pledge count");
      try
      {
        using (PledgeSubmissionsDataContext db = new PledgeSubmissionsDataContext())
        {
          Logger.Info("Data Context connection string: " + db.Connection.ConnectionString);
          var result = (from p in db.ReferringPractitionerPledgeSubmissions
                        where p.TimeSubmitted.Year == DateTime.Today.Year
                        select p).Count();
          count = result;
        }
      }
      catch (Exception ex)
      {
        Logger.Error("Could not get PledgeSubmissionsDataContext, or the table ReferringPractitionerPledgeSubmissions from that context.", ex);
        return 0;
      }
      Logger.Info("End getting Referring Practitioners Pledge Count");
      return count;
    }

    public static int GetFacilitiesPledgeCount()
    {
      int count = 0;
      Logger.Info("Start getting Facilities Pledge count");
      try
      {
        using (PledgeSubmissionsDataContext db = new PledgeSubmissionsDataContext())
        {
          Logger.Info("Data Context connection string: " + db.Connection.ConnectionString);
          var result = (from p in db.FacilityPledgeSubmissions
                        where p.TimeSubmitted.Year == DateTime.Today.Year
                        select p).Count();
          count = result;
        }
      }
      catch (Exception ex)
      {
        Logger.Error("Could not get PledgeSubmissionsDataContext, or the table FacilitiesPledgeSubmissions from that context.", ex);
        return 0;
      }
      Logger.Info("End getting Facilities Pledge Count");
      return count;
    }

    public static int GetAssociationPledgeCount()
    {
      int count = 0;
      Logger.Info("Start getting Facilities Pledge count");
      try
      {
        using (PledgeSubmissionsDataContext db = new PledgeSubmissionsDataContext())
        {
          Logger.Info("Data Context connection string: " + db.Connection.ConnectionString);
          var result = (from p in db.AssociationPledgeSubmissions
                        where p.TimeSubmitted.Year == DateTime.Today.Year
                        select p).Count();
          count = result;
        }
      }
      catch (Exception ex)
      {
        Logger.Error("Could not get PledgeSubmissionsDataContext, or the table AssociationsPledgeSubmissions from that context.", ex);
        return 0;
      }
      Logger.Info("End getting Associations Pledge Count");
      return count;
    }

    public static IList<PledgeCount> GetFacilityHonorRollPledgesCountByState()
    {
      using (PledgeSubmissionsDataContext db = new PledgeSubmissionsDataContext())
      {
        var facilityPledges = from p in db.FacilityPledgeSubmissions
                              where p.DisplayOnHonorRoll == 1 && p.TimeSubmitted.Year == DateTime.Now.Year && p.State != null
                              group p by p.State into g
                              select new PledgeCount
                              {
                                State = g.Key,
                                Count = g.Count()
                              };
        return facilityPledges.ToList();

      }

    }

    public static IList<PledgeCount> GetAssociationHonorRollPledgesCountByState()
    {
      using (PledgeSubmissionsDataContext db = new PledgeSubmissionsDataContext())
      {
        var facilityPledges = from p in db.AssociationPledgeSubmissions
                              where p.DisplayOnHonorRoll == 1 && p.TimeSubmitted.Year == DateTime.Now.Year && p.State != null
                              group p by p.State into g
                              select new PledgeCount
                              {
                                State = g.Key,
                                Count = g.Count()
                              };
        return facilityPledges.ToList();

      }

    }

    public static IList<Pledge> GetFacilitiesHonorRollPledges(string state)
    {
      using (PledgeSubmissionsDataContext db = new PledgeSubmissionsDataContext())
      {
        var facilityPledges = from p in db.FacilityPledgeSubmissions
                              where p.DisplayOnHonorRoll == 1 && p.TimeSubmitted.Year == DateTime.Now.Year && p.State == state
                              orderby p.Facility
                              select MapFacilityToPledge(p);
        return facilityPledges.ToList();

      }

    }

    public static IList<Pledge> GetAssociationsHonorRollPledges(string state)
    {
      using (PledgeSubmissionsDataContext db = new PledgeSubmissionsDataContext())
      {
        var facilityPledges = from p in db.AssociationPledgeSubmissions
                              where p.DisplayOnHonorRoll == 1 && p.TimeSubmitted.Year == DateTime.Now.Year && p.State == state
                              orderby p.Association
                              select MapAssociationToPledge(p);
        return facilityPledges.ToList();

      }

    }
  }
}

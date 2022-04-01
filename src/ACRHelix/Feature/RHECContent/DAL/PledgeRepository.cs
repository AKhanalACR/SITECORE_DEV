//using ACRHelix.Feature.Toolkits.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.RhecContent.DAL
{
  public class PledgeRepository : IPledgeRepository
  {
    private PledgeContext _context;
    public PledgeRepository()
    {
      _context = new PledgeContext();
    }

    /// <summary>
    /// To call stored procedure to check if email submitted already exists in Database for individual pledge
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public bool IsDuplicate(string email)
    {
      try { 
      var query = "DECLARE	@return_value int EXEC @return_value = [dbo].[RhecPledgeDuplicatesCheck] @Email = {0} SELECT 'Return Value' = @return_value";
      var response = _context.Database.SqlQuery<int>(query, email).FirstOrDefault(); ; 
      
      if (response > 0)
        return true;      

      return false;
      }
      catch(Exception ex)
      {
        Sitecore.Diagnostics.Log.Info("Rhec check duplicate error" + ex + "email:" + email, this);
        return true;
      }
    }
    /// <summary>
    /// To call stored procedure to get number of pledges submitted from database afer given date.
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public int PledgesCount(string date)
    {
      try { 
      var query = "DECLARE	@return_value int EXEC	@return_value = [dbo].[RhecPledgeCount] @Date = {0} SELECT	'Return Value' = @return_value";
      var response = _context.Database.SqlQuery<int>(query, date).FirstOrDefault();      
      return response;
      }
      catch(Exception ex)
      {
        Sitecore.Diagnostics.Log.Info("Rhec get pledge error" + ex + "date:"+ date, this);
        return 0;
      }
    }
    /// <summary>
    /// To call stored procedure to save Individual pledge form submitted data in database.
    /// </summary>
    public bool CreateIndividualPledge(string firstName,string lastName,string email, string country,string emailedTo)
    {
      try { 
      var query = "DECLARE	@return_value int EXEC	@return_value = [dbo].[AddRhecIndividualPledge] @First_Name = {0},@Last_Name ={1},@Email = {2},@Country = {3},@SubmissionEmailedTo = {4} SELECT 'Return Value' = @return_value";
      var response = _context.Database.SqlQuery<int>(query, firstName,lastName,email,country,emailedTo).FirstOrDefault();      if(response==0) 
      return true;
       return false;
      }
      catch(Exception ex)
      {
        Sitecore.Diagnostics.Log.Info("Rhec individual pledge submit to database error" + ex +"REsponse:"+ firstName + " " + lastName + " " + email+country + " " + emailedTo, this);
        return false;
      }
    }
    /// <summary>
    /// To call stored procedure to save Facility pledge form submitted data in database.
    /// </summary>
    public bool CreateFacilityPledge(string facilityName, string city, string country, string state, string zipCode, string firstName, string lastName, string email, string emailedTo)
    {
      try { 
      var query = "DECLARE	@return_value int EXEC @return_value = [dbo].[AddRhecFacilityPledge] @Facility_Name = {0},@City = {1},@Country = {2},@State = {3},@Zip_Code = {4},@First_Name = {5},@Last_Name = {6},@Email = {7},@SubmissionEmailedTo = {8} SELECT 'Return Value' = @return_value";
      var response = _context.Database.SqlQuery<int>(query,  facilityName,  city,  country,  state,  zipCode, firstName, lastName, email, emailedTo).FirstOrDefault();
        if (response == 0)
          return true;
        return false;
      }
      catch (Exception ex)
      {
        Sitecore.Diagnostics.Log.Info("Rhec facility pledge submit to database error" + ex + "REsponse:" + facilityName + " " + city + " " + country + " " + state + " " + zipCode + " " + firstName + " " + lastName + " " + email + " " + emailedTo, this);
        return false;
      }
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
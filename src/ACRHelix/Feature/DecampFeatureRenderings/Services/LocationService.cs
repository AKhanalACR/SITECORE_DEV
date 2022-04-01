using ACRHelix.Feature.DecampFeatureRenderings.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.IO;

namespace ACRHelix.Feature.DecampFeatureRenderings.Services
{
    public class LocationService
    {
        public IEnumerable<Location> GetLocations()
        {
            List<Location> locationList = new List<Location>();
            Sitecore.Diagnostics.Log.Info("--- Decamp service GetLocations: ", "");
            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"Get_All_Decamp_Locations";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;  
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        Location l = new Location();
                        l.Load(reader);
                        locationList.Add(l);
                    }
                    //Sitecore.Diagnostics.Log.Info("--- Decamp service GetLocations first item name: " + locationList.Count, "");
                }
            }
            return locationList;
        }
  
    }

    class DB
    {
        public static string ConnectionString
        {
            get
            {
                string connStr = ConfigurationManager.ConnectionStrings["ACR_APP_DATA_Entities_2"].ConnectionString;
                SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(connStr);
                sb.ApplicationName = ApplicationName ?? sb.ApplicationName;
                sb.ConnectTimeout = (ConnectionTimeout > 0) ? ConnectionTimeout : sb.ConnectTimeout;
                return sb.ToString();
            }
        }
        
        public static SqlConnection GetSqlConnection()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }
        
        public static int ConnectionTimeout { get; set; }
        
        public static string ApplicationName { get; set; }
    }
}
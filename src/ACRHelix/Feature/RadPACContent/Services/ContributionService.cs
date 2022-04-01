
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.IO;

namespace ACRHelix.Feature.RadPACContent.Services
{
    public class ContributionService
    {
        public Contribution GetStateContribution(string state, string month, string year)
        {
            Contribution stateCont = new Contribution();
            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"Get_RadPAC_State_Contribution";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@State", state);
                    cmd.Parameters.AddWithValue("@Month", month);
                    cmd.Parameters.AddWithValue("@Year", year);

                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        Contribution c = new Contribution();
                        c.Load(reader);
                        stateCont = c;
                    }                   
                }
            }
            return stateCont;
        }

        public IEnumerable<string> GetStateHighContributors(string state, string year)
        {
            List<string> contList = new List<string>();
            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"Get_RadPAC_State_Contributors";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@State", state);
                    cmd.Parameters.AddWithValue("@Year", year);

                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        Contributor c = new Contributor();
                        c.Load(reader);
                        contList.Add(c.LabelName);
                    }
                }
            }
            return contList;
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

    public class Contribution
    {
        
        public string Ranked { get; set; }
               
        public string MonthsContribution { get; set; }
                
        public string YearsTotal { get; set; }
        
        public void Load(SqlDataReader reader)
        {
            Ranked = reader["Rank"].ToString();
            MonthsContribution = reader["Months_Total"].ToString();
            YearsTotal = reader["Years_Total"].ToString();
        }
    }

    public class Contributor
    {

        public string LabelName { get; set; }

        public void Load(SqlDataReader reader)
        {
            LabelName = reader["Label Name"].ToString();
        }
    }
}
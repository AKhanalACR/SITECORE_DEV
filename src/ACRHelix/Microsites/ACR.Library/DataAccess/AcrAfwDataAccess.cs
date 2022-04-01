using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ACR.Library.DataContexts;
using ACR.Library.DataContext;

namespace ACR.Library.DataAccess
{
  public static class AcrAfwDataAccess
  {
    private static string ConnectionString
    {
      get
      {
        using (ACR_APP_DATA_Entities db = new ACR_APP_DATA_Entities())
        {
          return db.Database.Connection.ConnectionString;
        }
      }
    }

    public static DataTable ExecuteProcedure(string storedProcedureName, List<SqlParameter> paramList)
    {
      DataTable dt = new DataTable();

      // Open the connection 

      using (SqlConnection cnn = new SqlConnection(ConnectionString))
      {
        cnn.Open();

        // Define the command 
        using (SqlCommand cmd = new SqlCommand())
        {
          cmd.Connection = cnn;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandText = storedProcedureName;

          // Handle the parameters 
          if (paramList != null)
          {
            foreach (SqlParameter param in paramList)
              cmd.Parameters.Add(param);
          }

          // Define the data adapter and fill the dataset 
          using (SqlDataAdapter da = new SqlDataAdapter(cmd))
          {
            da.Fill(dt);
          }
        }
      }
      return dt;
    }
  }
}

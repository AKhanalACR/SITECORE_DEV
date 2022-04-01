using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ACR.Library.Ideas.Data;

namespace ACR.Library.DataAccess
{
    public static class IdeasDataAccess
    {
        
        public static List<FacilitiesAndPhysicianDB> GetMapData(string connection)
        {
            try
            {
                var context = new IdeasDataEntities(connection);
                var data = context.GetFacilitiesAndPhysician().ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static List<FacilitiesAndPhysicianByZipCodeDB> GetMapByZipData(string connection, string latitude, string longitude, string ZipCode, string Miles, string Type)
        {
            try
            {
                var context = new IdeasDataEntities(connection);
                var data = context.GetFacilitiesAndPhysicianByZipCode(latitude, longitude, ZipCode, Miles, Type).ToList();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

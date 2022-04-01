using ACRHelix.Feature.MyCtColonography.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace ACRHelix.Feature.MyCtColonography.Services
{
    public class LocationService
    {
        public IEnumerable<Location> GetLocations(string lat, string lng, string miles)
        {
            List<Location> locationList = new List<Location>();
            //Sitecore.Diagnostics.Log.Info("--- My Ct service GetLocations: " + lat + " " + lng, "");
            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"Get_CT_Colonography_Locations";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Latitude", lat);
                    cmd.Parameters.AddWithValue("@Longitude", lng);
                    cmd.Parameters.AddWithValue("@Miles", miles);
                    
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        Location l = new Location();
                        l.Load(reader);
                        locationList.Add(l);
                    }
                    //Sitecore.Diagnostics.Log.Info("--- service GetLocations first item store name: " + locationList.SingleOrDefault().Store, "");
                }
            }
            return locationList;
        }

        public bool CreateLocation(Location location)
        {
            int result = 0;
            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"Create_CT_Colonography_Location";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FirstName", location.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", location.LastName);
                    cmd.Parameters.AddWithValue("@Store", location.Store);
                    cmd.Parameters.AddWithValue("@Email", location.Email);
                    cmd.Parameters.AddWithValue("@Address1", location.Address1);
                    cmd.Parameters.AddWithValue("@Address2", location.Address2);
                    cmd.Parameters.AddWithValue("@City", location.City);
                    cmd.Parameters.AddWithValue("@State", location.State);
                    cmd.Parameters.AddWithValue("@Zip", location.Zip);
                    cmd.Parameters.AddWithValue("@Phone", location.Phone);
                    cmd.Parameters.AddWithValue("@Url", location.URL);
                    cmd.Parameters.AddWithValue("@Latitude", location.Latitude);
                    cmd.Parameters.AddWithValue("@Longitude", location.Longitude);

                    result = cmd.ExecuteNonQuery();
                }
            }
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetSignedUrl(string address)
        {
            try
            {
                ASCIIEncoding encoding = new ASCIIEncoding();

                string mapApiUrl = Sitecore.Configuration.Settings.GetSetting("Mapapi.Url");
                string clienId = Sitecore.Configuration.Settings.GetSetting("Mapapi.ClientId");
                string url = string.Format("{0}?address={1}&client={2}&components=country:US", mapApiUrl, HttpUtility.UrlEncode(address), clienId);
                Uri uri = new Uri(url);
                byte[] encodedPathAndQueryBytes = encoding.GetBytes(uri.LocalPath + uri.Query);

                // converting key to bytes will throw an exception, need to replace '-' and '_' characters first.
                string keyString = Sitecore.Configuration.Settings.GetSetting("Mapapi.CryptoKey");
                string usablePrivateKey = keyString.Replace("-", "+").Replace("_", "/");
                byte[] privateKeyBytes = Convert.FromBase64String(usablePrivateKey);

                // compute the hash
                HMACSHA1 algorithm = new HMACSHA1(privateKeyBytes);
                byte[] hash = algorithm.ComputeHash(encodedPathAndQueryBytes);

                // convert the bytes to string and make url-safe by replacing '+' and '/' characters
                string signature = Convert.ToBase64String(hash).Replace("+", "-").Replace("/", "_");
                Sitecore.Diagnostics.Log.Info("--- My Ct service Signed Url: " + uri.Scheme + "://" + uri.Host + uri.LocalPath + uri.Query + "&signature=" + signature, "");
                // Add the signature to the existing URI.
                return string.Format(uri.Scheme + "://" + uri.Host + uri.LocalPath + uri.Query + "&signature=" + signature);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Geocode getGeocode(string signedURL)
        {
            Geocode geoCode = new Geocode();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(signedURL);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var reader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var resonse = reader.ReadToEnd();
                    dynamic data = JObject.Parse(resonse);
                    var root = JsonConvert.DeserializeObject<RootObject>(resonse);
                    var status = root.status;
                    if (status == "OK")
                    {
                        foreach (var singleResult in root.results)
                        {
                            var location = singleResult.geometry.location;
                            var latitude = location.lat;
                            var longitude = location.lng;
                            geoCode.lat = latitude.ToString();
                            geoCode.lng = longitude.ToString();
                        }
                    }
                    else new Geocode { lat = "0", lng = "0" };
                }
            }
            catch
            {
                return new Geocode { lat = "0", lng = "0" };
            }
            return geoCode;
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

    public class Geocode
    {
        public string lat { get; set; }
        public string lng { get; set; }
    }

    public class AddressComponent
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public List<string> types { get; set; }
    }

    public class Bounds
    {
        public GeoLocation northeast { get; set; }
        public GeoLocation southwest { get; set; }
    }

    public class GeoLocation
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Geometry
    {
        public Bounds bounds { get; set; }
        public GeoLocation location { get; set; }
        public string location_type { get; set; }
        public Bounds viewport { get; set; }
    }

    public class Result
    {
        public List<AddressComponent> address_components { get; set; }
        public string formatted_address { get; set; }
        public Geometry geometry { get; set; }
        public bool partial_match { get; set; }
        public List<string> types { get; set; }
    }

    public class RootObject
    {
        public List<Result> results { get; set; }
        public string status { get; set; }
    }
}
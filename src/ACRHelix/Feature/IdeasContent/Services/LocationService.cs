using System;
using ACRHelix.Feature.IdeasContent.Models;
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

namespace ACRHelix.Feature.IdeasContent.Services
{
    public class LocationService
    {
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

                // Add the signature to the existing URI.
                return string.Format(uri.Scheme + "://" + uri.Host + uri.LocalPath + uri.Query + "&signature=" + signature);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }    
}
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sitecore.Data.Items;
using System.Net;
using System.Text;
using System.IO;
using ACRHelix.Feature.Toolkits.Models;
using ACRHelix.Feature.Toolkits.DAL;

namespace ACRHelix.Feature.Toolkits.Services
{
  public class ClientService
  {    
    public static string CreateMediaItem(IPfccMediaItem mediaItem, bool pfcc = true)
    {
      var mediaFolder = pfcc ? ReferenceItems.MediaFolder : ReferenceItems.MesoMediaFolder;
      string url = ReferenceItems.CMSiteUrl + ReferenceItems.ItemWebApi + mediaFolder + "?Name=" + mediaItem.Name.Replace(" ", string.Empty) + "&sc_database=master";
      HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

      request.KeepAlive = true;
      request.Headers.Add("X-Scitemwebapi-Username", ReferenceItems.ClientDomain + "\\" + ReferenceItems.ClientUserName);
      request.Headers.Add("X-Scitemwebapi-Password", ReferenceItems.ClientPassword);
      request.Method = "POST";

      var requestStream = request.GetRequestStream();
      var boundary = "----" + DateTime.Now.Ticks.ToString("yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture);
      request.ContentType = "multipart/form-data; boundary=" + boundary;
      byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
      requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
      
      string header = "Content-Disposition: form-data; name=\"" + mediaItem.Name.Replace(" ", string.Empty) + "\"; filename=\"" + mediaItem.Name.Replace(" ", string.Empty) + mediaItem.Extension + "\";\r\nContent-Type: multipart/form-data\r\n\r\n";
      byte[] start = Encoding.UTF8.GetBytes(header);
      requestStream.Write(start, 0, start.Length);
      
      byte[] buffer = new byte[mediaItem.Blob.Length];
      int bytesRead = 0;
      while ((bytesRead = mediaItem.Blob.Read(buffer, 0, buffer.Length)) != 0)
      {
        requestStream.Write(buffer, 0, bytesRead);
      }
      
      byte[] end = Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
      requestStream.Write(end, 0, end.Length);
      requestStream.Close();
      Sitecore.Diagnostics.Log.Info("--- pfcc  create media after : end", new object());

      var response = (HttpWebResponse)request.GetResponse();
      using (var reader = new StreamReader(response.GetResponseStream(), ASCIIEncoding.ASCII))
      { 
        var responseText = reader.ReadToEnd();
        dynamic json = JObject.Parse(responseText);
        return json.result.items[0].ID;
      }
    }
  }
}
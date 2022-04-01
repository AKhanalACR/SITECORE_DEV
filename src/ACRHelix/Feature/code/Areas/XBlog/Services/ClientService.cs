using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sitecore.Data.Items;
using System.Net;
using System.Text;
using System.IO;
using Sitecore.Diagnostics;

namespace Sitecore.Feature.XBlog.Areas.XBlog.Services
{
  public class ClientService
  {
    public static bool CreateCommentItem(string comment, string name, string email, string parentItemId, string commentItemName)
    {      
      string cmSiteUrl= Sitecore.Configuration.Settings.GetSetting("CM_SiteUrl");
      string itemApiUser= Sitecore.Configuration.Settings.GetSetting("ItemApiUser");
      string itemApiPassword= Sitecore.Configuration.Settings.GetSetting("ItemApiPassword");
      string itemApiDomain= Sitecore.Configuration.Settings.GetSetting("ItemApiDomain");
      string templateId = "{24361175-3EC2-4F90-88E1-D17B14A9D47E}";
      string url= cmSiteUrl+"/-/item/v1/?sc_itemid="+ parentItemId + "&name="+ commentItemName + "&template="+ templateId + "&sc_database=master";  
      HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
      request.KeepAlive = true;
      request.Headers.Add("X-Scitemwebapi-Username", itemApiDomain + "\\" + itemApiUser);
      request.Headers.Add("X-Scitemwebapi-Password", itemApiPassword);
      request.Method = "POST";
      request.ContentType = "application/x-www-form-urlencoded";
      var requestStream = request.GetRequestStream();
      string header = "Comment="+ comment + "&Name="+name+"&Email="+email+"&__Workflow={8DD82BD6-679F-4326-B806-E0878B1114E0}&__Workflow state={4ADA52ED-9B0E-411C-BFE4-6CB420149E22}&ParentItemId="+ parentItemId;
      byte[] start = Encoding.UTF8.GetBytes(header);
      requestStream.Write(start, 0, start.Length);
      HttpWebResponse response;
      try
      {
         response = (HttpWebResponse)request.GetResponse();
      if (response.StatusCode == HttpStatusCode.OK)
        {
          Error.LogError("commentCreationInitiated = " + "Check above for error");
          return true;
        }
        else
        {
          return false;
        }
      }
      catch(Exception ex) {
        Console.WriteLine(ex);
        Error.LogError("commentCreationException = " + ex);
        return false;
      }
    }
  }
}
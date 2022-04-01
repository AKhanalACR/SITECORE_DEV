using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using ACR.Foundation.Personify.Settings;

namespace ACR.Foundation.Personify.PersonifyService
{
  public static class SvcClient
  {
    static SvcClientCore oClient = new SvcClientCore();


    static SvcClient()
    {
      oClient.Uri = ACRSettings.PersonifyServiceUrl;
      oClient.EnableBasicAuthentication = "True";
      oClient.UserName = ACRSettings.PersonifyServiceUser;
      oClient.Password = ACRSettings.PersonifyServicePass;
      oClient.SourceFormatValue = "";

      ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
    }

    #region Helpers


    public static PersonifyDS.PersonifyEntitiesACR Ctxt
    {
      get { return oClient.Ctxt; }
    }

    public static PersonifyDS.PersonifyEntitiesACR CtxtAnonymous
    {
      get { return oClient.CtxtAnonymous; }
    }

    public static string CurrentAPIVersion
    {
      get
      {
        return oClient.CurrentAPIVersion;
      }
    }

    public static SourceFormatEnum SourceFormatting
    {
      get { return oClient.SourceFormatting; }
    }

    public static string ContentType
    {
      get { return oClient.ContentType; }
    }

    public static ReturnType Post<ReturnType>(string SvcOperName, object o)
    {
      return oClient.Post<ReturnType>(SvcOperName, o);
    }

    public static ReturnType Post<ReturnType>(string SvcOperName, object o, string contentType)
    {
      return oClient.Post<ReturnType>(SvcOperName, o, contentType);
    }

    public static ReturnType PostAnonymous<ReturnType>(string SvcOperName, object o)
    {
      return oClient.PostAnonymous<ReturnType>(SvcOperName, o);
    }

    public static ReturnType Create<ReturnType>()
    {
      return oClient.Create<ReturnType>();
    }

    public static ReturnType Save<ReturnType>(object entityToSave, string addModOper = null)
    {
      return oClient.Save<ReturnType>(entityToSave, addModOper);
    }

    public static ReturnType Delete<ReturnType>(object entityToDelete)
    {
      return oClient.Delete<ReturnType>(entityToDelete);
    }

    public static string FileUpload(byte[] fileContent, string TargetFileName)
    {
      return oClient.FileUpload(fileContent, TargetFileName);
    }

    public static Stream FileDownload(string downloadResourceType, string fileName, string additionalPathExtension)
    {
      return oClient.FileDownload(downloadResourceType, fileName, additionalPathExtension);
    }

    public static string AddUpdateCartWorkflowData(string workflowId, string workflowName, long shoppingCartItemId, byte[] fileContent)
    {
      var req = (HttpWebRequest)WebRequest.Create(
          string.Format("{0}/SaveCartWorkflowData?workflowId='{1}'&workflowName='{2}'&shoppingCartItemId='{3}'",
                        System.Configuration.ConfigurationManager.AppSettings["svcUri"].TrimEnd('/'), workflowId, workflowName, shoppingCartItemId));

      req.Credentials = new NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["UserName"], System.Configuration.ConfigurationManager.AppSettings["Password"]);
      req.Method = "POST";
      req.Timeout = 1000 * 60 * 20; // 20 minutes
      req.SendChunked = true;
      req.ContentLength = fileContent.Length;

      var requestStream = req.GetRequestStream();
      requestStream.Write(fileContent, 0, fileContent.Length);
      requestStream.Close();

      try
      {
        var resp = (HttpWebResponse)req.GetResponse();
        return GetResponseString(resp);
      }
      catch (WebException wex)
      {
        throw wex;
      }
    }

    private static string GetResponseString(HttpWebResponse response)
    {
      string objText = string.Empty;
      using (var reader = new StreamReader(response.GetResponseStream()))
      {
        objText = reader.ReadToEnd();
      }
      return objText;
    }

    #endregion
  }
}
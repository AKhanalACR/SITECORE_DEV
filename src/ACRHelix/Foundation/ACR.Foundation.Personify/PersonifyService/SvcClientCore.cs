using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using ACR.Foundation.Personify.Extensions;

namespace ACR.Foundation.Personify.PersonifyService
{
  public class SvcClientCore
  {
    public string Uri { get; set; }
    public string EnableBasicAuthentication { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string SourceFormatValue { get; set; }

    Uri svcUri;

    #region Helpers


    private PersonifyDS.PersonifyEntitiesACR ctxt;
    public PersonifyDS.PersonifyEntitiesACR Ctxt
    {
      get
      {
        if (ctxt == null)
        {
          ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
          svcUri = new Uri(Uri);
          ctxt = new PersonifyDS.PersonifyEntitiesACR(svcUri);
          ctxt.MergeOption = MergeOption.PreserveChanges;
          //enable authentication if necessary
          if (Convert.ToBoolean(EnableBasicAuthentication) == true)
          {
            var serviceCreds = new NetworkCredential(UserName, Password);
            var cache = new CredentialCache();
            cache.Add(svcUri, "Basic", serviceCreds);
            ctxt.Credentials = cache;

           
          }
          ctxt.IgnoreResourceNotFoundException = true;
        }
        return ctxt;
      }
    }

    private PersonifyDS.PersonifyEntitiesACR ctxtAnonymous;
    public PersonifyDS.PersonifyEntitiesACR CtxtAnonymous
    {
      get
      {
        if (ctxtAnonymous == null)
        {
          ctxtAnonymous = new PersonifyDS.PersonifyEntitiesACR(svcUri);
          ctxtAnonymous.IgnoreResourceNotFoundException = true;
        }
        return ctxtAnonymous;
      }
    }

    public string CurrentAPIVersion
    {
      get
      {
        return System.Configuration.ConfigurationManager.AppSettings["APIVersion"];
      }
    }

    public SourceFormatEnum SourceFormatting
    {
      get
      {
        try
        {
          if (string.IsNullOrEmpty(SourceFormatValue))
            SourceFormatValue = "XML";

          return (SourceFormatEnum)Enum.Parse(typeof(SourceFormatEnum), SourceFormatValue, true);
        }
        catch (Exception ex)
        {
          return SourceFormatEnum.XML;
        }
      }
    }

    public string ContentType
    {
      get
      {
        if (SourceFormatting == SourceFormatEnum.JSON)
          return "application/json;charset=utf-8";
        else
          return "application/xml;charset=utf-8";
      }
    }

    public ReturnType Post<ReturnType>(string SvcOperName, object o)
    {
      return DoPost<ReturnType>(SvcOperName, o, true);
    }

    public ReturnType Post<ReturnType>(string SvcOperName, object o, string contentType)
    {
      return DoPost<ReturnType>(SvcOperName, o, true, contentType);
    }

    public ReturnType PostAnonymous<ReturnType>(string SvcOperName, object o)
    {
      return DoPost<ReturnType>(SvcOperName, o, false);
    }

    private ReturnType DoPost<ReturnType>(string SvcOperName, object o, bool enableAuthentication)
    {
      return DoPost<ReturnType>(SvcOperName, o, enableAuthentication, string.Empty);
    }

    private ReturnType DoPost<ReturnType>(string SvcOperName, object o, bool enableAuthentication, string contentType)
    {
      HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Uri.TrimEnd('/') + "/" + SvcOperName);
      SourceFormatValue = contentType;
      if (enableAuthentication)
      {
        NetworkCredential serviceCreds = new NetworkCredential(UserName, Password);
        CredentialCache cache = new CredentialCache();
        Uri uri = new Uri(Uri);
        cache.Add(uri, "Basic", serviceCreds);
        req.Credentials = cache;
      }

      req.Method = "POST";
      //req.ContentType = "application/x-www-form-urlencoded";
      req.ContentType = ContentType;
      req.Timeout = 1000 * 60 * 15; // 15 minutes

      byte[] arr = o.ToSerializedByteArrayUTF8(SourceFormatting);
      req.ContentLength = arr.Length;
      Stream reqStrm = req.GetRequestStream();
      reqStrm.Write(arr, 0, arr.Length);
      reqStrm.Close();

      //HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
      ////string s = resp.StatusDescription;
      //Stream respStream = resp.GetResponseStream();
      //StreamReader sr = new StreamReader(resp.GetResponseStream());
      //string sResp = sr.ReadToEnd();
      //sr.Close();
      //respStream.Close();
      //resp.Close();
      //ReturnType oRespCus = sResp.ToBusinessEntity<ReturnType>(SourceFormatEnum.XML);
      try
      {
        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        return GetResponseValue<ReturnType>(resp);
      }
      catch (WebException wex)
      {
        throw DataServiceExceptionUtil.ParseException(wex);
      }
    }

    private ReturnType GetResponseValue<ReturnType>(HttpWebResponse response)
    {
      ReturnType oEntity;
      string objText;
      objText = GetResponseString(response);
      response.Close();
      if (!string.IsNullOrWhiteSpace(objText))
        oEntity = objText.ToBusinessEntity<ReturnType>(SourceFormatting);
      else
        oEntity = default(ReturnType);
      return oEntity;
    }

    private string GetResponseString(HttpWebResponse response)
    {
      string objText = string.Empty;
      using (var reader = new StreamReader(response.GetResponseStream()))
      {
        objText = reader.ReadToEnd();
      }
      return objText;
    }

    public ReturnType Create<ReturnType>()
    {
      HttpWebRequest req = (HttpWebRequest)WebRequest.Create(
          string.Format("{0}/Create?EntityName='{1}'",
              Uri.TrimEnd('/'),
              typeof(ReturnType).Name)
              );
      NetworkCredential serviceCreds = new NetworkCredential(UserName, Password);
      CredentialCache cache = new CredentialCache();
      cache.Add(new Uri(Uri), "Basic", serviceCreds);

      req.Credentials = cache;
      req.Method = "GET";
      //req.ContentType = "application/x-www-form-urlencoded";
      req.ContentType = ContentType;
      req.Timeout = 1000 * 60 * 15; // 15 minutes

      //req.Headers.Add("Cookie", SessionCookie);

      try
      {
        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        return GetResponseValue<ReturnType>(resp);
      }
      catch (WebException wex)
      {
        throw DataServiceExceptionUtil.ParseException(wex);
      }
    }

    public ReturnType Save<ReturnType>(object entityToSave, string addModOper = null)
    {

      HttpWebRequest req = (HttpWebRequest)WebRequest.Create(
          string.Format("{0}/Save?EntityName='{1}'",
              Uri.TrimEnd('/'),
              typeof(ReturnType).Name)
              );
      NetworkCredential serviceCreds = new NetworkCredential(UserName, Password);
      CredentialCache cache = new CredentialCache();
      Uri uri = new Uri(Uri);
      cache.Add(uri, "Basic", serviceCreds);

      req.Credentials = cache;
      req.Method = "POST";
      //req.ContentType = "application/x-www-form-urlencoded";
      req.ContentType = ContentType;
      req.Timeout = 1000 * 60 * 15; // 15 minutes

      if (!string.IsNullOrEmpty(addModOper))
      {
        req.Headers.Add("AddModOper", addModOper);
      }

      byte[] arr = entityToSave.ToSerializedByteArrayUTF8(SourceFormatting);
      req.ContentLength = arr.Length;
      Stream reqStrm = req.GetRequestStream();
      reqStrm.Write(arr, 0, arr.Length);
      reqStrm.Close();

      WebResponse webresponse;// = req.GetResponse();
      HttpWebResponse resp;
      try
      {
        webresponse = req.GetResponse();
        resp = (HttpWebResponse)webresponse;


        //string x = GetResponseString(resp);

        return GetResponseValue<ReturnType>(resp);
      }
      catch (WebException wex)
      {

        string r1 = GetResponseString((HttpWebResponse)wex.Response);

        throw DataServiceExceptionUtil.ParseException(wex);
      }
    }

    public ReturnType Delete<ReturnType>(object entityToDelete)
    {

      HttpWebRequest req = (HttpWebRequest)WebRequest.Create(
          string.Format("{0}/Delete?EntityName='{1}'",
              Uri.TrimEnd('/'),
              typeof(ReturnType).Name)
              );
      NetworkCredential serviceCreds = new NetworkCredential(UserName, Password);
      CredentialCache cache = new CredentialCache();
      Uri uri = new Uri(Uri);
      cache.Add(uri, "Basic", serviceCreds);

      req.Credentials = cache;
      req.Method = "POST";
      //req.ContentType = "application/x-www-form-urlencoded";
      req.ContentType = ContentType;
      req.Timeout = 1000 * 60 * 15; // 15 minutes
                                    //req.Headers.Add("Cookie", SessionCookie);

      byte[] arr = entityToDelete.ToSerializedByteArrayUTF8(SourceFormatting);
      req.ContentLength = arr.Length;
      Stream reqStrm = req.GetRequestStream();
      reqStrm.Write(arr, 0, arr.Length);
      reqStrm.Close();

      try
      {
        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        return GetResponseValue<ReturnType>(resp);
      }
      catch (WebException wex)
      {
        throw DataServiceExceptionUtil.ParseException(wex);
      }
    }

    public string FileUpload(byte[] fileContent, string TargetFileName)
    {
      HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Uri.TrimEnd('/') + "/FileUpload?fileName='" + TargetFileName + "'");
      NetworkCredential serviceCreds = new NetworkCredential(UserName, Password);
      CredentialCache cache = new CredentialCache();
      Uri uri = new Uri(Uri);
      cache.Add(uri, "Basic", serviceCreds);
      req.Credentials = cache;
      req.Method = "POST";
      req.Timeout = 1000 * 60 * 20; // 20 minutes
      req.SendChunked = true;

      req.ContentLength = fileContent.Length;
      Stream reqStrm = req.GetRequestStream();
      reqStrm.Write(fileContent, 0, fileContent.Length);
      reqStrm.Close();

      try
      {
        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        return GetResponseString(resp);
      }
      catch (WebException wex)
      {
        throw DataServiceExceptionUtil.ParseException(wex);
      }


    }

    public Stream FileDownload(string downloadResourceType, string fileName, string additionalPathExtension)
    {
      var url = string.Format("{0}/FileDownload?downloadResourceType='{1}'&fileName='{2}'&additionalPathExtension='{3}'",
          Uri.TrimEnd('/'), downloadResourceType, fileName, additionalPathExtension);

      var serviceCreds = new NetworkCredential(UserName, Password);
      var cache = new CredentialCache();
      var uri = new Uri(Uri);
      cache.Add(uri, "Basic", serviceCreds);

      var req = (HttpWebRequest)WebRequest.Create(url);
      req.Credentials = cache;
      req.Method = "GET";
      req.Timeout = 1000 * 60 * 20; // 20 minutes

      try
      {
        var resp = (HttpWebResponse)req.GetResponse();
        return resp.GetResponseStream();
      }
      catch (WebException wex)
      {
        throw DataServiceExceptionUtil.ParseException(wex);
      }
    }

    #endregion

  }

  public class DataServiceExceptionUtil
  {
    public static Exception ParseException(Exception ex)
    {
      return ex;
    }
  }

  public enum SourceFormatEnum
  {
    XML,
    JSON
  }
}
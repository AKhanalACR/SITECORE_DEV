using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sitecore.Data.Items;
using System.Net;
using System.Text;
using ACRHelix.Feature.MembershipTestimonials.Models;
using System.IO;

namespace ACRHelix.Feature.MembershipTestimonials.Services
{
  public class ClientService
  {
    private static string _cmsiteurl = Sitecore.Configuration.Settings.GetSetting("cm_site_url");
    private static string _itemWebApi = Sitecore.Configuration.Settings.GetSetting("item.webapi");
    private static string _clientService = Sitecore.Configuration.Settings.GetSetting("client.service");
    private static string _clientServiceLogin = Sitecore.Configuration.Settings.GetSetting("client.service.login");
    private static string _clientServiceItem = Sitecore.Configuration.Settings.GetSetting("client.service.item");
    private static string _clientServiceUsername = Sitecore.Configuration.Settings.GetSetting("client.service.username");
    private static string _clientServicePassword = Sitecore.Configuration.Settings.GetSetting("client.service.password");
    private static string _clientServiceDomain = Sitecore.Configuration.Settings.GetSetting("client.service.domain");
    private static string _testimonialParent = Sitecore.Configuration.Settings.GetSetting("membership.testimoial.parent");
    private static string _testimonialMedia = Sitecore.Configuration.Settings.GetSetting("membership.testimoial.media");
    private static string _templateId = Sitecore.Configuration.Settings.GetSetting("membership.template.id");

    public static string AuthenticationToken()
    {
      //authenticate
      using (WebClient client = new WebClient())
      {
        try
        {
          //authenticate
          var uri = _cmsiteurl + _clientService + _clientServiceLogin;
          var stringData = JsonConvert.SerializeObject(
              new
              {
                domain = _clientServiceDomain,
                username = _clientServiceUsername,
                password = _clientServicePassword
              });

          Sitecore.Diagnostics.Log.Info("--- vvvv authenticate uri: " + uri, new object());

          client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
          client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
          ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
          var body = client.UploadString(uri, stringData);

          Sitecore.Diagnostics.Log.Info("--- vvvv authenticate response body: " + body, new object());
          return Convert.ToString(JObject.Parse(body)["token"]);

        }
        catch (Exception ex)
        {
          Sitecore.Diagnostics.Log.Error("--- vvvv trying to authenticate: " + ex.StackTrace, ex, ex.GetType());
          Sitecore.Diagnostics.Log.Error(ex.StackTrace, ex, ex.GetType());
          return null;
        }
      }

    }

    public static string CreateItem(ITestimonial testimonial, string token)
    {
      using (WebClient client = new WebClient())
      {
        try
        {
          //create item
          client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
          client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
          client.Headers.Add("token", token);

          string uri2 = _cmsiteurl + _clientService + _clientServiceItem + _testimonialParent + "/?database=master";

          var stringData2 = JsonConvert.SerializeObject(
              new
              {
                ItemName = ItemUtil.ProposeValidItemName(testimonial.Name),
                TemplateID = _templateId,
                Title = testimonial.Name,
                Full___Name = testimonial.FullName,
                Customer___ID = testimonial.CustomerId,
                Chapter = testimonial.Chapter,
                FaceBook = testimonial.FaceBook,
                Twitter___Handle = testimonial.TwitterHandle,
                LinkedIn = testimonial.LinkedIn,
                Engage___Profile = testimonial.EngageProfile,
                YouTube___Link = testimonial.YouTubeLink,
                Category = testimonial.Category,
                Intro___Message = testimonial.IntroMessage,
                Brief___Message = testimonial.BriefMessage,
                SubTitle = testimonial.SubTitle,
                Testimonial___Message = testimonial.TesimonialMessage

              }, Formatting.Indented);


          stringData2 = stringData2.Replace("___", " ");

          ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
          client.UploadString(uri2, stringData2);

          var resp = JsonConvert.SerializeObject(new { Location = client.ResponseHeaders.Get("Location"), token = token }, Formatting.Indented);

          Sitecore.Diagnostics.Log.Info("--- vvvv item create response body: " + client.ResponseHeaders.ToString() + " " + resp, new object());

          return resp;

        }
        catch (Exception ex)
        {
          Sitecore.Diagnostics.Log.Error("--- vvvv trying to create item exception: " + ex.Message, ex, ex.GetType());
          Sitecore.Diagnostics.Log.Error(ex.StackTrace, ex, ex.GetType());
          return null;
        }
      }
    }

    public static string CreateMediaItem(IMediaItem mediaItem)
    {
      string url = _cmsiteurl + _itemWebApi + _testimonialMedia + "?Name=" + mediaItem.Name.Replace(" ", string.Empty) + "&sc_database=master";
      HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

      request.KeepAlive = true;
      request.Headers.Add("X-Scitemwebapi-Username", _clientServiceDomain + "\\" + _clientServiceUsername);
      request.Headers.Add("X-Scitemwebapi-Password", _clientServicePassword);
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

      var response = (HttpWebResponse)request.GetResponse();
      using (var reader = new StreamReader(response.GetResponseStream(), System.Text.ASCIIEncoding.ASCII))
      {
        var responseText = reader.ReadToEnd();
        Sitecore.Diagnostics.Log.Info(" -- Mt new media item created --" + responseText, new object());
        dynamic json = JObject.Parse(responseText);
        return json.result.items[0].ID;
      }
    }

    public static string EditItem(ITestimonial testimonial, string tokenAndLocation)
    {
      using (WebClient client = new WebClient())
      {
        try
        {
          //edit item
          client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
          client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
          client.Headers.Add("token", Convert.ToString(JObject.Parse(tokenAndLocation)["token"]));

          //Sitecore.Diagnostics.Log.Info("--- vvvv item edit token: " + Convert.ToString(JObject.Parse(tokenAndLocation)["token"]), new object());
          string uri2 = Convert.ToString(JObject.Parse(tokenAndLocation)["Location"]);
          Sitecore.Diagnostics.Log.Info("--- vvvv item edit uri: " + uri2, new object());

          var stringData2 = JsonConvert.SerializeObject(
              new
              {
                imageUrl = "<image mediaid=\"" + testimonial.ProfileImage.MediaId + "\" alt=\"" + testimonial.ProfileImage.Alt + "\" height=\"\" width=\"\" hspace=\"\" vspace=\"\" />"
              }, Formatting.Indented);

          stringData2 = stringData2.Replace("imageUrl", "Profile Image");
          Sitecore.Diagnostics.Log.Info("--- vvvv item edit data: " + stringData2, new object());

          ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
          client.UploadData(uri2, "PATCH", Encoding.Default.GetBytes(stringData2));

          return client.ResponseHeaders.ToString();

        }
        catch (Exception ex)
        {
          Sitecore.Diagnostics.Log.Error("--- vvvv tring to item edit exception: " + ex.Message, ex, ex.GetType());
          Sitecore.Diagnostics.Log.Error(ex.StackTrace, ex, ex.GetType());
          return null;
        }
      }
    }

    public static string EditMediaItem(IMediaItem media, string tokenAndLocation)
    {
      using (WebClient client = new WebClient())
      {
        try
        {
          //edit item
          client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
          client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
          client.Headers.Add("token", Convert.ToString(JObject.Parse(tokenAndLocation)["token"]));

          string uri2 = Convert.ToString(JObject.Parse(tokenAndLocation)["Location"]);
          Sitecore.Diagnostics.Log.Info("--- vvvv item edit uri: " + uri2, new object());
          var stringData2 = JsonConvert.SerializeObject(
              new
              {
                IconUrl = "",
                Icon = _templateId,

              }, Formatting.Indented);

          Sitecore.Diagnostics.Log.Info("--- vvvv item edit data: " + stringData2, new object());

          ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
          string returnitem = Encoding.ASCII.GetString(client.UploadData(uri2, "PATCH", Encoding.Default.GetBytes(stringData2)));

          var resp = JsonConvert.SerializeObject(new { Location = returnitem, token = Convert.ToString(JObject.Parse(tokenAndLocation)["token"]) }, Formatting.Indented);

          Sitecore.Diagnostics.Log.Info("--- vvvv response body: " + resp, new object());

          return resp;

        }
        catch (Exception ex)
        {
          Sitecore.Diagnostics.Log.Error("--- vvvv tring to item edit exception: " + ex.Message, ex, ex.GetType());
          Sitecore.Diagnostics.Log.Error(ex.StackTrace, ex, ex.GetType());
          return null;
        }
      }
    }
  }
}
using ACR.Foundation.CaseInPointService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serialization.Json;

namespace ACR.Foundation.CaseInPointService
{
    public class CaseInPointClient
    {
             
        public CaseInPointItem GetCaseInPoint(string apiUrl ,string apiKey)
        {
      try
      {
        // Api call Format - https://cortexuat.acr.org/WebAPI/CiPUtility/GetPublishedCaseData/<publishdate>/<apikey>
        var client = new RestClient(apiUrl);
        string date = DateTime.Now.ToString("yyyy-MM-dd");
        // Api does not return data on saturday and sunday so for saturday and sunday date of friday is used.
        if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
        {
          date= DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
        }
        if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
        {
          date = DateTime.Now.AddDays(-2).ToString("yyyy-MM-dd");
        }
        string key = apiKey ;//"78a0b86257cd437c8b94b6159e4d793c"
        var request = new RestRequest("{date}/{key}");
        request.AddUrlSegment("date", date);
        request.AddUrlSegment("key", key);
        var response = client.Execute(request);
        var deserialize = new JsonDeserializer();
        var output = deserialize.Deserialize<Dictionary<string, string>>(response);
        if (!output.ContainsKey("ErrorMessage"))
        {
          var caseinPointItem = new CaseInPointItem();
          caseinPointItem.CaseId = output["CaseId"];
          caseinPointItem.History = output["History"];
          caseinPointItem.PublishDate = ToDateTime(output["PublishDate"]);
          caseinPointItem.Url = output["Url"];
          caseinPointItem.ImageUrl = output["ImageUrl"];
          return caseinPointItem;
        }
      }
      catch
      {        
      }
      return null;
    }

    private static string GetValue(XElement e)
        {
            if (e != null)
                return e.Value;
            return null;
        }

        private static DateTime? ToDateTime(string datetime)
        {
            DateTime d;
            if (DateTime.TryParse(datetime, out d))
            {
                return d;
            }
            return null;
        }
    }
}
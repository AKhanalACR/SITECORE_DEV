using ACR.Foundation.Personify.PersonifyDS;
using ACR.Foundation.Personify.PersonifyService;
using ACRHelix.Feature.Toolkits.Models;
using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ACRHelix.Feature.Toolkits.Services
{
  public class PersonifyData : ACR.Foundation.Personify.PersonifyService.PersonifyEntitiesACR
  {
    public PersonifyData() : base() {  }

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
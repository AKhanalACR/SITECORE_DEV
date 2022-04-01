using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ACR.Foundation.CaseInPointService.Settings
{
  public static class CaseInPointServiceSettings
  {
    private const string SectionName = "CaseInPointServiceSettings";

    private static NameValueCollection ConfigurationSection
    {
      get
      {
        return (NameValueCollection)ConfigurationManager.GetSection(SectionName);
      }
    }

    public static string CaseInPointServiceUrl
        {
      get
      {
        return ConfigurationSection["CaseInPointServiceUrl"] ?? "https://3s.acr.org/cipcmewebservice/Service1.asmx";
      }
    }

    public static string CaseInPointServiceUser
        {
      get
      {
        return ConfigurationSection["CaseInPointServiceUser"] ?? "cipapplication";
      }
    }

    public static string CaseInPointServicePass
    {
      get
      {
        return ConfigurationSection["PersonifyServicePass"] ?? "*CIPappl1!";
      }
    }
  }
}
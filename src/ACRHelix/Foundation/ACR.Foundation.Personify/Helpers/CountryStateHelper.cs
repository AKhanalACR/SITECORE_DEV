using ACR.Foundation.Personify.PersonifyService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACR.Foundation.Personify.Helpers
{
  public static class CountryStateHelper
  {
    public static List<SelectListItem> GetPersonifyCountries()
    {
      var cacheCountries = HttpContext.Current.Cache["informzPSCountries"] as List<SelectListItem>;
      if (cacheCountries != null)
      {
        return cacheCountries;
      }
      else
      {
        List<SelectListItem> countries = new List<SelectListItem>();
        PersonifyEntitiesACR svc = new PersonifyEntitiesACR();
        foreach (var c in svc.Countries.Where(x => x.ActiveFlag == true))
        {
          countries.Add(new SelectListItem()
          {
            Text = c.CountryDescription,
            Value = c.CountryCode,
            Selected = false
          });
        }

        var usa = countries.FirstOrDefault(x => x.Value == "USA");
        if (usa != null)
        {
          usa.Selected = true;
        }
        HttpContext.Current.Cache["informzPSCountries"] = countries;
        return countries;
      }

    }

    public static List<SelectListItem> GetPersonifyStates()
    {
      var cacheStates = HttpContext.Current.Cache["informzPSStates"] as List<SelectListItem>;
      if (cacheStates != null)
      {
        return cacheStates;
      }
      else
      {
        List<SelectListItem> states = new List<SelectListItem>();
        PersonifyEntitiesACR svc = new PersonifyEntitiesACR();
        foreach (var s in svc.States.Where(x => x.ActiveFlag == true))
        {
          states.Add(new SelectListItem()
          {
            Text = s.StateDescription,
            Value = s.StateCode + "|" + s.CountryCodeString,
          });
        }
        HttpContext.Current.Cache["informzPSStates"] = states;
        return states;
      }
    }
  }
}
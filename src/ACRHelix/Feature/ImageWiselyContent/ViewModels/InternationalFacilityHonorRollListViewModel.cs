using ACR.Library.ImageWisely.Data;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ACRHelix.Feature.ImageWiselyContent.ViewModels
{
  public class InternationalFacilityHonorRollListViewModel
  {

    public string NoFacilitiesText { get; set; }

    public InternationalFacilityHonorRollListViewModel(List<InternationalFacility> facilities)
    {
      FacilityCountries = new List<FacilityCountry>();
      List<string> countries = facilities.Select(x => x.Country).Distinct().ToList();

      TextInfo textInfo = new CultureInfo("en-us", false).TextInfo;
      foreach (string country in countries)
      {
        FacilityCountry facilityCountry = new FacilityCountry()
        {
          Country = country,
          Cities = new List<FacilityCity>()
        };

        List<InternationalFacility> countryFacilities = facilities.Where(x => x.Country == country).ToList();
        //FacilitiesByCountry.Add(textInfo.ToTitleCase(country.ToLower()), countryFacilities);
        List<string> cities = countryFacilities.Select(x => x.City).Distinct().ToList();

        foreach (var city in cities)
        {
          var cityFacilities = countryFacilities.Where(x => x.City == city).ToList();
          FacilityCity fcity = new FacilityCity() { City = city, Facilities = new List<InternationalFacility>() };
          foreach (var cityf in cityFacilities)
          {
            fcity.Facilities.Add(cityf);
          }
          facilityCountry.Cities.Add(fcity);
        }
        FacilityCountries.Add(facilityCountry);
      }

    }


    public List<FacilityCountry> FacilityCountries { get; set; }

  }

  public class FacilityCountry
  {
    public string Country { get; set; }
    public List<FacilityCity> Cities { get; set; }
  }

  public class FacilityCity
  {
    public string City { get; set; }

    public List<InternationalFacility> Facilities { get; set; }
  }
}
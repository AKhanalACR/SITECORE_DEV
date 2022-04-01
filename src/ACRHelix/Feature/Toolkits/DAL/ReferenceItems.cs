using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.Toolkits.DAL
{
  public class ReferenceItems
  {
    private static IList<SelectListItem> _states;
    private static IList<SelectListItem> _facetTypes;
    private static IList<SelectListItem> _mesoFacetTypes;

    private const string _cmsiteurl = "https://auth.acr.org";
    private const string _itemWebApi = "/-/item/v1";
    private const string _mediaFolder = "/sitecore/media library/ACR/NOINDEX/PFCC Toolkit";
    private const string _mesoMediaFolder = "/sitecore/media library/ACR/NOINDEX/MESO Toolkit";
    private const string _mediaFolderUrl = "/-/media/ACR/NOINDEX/PFCC-Toolkit/";
    private const string _mesoMediaFolderUrl = "/-/media/ACR/NOINDEX/MESO-Toolkit/";
    private const string _mesoMediaFolderId = "{B54C2105-22CA-425F-804D-62E2E3C260B8}";
    private const string _clientUsername = "ageteneh";
    private const string _clientPassword = "Greenmap28";
    private const string _clientDomain = "sitecore";

    public static IEnumerable<SelectListItem> States
    {
      get
      {
        if (_states == null)
        {
          _states = new List<SelectListItem>();

          _states.Add(new SelectListItem() { Value = "AL", Text = "Alabama" });
          _states.Add(new SelectListItem() { Value = "AK", Text = "Alaska" });
          _states.Add(new SelectListItem() { Value = "AS", Text = "American Samoa" });
          _states.Add(new SelectListItem() { Value = "AZ", Text = "Arizona" });
          _states.Add(new SelectListItem() { Value = "AR", Text = "Arkansas" });
          _states.Add(new SelectListItem() { Value = "CA", Text = "California" });
          _states.Add(new SelectListItem() { Value = "CO", Text = "Colorado" });
          _states.Add(new SelectListItem() { Value = "CT", Text = "Connecticut" });
          _states.Add(new SelectListItem() { Value = "DE", Text = "Delaware" });
          _states.Add(new SelectListItem() { Value = "DC", Text = "District of Columbia" });
          _states.Add(new SelectListItem() { Value = "FM", Text = "Fed. States of Micronesia" });
          _states.Add(new SelectListItem() { Value = "FL", Text = "Florida" });
          _states.Add(new SelectListItem() { Value = "GA", Text = "Georgia" });
          _states.Add(new SelectListItem() { Value = "GU", Text = "Guam" });
          _states.Add(new SelectListItem() { Value = "HI", Text = "Hawaii" });
          _states.Add(new SelectListItem() { Value = "ID", Text = "Idaho" });
          _states.Add(new SelectListItem() { Value = "IL", Text = "Illinois" });
          _states.Add(new SelectListItem() { Value = "IN", Text = "Indiana" });
          _states.Add(new SelectListItem() { Value = "IA", Text = "Iowa" });
          _states.Add(new SelectListItem() { Value = "KS", Text = "Kansas" });
          _states.Add(new SelectListItem() { Value = "KY", Text = "Kentucky" });
          _states.Add(new SelectListItem() { Value = "LA", Text = "Louisiana" });
          _states.Add(new SelectListItem() { Value = "ME", Text = "Maine" });
          _states.Add(new SelectListItem() { Value = "MH", Text = "Marshall Islands" });
          _states.Add(new SelectListItem() { Value = "MD", Text = "Maryland" });
          _states.Add(new SelectListItem() { Value = "MA", Text = "Massachusetts" });
          _states.Add(new SelectListItem() { Value = "MI", Text = "Michigan" });
          _states.Add(new SelectListItem() { Value = "MN", Text = "Minnesota" });
          _states.Add(new SelectListItem() { Value = "MS", Text = "Mississippi" });
          _states.Add(new SelectListItem() { Value = "MO", Text = "Missouri" });
          _states.Add(new SelectListItem() { Value = "MT", Text = "Montana" });
          _states.Add(new SelectListItem() { Value = "NE", Text = "Nebraska" });
          _states.Add(new SelectListItem() { Value = "NV", Text = "Nevada" });
          _states.Add(new SelectListItem() { Value = "NH", Text = "New Hampshire" });
          _states.Add(new SelectListItem() { Value = "NJ", Text = "New Jersey" });
          _states.Add(new SelectListItem() { Value = "NM", Text = "New Mexico" });
          _states.Add(new SelectListItem() { Value = "NY", Text = "New York" });
          _states.Add(new SelectListItem() { Value = "NC", Text = "North Carolina" });
          _states.Add(new SelectListItem() { Value = "ND", Text = "North Dakota" });
          _states.Add(new SelectListItem() { Value = "MP", Text = "Northern Mariana Is." });
          _states.Add(new SelectListItem() { Value = "OH", Text = "Ohio" });
          _states.Add(new SelectListItem() { Value = "OK", Text = "Oklahoma" });
          _states.Add(new SelectListItem() { Value = "OR", Text = "Oregon" });
          _states.Add(new SelectListItem() { Value = "PW", Text = "Palau" });
          _states.Add(new SelectListItem() { Value = "PA", Text = "Pennsylvania" });
          _states.Add(new SelectListItem() { Value = "PR", Text = "Puerto Rico" });
          _states.Add(new SelectListItem() { Value = "RI", Text = "Rhode Island" });
          _states.Add(new SelectListItem() { Value = "SC", Text = "South Carolina" });
          _states.Add(new SelectListItem() { Value = "SD", Text = "South Dakota" });
          _states.Add(new SelectListItem() { Value = "TN", Text = "Tennessee" });
          _states.Add(new SelectListItem() { Value = "TX", Text = "Texas" });
          _states.Add(new SelectListItem() { Value = "UT", Text = "Utah" });
          _states.Add(new SelectListItem() { Value = "VT", Text = "Vermont" });
          _states.Add(new SelectListItem() { Value = "VI", Text = "Virgin Islands" });
          _states.Add(new SelectListItem() { Value = "VA", Text = "Virginia" });
          _states.Add(new SelectListItem() { Value = "WA", Text = "Washington" });
          _states.Add(new SelectListItem() { Value = "WV", Text = "West Virginia" });
          _states.Add(new SelectListItem() { Value = "WI", Text = "Wisconsin" });
          _states.Add(new SelectListItem() { Value = "WY", Text = "Wyoming" });
        }

        return _states;

      }
    }

    public static IEnumerable<SelectListItem> FacetTypes
    {
      get
      {
        if (_facetTypes == null)
        {
          _facetTypes = new List<SelectListItem>();

          _facetTypes.Add(new SelectListItem() { Text = "Practice Setting", Value = "PFCC_CATEORY" });
          _facetTypes.Add(new SelectListItem() { Text = "Topic", Value = "CONTENT_TYPE" });
          _facetTypes.Add(new SelectListItem() { Text = "Format", Value = "RESOURCE_TYPE" });

        }

        return _facetTypes;
      }
    }

    public static IEnumerable<SelectListItem> MesoFacetTypes
    {
      get
      {
        if (_mesoFacetTypes == null)
        {
          _mesoFacetTypes = new List<SelectListItem>();

          _mesoFacetTypes.Add(new SelectListItem() { Text = "Audience", Value = "MESO_TARGET" });
          _mesoFacetTypes.Add(new SelectListItem() { Text = "Core Knowledge Type", Value = "MESOCORETYPE" });
          _mesoFacetTypes.Add(new SelectListItem() { Text = "Anatomy Subcategory Type", Value = "MESOSUBCATEGORY" });
          _mesoFacetTypes.Add(new SelectListItem() { Text = "Format", Value = "MESORESOURCETYPE" });
          

        }

        return _mesoFacetTypes;
      }
    }

    public static string CMSiteUrl
    {
      get { return _cmsiteurl; }
    }

    public static string ItemWebApi
    {
      get { return _itemWebApi; }
    }

    public static string MediaFolder
    {
      get { return _mediaFolder; }
    }
    public static string MesoMediaFolder
    {
      get { return _mesoMediaFolder; }
    }
    public static string MediaFolderUrl
    {
      get { return _mediaFolderUrl; }
    }
    public static string MesoMediaFolderUrl
    {
      get { return _mesoMediaFolderUrl; }
    }

    public static string MesoMediaFolderId
    {
      get { return _mesoMediaFolderId; }
    }

    public static string ClientUserName
    {
      get { return _clientUsername; }
    }

    public static string ClientPassword
    {
      get { return _clientPassword; }
    }

    public static string ClientDomain
    {
      get { return _clientDomain; }
    }
  }
}

using ACRHelix.Feature.MyCtColonography.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.MyCtColonography.ViewModels
{
  public class RegisterFacilityViewModel
  { 
    public Location FacilityLocation { get; set; }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public string AcceptText { get; set; }
    public string ButtonText { get; set; }
    public string ValidationErrorMessage { get; set; }

    private  IList<SelectListItem> _states;
    public  IEnumerable<SelectListItem> States
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
  }
}
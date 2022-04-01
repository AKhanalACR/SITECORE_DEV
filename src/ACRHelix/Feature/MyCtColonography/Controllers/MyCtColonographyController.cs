using ACRHelix.Feature.MyCtColonography.Models;
using ACRHelix.Feature.MyCtColonography.Services;
using ACRHelix.Feature.MyCtColonography.ViewModels;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using System;
using System.Web.Mvc;

namespace ACRHelix.Feature.MyCtColonography
{
    public class MyCtColonographyController : Controller
    {
        private readonly IContentService _contentService;
        private LocationService _locationService;

        public MyCtColonographyController(IContentService contentService)
        {
            _contentService = contentService;
            _locationService = new LocationService();

        }

        public ViewResult MyCtColonography()
        {
            var viewModel = new MyCtColonographyViewModel();
            return View(viewModel);
        }

        public JsonResult GetLocations(string lat, string lng, string miles)
        {
            var Data = _locationService.GetLocations(lat, lng, miles);
            return Json(Data, JsonRequestBehavior.AllowGet);           
        }

        public string GetSignedUrl(string address)
        {
            return _locationService.GetSignedUrl(address);
            
        }

        [HttpGet]
        public ActionResult RegisterFacility()
        {
            var viewModel = new RegisterFacilityViewModel();
            var dataSource = RenderingContext.Current.Rendering.DataSource;
            if (string.IsNullOrEmpty(dataSource))
                dataSource = Sitecore.Context.Item.ID.ToString();

            if (!string.IsNullOrEmpty(dataSource))
            {
                var RegistrationForm = _contentService.GetFacilityRegistration(dataSource);
                if (RegistrationForm != null)
                {
                    viewModel.Id = RegistrationForm.Id;
                    viewModel.Title = RegistrationForm.Title;
                    viewModel.Subtitle = RegistrationForm.Subtitle;
                    viewModel.AcceptText = RegistrationForm.AcceptText;
                    viewModel.ButtonText = RegistrationForm.ButtonText;
                    viewModel.ValidationErrorMessage = RegistrationForm.ValidationErrorMessage;
                }
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult RegisterFacility(RegisterFacilityViewModel viewModel, FormCollection formCol)
        {
            string ctcThankYouPage = Sitecore.Configuration.Settings.GetSetting("CTC.ThankYouPage");
            string ctcErrorPage = Sitecore.Configuration.Settings.GetSetting("CTC.ErrorPage");
            var options = LinkManager.GetDefaultUrlOptions();
            options.AlwaysIncludeServerUrl = true;
            bool successfulEntry = false;
            if (ModelState.IsValid)
            {
                Location inputLoc = GetInputLocation(formCol);

                if ((!String.IsNullOrEmpty(inputLoc.Store)) && (!String.IsNullOrEmpty(inputLoc.Address1)))
                {
                    //Save into Database
                    successfulEntry = _locationService.CreateLocation(inputLoc);
                }

                if (successfulEntry)
                {
                    Item thkItem = Sitecore.Context.Database.GetItem(ctcThankYouPage);
                    return Redirect(LinkManager.GetItemUrl(thkItem, options));
                }
                Item errItem = Sitecore.Context.Database.GetItem(ctcErrorPage);
                return Redirect(LinkManager.GetItemUrl(errItem, options));
            }
            else
            {
                return View("RegisterFacility", viewModel);
            }
        }


        public Location GetInputLocation(FormCollection formCol)
        {
            Location newLoc = new Location();
            newLoc.FirstName = (!string.IsNullOrEmpty(formCol["FacilityLocation.FirstName"])) ? formCol["FacilityLocation.FirstName"].ToString() : "";
            newLoc.LastName = (!string.IsNullOrEmpty(formCol["FacilityLocation.LastName"])) ? formCol["FacilityLocation.LastName"].ToString() : "";
            newLoc.Email = (!string.IsNullOrEmpty(formCol["FacilityLocation.Email"])) ? formCol["FacilityLocation.Email"].ToString() : "";
            newLoc.Store = (!string.IsNullOrEmpty(formCol["FacilityLocation.Store"])) ? formCol["FacilityLocation.Store"].ToString() : "";
            newLoc.Address1 = (!string.IsNullOrEmpty(formCol["FacilityLocation.Address1"])) ? formCol["FacilityLocation.Address1"].ToString() : "";
            newLoc.Address2 = (!string.IsNullOrEmpty(formCol["FacilityLocation.Address2"])) ? formCol["FacilityLocation.Address2"].ToString() : "";
            newLoc.City = (!string.IsNullOrEmpty(formCol["FacilityLocation.City"])) ? formCol["FacilityLocation.City"].ToString() : "";
            newLoc.State = (!string.IsNullOrEmpty(formCol["FacilityLocation.State"])) ? formCol["FacilityLocation.State"].ToString() : "";
            newLoc.Zip = (!string.IsNullOrEmpty(formCol["FacilityLocation.Zip"])) ? formCol["FacilityLocation.Zip"].ToString() : "";
            newLoc.Phone = (!string.IsNullOrEmpty(formCol["FacilityLocation.Phone"])) ? formCol["FacilityLocation.Phone"].ToString() : "";
            newLoc.URL = (!string.IsNullOrEmpty(formCol["FacilityLocation.Url"])) ? formCol["FacilityLocation.Url"].ToString() : "";

            //Get latitude and longitude
            string fullAddress = newLoc.Address1 + " " + newLoc.City + ", " + newLoc.State + " " + newLoc.Zip;
            string signedURL = GetSignedUrl(fullAddress);
            _locationService = new LocationService();
            Geocode locGeoCode = _locationService.getGeocode(signedURL);
            newLoc.Latitude = locGeoCode.lat;
            newLoc.Longitude = locGeoCode.lng;

            return newLoc;
        }

    }
}
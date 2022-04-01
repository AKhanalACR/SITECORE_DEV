using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.ImageWiselyContent.Models
{
    public class GroupPledge : Pledge
    {
        [Required(ErrorMessage = "Please enter a name.")]
        [DisplayName("Facility Name")]
        public string FacilityName { get; set; }

        public string Country { get; set; }

        [DisplayName("Country")]
        public IEnumerable<SelectListItem> Countries { get; set; }

        [DisplayName("State")]
        public string State { get; set; }

        public IEnumerable<SelectListItem> States { get; set; }

        [DisplayName("Province")]
        public string Province { get; set; }

        public IEnumerable<SelectListItem> Provinces { get; set; }

        [Required(ErrorMessage = "Please enter a city.")]
        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("Title")]
        public string Title { get; set; }

        public bool IsDisplayOnHonorRoll { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.ImageWiselyContent.Models
{

    public class IndividualPledge : Pledge
    {
        [Required(ErrorMessage = "Required")]
        [DisplayName("Profession / Role")]
        public string ProfessionOrRole{ get; set; }

        public IEnumerable<SelectListItem> ProfessionOrRoleList { get; set; }

        [DisplayName("If other, Please specify")]
        public string OtherProfesionOrRole { get; set; }

        [Required(ErrorMessage = "Please enter your primary institution or hospital.")]
        [DisplayName("Primary Institution / Hospital")]
        public string InstitutionOrHospital { get; set; }

        public string Country { get; set; }

        [DisplayName("Country")]
        public IEnumerable<SelectListItem> Countries { get; set; }

        public string PracticeType { get; set; }

        [DisplayName("Practice Type")]
        public IEnumerable<SelectListItem> PracticeTypes { get; set; }

        [DisplayName("If other, Please specify")]
        public string OtherPracticeType { get; set; }

        //[DisplayName("How did you learn about this campaign")]
        //public string HowLearnAboutCampaign { get; set; }

        //public IEnumerable<SelectListItem> HowLearnAboutCampaignList { get; set; }

        //[DisplayName("If other, Please specify")]
        //public string OtherHowLearnAboutCampaign { get; set; }

    }
}
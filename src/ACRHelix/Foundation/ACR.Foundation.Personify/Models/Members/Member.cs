using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACR.Foundation.Personify.Models.Members
{
    public class Member
    {
        [Display(Name = "Master Customer Id")]
        public string MasterCustomerId { get; set; }

        [Display(Name = "Sort Name")]
        public string SortName { get; set; }

        [Display(Name = "Attn")]
        public string Attn { get; set; }

        [Display(Name = "LabelName")]
        public string LabelName { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Zip")]
        public string Zip { get; set; }

        [Display(Name = "BusinessPhone")]
        public string BusinessPhone { get; set; }

        [Display(Name = "BusinessFax")]
        public string BusinessFax { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Address1")]
        public string Address1 { get; set; }

        [Display(Name = "Address2")]
        public string Address2 { get; set; }

        [Display(Name = "City/Street/Zip")]
        public string CityStreetZip { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "MemberSince")]
        public DateTime? MemberSince { get; set; }
    }
}
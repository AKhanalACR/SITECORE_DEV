using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;


namespace ACRHelix.Feature.ImageWiselyContent.Models
{
    public abstract class Pledge
    {
        [Required(ErrorMessage = "Please enter your first name.")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name.")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Invalid email address. Please try again.")]
        [DisplayName("Email Address (for pledge confirmation and certificate)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Invalid email address. Please try again.")]
        [Compare("Email", ErrorMessage = "Email addresses do not match. Please try again.")]
        [DisplayName("Confirm Email address")]
        public string ConfirmEmail { get; set; }
    }
}
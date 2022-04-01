using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace ACRHelix.Feature.Toolkits.Models
{
  public class ResourceFormData
  {
    [Required(ErrorMessage = "Please enter your first name.")]
    [DisplayName("First Name")]
    [Column("FirstName")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Please enter your last name.")]
    [DisplayName("Last Name")]
    [Column("LastName")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Please enter your email address.")]
    [DisplayName("Email Address")]
    [Column("Email")]
    public string Email { get; set; }

    //[DisplayName("Address 1")]
    //[Column("Address1")]
    //public string Address1 { get; set; }

    //[DisplayName("Address 2")]
    //[Column("Address2")]
    //public string Address2 { get; set; }

    //[DisplayName("City")]
    //[Column("City")]
    //public string City { get; set; }

    //[Column("State")]
    //public string State { get; set; }

    //[DisplayName("State")]
    //public IEnumerable<SelectListItem> StatesList { get; set; }

    //[DisplayName("Zip Code")]
    //[Column("PostalCode")]
    //public string ZipCode { get; set; }

    //[Column("PhoneArea")]
    //public string PhoneArea { get; set; }

    //[DisplayName("Phone Number")]
    //[Column("Phone")]
    //public string Phone { get; set; }

    [Required(ErrorMessage = "Please enter resource title.")]
    [DisplayName("Resource Title")]
    [Column("Title")]
    public string Title { get; set; }

    [DisplayName("URL")]
    [Column("Url")]
    public string Url { get; set; }

    //[Required(ErrorMessage = "Please select practice setting.")]
    [Column("CareSettins")]
    public string PracticeSetting { get; set; }
        
    [DisplayName("Practice Setting")]
    public IEnumerable<FacetItem> PracticeSettingsList { get; set; }

    //[Required(ErrorMessage = "Please select topic.")]
    [Column("ContentType")]
    public string ContentType { get; set; }
        
    [DisplayName("Topic")]
    public IEnumerable<FacetItem> ContentTypesList { get; set; }

    //[Required(ErrorMessage = "Please select format.")]
    [Column("ResourceType")]
    public string ResourceType { get; set; }

    [DisplayName("Format")]
    public IEnumerable<FacetItem> ResourceTypesList { get; set; }
    
    [Required(ErrorMessage = "Please enter description.")]
    [DisplayName("Description")]
    [Column("Description")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Please enter keyword.")]
    [DisplayName("Keywords")]
    [Column("Keywords")]
    public string Keyword { get; set; }

    [DisplayName("File Name")]
    [Column("FileName")]
    public string FileName { get; set; }

    [Column("Status")]
    public string Status { get; set; }

    [DisplayName("Attachement URL")]
    public string AttachementUrl { get; set; }

  }
}
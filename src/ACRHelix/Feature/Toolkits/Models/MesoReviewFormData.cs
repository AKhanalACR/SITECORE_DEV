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
  public class MesoReviewFormData
  {
    public Int64 ToolId { get; set; }

    [Required(ErrorMessage = "Please enter title.")]
    [DisplayName("Title")]
    [Column("Title")]
    public string Title { get; set; }

    [Column("ContentType")] //core knowledge type
    public string ContentType { get; set; }

    [Column("ResourceType")] //anatomy subcategory type
    public string ResourceType { get; set; }

    [Required(ErrorMessage = "Please enter description.")]
    [DisplayName("Description")]
    [Column("Description")]
    public string Description { get; set; }
    
    [DisplayName("URL")]
    [Column("Url")]
    public string Url { get; set; }

    [DisplayName("File Name")]
    [Column("Filename")]
    public string FileName { get; set; }

    [Required(ErrorMessage = "Please enter keyword.")]
    [DisplayName("Keywords")]
    [Column("Keywords")]
    public string Keywords { get; set; }

    [Column("Status")]
    public string Status { get; set; }
        
    [DisplayName("Last Name")]
    [Column("LastName")]
    public string LastName { get; set; }
        
    [DisplayName("First Name")]
    [Column("FirstName")]
    public string FirstName { get; set; }

    [DisplayName("Address 1")]
    [Column("Address1")]
    public string Address1 { get; set; }

    [DisplayName("Address 2")]
    [Column("Address2")]
    public string Address2 { get; set; }

    [DisplayName("City")]
    [Column("City")]
    public string City { get; set; }

    [Column("State")]
    public string State { get; set; }

    [DisplayName("State")]
    public IEnumerable<SelectListItem> StatesList { get; set; }

    [DisplayName("Zip Code")]
    [Column("PostalCode")]
    public string ZipCode { get; set; }

    [Column("PhoneArea")]
    public string PhoneArea { get; set; }

    [DisplayName("Phone Number")]
    [Column("Phone")]
    public string Phone { get; set; }
        
    [DisplayName("Email Address")]
    [Column("Email")]
    public string Email { get; set; }

    [Column("CareSettings")] //target audience group
    public string PracticeSetting { get; set; }

    [DisplayName("Audience")]
    public IEnumerable<FacetItem> PracticeSettingsList { get; set; }
 
    [DisplayName("Core Knowledge Type")]
    public IEnumerable<FacetItem> ContentTypesList { get; set; }
    
    [DisplayName("Anatomy Subcategory Type")]
    public IEnumerable<FacetItem> ResourceTypesList { get; set; }

    [Column("ResourceFormat")] //content type
    public string ResourceFormat { get; set; }

    [DisplayName("Format")]
    public IEnumerable<FacetItem> ResourceFormatsList { get; set; }

  }
}
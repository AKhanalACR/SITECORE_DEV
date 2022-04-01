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
  public class MesoFormData
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

    [Required(ErrorMessage = "Please enter resource title.")]
    [DisplayName("Resource Title")]
    [Column("Title")]
    public string Title { get; set; }

    [DisplayName("URL")]
    [Column("Url")]
    public string Url { get; set; }

    //-- target group
    [Column("Audience")]
    public string TargetAudience { get; set; }

    [DisplayName("Audience")]
    public IEnumerable<FacetItem> TargetAudienceList { get; set; }

    //-- Core Knowledge
    [Column("Core Knowledge")]
    public string CoreKnowledge { get; set; }
        
    [DisplayName("Core Knowledge Type")]
    public IEnumerable<FacetItem> CoreKnowledgeTypeList { get; set; }

    [Column("AnatomySubCategoryType")]
    public string AnatomySubcategory { get; set; }

    [DisplayName("Anatomy Subcategory Type")]
    public IEnumerable<FacetItem> AnatomySubcategoryTypeList { get; set; }

    [Column("ResourceType")]
    public string ResourceType { get; set; }

    [DisplayName("Format")]
    public IEnumerable<FacetItem> ResourceTypeList { get; set; }

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
using ACRHelix.Feature.Biography.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Biography.Models
{
  public class Biography : IBiography
  {
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string OtherPositions { get; set; }
    //public Image Image { get; set; }
    public Image BioImage { get; set; }
    public string RichText { get; set; }
    public string StaffDirectoryCategory { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public bool DisplayDetailLink { get; set; }
    public string GroupPracticeName { get; set; }
    public string ParentOrganization { get; set; }

    public string URL { get; set; }
  }
}
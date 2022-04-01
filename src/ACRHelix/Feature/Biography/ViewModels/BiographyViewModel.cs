using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Fields;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Biography.ViewModels
{
  public class BiographyViewModel
  {
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string OtherPositions { get; set; }
    //public Image Image { get; set; }
    public Image BioImage { get; set; }
    public String RichText { get; set; }
    //public String StaffDirectoryCategory { get; set; }
    public String Phone { get; set; }
    public String Email { get; set; }
    public bool DisplayDetailLink { get; set; }
    public String GroupPracticeName { get; set; }
    public String ParentOrganization { get; set; }
    public string URL { get; set; }
  }
}
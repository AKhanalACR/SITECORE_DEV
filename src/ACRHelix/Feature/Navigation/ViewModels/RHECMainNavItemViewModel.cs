using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.Navigation.ViewModels
{
  public class RHECMainNavItemViewModel
  {
    public string Title { get; set; }
    public string URL { get; set; }
    public bool NewWindow { get; set; }
    public IEnumerable<RHECMainNavItemViewModel> Children { get; set; }
    public ID TemplateID { get; set; }
    public string Target
    {
      get
      {
        return NewWindow ? "_blank" : "_self";
      }
    }

    public DateTime Updated { get; set; }

    public string Frequency { get; set; } = "Weekly";
  }
}
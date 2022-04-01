using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.DecampFeatureRenderings.ViewModels
{
  public class TextCalloutSectionViewModel
  {
    public Guid Id { get; set; }
    public string Title { get; set; }  
    public string SubTitle { get; set; }
    public string RichText { get; set; }
    public Image Image { get; set; }
    
  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.RhecContent.ViewModels
{
    public class PledgeViewModel
  {
    public ID Id { get; set; }
    public string Title { get; set; }
    public string SubTitle { get; set; }

    public string RichText { get; set; }
    public string ProTabTex { get; set; }
    public string FacTabText { get; set; }
    public string ProPledgeTitle { get; set; }
    public string ProPledgeText { get; set; }
    public string FacPledgeTitle { get; set; }
    public string FacPledgeText { get; set; }
  }
}
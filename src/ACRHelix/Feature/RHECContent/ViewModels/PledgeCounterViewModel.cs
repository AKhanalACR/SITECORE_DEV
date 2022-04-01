using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.RhecContent.ViewModels
{
    public class PledgeCounterViewModel
  {
    public ID Id { get; set; }
    public string Title { get; set; }
    public bool DisplayCounter { get; set; }

    public int PledgeCount { get; set; }
 
  }
}
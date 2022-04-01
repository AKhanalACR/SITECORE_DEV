using ACRHelix.Feature.ImageWiselyContent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.ImageWiselyContent.ViewModels
{
    public class PledgeCounterSectionViewModel
    {
        public IPledgeCounterSection PledgeCounterSection { get; set; }
        public int ImagingPCount { get; set; }
        public int ReferringPCount { get; set; }
        public int ImagingFCount { get; set; }
        public int AssocAEdProgCount { get; set; }
        public int TotalPledgeCount { get; set; }
    }
}
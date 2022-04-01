using ACRHelix.Feature.ImageWiselyContent.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.ImageWiselyContent.Models
{
    public class PledgeCounterSection : IPledgeCounterSection
    {
        public ID Id { get; set; }
        public string TotalPledgeText { get; set; }
        
        public Image Image { get; set; }
        [SitecoreField("Background Image")]
        public Image BackgroundImage { get; set; }
    }
}
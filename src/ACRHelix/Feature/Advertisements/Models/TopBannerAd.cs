using ACRHelix.Feature.Advertisements.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Advertisements.Models
{
    public class TopBannerAd : ITopBannerAd
    {
        public Guid Id { get; set; }
        public string Javascript { get; set; }
    }
}
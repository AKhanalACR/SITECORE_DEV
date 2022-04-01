using ACRHelix.Feature.Advertisements.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Advertisements.Models
{
    public interface ITopBannerAd : ICMSEntity
    {
        Guid Id { get; set; }
        string Javascript { get; set; }
    }
}
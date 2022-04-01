using ACRHelix.Feature.Advertisements.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Advertisements.Models
{
    public class AdBar : IAdBar
    {
        public virtual Guid Id { get; set; }
        public virtual string HTML { get; set; }
    }
}
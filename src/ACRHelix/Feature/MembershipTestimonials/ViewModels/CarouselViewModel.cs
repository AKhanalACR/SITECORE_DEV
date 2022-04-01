using ACRHelix.Feature.MembershipTestimonials.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.MembershipTestimonials.ViewModels
{    
    public class CarouselViewModel
    {
        public IEnumerable<CarouselItem> CarouselItems { get; set; }
    }
}
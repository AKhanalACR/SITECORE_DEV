using ACRHelix.Feature.CareerCenter.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.CareerCenter.Models
{
    public class FeaturedJobs : IFeaturedJobs
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public string JobsFeedUrl { get; set; }

        public int ItemsToDisplay { get; set; }
    }
}
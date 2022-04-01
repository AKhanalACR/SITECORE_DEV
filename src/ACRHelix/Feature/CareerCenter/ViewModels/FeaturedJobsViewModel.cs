using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.CareerCenter.ViewModels
{
    public class FeaturedJobsViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public IEnumerable<Job> Jobs { get; set; }

    }

    public class Job
    {        
        public string JobTitle { get; set; }
        public string JobLink { get; set; }
        public string JobDescription { get; set; }
        public string Company { get; set; }
        public bool Featured { get; set; }
        public IEnumerable<Location> Locations { get; set; }
    }
    public class Location
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
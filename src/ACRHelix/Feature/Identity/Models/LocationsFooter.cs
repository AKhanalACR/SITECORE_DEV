using ACRHelix.Feature.Identity.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Identity.Models
{
    public class LocationsFooter : ILocationsFooter
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string LinkText { get; set; }
        public Link Link { get; set; }
        public IEnumerable<ILocation> Locations { get; set; }
    }
}
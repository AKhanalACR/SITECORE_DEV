using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Identity.ViewModels
{
    public class LocationsFooterViewModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string LinkText { get; set; }
        public Link Link { get; set; }
        public IEnumerable<LocationViewModel> Locations { get; set; } = new List<LocationViewModel>();
    }
}
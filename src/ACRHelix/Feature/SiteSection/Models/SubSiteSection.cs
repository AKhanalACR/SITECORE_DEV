using ACRHelix.Feature.SiteSection.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.SiteSection.Models
{
    public class SubSiteSection : ISubSiteSection
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }
        public IEnumerable<ITile> Tiles {get; set;}
    }
}
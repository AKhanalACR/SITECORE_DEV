using ACRHelix.Feature.TabbedSlider.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.TabbedSlider.Models
{
    public class Tab : ITab
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Anchor { get; set; }
        public string TemplateName { get; set; }
        public IEnumerable<ISlide> Slides { get; set; }
    }
}
using ACRHelix.Feature.TabbedSlider.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.TabbedSlider.Models
{
    public interface ITab : ICMSEntity
    {
        Guid Id { get; set; }
        string Title { get; set; }
        string Anchor { get; set; }
        string TemplateName { get; set; }
        IEnumerable<ISlide> Slides { get; set; }
    }
}
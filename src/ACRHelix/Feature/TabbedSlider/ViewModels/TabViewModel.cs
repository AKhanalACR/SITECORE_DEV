using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.TabbedSlider.ViewModels
{
    public class TabViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Anchor { get; set; }        
        public IEnumerable<SlideViewModel> Slides { get; set; } = new List<SlideViewModel>();
    }
}
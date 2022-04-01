using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.SiteSection.ViewModels
{
    public class SubSiteSectionViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }
        public IEnumerable<TileViewModel> Tiles { get; set; }
    }
}
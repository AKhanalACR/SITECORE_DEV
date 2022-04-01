using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Navigation.Models
{
    public class LinkMenu : ILinkMenu
    {
        public string Name { get; set; }
        public bool IncludeCharacterBasedDivider { get; set; }
        public IEnumerable<ILinkMenuItem> MenuItems { get; set; }
    }
}
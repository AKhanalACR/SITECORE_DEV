using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Navigation.ViewModels
{
    public class LinkMenuViewModel
    {
        public string Title { get; set; }
        public bool IncludeCharacterBasedDivider { get; set; }
        public IEnumerable<MenuItemViewModel> MenuItems { get; set; } = new List<MenuItemViewModel>();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Navigation.ViewModels
{
    public class MainNavbarViewModel
    {
        public IEnumerable<MainNavItemViewModel> NavigationItems { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Navigation.ViewModels
{
    public class RHECMainNavbarViewModel
    {
        public IEnumerable<RHECMainNavItemViewModel> NavigationItems { get; set; }
    }
}
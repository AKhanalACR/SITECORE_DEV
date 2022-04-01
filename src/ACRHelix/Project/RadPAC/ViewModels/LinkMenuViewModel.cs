using ACRHelix.Project.RadPAC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Project.RadPAC.ViewModels
{
    public class LinkMenuViewModel
    {
        private IEnumerable<ILinkMenuItem> _menuItems;

        public Guid Id { get; set; }
        public IEnumerable<MenuItemViewModel> MenuItems { get; set; } = new List<MenuItemViewModel>();
    }
}
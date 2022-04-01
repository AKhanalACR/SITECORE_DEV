using ACRHelix.Project.Decamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Project.Decamp.ViewModels
{
  public class LinkMenuViewModel
  {
    private IEnumerable<ILinkMenuItem> _menuItems;

    public Guid Id { get; set; }
    public IEnumerable<MenuItemViewModel> MenuItems { get; set; } = new List<MenuItemViewModel>();
  }
}
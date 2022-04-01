using System;
using System.Collections.Generic;

namespace RHEC.Website.ViewModels
{
  public class CopyrightViewModel
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string CopyrightText { get; set; }
    public IEnumerable<MenuItemViewModel> MenuItems { get; set; } = new List<MenuItemViewModel>();
  }
}
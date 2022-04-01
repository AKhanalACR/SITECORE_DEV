using System;
using System.Collections.Generic;

namespace RHEC.Website.Models
{
  public class LinkMenu : ILinkMenu
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public IEnumerable<ILinkMenuItem> MenuItems { get; set; }
  }
}
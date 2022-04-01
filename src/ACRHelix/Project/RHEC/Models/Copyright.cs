using System;
using System.Collections.Generic;

namespace RHEC.Website.Models
{
  public class Copyright : ICopyright
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string CopyrightText { get; set; }
    public IEnumerable<ILinkMenuItem> MenuItems { get; set; }
  }
}
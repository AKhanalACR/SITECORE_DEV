using System;
using System.Collections.Generic;

namespace RHEC.Website.ViewModels
{
  public class PartnersLogoViewModel
  {
    public Guid Id { get; set; }
    public IEnumerable<LogoViewModel> Partners { get; set; } = new List<LogoViewModel>();
  }
}
using System;
using System.Collections.Generic;

namespace RHEC.Website.Models
{
  public class PartnersLogo : IPartnersLogo
  {
    public Guid Id { get; set; }
    public IEnumerable<ILogo> Partners { get; set; }
  }
}
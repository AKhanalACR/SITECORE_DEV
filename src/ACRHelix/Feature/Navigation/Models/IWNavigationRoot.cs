using System;
using System.Collections.Generic;
using Sitecore.Data;

namespace ACRHelix.Feature.Navigation.Models
{
  public class IWNavigationRoot : IIWNavigationRoot
  {
    public ID Id { get; set; }

    public string Name { get; set; }

    public IEnumerable<IWNavigableItem> Children { get; set; }
   
  }
}
using System;
using System.Collections.Generic;
using Sitecore.Data;

namespace ACRHelix.Feature.Navigation.Models
{
  public class NavigationRoot : INavigationRoot
  {
    public ID Id { get; set; }

    public string Name { get; set; }

    public IEnumerable<NavigableItem> Children { get; set; }
   
  }
}
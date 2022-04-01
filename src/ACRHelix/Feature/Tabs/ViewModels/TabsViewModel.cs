using System.Collections.Generic;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.Tabs.ViewModels
{
  public class TabsViewModel 
  {
    public ID Id { get; set; }
 
    public List<TabNameViewModel> TabNames { get; set; }

  }
}
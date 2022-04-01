using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Feature.Tabs.Helpers;

namespace ACRHelix.Feature.Tabs.ViewModels
{
  public class TabNameViewModel
  {
    public TabNameViewModel(string tabName)
    {
      TabName = tabName;
      TabNameID = HttpContext.Current.Server.HtmlEncode(TabHelper.EncodeTabNameID(tabName));
    }

    public string TabName { get; set; }
    public string TabNameID { get; set; }
  }
}
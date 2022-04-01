using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ACRHelix.Feature.Tabs.Helpers
{
  public static class TabHelper
  {
    private const string pattern = "[^0-9a-zA-Z]+";
    public static string EncodeTabNameID(string tabname)
    {
      return Regex.Replace(tabname, pattern,"");
    }
  }
}
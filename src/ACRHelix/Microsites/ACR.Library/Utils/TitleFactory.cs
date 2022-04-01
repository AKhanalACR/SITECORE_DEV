using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.Library.Utils
{
  public static class TitleFactory
  {
    public static string GetRLINavTitle(Item item)
    {
      string text = "";
      var navTitle = item.Fields["Navigation Title"];
      var varTitle = item.Fields["Title"];
      if (navTitle != null)
      {
        if (!string.IsNullOrWhiteSpace(navTitle.Value))
        {
          text = navTitle.Value;
        }
      }
      if (string.IsNullOrWhiteSpace(text))
      {
        if (varTitle != null)
        {
          text = string.IsNullOrWhiteSpace(varTitle.Value) ? varTitle.DisplayName : varTitle.Value;
        }
      }
      return text;
    }

    public static string GetAIRPNavTitle(Item item)
    {
      string text = "";
      var navTitle = item.Fields["Navigation Title"];
      var varTitle = item.Fields["Title"];
      if (navTitle != null)
      {
        if (!string.IsNullOrWhiteSpace(navTitle.Value))
        {
          text = navTitle.Value;
        }
      }
      if (string.IsNullOrWhiteSpace(text))
      {
        if (varTitle != null)
        {
          text = string.IsNullOrWhiteSpace(varTitle.Value) ? varTitle.DisplayName : varTitle.Value;
        }
      }
      return text;
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Foundation.Assets.Models
{
  internal class AssetEqualityComparer : IEqualityComparer<Asset>
  {
    public bool Equals(Asset x, Asset y)
    {
      if (x.File == y.File && x.Inline == y.Inline && x.Location == y.Location && x.Type == y.Type)
      {
        return true;
      }
      return false;
    }

    public int GetHashCode(Asset obj)
    {
      int hcode = 0;

      if (obj.File != null)
      {
        hcode += obj.File.GetHashCode();
      }
      if (obj.Inline != null)
      {
        hcode += obj.Inline.GetHashCode();
      }
      hcode += obj.Location.GetHashCode();
      hcode += obj.Type.GetHashCode();

      return hcode;
    }
  }
}
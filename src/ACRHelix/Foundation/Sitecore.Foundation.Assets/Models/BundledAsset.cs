using Sitecore.Data;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Foundation.Assets.Models
{
  public class BundledAsset
  {

    public BundledAsset(List<BundleInfo> info, List<string> scripts)
    {
      Info = info;
      Scripts = scripts;
    }

    public List<BundleInfo> Info { get; set; }

    public List<string> Scripts { get; set; }
  }

  public class BundleInfo{
    public ID Id { get; set; }
    public string Name { get; set; }

    }
}
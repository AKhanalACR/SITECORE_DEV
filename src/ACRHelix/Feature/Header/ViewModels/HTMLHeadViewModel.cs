using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.HTMLHead.ViewModels
{
  public class HTMLHeadViewModel
  {
     public Guid Id { get; set; }  
    public string Javascript { get; set; }
    public string Fonts { get; set; }
    public string CSS { get; set; }
    public string CanonicalURL { get; set; }
    public string JavascriptAssets { get; set; }
    public string CSSAssets { get; set; }
    public string Favicons { get; set; }
  }
}
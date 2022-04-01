using ACRHelix.Feature.HTMLHead.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.HTMLHead.Models
{
  public class HTMLHead : IHTMLHead
  {
    public Guid Id { get; }
    /*
    public string Javascript { get; }
    public string CSS { get; }
    public string Fonts { get; }
    public string Favicons { get; }
    */
  }
}
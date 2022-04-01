using ACRHelix.Feature.HTMLHead.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.HTMLHead.Models
{
  public interface IHTMLHead : ICMSEntity
  {
    Guid Id { get; }
    /*
    string Javascript { get; }
    string CSS { get; }
    string Fonts { get; }
    string Favicons { get; }*/
  }
}
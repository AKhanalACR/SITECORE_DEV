using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using ACRHelix.Foundation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.DecampFeatureRenderings.Models
{
  public interface ITextCalloutSection : ICMSEntity
  {
    Guid Id { get; set; }

    string Title { get; set; }
    
    string SubTitle { get; set; }
    string RichText { get; set; }
    Image Image { get; set; }
  }
}
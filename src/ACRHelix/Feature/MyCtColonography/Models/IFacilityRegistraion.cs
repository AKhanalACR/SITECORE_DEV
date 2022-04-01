using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.MyCtColonography.Models
{
  public interface IFacilityRegistraion : ICMSEntity
  {
    Guid Id { get; set; }
    string Title { get; set; }
    string Subtitle { get; set; }
    [SitecoreField("Accept Text")]
    string AcceptText { get; set; }
    [SitecoreField("Button Text")]
    string ButtonText { get; set; }
    string ValidationErrorMessage { get; set; }
  }
}
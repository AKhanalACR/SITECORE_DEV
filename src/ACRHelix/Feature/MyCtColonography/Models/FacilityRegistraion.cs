using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.MyCtColonography.Models
{
  public class FacilityRegistraion: IFacilityRegistraion
  {
      public Guid Id { get; set; }
      public string Title { get; set; }
      public string Subtitle { get; set; }
      [SitecoreField("Accept Text")]
      public string AcceptText { get; set; }
      [SitecoreField("Button Text")]
      public string ButtonText { get; set; }
      public string ValidationErrorMessage { get; set; }
  }
}
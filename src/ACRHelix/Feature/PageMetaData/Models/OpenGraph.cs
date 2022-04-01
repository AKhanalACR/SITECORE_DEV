using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.HTMLMetadata.Models
{
  public class OpenGraph : IOpenGraph
  {
    public string OG_Description
    {
      get; set;
    }

    public Image OG_Image
    {
      get;set;
    }

    public string OG_Title
    {
      get; set;
    }
  }
}
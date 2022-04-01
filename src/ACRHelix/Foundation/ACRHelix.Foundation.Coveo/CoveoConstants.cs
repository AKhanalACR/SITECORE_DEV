using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Foundation.CustomCoveo
{
  public struct CoveoConstants
  {
    public struct CoveoFieldTypes
    {
      public const string CoveoString = "string";
      public const string CoveoDateTime = "datetime";
      public const string CoveoInteger = "Integer";
    }

    public struct CoveoFormats
    {
      public const string CoveoIndexDateFormat = "yyyy/MM/dd@HH:mm:ssZ";
    }
  }
}
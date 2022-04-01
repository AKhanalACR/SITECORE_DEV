using ACRHelix.Feature.Callouts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Callouts.Services
{
  public interface IContentService
  {
    ICallouts GetCalloutsContent(string contentGuid);

    ICalloutsItem GetCalloutItem(string contentGuid);
  }
}
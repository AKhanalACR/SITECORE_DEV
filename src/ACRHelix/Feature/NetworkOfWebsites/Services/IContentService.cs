using ACRHelix.Feature.NetworkOfWebsites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.NetworkOfWebsites.Services
{
  public interface IContentService
  {
    Models.NetworkOfWebsites GetNetworkOfWebsitesContent(string contentGuid);
  }
}
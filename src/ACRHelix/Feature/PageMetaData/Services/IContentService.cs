using ACRHelix.Feature.HTMLMetadata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.HTMLMetadata.Services
{
  public interface IContentService
  {
    IHTMLMetadata GetHTMLMetadataContent(string contentGuid);
    IOpenGraph GetOpenGraphContent(string contentGuid);
  }
}
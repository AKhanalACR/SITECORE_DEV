using ACRHelix.Feature.AdditionalResources.Models;
using ACRHelix.Foundation.Index.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.AdditionalResources.Services
{
    public interface IContentService
    {
        Models.AdditionalResources GetAdditionalResourcesContent(string contentGuid);
        //IEnumerable<TagSearchResult> SearchTags(IEnumerable<string> tags);
    }
}
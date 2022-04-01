using ACRHelix.Feature.IdeasResources.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.IdeasResources.Services
{
    public interface IContentService
    {
        IdeasSelectedResources GetIdeasSelectedResources(string contentGuid);
        IdeasResourceListings GetIdeasResourceLsitings(string contentGuid);
        IdeasResource GetIdeasVideoResource(string contentGuid);

    }
}
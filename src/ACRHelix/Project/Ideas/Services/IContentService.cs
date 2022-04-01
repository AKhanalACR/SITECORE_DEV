using ACRHelix.Feature.Ideas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Ideas.Services
{
    public interface IContentService
    {
        IIdeas GetIdeasContent(string contentGuid);
    }
}
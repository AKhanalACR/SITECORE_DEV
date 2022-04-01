using ACRHelix.Feature.Biography.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Biography.Services
{
    public interface IContentService
    {
        IBiography GetBiographyContent(string contentGuid);
    }
}
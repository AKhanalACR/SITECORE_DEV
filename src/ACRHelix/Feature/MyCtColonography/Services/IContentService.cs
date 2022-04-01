using ACRHelix.Feature.MyCtColonography.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.MyCtColonography.Services
{
    public interface IContentService
    {
        IMyCtColonography GetMyCtColonographyContent(string contentGuid);
        IFacilityRegistraion GetFacilityRegistration(string contentGuid);
    }
}
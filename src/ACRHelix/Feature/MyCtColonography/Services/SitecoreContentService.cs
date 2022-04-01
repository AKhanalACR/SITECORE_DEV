using ACRHelix.Feature.MyCtColonography.Models;
using ACRHelix.Foundation.Repository.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.MyCtColonography.Services
{
    public class SitecoreContentService : IContentService
    {
        private readonly IContentRepository _repository;
        public SitecoreContentService(IContentRepository repository)
        {
            _repository = repository;
        }
        public IMyCtColonography GetMyCtColonographyContent(string contentGuid)
        {
            return _repository.GetContentItem<IMyCtColonography>(contentGuid);
        }

        public IFacilityRegistraion GetFacilityRegistration(string contentGuid)
        {
            return _repository.GetContentItem<IFacilityRegistraion>(contentGuid);
        }
    }
}
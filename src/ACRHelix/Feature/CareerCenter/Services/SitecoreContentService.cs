using ACRHelix.Feature.CareerCenter.Models;
using ACRHelix.Foundation.Repository.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.CareerCenter.Services
{
    public class SitecoreContentService : IContentService
    {
        private readonly IContentRepository _repository;
        public SitecoreContentService(IContentRepository repository)
        {
            _repository = repository;
        }
        public ICareerCenter GetCareerCenterContent(string contentGuid)
        {
            return _repository.GetContentItem<ICareerCenter>(contentGuid);
        }

        public IFeaturedJobs GetFeaturedJobsContent(string contentGuid)
        {
            return _repository.GetContentItem<IFeaturedJobs>(contentGuid);
        }
    }
}
using ACRHelix.Feature.StaffDirectory.Models;
using ACRHelix.Foundation.Repository.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.StaffDirectory.Services
{
    public class SitecoreContentService : IContentService
    {
        private readonly IContentRepository _repository;
        public SitecoreContentService(IContentRepository repository)
        {
            _repository = repository;
        }
        public Models.StaffDirectory GetStaffDirectoryContent(string contentGuid)
        {
            return _repository.GetContentItem<Models.StaffDirectory>(contentGuid);
        }
    }
}
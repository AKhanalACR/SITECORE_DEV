using ACRHelix.Foundation.Repository.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACR.Foundation.Personify;
using ACR.Foundation.Personify.PersonifyService;
using ACRHelix.Feature.MemberDirectory.Models;

namespace ACRHelix.Feature.MemberDirectory.Services
{
    public class SitecoreContentService : IContentService
    {
        private readonly IContentRepository _repository;
        public SitecoreContentService(IContentRepository repository)
        {
            _repository = repository;
        }
        public IMemberDirectory GetMemberDirectoryContent(string contentGuid)
        {
            return _repository.GetContentItem<IMemberDirectory>(contentGuid);
        }

        public IEnumerable<ACR.Foundation.Personify.Models.Members.Member> SearchMembers(string firstName, string lastName, string city, string state, string zip, string country)
        {
            PersonifyEntitiesACR personifyContext = new PersonifyEntitiesACR();
            var matchingMembers = personifyContext.GetMembershipData(new string[] { lastName, firstName, city, state, zip, country });
            return matchingMembers;
        }
    }
}
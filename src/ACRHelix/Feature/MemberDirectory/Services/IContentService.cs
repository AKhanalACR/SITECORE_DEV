using ACRHelix.Feature.MemberDirectory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.MemberDirectory.Services
{
    public interface IContentService
    {
        IMemberDirectory GetMemberDirectoryContent(string contentGuid);
        IEnumerable<ACR.Foundation.Personify.Models.Members.Member> SearchMembers(string firstName, string lastName, string city, string state, string zip, string country);
    }
}
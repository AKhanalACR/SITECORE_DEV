using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACR.Foundation.Personify.Models.Products;
using ACR.Foundation.Personify.Models.Taxonomy;

namespace ACR.Foundation.SSO.Profile
{
    public interface IAcrProfile
    {
      string FirstName { get; }
      string LastName { get; }
      string LabelName { get; }

      MemberStatus MemberStatus { get; }
      DateTime MemberSince { get; }
      string Action { get; }
      string ActionLink { get; }
      string Chapter { get; }
      string ChapterPortalUrl { get; }
      string EngageLink { get; }
      int MessagesCount { get; }
      string MitStatus { get; }
      decimal CmeCredits { get; }
      DateTime ProfileModifiedDate { get; }
      bool IsAcrStaff { get; }


      ICollection<ProductStubItem> PurchaseHistory { get; }
      ICollection<ProductStubItem> MeetingsList { get; }
      ICollection<KeyValuePair<string, string>> Committees { get; }
      bool DisplayCommitteesLink { get; }

      ICollection<PersonifyTaxonomyItem> Modalities { get; }
      ICollection<PersonifyTaxonomyItem> Subspecialities { get; }
      ICollection<PersonifyTaxonomyItem> Interests { get; }
      ICollection<PersonifyTaxonomyItem> Roles { get; }
    }
}

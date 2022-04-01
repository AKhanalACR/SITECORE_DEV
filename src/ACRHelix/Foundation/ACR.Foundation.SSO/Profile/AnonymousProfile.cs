using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACR.Foundation.Personify.Models.Products;
using ACR.Foundation.Personify.Models.Taxonomy;

namespace ACR.Foundation.SSO.Profile
{
  [Serializable]
  public class AnonymousProfile : IAcrProfile
  {
    private string _firstName = "";
    private string _lastName = "";
    private string _labelName = "";
    private string _mitStatus = "";
    private decimal _cmeCredits = 0;
    private ICollection<ProductStubItem> _purchaseHistory = new List<ProductStubItem>();
    private ICollection<PersonifyTaxonomyItem> _modalities = new List<PersonifyTaxonomyItem>();
    private ICollection<PersonifyTaxonomyItem> _subspecialties = new List<PersonifyTaxonomyItem>();
    private ICollection<PersonifyTaxonomyItem> _interests = new List<PersonifyTaxonomyItem>();
    private ICollection<PersonifyTaxonomyItem> _roles = new List<PersonifyTaxonomyItem>();
    private ICollection<KeyValuePair<string, string>> _committees = new List<KeyValuePair<string, string>>();
    private bool _displayCommitteesLink = false;
    private ICollection<ProductStubItem> _meetings = new List<ProductStubItem>();

    #region Implementation of IAcrProfile

    public string FirstName
    {
      get { return _firstName; }
    }

    public string LastName
    {
      get { return _lastName; }
    }

    public string LabelName
    {
      get { return _labelName; }
    }

    public MemberStatus MemberStatus
    {
      get { return MemberStatus.NonMember; }
    }

    public DateTime MemberSince
    {
      get { return DateTime.MinValue; }
    }

    public string Action
    {
      get { return string.Empty; }
    }

    public string ActionLink
    {
      get { return string.Empty; }
    }

    public string Chapter
    {
      get { return string.Empty; }
    }

    public string ChapterPortalUrl
    {
      get { return string.Empty; }
    }

    public string EngageLink
    {
      get { return string.Empty; }
    }

    public int MessagesCount
    {
      get { return 0; }
    }

    public string MitStatus
    {
      get { return _mitStatus; }
    }

    public decimal CmeCredits
    {
      get { return _cmeCredits; }
    }

    public DateTime ProfileModifiedDate
    {
      get { return DateTime.MinValue; }
    }

    public bool IsAcrStaff
    {
      get { return false; }
    }

    public ICollection<ProductStubItem> PurchaseHistory
    {
      get { return _purchaseHistory; }
    }

    public ICollection<ProductStubItem> MeetingsList
    {
      get { return _meetings; }
    }

    public ICollection<KeyValuePair<string, string>> Committees
    {
      get { return _committees; }
    }


    public bool DisplayCommitteesLink
    {
      get { return _displayCommitteesLink; }
    }

    public ICollection<PersonifyTaxonomyItem> Modalities
    {
      get { return _modalities; }
    }

    public ICollection<PersonifyTaxonomyItem> Subspecialities
    {
      get { return _subspecialties; }
    }

    public ICollection<PersonifyTaxonomyItem> Interests
    {
      get { return _interests; }
    }

    public ICollection<PersonifyTaxonomyItem> Roles
    {
      get { return _roles; }
    }

    #endregion
  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using ACR.Foundation.Personify.Cache;
using ACR.Foundation.Personify.Constants;
using ACR.Foundation.Personify.Models.Products;
using ACR.Foundation.Personify.Models.Taxonomy;
using ACR.Foundation.Personify.PersonifyService;
using ACR.Foundation.SSO.Logger;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using ACR.Foundation.Personify.Services;
using ACR.Foundation.Personify.ProductSearch;

namespace ACR.Foundation.SSO.Profile
{
  [Serializable]
  public class AcrUserProfile : IAcrProfile, ISerializable
  {
    private string _firstName = "";
    private string _lastName = "";
    private string _labelName = "";
    private MemberStatus _memberStatus = MemberStatus.NonMember;
    private DateTime _memberSince = DateTime.MinValue;
    private string _action = string.Empty;
    private string _actionLink = string.Empty;
    private string _chapter = string.Empty;
    private string _chapterPortalUrl = string.Empty;
    private string _engageLink = string.Empty;
    private int _messagesCount = 0;
    private string _mitStatus = "";
    private decimal _cmeCredits = 0;
    private DateTime _profileModified = DateTime.MinValue;
    private bool _isStaff;
    private ICollection<ProductStubItem> _purchaseHistory = new List<ProductStubItem>();
    private ICollection<PersonifyTaxonomyItem> _modalities = new List<PersonifyTaxonomyItem>();
    private ICollection<PersonifyTaxonomyItem> _subspecialties = new List<PersonifyTaxonomyItem>();
    private ICollection<PersonifyTaxonomyItem> _interests = new List<PersonifyTaxonomyItem>();
    private ICollection<PersonifyTaxonomyItem> _roles = new List<PersonifyTaxonomyItem>();
    private ICollection<KeyValuePair<string, string>> _committees = new List<KeyValuePair<string, string>>();
    private bool _displayCommitteesLink = false;
    //private ICollection<IMeeting> _meetings = new List<IMeeting>();
    private ICollection<ProductStubItem> _meetings = new List<ProductStubItem>();

    //private Personify.PersonifyDS.PdsCustomerInfo _customerInfo = new Personify.PersonifyDS.PdsCustomerInfo();

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
      get { return _memberStatus; }
    }

    public DateTime MemberSince
    {
      get { return _memberSince; }
    }

    public string Action
    {
      get { return _action; }
    }

    public string ActionLink
    {
      get { return _actionLink; }
    }

    public string Chapter
    {
      get { return _chapter; }
    }

    public string ChapterPortalUrl
    {
      get { return _chapterPortalUrl; }
    }

    public string EngageLink
    {
      get { return _engageLink; }
    }

    public int MessagesCount
    {
      get { return _messagesCount; }
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
      get { return _profileModified; }
    }

    public bool IsAcrStaff
    {
      get { return _isStaff; }
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

    #region Implementation of ISerializable

    internal class SerializationKeys
    {
      public const string FirstName = "AUP_FIRST";
      public const string LastName = "AUP_LAST";
      public const string LabelName = "AUP_LABEL";
      public const string MemberStatus = "AUP_STATUS";
      public const string MemberSince = "AUP_SINCE";
      public const string Action = "AUP_ACTION";
      public const string ActionLink = "AUP_ACTIONLINK";
      public const string Chapter = "AUP_CHAPTER";
      public const string ChapterPortalUrl = "AUP_CHAPTER_PORTAL_URL";
      public const string EngageLink = "AUP_ENGAGE_LINK";
      public const string MessagesCount = "AUP_MESSAGES_COUNT";
      public const string ProfileModified = "AUP_MODIFIED";
      public const string MitStatus = "AUP_MIT";
      public const string CmeCredits = "AUP_CME";
      public const string DisplayCommitteesLink = "AUP_DISP";
      public const string IsStaff = "AUP_STAFF";

      public const string PurchaseHistory = "AUP_PH";
      public const string Modalities = "AUP_MOD";
      public const string Subspecialities = "AUP_SUB";
      public const string Interests = "AUP_INT";
      public const string Committees = "AUP_COMS";
      public const string Meetings = "AUP_MEET";
      public const string Roles = "AUP_ROLES";
    }

    // Deserialization Constructor
    public AcrUserProfile(SerializationInfo info, StreamingContext ctxt)
    {
      // Basic members
      _firstName = info.GetString(SerializationKeys.FirstName);
      _lastName = info.GetString(SerializationKeys.LastName);
      _labelName = info.GetString(SerializationKeys.LabelName);
      _memberStatus = MemberStatusUtil.GetMemberStatus(info.GetString(SerializationKeys.MemberStatus));
      _memberSince = info.GetDateTime(SerializationKeys.MemberSince);
      _action = info.GetString(SerializationKeys.Action);
      _actionLink = info.GetString(SerializationKeys.ActionLink);
      _chapter = info.GetString(SerializationKeys.ActionLink);
      _chapterPortalUrl = info.GetString(SerializationKeys.ChapterPortalUrl);
      _engageLink = info.GetString(SerializationKeys.EngageLink);
      _messagesCount = info.GetInt32(SerializationKeys.MessagesCount);
      _profileModified = info.GetDateTime(SerializationKeys.ProfileModified);
      _mitStatus = info.GetString(SerializationKeys.MitStatus);
      _cmeCredits = info.GetDecimal(SerializationKeys.CmeCredits);
      _displayCommitteesLink = info.GetBoolean(SerializationKeys.DisplayCommitteesLink);
      _isStaff = info.GetBoolean(SerializationKeys.IsStaff);


      SitecoreContentService contentService = new SitecoreContentService();
      PersonifySitecoreService sitecoreService = new PersonifySitecoreService();

      // Purchase History
      string purchaseHistIds = (string)info.GetValue(SerializationKeys.PurchaseHistory, typeof(string));
      _purchaseHistory = GetItemsFromJoinedIdString(purchaseHistIds).Select(i => sitecoreService.GetProductStub(i)).ToList();

      // Modalities 
      string modalityIds = (string)info.GetValue(SerializationKeys.Modalities, typeof(string));
      _modalities = GetItemsFromJoinedIdString(modalityIds).Select(i => sitecoreService.GetPersonifyTaxonomyItem(i)).ToList();

      // Subspecialties
      string subspecIds = (string)info.GetValue(SerializationKeys.Subspecialities, typeof(string));
      _subspecialties = GetItemsFromJoinedIdString(subspecIds).Select(i => sitecoreService.GetPersonifyTaxonomyItem(i)).ToList();

      // Interests
      string interestIds = (string)info.GetValue(SerializationKeys.Interests, typeof(string));
      _interests = GetItemsFromJoinedIdString(interestIds).Select(i => sitecoreService.GetPersonifyTaxonomyItem(i)).ToList();

      // Roles
      string rolesIds = (string)info.GetValue(SerializationKeys.Roles, typeof(string));
      _roles = GetItemsFromJoinedIdString(rolesIds).Select(i => sitecoreService.GetPersonifyTaxonomyItem(i)).ToList();

      // Meetings
      string meetingIds = (string)info.GetValue(SerializationKeys.Meetings, typeof(string));
      _meetings = GetItemsFromJoinedIdString(meetingIds).Select(i => sitecoreService.GetProductStub(i)).Where(i => i != null).ToList();
      //TODO Must ReImplement!!!


      // Committees
      string committeePairs = (string)info.GetValue(SerializationKeys.Committees, typeof(string));
      if (!string.IsNullOrEmpty(committeePairs))
      {
        string[] split = committeePairs.Split('|');
        foreach (string pair in split)
        {
          string[] kv = pair.Split('*');
          if (kv.Length != 2)
          {
            continue;
          }
          _committees.Add(new KeyValuePair<string, string>(kv[0], kv[1]));
        }
      }
    }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      // Basic members
      info.AddValue(SerializationKeys.FirstName, FirstName);
      info.AddValue(SerializationKeys.LastName, LastName);
      info.AddValue(SerializationKeys.LabelName, LabelName);
      info.AddValue(SerializationKeys.MemberStatus, MemberStatus.ToSerializedString());
      info.AddValue(SerializationKeys.MemberSince, MemberSince);
      info.AddValue(SerializationKeys.Action, Action);
      info.AddValue(SerializationKeys.ActionLink, ActionLink);
      info.AddValue(SerializationKeys.Chapter, Chapter);
      info.AddValue(SerializationKeys.ChapterPortalUrl, ChapterPortalUrl);
      info.AddValue(SerializationKeys.EngageLink, EngageLink);
      info.AddValue(SerializationKeys.MessagesCount, MessagesCount);
      info.AddValue(SerializationKeys.ProfileModified, ProfileModifiedDate);
      info.AddValue(SerializationKeys.MitStatus, MitStatus);
      info.AddValue(SerializationKeys.CmeCredits, CmeCredits);
      info.AddValue(SerializationKeys.DisplayCommitteesLink, DisplayCommitteesLink);
      info.AddValue(SerializationKeys.IsStaff, IsAcrStaff);

      info.AddValue(SerializationKeys.PurchaseHistory,
        _purchaseHistory.Any()
        ? string.Join("|", _purchaseHistory.Select(i => i.ID.ToString()).ToArray())
        : string.Empty);

      info.AddValue(SerializationKeys.Modalities,
        _modalities.Any()
        ? string.Join("|", _modalities.Select(i => i.ID.ToString()).ToArray())
        : string.Empty);

      info.AddValue(SerializationKeys.Subspecialities,
        _subspecialties.Any()
        ? string.Join("|", _subspecialties.Select(i => i.ID.ToString()).ToArray())
        : string.Empty);

      info.AddValue(SerializationKeys.Interests,
        _interests.Any()
        ? string.Join("|", _interests.Select(i => i.ID.ToString()).ToArray())
        : string.Empty);

      info.AddValue(SerializationKeys.Roles,
        _roles.Any()
        ? string.Join("|", _roles.Select(i => i.ID.ToString()).ToArray())
        : string.Empty);

      info.AddValue(SerializationKeys.Meetings,
        _meetings.Any()
        //? string.Join("|", _meetings.Select(i => ((CustomItemBase)i).ID.ToString()).ToArray())
        ? string.Join("|", _meetings.Select(i => (i).ID.ToString()).ToArray())
        : string.Empty);

      info.AddValue(SerializationKeys.Committees,
        _committees.Any()
        ? string.Join("|", _committees.Select(k => string.Format("{0}*{1}", k.Key, k.Value)).ToArray())
        : string.Empty);

    }

    #endregion

    private IEnumerable<Item> GetItemsFromJoinedIdString(string joinedIds)
    {
      if (string.IsNullOrEmpty(joinedIds))
      {
        return new List<Item>();
      }

      var IDs = joinedIds.Split('|');
      if (!IDs.Any())
      {
        return new List<Item>();
      }

      var items = new List<Item>();

      foreach (string id in IDs)
      {
        if (!ID.IsID(id))
        {
          continue;
        }
        Item item = Sitecore.Context.Database.GetItem(id);
        if (item == null)
        {
          continue;
        }
        items.Add(item);
      }
      return items;
    }

    public AcrUserProfile(string masterCustomerId, string subCustomerId)
    {
      if (masterCustomerId == String.Empty)
      {
        Log.Warn("MasterCustomerId was not passed to AcrUserProfile constructor. StackTrace = " + Environment.StackTrace, this);
      }

      PersonifyEntitiesACR svc = new PersonifyEntitiesACR();
      SetProfileInfo(svc, masterCustomerId);
      SetMembershipInfo(svc, masterCustomerId);
      SetPurchaseHistory(svc, masterCustomerId);
      SetModalitiesAndSubspecialties(svc, masterCustomerId);
      SetInterests(svc, masterCustomerId);
      SetCommittees(svc, masterCustomerId);
      SetMeetingProducts(svc, masterCustomerId);
    }

    #region Personify profile service loaders

    private void SetProfileInfo(PersonifyEntitiesACR svc, string custId)
    {
      IList<Personify.PersonifyDS.CustomerInfo> custInfos;
      try
      {
        custInfos = svc.CustomerInfos.Where(c => c.MasterCustomerId == custId).ToList();
      }
      catch (Exception exc)
      {

        SSOLogger.Logger.Error("Error occured in Personify web service method, \"CustomerInfos\".  Could not retrieve User's Customer Info. Master ID = " + custId, exc);
        //Elmah.ErrorSignal.FromCurrentContext().Raise(exc);
        return;
      }

      var custInfo = custInfos.FirstOrDefault();
      if (custInfo != null)
      {
        _firstName = custInfo.FirstName;
        _lastName = custInfo.LastName;
        _labelName = custInfo.LabelName;
      }
    }

    


    private void SetMembershipInfo(PersonifyEntitiesACR svc, string custId)
    {
      IList<Personify.PersonifyDS.PdsCustomerInfo> members;
      try
      {
        members = svc.PdsCustomerInfos.Where(m => m.MasterCustomerId == custId).ToList();
      }
      catch (Exception exc)
      {
        SSOLogger.Logger.Error("Error occured in Personify web service method, \"CustomerInfos\".  Could not retrieve User's Customer Info. Master ID = " + custId, exc);
        //Elmah.ErrorSignal.FromCurrentContext().Raise(exc);
        return;
      }

      var member = members.FirstOrDefault();
      if (member != null)
      {      
        _memberStatus = MemberStatusUtil.GetMemberStatus(member.MemberStatus);
        _action = member.Action;
        _actionLink = member.ActionLink;
        _chapter = member.Chapter;
        _chapterPortalUrl = member.ChapterPortalUrl;
        _engageLink = member.EngageLink;
        _isStaff = member.Datacolumn2.ToLower() == "staff";

        if (!string.IsNullOrEmpty(member.Datacolumn3))
        {
          SetRoles(member.Datacolumn3);
        }
        if (member.InitialBeginDate.HasValue)
        {
          _memberSince = member.InitialBeginDate.Value;
        }
        if (member.LastUpdateDate.HasValue)
        {
          _profileModified = member.LastUpdateDate.GetValueOrDefault();
        }
        if (member.MitFlag.HasValue)
        {
          _mitStatus = member.MitFlag.GetValueOrDefault().ToString();
        }
        if (member.MessagesCount.HasValue)
        {
          _messagesCount = member.MessagesCount.GetValueOrDefault();
        }
        if (member.CECredits.HasValue)
        {
          _cmeCredits = member.CECredits.GetValueOrDefault();
        }
      }
    }

    private void SetPurchaseHistory(PersonifyEntitiesACR svc, string custId)
    {
      IList<Personify.PersonifyDS.PdsOrderInfo> productsInOrders;
      try
      {
        productsInOrders = svc.PdsOrderInfos.Where(o => o.MasterCustomerId == custId).ToList();
      }
      catch (Exception exc)
      {
        SSOLogger.Logger.Error("Error occured in Personify web service method, \"PdsMyOrders\". Could not retrieve User's purchase history. Master ID = " + custId, exc);
        //Elmah.ErrorSignal.FromCurrentContext().Raise(exc);
        return;
      }

      //replace this with a search index, preferrably Coveo!!
      if (productsInOrders.Any())
      {
        ProductSearchManager productSearchManager = new ProductSearchManager(ProductSearchManager.IndexEnum.Web);
        SitecoreContentService contentService = new SitecoreContentService();
        //ProductIndex index = new ProductIndex();
        foreach (var product in productsInOrders)
        {
          long? productId = product.ProductId;
          if (productId.HasValue)
          {
            SSOLogger.Logger.Error("Searching for product: " + productId.ToString() + ".  Need to recreate search / indexing");

            var pid = productSearchManager.GetProducts(productId.ToString()).FirstOrDefault();
            if (pid != null)
            {
              ProductStubItem stub = contentService.GetProductStub(pid.ItemId);
              if (stub != null)
              {
                _purchaseHistory.Add(stub);
              }
            }

          }
        }
      }
    }

    private void SetModalitiesAndSubspecialties(PersonifyEntitiesACR svc, string custId)
    {
      //set modalities
      Dictionary<string, PersonifyTaxonomyItem> modalityItems = ACRCache.GetFromCache(ItemConstants.TaxonomyFolders.Modalities.ToShortID().ToString(), GetModalities);
      Dictionary<string, PersonifyTaxonomyItem> subspecialtyItems = ACRCache.GetFromCache(ItemConstants.TaxonomyFolders.Subspecialties.ToShortID().ToString(), GetSubspecialties);

      IList<Personify.PersonifyDS.PdsCustomerModalitySpecialty> modalitiesSubspecialties;
      try
      {
        modalitiesSubspecialties = svc.PdsCustomerModalitySpecialties.Where(m => m.MasterCustomerId == custId).ToList();
      }
      catch (Exception exc)
      {
        SSOLogger.Logger.Error("Error occured in Personify web service method, \"PdsCustomerModalitySpecialties\". Could not retrieve User's modalities and subspecialties. Master ID = " + custId, exc);
        //Elmah.ErrorSignal.FromCurrentContext().Raise(exc);
        return;
      }

      if (modalitiesSubspecialties.Any())
      {
        foreach (var m in modalitiesSubspecialties)
        {
          string code = m.UserDefinedCustomerSpecialtyCode;

          if (m.UserDefinedSubscriptionMode.ToLower() == "modality")
          {
            if (modalityItems.ContainsKey(code))
            {
              _modalities.Add(modalityItems[code]);
            }
            else
            {
              SSOLogger.Logger.Warn("AcrUserProfile: Could not find modality item. UserDefinedCustomerSpecialtyCode = " + code);
            }
          }
          else if (m.UserDefinedSubscriptionMode.ToLower() == "subspecialty")
          {
            if (subspecialtyItems.ContainsKey(code))
            {
              _subspecialties.Add(subspecialtyItems[code]);
            }
            else
            {
              SSOLogger.Logger.Warn("AcrUserProfile: Could not find subspecialty item. UserDefinedCustomerSpecialtyCode = " + code);
            }
          }
        }
      }
    }

    private void SetInterests(PersonifyEntitiesACR svc, string custId)
    {
      Dictionary<string, PersonifyTaxonomyItem> interestItems = ACRCache.GetFromCache(ItemConstants.TaxonomyFolders.Interests.ToShortID().ToString(), GetInterests);

      IList<Personify.PersonifyDS.CustomerInterest> interests;
      try
      {
        interests = svc.CustomerInterests
          .Where(m => m.MasterCustomerId == custId)
          .ToList()
          .Where(m => m.OptedInFlag == true).ToList();
        // Crappy way to get around a bug in the service where we cannnot filter on OptedInFlag
      }
      catch (Exception exc)
      {
        SSOLogger.Logger.Error("Error occured in Personify web service method, \"CustomerInterests\". Could not retrieve User's interests. Master ID = " + custId, exc);
        //Elmah.ErrorSignal.FromCurrentContext().Raise(exc);
        return;
      }

      if (interests.Count() <= 0) return;

      foreach (var i in interests)
      {
        var personifyId = i.OptionShortSubName;
        if (interestItems.ContainsKey(personifyId))
        {
          _interests.Add(interestItems[personifyId]);
        }
      }
    }

    private void SetRoles(string roles)
    {
      Dictionary<string, PersonifyTaxonomyItem> rolesItems = ACRCache.GetFromCache(ItemConstants.TaxonomyFolders.Roles.ToShortID().ToString(), GetRoles);

      IEnumerable<string> individualRoles = roles.Split(',').Select(s => s.Trim().ToUpper()).ToList();

      if (!individualRoles.Any()) return;

      foreach (var id in individualRoles)
      {
        if (rolesItems.ContainsKey(id))
        {
          _roles.Add(rolesItems[id]);
        }
      }
    }

    private void SetCommittees(PersonifyEntitiesACR svc, string custId)
    {
      IList<KeyValuePair<string, string>> committees;
      try
      {
        //committees = svc.PdsMyCommittees
        //.Where(c => c.MasterCustomerId == custId)
        //.Select(c => new KeyValuePair<string, string>(c.CommitteeName, c.SharepointUrl)).ToList();
        List<Personify.PersonifyDS.PdsMyCommittee> tmpcommittees = svc.PdsMyCommittees
        .Where(c => c.MasterCustomerId == custId).ToList();

        committees = tmpcommittees.Select(c => new KeyValuePair<string, string>(c.CommitteeName, c.SharepointUrl)).ToList();

        _displayCommitteesLink = tmpcommittees.Any(c => !String.IsNullOrEmpty(c.SharepointUrl));
      }
      catch (Exception exc)
      {
        SSOLogger.Logger.Error("Error occured in Personify web service method, \"PdsMyCommittees\". Could not retrieve User's committees. Master ID = " + custId, exc);
        //Elmah.ErrorSignal.FromCurrentContext().Raise(exc);
        return;
      }

      _committees = committees;
    }

    private void SetMeetingProducts(PersonifyEntitiesACR svc, string custId)
    {
      IList<Personify.PersonifyDS.PdsMyMeeting> meetingProducts;
      try
      {
        meetingProducts = svc.PdsMyMeetings.Where(c => c.MasterCustomerId == custId).ToList();
      }
      catch (Exception exc)
      {
        SSOLogger.Logger.Error("Error occured in Personify web service method, \"PdsMyMeetings\". Could not retrieve User's meetings. Master ID = " + custId, exc);
        //Elmah.ErrorSignal.FromCurrentContext().Raise(exc);
        return;
      }

      //TODO replace this shit with a better search / indexing

      SSOLogger.Logger.Error("need to recreate Product / Meetings Index so can match user with Sitecore items, ACRUserProfile line 616");

      ProductSearchManager productSearchManager = new ProductSearchManager(ProductSearchManager.IndexEnum.Web);
      SitecoreContentService contentService = new SitecoreContentService();
      foreach (var m in meetingProducts)
      {
       var prod = productSearchManager.GetProducts(m.ToString()).FirstOrDefault();
        if (prod != null)
        {
          var productStub = contentService.GetProductStub(prod.ItemId);
          if (productStub != null)
          {
            _meetings.Add(productStub);
          }
        }
      }
        /*
        MeetingsIndex meetingsIndex = new MeetingsIndex();
          ProductIndex productIndex = new ProductIndex();
          foreach (var m in meetingProducts)
          {
            long productId = m.ProductId;
            ProductStubItem productStub = productIndex.GetProductsByID(productId.ToString()).FirstOrDefault();
            //productIndex.GetProduct(ProductStubItem.FieldName_PersonifyID, productId.ToString(), new SearchOptions());

            if (productStub != null)
            {
              //Check if there is a Course meeting summary page that has this product attached first, and add that item.
              //Otherwise, add the product stub item
              IMeeting meeting = meetingsIndex.GetMeeting(CourseMeetingSummaryItem.FieldName_Products, productStub.ID.ToString(), CourseMeetingSummaryItem.TemplateId);
              if (meeting != null)
              {
                _meetings.Add(meeting);
              }
              else
              {
                _meetings.Add(productStub);
              }
            }
          }*/

      }

    private Dictionary<string, PersonifyTaxonomyItem> GetModalities()
    {
      try
      {
        SitecoreContentService contentService = new SitecoreContentService();

        var modalityRoot = contentService.GetTaxonomyFolder(ItemConstants.TaxonomyFolders.Modalities);

        //var items = modalityRoot.TaxonomyItems.Select(x => (PersonifyTaxonomyItem)x);
        /*
        IEnumerable<PersonifyTaxonomyItem> items = ItemReference.ACR_Taxonomy_ModalitiesRoot.InnerItem.GetChildren()
          .Where(t => t != null && SitecoreUtils.IsValid(PersonifyTaxonomyItem.TemplateId, t))
          .Select(t => (PersonifyTaxonomyItem)t);
          */
        Dictionary<string, PersonifyTaxonomyItem> dict = new Dictionary<string, PersonifyTaxonomyItem>();
        foreach (var personifyTaxonomyItem in modalityRoot.TaxonomyItems)
        {
          if (!dict.ContainsKey(personifyTaxonomyItem.PersonifyID))
          {
            dict.Add(personifyTaxonomyItem.PersonifyID, personifyTaxonomyItem);
          }
        }
        return dict;
      }
      catch (Exception exc)
      {
        SSOLogger.Logger.Error("Could not get dictionary of Modalities.", exc);
        //Elmah.ErrorSignal.FromCurrentContext().Raise(exc);
        return new Dictionary<string, PersonifyTaxonomyItem>();
      }


    }

    private Dictionary<string, PersonifyTaxonomyItem> GetSubspecialties()
    {
      try
      {
        SitecoreContentService contentService = new SitecoreContentService();
        /*
        IEnumerable<PersonifyTaxonomyItem> items = ItemReference.ACR_Taxonomy_SubspecialtiesRoot.InnerItem.GetChildren()
            .Where(t => t != null && SitecoreUtils.IsValid(PersonifyTaxonomyItem.TemplateId, t))
            .Select(t => (PersonifyTaxonomyItem)t);
            */
        var subSpecialtyRoot = contentService.GetTaxonomyFolder(ItemConstants.TaxonomyFolders.Subspecialties);
        //var items = subSpecialtyRoot.TaxonomyItems.Select(x => (PersonifyTaxonomyItem)x);

        Dictionary<string, PersonifyTaxonomyItem> dict = new Dictionary<string, PersonifyTaxonomyItem>();
        foreach (var personifyTaxonomyItem in subSpecialtyRoot.TaxonomyItems)
        {
          if (!dict.ContainsKey(personifyTaxonomyItem.PersonifyID))
          {
            dict.Add(personifyTaxonomyItem.PersonifyID, personifyTaxonomyItem);
          }
        }
        return dict;
      }
      catch (Exception exc)
      {
        SSOLogger.Logger.Error("Could not get dictionary of Subspecialties.", exc);
        //Elmah.ErrorSignal.FromCurrentContext().Raise(exc);
        return new Dictionary<string, PersonifyTaxonomyItem>();
      }

    }

    private Dictionary<string, PersonifyTaxonomyItem> GetInterests()
    {
      try
      {
        SitecoreContentService contentService = new SitecoreContentService();

        var interestRoot = contentService.GetTaxonomyFolder(ItemConstants.TaxonomyFolders.Interests);

        //var items = interestRoot.TaxonomyItems.Select(x => (PersonifyTaxonomyItem)x);
        /*
        IEnumerable<PersonifyTaxonomyItem> items = ItemReference.ACR_Taxonomy_InterestsRoot.InnerItem.GetChildren()
            .Where(t => t != null && SitecoreUtils.IsValid(PersonifyTaxonomyItem.TemplateId, t))
            .Select(t => (PersonifyTaxonomyItem)t);*/
        Dictionary<string, PersonifyTaxonomyItem> dict = new Dictionary<string, PersonifyTaxonomyItem>();
        foreach (var personifyTaxonomyItem in interestRoot.TaxonomyItems)
        {
          if (!dict.ContainsKey(personifyTaxonomyItem.PersonifyID))
          {
            dict.Add(personifyTaxonomyItem.PersonifyID, personifyTaxonomyItem);
          }
        }
        return dict;
      }
      catch (Exception exc)
      {
        SSOLogger.Logger.Error("Could not get dictionary of Interests.", exc);
        //Elmah.ErrorSignal.FromCurrentContext().Raise(exc);
        return new Dictionary<string, PersonifyTaxonomyItem>();
      }
    }

    private Dictionary<string, PersonifyTaxonomyItem> GetRoles()
    {
      try
      {
        SitecoreContentService contentService = new SitecoreContentService();
        var rolesRoot = contentService.GetTaxonomyFolder(ItemConstants.TaxonomyFolders.Roles);
        /*
        IEnumerable<PersonifyTaxonomyItem> items = ItemReference.ACR_Taxonomy_RolesRoot.InnerItem.GetChildren()
          .Where(t => t != null && SitecoreUtils.IsValid(PersonifyTaxonomyItem.TemplateId, t))
          .Select(t => (PersonifyTaxonomyItem)t);*/

        //var items = rolesRoot.TaxonomyItems.Select(x => (PersonifyTaxonomyItem)x);
        Dictionary<string, PersonifyTaxonomyItem> dict = new Dictionary<string, PersonifyTaxonomyItem>();
        foreach (var personifyTaxonomyItem in rolesRoot.TaxonomyItems)
        {
          if (!dict.ContainsKey(personifyTaxonomyItem.PersonifyID))
          {
            dict.Add(personifyTaxonomyItem.PersonifyID, personifyTaxonomyItem);
          }
        }
        return dict;
      }
      catch (Exception exc)
      {
        SSOLogger.Logger.Error("Could not get dictionary of Roles.", exc);
        //Elmah.ErrorSignal.FromCurrentContext().Raise(exc);
        return new Dictionary<string, PersonifyTaxonomyItem>();
      }
    }
    #endregion
  }
}
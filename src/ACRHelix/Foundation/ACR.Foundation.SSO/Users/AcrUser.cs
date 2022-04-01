using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACR.Foundation.Personify.Models;
using ACR.Foundation.Personify.Models.Products;
using ACR.Foundation.Personify.Models.Taxonomy;
using ACR.Foundation.SSO.Profile;
using ACR.Foundation.Utilities.Session;
using RequiredAccess = ACR.Foundation.Personify.Constants.Templates.AcrProtectedContent.RequiredAccess;
using ACR.Foundation.SSO.Logger;
using ACR.Foundation.Personify.PersonifyService;

namespace ACR.Foundation.SSO.Users
{
  [Serializable]
  public class AcrUser : IAcrUser
  {
    public AcrUser(string masterCustomerId, string subCustomerId)
    {
      _masterCustomerId = masterCustomerId;
      _subCustomerId = (subCustomerId == "") ? "0" : subCustomerId;
    }

    public AcrUser(string masterCustomerId, string subCustomerId, bool isInternationalUser)
    {
      _masterCustomerId = masterCustomerId;
      _subCustomerId = (subCustomerId == "") ? "0" : subCustomerId;
      _isInternationalUser = isInternationalUser;

    }
    private string _masterCustomerId;
    private string _subCustomerId;
    private bool _isInternationalUser;
    private const string CurrentUserProfileSessionKey = "f599f85a-a105-4081-8f3a-90607e2199b7";

    #region Implementation of IAcrUser

    public bool IsAnonymous
    {
      get { return false; }
    }

    public bool IsAuthenticated
    {
      get { return true; }
    }

    public bool IsAcrMember
    {
      get { return Profile != null && Profile.MemberStatus == MemberStatus.Active; }
    }
    public bool IsInternationalUser
    {
      get { return _isInternationalUser; }
    }
    public string MasterCustomerID
    {
      get { return _masterCustomerId; }
    }

    public string SubCustomerID
    {
      get { return _subCustomerId; }
    }

    private IAcrProfile _profile;
    public IAcrProfile Profile
    {
      get
      {
        if (_profile == null)
        {
          // try to get from session
          _profile = SessionManager.GetSessionValue<IAcrProfile>(CurrentUserProfileSessionKey);
          // if still null make a new profile and set it into session
          if (_profile == null)
          {
            _profile = new AcrUserProfile(MasterCustomerID, SubCustomerID);
            SessionManager.SetSessionValue(CurrentUserProfileSessionKey, _profile);
          }
        }
        return _profile;
      }
      private set
      {
        _profile = value;
        SessionManager.SetSessionValue(CurrentUserProfileSessionKey, _profile);
      }
    }

    public Personify.PersonifyDS.PdsCustAddrInfo GetCustAddrInfo(){
      IList<Personify.PersonifyDS.PdsCustAddrInfo> members;
      try
      {
        PersonifyEntitiesACR svc = new PersonifyEntitiesACR();
        members = svc.PdsCustAddrInfos.Where(m => m.MasterCustomerId == MasterCustomerID).ToList();
      }
      catch (Exception exc)
      {
        SSOLogger.Logger.Error("Error occured in Personify web service method, \"CustomerInfos\".  Could not retrieve User's address Info. Master ID = " + MasterCustomerID, exc);
        //Elmah.ErrorSignal.FromCurrentContext().Raise(exc);
        return null;
      }

      var member = members.FirstOrDefault();
      if (member != null)
      {
        return member;
      }
      return null;
    }

    public KeyValuePair<bool,double> GetACRCMECredits()
    {
      PersonifyEntitiesACR svc = new PersonifyEntitiesACR();
      return svc.GetACRCMECredits(MasterCustomerID);
    }

    public Personify.PersonifyDS.PdsCustMbrAddrInfo GetCustMbrAddrInfo()
    {
      IList<Personify.PersonifyDS.PdsCustMbrAddrInfo> members;
      try
      {
        PersonifyEntitiesACR svc = new PersonifyEntitiesACR();
        members = svc.PdsCustMbrAddrInfos.Where(m => m.MasterCustomerId == MasterCustomerID).ToList();
      }
      catch (Exception exc)
      {
        SSOLogger.Logger.Error("Error occured in Personify web service method, \"CustomerInfos\".  Could not retrieve User's mbraddress Info. Master ID = " + MasterCustomerID, exc);
        //Elmah.ErrorSignal.FromCurrentContext().Raise(exc);
        return null;
      }

      var member = members.FirstOrDefault();
      if (member != null)
      {
        return member;
      }
      return null;
    }


    public Personify.PersonifyDS.PdsCustomerInfo GetRawCustomerInfo()
    {
      IList<Personify.PersonifyDS.PdsCustomerInfo> members;
      try
      {
        PersonifyEntitiesACR svc = new PersonifyEntitiesACR();
        members = svc.PdsCustomerInfos.Where(m => m.MasterCustomerId == MasterCustomerID).ToList();
      }
      catch (Exception exc)
      {
        SSOLogger.Logger.Error("Error occured in Personify web service method, \"CustomerInfos\".  Could not retrieve User's Customer Info. Master ID = " + MasterCustomerID, exc);
        //Elmah.ErrorSignal.FromCurrentContext().Raise(exc);
        return null;
      }

      var member = members.FirstOrDefault();
      if (member != null)
      {
        return member;
      }
      return null;
    }

    public bool IsEntitled(AcrProtectedContent contentItem)
    {
      bool hasProducts = contentItem.RequiredProducts.Any();
      bool hasRoles = contentItem.RequiredRoles.Any();

      // First check that the content has access requirements
      if (contentItem.RequiredAccess == RequiredAccess.None
        && !hasProducts
        && !hasRoles)
      {
        return true;
      }

      if (IsAuthenticated)
      {
        bool loginValid = false;
        bool productsValid = true;
        bool rolesValid = true;

        //acr staff can always see everything
        if (Profile.IsAcrStaff)
        {
          return true;
        }

        if (contentItem.RequiredAccess == RequiredAccess.ACRMembershipRequired && IsAcrMember)
        {
          loginValid = true;
        }
        if (contentItem.RequiredAccess == RequiredAccess.AuthenticationRequired && IsAuthenticated)
        {
          loginValid = true;
        }

        if (contentItem.RequiredProducts.Any())
        {
          productsValid = false;
          foreach (ProductStubItem product in contentItem.RequiredProducts)
          {
            if (Profile.PurchaseHistory.Contains(product))
            {
              productsValid = true;
            }
          }
        }

        if (contentItem.RequiredRoles.Any())
        {
          rolesValid = false;
          foreach (PersonifyTaxonomyItem role in contentItem.RequiredRoles)
          {
            if (Profile.Roles.Contains(role))
            {
              rolesValid = true;
            }
          }
        }
        //no roles or products
        if (!hasRoles && !hasProducts)
        {
          return loginValid;
        }

        //no roles
        if (!hasRoles)
        {
          return loginValid && productsValid;
        }

        //no products
        if (!hasProducts)
        {
          return loginValid && rolesValid;
        }

        //roles and products
        if (hasRoles && hasProducts)
        {      
          //only roles or products must be valid 
            if (rolesValid && loginValid)
            {
              return true;
            }
            if (productsValid && loginValid)
            {
              return true;
            }          
        }
      }
      // No conditions match, return false
      return false;
    }

    /// <summary>
    /// Clear the profile to force it to reload.
    /// </summary>
    public void ClearProfile()
    {
      _profile = null;
      SessionManager.SetSessionValue(CurrentUserProfileSessionKey, null);
    }

    #endregion
  }
}
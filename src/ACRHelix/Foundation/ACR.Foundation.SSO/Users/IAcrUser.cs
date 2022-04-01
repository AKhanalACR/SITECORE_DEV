using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACR.Foundation.Personify.Models;
using ACR.Foundation.SSO.Profile;

namespace ACR.Foundation.SSO.Users
{
  public interface IAcrUser
  {
    bool IsAnonymous { get; }
    bool IsAuthenticated { get; }
    bool IsAcrMember { get; }
    string MasterCustomerID { get; }
    string SubCustomerID { get; }
    bool IsInternationalUser { get; }

    IAcrProfile Profile { get; }

    /// <summary>
    /// Returns true if the user is entitled to view the content item.
    /// </summary>
    /// <param name="contentItem"></param>
    /// <returns></returns>
    bool IsEntitled(AcrProtectedContent contentItem);
    Personify.PersonifyDS.PdsCustomerInfo GetRawCustomerInfo();
    Personify.PersonifyDS.PdsCustMbrAddrInfo GetCustMbrAddrInfo();
    Personify.PersonifyDS.PdsCustAddrInfo GetCustAddrInfo();

    KeyValuePair<bool,double> GetACRCMECredits();
    /// <summary>
    /// Clears the user's profile, forcing a reload next time it is referenced.
    /// </summary>
    void ClearProfile();
  }
}
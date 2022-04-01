using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACR.Foundation.SSO.UserContext;

namespace ACR.Foundation.SSO.Users
{
  public static class UserManager
  {
    public static bool FakeUserMode
    {
      //get { return SessionManager.GetSessionValue<bool>(SessionManager.UserManagerTestModeKey); }
      //set { SessionManager.SetSessionValue(SessionManager.UserManagerTestModeKey, value); }
      get
      {
        return false;
      }

    }

    /// <summary>
    /// Gets the user context. This can be switched between the testing stub and the real user implementation.
    /// </summary>
    /// <returns></returns>
    public static IUserContext CurrentUserContext
    {
      get
      {
        return new AcrUserContext();
        /*
        if (!FakeUserMode)
        {
          return new AcrUserContext();
        }
        else
        {
          return new UserContextStub();
        }*/
      }
    }
  }
}
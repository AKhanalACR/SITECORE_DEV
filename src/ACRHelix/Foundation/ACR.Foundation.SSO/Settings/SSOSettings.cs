using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ACR.Foundation.SSO.Settings
{
  public static class SSOSettings
  {
    private const string SectionName = "SSOSettings";

    private static NameValueCollection ConfigurationSection
    {
      get
      {
        return (NameValueCollection)ConfigurationManager.GetSection(SectionName);
      }
    }

    public static string SSOCustomerTokenParam
    {
      get
      {
        return ConfigurationSection["SSOCustomerTokenParam"] ?? "CT";
      }
    }

    public static string SSOVendorIdentifierParam
    {
      get
      {
        return ConfigurationSection["SSOVendorIdentifierParam"] ?? "vi";
      }
    }

    public static string SSOVendorTokenParam
    {
      get
      {
        return ConfigurationSection["SSOVendorTokenParam"] ?? "vt";
      }
    }

    public static string SSOLoggedIn
    {
      get
      {
        return ConfigurationSection["SSOLoggedIn"] ?? "ssologgedin";
      }
    }

    public static string SSOUsernameParam
    {
      get
      {
        return ConfigurationSection["SSOUsernameParam"] ?? "uname";
      }
    }

    public static string SSOPasswordParam
    {
      get
      {
        return ConfigurationSection["SSOPasswordParam"] ?? "password";
      }
    }

    public static string LoginRedirectUrlKey
    {
      get
      {
        return ConfigurationSection["LoginRedirectUrlKey"] ?? "579d4714-bd40-4119-ac06-0f5d3547da61";
      }
    }


    public static string AcrAuthVendorUsername
    {
      get
      {
        return ConfigurationSection["AcrAuth.VendorUsername"];
      }
    }

    public static string AcrAuthVendorPassword
    {
      get
      {
        return ConfigurationSection["AcrAuth.VendorPassword"];
      }
    }

    public static string AcrAuthVendorBlock
    {
      get
      {
        return ConfigurationSection["AcrAuth.VendorBlock"];
      }
    }
    public static string AcrAuthVendorIdentifier
    {
      get
      {
        return ConfigurationSection["AcrAuth.VendorIdentifier"];
      }
    }

    public static string AcrAuthSSOWebReferenceURL
    {
      get
      {
        return ConfigurationSection["AcrAuth.SSOWebReferenceURL"];
      }
    }

    public static string AcrAuthSSOLoginURL
    {
      get
      {
        return ConfigurationSection["AcrAuth.SSOLoginURL"];
      }
    }

  }
}
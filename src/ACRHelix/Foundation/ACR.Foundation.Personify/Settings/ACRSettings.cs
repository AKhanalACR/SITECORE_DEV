using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ACR.Foundation.Personify.Settings
{
  public static class ACRSettings
  {
    private const string SectionName = "ACRSettings";

    private static NameValueCollection ConfigurationSection
    {
      get
      {
        return (NameValueCollection)ConfigurationManager.GetSection(SectionName);
      }
    }

    public static string PersonifyServiceUrl
    {
      get
      {
        return ConfigurationSection["PersonifyServiceUrl"] ?? "https://personifyds75.acr.org/PersonifyDataACR.svc";
      }
    }

    public static string PersonifyServiceUser
    {
      get
      {
        return ConfigurationSection["PersonifyServiceUser"] ?? "pdsuser";
      }
    }

    public static string PersonifyServicePass
    {
      get
      {
        return ConfigurationSection["PersonifyServicePass"] ?? "pds#$12";
      }
    }

    public static string AcrShopUrl
    {
      get
      {
        return ConfigurationSection["AcrShopUrl"] ?? "https://shop.acr.org";
      }
    }

    public static string LogOffUrl
    {
      get
      {
        return AcrShopUrl + (ConfigurationSection["LogOffUrl"].Replace("&amp;","&") ?? "/default.aspx?ctl=logoff&returnurl=");
      }
    }

    public static string RenewMembershipLink
    {
      get
      {
        return AcrShopUrl + (ConfigurationSection["RenewMembershipLink"] ?? "/MyACR/MYMEMBERSHIP.aspx");
      }
    }

    public static string BecomeAMemberLink
    {
      get
      {
        return AcrShopUrl + (ConfigurationSection["BecomeAMemberLink"] ?? "/ACRMembership/ACRMembershipType.aspx");
      }
    }

    public static string AcrImagePath
    {
      get
      {
        return ConfigurationSection["AcrImagePath"] ?? "/images/productimages/";
      }
    }

    public static string ShoppingCartUrl
    {
      get
      {
        return AcrShopUrl + (ConfigurationSection["ShoppingCartUrl"] ?? "/Default.aspx?TabId=57");
      }
    }

    public static string ProductUrlRoot
    {
      get
      {
        return AcrShopUrl + ConfigurationSection["ProductUrlRoot"] ?? "/Default.aspx?TabId=55";
      }
    }

    public static string CourseMeetingUrlRoot
    {
      get
      {
        return AcrShopUrl + ConfigurationSection["CourseMeetingUrlRoot"] ?? "/Default.aspx?TabId=235";
      }
    }

    public static string PhysicistQuickLinkTitle
    {
      get
      {
        return ConfigurationSection["PhysicistQuickLinkTitle"] ?? "Medical Physicist Resources";
      }
    }

    public static string PhysicistQuickLinkURL
    {
      get
      {
        return ConfigurationSection["PhysicistQuickLinkURL"] ?? "https://www.acr.org/Clinical-Resources/Medical-Physics-Resources";
      }
    }

    public static string PersonifyExclude
    {
      get
      {
        return ConfigurationSection["PersonifyExclude"] ?? string.Empty;
      }
    }
  }
}
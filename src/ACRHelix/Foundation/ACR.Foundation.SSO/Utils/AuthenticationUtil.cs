using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using ACR.Foundation.Personify.Settings;
using ACR.Foundation.SSO.AcrAuthentication.SSO;
using ACR.Foundation.SSO.Logger;
using ACR.Foundation.SSO.Settings;
using ACR.Foundation.Utilities.Url;

namespace ACR.Foundation.SSO.Utils
{
  public static class AuthenticationUtil
  {
    /// <summary>
		/// Validates the supplied credentials with the SSO service
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		public static SSOCustomerAuthenticateResult Authenticate(string username, string password)
    {
      if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
      {
        return new SSOCustomerAuthenticateResult() { Result = false };
      }

      SSOLogger.Logger.Info("LOGIN AUDIT: Getting ready to call soap service.");
      using (serviceSoapClient wsLoginSSO = new serviceSoapClient())
      {
        SSOLogger.Logger.Info("LOGIN AUDIT: About to call wsLoginSSO.SSOCustomerAuthenticate.");
        var result = wsLoginSSO.SSOCustomerAuthenticate(SSOSettings.AcrAuthVendorUsername,
                    SSOSettings.AcrAuthVendorPassword, username, password);
        SSOLogger.Logger.Info("LOGIN AUDIT: Response from wsLoginSSO.SSOCustomerAuthenticate.");
        return result;
      }
    }

    public static SSOCustomerTokenIsValidResult ValidateCustomerToken(string token)
    {
      if (string.IsNullOrEmpty(token))
      {
        return new SSOCustomerTokenIsValidResult() { Valid = false };
      }
      using (serviceSoapClient wsLoginSSO = new serviceSoapClient())
      {
        var result = wsLoginSSO.SSOCustomerTokenIsValid(SSOSettings.AcrAuthVendorUsername,
          SSOSettings.AcrAuthVendorPassword, token);
        return result;
      }
    }

    /// <summary>
    /// Decrypts and parses out the customer token if it exists from a Request
    /// First, it checks the url params, then checks the request cookies.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public static string GetCustomerToken(HttpRequest request)
    {
      if (request == null)
      {
        return string.Empty;
      }
      string customerToken = string.Empty;
      // Check the url
      if (!string.IsNullOrEmpty(request[SSOSettings.SSOCustomerTokenParam]))
      {
        customerToken = DecryptCustomerToken(request[SSOSettings.SSOCustomerTokenParam]);
      }

      return customerToken;
    }

    public static SSOCustomerLogoutResult Logout(string customerToken)
    {
      if (string.IsNullOrEmpty(customerToken))
      {
        return new SSOCustomerLogoutResult() { };
      }
      using (serviceSoapClient wsLoginSSO = new serviceSoapClient())
      {
        var result = wsLoginSSO.SSOCustomerLogout(SSOSettings.AcrAuthVendorUsername,
          SSOSettings.AcrAuthVendorPassword, customerToken);
        return result;
      }
    }

    #region User Cookies

    private const string CustomerTokenCookieKey = "1abaca4b-e304-400a-9787-473957dcc053";
    private const string CustomerIdCookieKey = "ACRICookie";
    private const string CustomerRememberMeCookieKey = "051ed7d9-2402-4884-ab97-515752b38752";
    private const string UpdateProfileCookieKey = "IsACRProfileUpdated";
    private const string AcrCookieDomain = ".acr.org";

    private static string ReadCookie(HttpRequest request, string key)
    {
      if (request == null || string.IsNullOrEmpty(key))
      {
        return string.Empty;
      }
      HttpCookie cookie = request.Cookies[key];
      if (cookie == null)
      {
        return string.Empty;
      }
      return cookie.Value;
    }

    private static void WriteCookie(HttpResponse response, string key, string value, string domain, bool persist)
    {
      if (response == null || string.IsNullOrEmpty(key))
      {
        return;
      }

      HttpCookie cookie = new HttpCookie(key);
      cookie.Secure = true;
      cookie.Value = value;
      if (persist)
      {
        cookie.Expires = DateTime.Now.AddYears(1);
      }
      if (!string.IsNullOrEmpty(domain))
      {
        cookie.Domain = domain;
      }
      response.Cookies.Add(cookie);
    }

    private static void DeleteCookie(HttpResponse response, string key, string domain)
    {
      if (response == null || string.IsNullOrEmpty(key))
      {
        return;
      }
      HttpCookie cookie = new HttpCookie(key);
      cookie.Value = string.Empty;
      cookie.Expires = DateTime.Now.AddDays(-1);
      if (!string.IsNullOrEmpty(domain))
      {
        cookie.Domain = domain;
      }
      response.Cookies.Add(cookie);
    }

    //public static string ReadCustomerTokenCookie(HttpRequest request)
    //{
    //  return ReadCookie(request, CustomerTokenCookieKey);
    //}

    //public static void WriteCustomerTokenCookie(HttpResponse response, string customerToken, bool persist)
    //{
    //  WriteCookie(response, CustomerTokenCookieKey, customerToken, null, false);
    //}

    //public static void DeleteCustomerTokenCookie(HttpResponse response)
    //{
    //  DeleteCookie(response, null, CustomerTokenCookieKey);
    //}

    public static string ReadCustomerIdCookie(HttpRequest request)
    {
      return ReadCookie(request, CustomerIdCookieKey);
    }

    public static void DeleteCustomerIdCookie(HttpResponse response)
    {
      DeleteCookie(response, CustomerIdCookieKey, AcrCookieDomain);
    }

    public static string ReadCustomerRememberMeCookie(HttpRequest request)
    {
      return ReadCookie(request, CustomerRememberMeCookieKey);
    }

    public static void WriteCustomerRememberMeCookie(HttpResponse response, string customerName, bool persist)
    {
      WriteCookie(response, CustomerRememberMeCookieKey, customerName, null, true);
    }

    public static void DeleteCustomerRememberMeCookie(HttpResponse response)
    {
      DeleteCookie(response, CustomerRememberMeCookieKey, null);
    }

    public static string ReadUpdateProfileCookie(HttpRequest request)
    {
      return ReadCookie(request, UpdateProfileCookieKey);
    }

    public static void WriteUpdateProfileCookie(HttpResponse response)
    {
      WriteCookie(response, UpdateProfileCookieKey, "NO", AcrCookieDomain, false);
    }

    #endregion

    /// <summary>
    /// Gets an encrypted vendor token to pass to the SSO login page.
    /// </summary>
    /// <param name="returnUrl">The url the SSO page should redirect to upon authentication.</param>
    /// <returns></returns>
    public static string GetVendorToken(string returnUrl)
    {
      if (string.IsNullOrEmpty(returnUrl))
      {
        return string.Empty;
      }
      if (returnUrl.Contains(":443"))
      {
        returnUrl = returnUrl.Replace(":443", "");
      }
      return Encrypt(GetTimeStamp() + "|" + returnUrl,
        SSOSettings.AcrAuthVendorPassword, SSOSettings.AcrAuthVendorBlock);
    }

    /// <summary>
    /// Builds a URL for SSO authentication.
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <param name="returnUrl">The url the SSO page should redirect to upon authentication.</param>
    /// <param name="noPrompt">True to inlude DPLF=Y in the url so the user is not prompted to log in on a failed login attempt.</param>
    /// <returns></returns>
    public static string ConstructSSOUrl(string username, string password, string returnUrl, bool noPrompt)
    {
      var options = HttpUtility.ParseQueryString("");

      // Add vendor identifier
      options.Add(SSOSettings.SSOVendorIdentifierParam, SSOSettings.AcrAuthVendorIdentifier);
      // Add vendor token
      string vendorToken = GetVendorToken(returnUrl);
      options.Add(SSOSettings.SSOVendorTokenParam, vendorToken);

      // Add username & pass
      if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
      {
        options.Add(SSOSettings.SSOUsernameParam, Encrypt(username));
        options.Add(SSOSettings.SSOPasswordParam, Encrypt(password));
      }
      if (noPrompt)
      {
        options.Add("DPLF", "Y");
      }

      // Build url
      string loginurl = UrlUtil.CreateUrl(SSOSettings.AcrAuthSSOLoginURL, options);

      //string strLoginurl = ACRSettings.AcrAuthSSOLoginURL + "?vi=" + ACRSettings.AcrAuthVendorIdentifier + "&vt=" + vendorToken;
      return loginurl;
    }


    public static string ConstructSSOUrlWithPrompt(string returnUrl)
    {
      var options = HttpUtility.ParseQueryString("");

      // Add vendor identifier
      options.Add(SSOSettings.SSOVendorIdentifierParam, SSOSettings.AcrAuthVendorIdentifier);
      // Add vendor token
      string vendorToken = GetVendorToken(returnUrl);
      options.Add(SSOSettings.SSOVendorTokenParam, vendorToken);

      // Add username & pass
      //if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
      //{
      //    options.Add(SSOSettings.SSOUsernameParam, Encrypt(username));
      //    options.Add(SSOSettings.SSOPasswordParam, Encrypt(password));
      //}
      //if (noPrompt)
      //{
      //    //options.Add("DPLF", "Y");
      //}

      // Build url
      string loginurl = UrlUtil.CreateUrl(SSOSettings.AcrAuthSSOLoginURL, options);

      //string strLoginurl = ACRSettings.AcrAuthSSOLoginURL + "?vi=" + ACRSettings.AcrAuthVendorIdentifier + "&vt=" + vendorToken;
      return loginurl;
    }

    public static string GetVendorCustomerId(string customerToken)
    {
      using (serviceSoapClient wsLoginSSO = new serviceSoapClient())
      {
        VendorSSOCustomerIdentifierGetResult objCustomer =
          wsLoginSSO.VendorSSOCustomerIdentifierGet(SSOSettings.AcrAuthVendorUsername, SSOSettings.AcrAuthVendorPassword,
                                                    customerToken);
        if (objCustomer == null || objCustomer.CustomerIdentifier == null)
        {
          return string.Empty;
        }
        return objCustomer.CustomerIdentifier;
      }
    }

    public static string GetSSOUserName(string customerToken)
    {
      using (serviceSoapClient wsLoginSSO = new serviceSoapClient())
      {
        SSOCustomerGetResult wsSSOEmailResult =
          wsLoginSSO.SSOCustomerGetByCustomerToken(SSOSettings.AcrAuthVendorUsername, SSOSettings.AcrAuthVendorPassword, customerToken);
        if (wsSSOEmailResult.Errors == null)
        {
          return wsSSOEmailResult.UserName;
        }
        return "";
      }
    }

        public static string GetSSOUserCutomerId(string customerToken)
        {
            if (!string.IsNullOrEmpty(customerToken))
            {
                using (serviceSoapClient wsLoginSSO = new serviceSoapClient())
                {
                    //CustomerTokenDecryptResult decCt = wsLoginSSO.CustomerTokenDecrypt(SSOSettings.AcrAuthVendorUsername, SSOSettings.AcrAuthVendorPassword, SSOSettings.AcrAuthVendorBlock, customerToken);
                    //SSOCustomerTokenIsValidResult validCt = wsLoginSSO.SSOCustomerTokenIsValid(SSOSettings.AcrAuthVendorUsername, SSOSettings.AcrAuthVendorPassword, customerToken);
                    TIMSSCustomerIdentifierGetResult identifier = wsLoginSSO.TIMSSCustomerIdentifierGet(SSOSettings.AcrAuthVendorUsername, SSOSettings.AcrAuthVendorPassword, customerToken);
                    var customerId = identifier.CustomerIdentifier;
                    if (identifier.Errors == null)
                    {
                        return customerId = customerId.Remove(customerId.IndexOfAny(new char[] { '|' })); ;
                    }
                    return "";
                }
            }
            return "";
        }

        #region Helper Methods

        /*
        public static bool IsInternationalUser(string masterCustID)
        {
          SimpleWebService simplWS = new SimpleWebService();
          string countryCode = simplWS.getCountry(masterCustID);

          if (countryCode.ToUpper() == "USA" || countryCode.ToUpper() == "CAN")
            return false;

          return true;
        }*/
        private static string DecryptCustomerToken(string encryptedToken)
    {
      if (string.IsNullOrEmpty(encryptedToken))
      {
        return string.Empty;
      }
      string decrypted = Decrypt(encryptedToken,
        SSOSettings.AcrAuthVendorPassword, SSOSettings.AcrAuthVendorBlock);
      if (string.IsNullOrEmpty(decrypted) || decrypted.IndexOf("|") == -1)
      {
        return string.Empty;
      }
      string customerToken = decrypted.Substring(decrypted.IndexOf("|") + 1, decrypted.Length - decrypted.IndexOf("|") - 1);
      return customerToken;
    }

    private static string Encrypt(string text)
    {
      return Encrypt(text, SSOSettings.AcrAuthVendorPassword, SSOSettings.AcrAuthVendorBlock);
    }

    private static string Encrypt(string text, string password, string block)
    {
      SymmetricAlgorithm provider = null;
      MemoryStream buffer = null;
      CryptoStream writer = null;
      try
      {
        provider = new RijndaelManaged();
        buffer = new MemoryStream(text.Length);
        writer = new CryptoStream(buffer, provider.CreateEncryptor(FromHexaDecimal(password), FromHexaDecimal(block)),
                                  CryptoStreamMode.Write);
        ASCIIEncoding encoding = new ASCIIEncoding();
        byte[] bytes = encoding.GetBytes(text);
        writer.Write(bytes, 0, bytes.Length);
        writer.Close();
        return ToHexaDecimal(buffer.ToArray());
      }
      finally
      {
        if (provider != null) provider.Clear();
        if (buffer != null) buffer.Close();
      }
    }

    private static string Decrypt(string text)
    {
      return Decrypt(text, SSOSettings.AcrAuthVendorPassword, SSOSettings.AcrAuthVendorBlock);
    }

    private static string Decrypt(string encrypted, string password, string block)
    {
      SymmetricAlgorithm provider = null;
      MemoryStream buffer = null;
      CryptoStream reader = null;
      try
      {
        provider = new RijndaelManaged();
        byte[] bytes = FromHexaDecimal(encrypted);
        buffer = new MemoryStream(bytes.Length);
        reader = new CryptoStream(buffer, provider.CreateDecryptor(FromHexaDecimal(password), FromHexaDecimal(block)),
                                  CryptoStreamMode.Read);
        buffer.Write(bytes, 0, bytes.Length);
        buffer.Position = 0;
        string decrypted = new StreamReader(reader).ReadToEnd();
        reader.Close();
        return decrypted;
      }
      finally
      {
        if (provider != null) provider.Clear();
        if (buffer != null) buffer.Close();
      }
    }

    private static string GetTimeStamp()
    {
      StringBuilder buffer = new StringBuilder();
      DateTime now = DateTime.Now;
      buffer.Append(now.Year);
      buffer.Append(GetAsTwoDigits(now.Month));
      buffer.Append(GetAsTwoDigits(now.Day));
      buffer.Append(GetAsTwoDigits(now.Hour));
      buffer.Append(GetAsTwoDigits(now.Minute));
      buffer.Append(GetAsTwoDigits(now.Second));
      buffer.Append(GetAsThreeDigits(now.Millisecond));
      return buffer.ToString();
    }

    private static string GetAsTwoDigits(int number)
    {
      return string.Format("{0,2:d}", number).Replace(" ", "0");
    }

    private static string GetAsThreeDigits(int number)
    {
      return string.Format("{0,3:d}", number).Replace(" ", "0");
    }

    private static byte[] FromHexaDecimal(string hexadecimal)
    {
      if (string.IsNullOrEmpty(hexadecimal))
      {
        return new byte[] { };
      }
      bool hasOddLength = (hexadecimal.Length & 1) == 1;
      if (hasOddLength)
      {
        throw new Exception("The hexadecimal string must have an even length (2 characters per byte).");
      }
      int length = hexadecimal.Length;
      byte[] bytes = new byte[Convert.ToInt32(length / 2)];
      for (int n = 0; n <= length - 2; n += 2)
      {
        string hexValue = hexadecimal.Substring(n, 2);
        bytes[Convert.ToInt32(n / 2)] = Convert.ToByte(hexValue, 16);
      }
      return bytes;
    }

    private static string ToHexaDecimal(byte[] bytes)
    {
      if (bytes == null)
      {
        return "";
      }
      StringBuilder buffer = new StringBuilder();
      int length = bytes.Length;
      for (int n = 0; n <= length - 1; n++)
      {
        buffer.Append(string.Format("{0,2:x}", bytes[n]).Replace(" ", "0"));
      }
      return buffer.ToString();
    }
    #endregion
  }
}
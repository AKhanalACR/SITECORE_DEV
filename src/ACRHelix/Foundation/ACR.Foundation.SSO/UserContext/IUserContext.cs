using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACR.Foundation.Personify.Models.Products;
using ACR.Foundation.SSO.Users;

namespace ACR.Foundation.SSO.UserContext
{
  public interface IUserContext
  {
    IAcrUser CurrentUser { get; }

    /// <summary>
    /// The current SSO customer token.
    /// </summary>
    string CurrentCustomerToken { get; }

    /// <summary>
    /// Authenticates user's credentials without redirecting to the SSO login page.
    /// Used to validate credentials.
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    AcrAuthentication.SSO.SSOCustomerAuthenticateResult Authenticate(string username, string password);

    /// <summary>
    /// Logs the user in to the SSO server, and redirects them to the provided page afterward. 
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <param name="redirectUrl"></param>
    void Login(string username, string password, string redirectUrl);


    void LoginWithPrompt(string redirectUrl);
    /// <summary>
    /// Validates the provided customer token and loads the user into session
    /// </summary>
    /// <param name="customerToken"></param>
    /// <param name="forceRevalidate">True to force a token validation even if it matches what's stored in session.</param>
    /// <returns>True is the user is loaded, false if the token was invalid.</returns>
    bool ValidateCustomerToken(string customerToken, bool forceRevalidate);

    /// <summary>
    /// Validates the provided customer token and loads the user into session
    /// </summary>
    /// <param name="customerToken"></param>
    /// <param name="forceRevalidate">True to force a token validation even if it matches what's stored in session.</param></param>
    /// <param name="checkInternationalUsers">true to check for international users</param>
    /// <returns></returns>
    bool ValidateCustomerToken(string customerToken, bool forceRevalidate, bool checkInternationalUsers);

    /// <summary>
    /// Logs out User
    /// </summary>
    /// <returns>SSOCustomerLogoutResult</returns>
    AcrAuthentication.SSO.SSOCustomerLogoutResult Logout();

    /// <summary>
    /// Adds X quantities of the product to the shopping cart
    /// </summary>
    /// <param name="product"></param>
    /// <param name="quantity"></param>
    /// <returns></returns>
    bool AddToCart(ProductStubItem product, bool saveForLater = false);
    //bool AddToCart(string productId);
    /// <summary>
    /// Gets the number of product order lines in the cart
    /// </summary>
    /// <returns>int</returns>
    int GetCartOrderLineCount();

    /// <summary>
    /// Gets a list of PersonifyIDs of products added to the shopping cart
    /// </summary>
    /// <returns></returns>
    IList<string> ProductPersonifyIdsInCart();


  }
}

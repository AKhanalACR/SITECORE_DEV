using ACR.Foundation.SSO.Logger;
using ACR.Foundation.SSO.Users;
using ACR.Foundation.SSO.Utils;
using ACRHelix.Project.RadPAC.Services;
using ACRHelix.Project.RadPAC.ViewModels;
using System.Web.Mvc;

namespace ACRHelix.Project.RadPAC.Controllers
{
    public class RadPACLoginController : Controller
    {
        private readonly IContentService _contentService;
        
        public RadPACLoginController(IContentService contentService)
        {
            _contentService = contentService;
        }

        [HttpGet]
        public ActionResult LoginForm()
        {
            var viewModel = new LoginViewModel();
            var LoginContent = _contentService.GetLoginContent(Sitecore.Context.Item.ID.ToString());
            if (LoginContent != null)
            {
                viewModel = new LoginViewModel(LoginContent);
                string customerRememberMeCookie = AuthenticationUtil.ReadCustomerRememberMeCookie(System.Web.HttpContext.Current.Request);
                if (!string.IsNullOrEmpty(customerRememberMeCookie))
                {
                    viewModel.Username = customerRememberMeCookie;
                    viewModel.RememberMe = true;
                }
                viewModel.ReturnUrl = Request.QueryString["returnUrl"];
            }
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginForm(LoginViewModel login)
        {
            var viewModel = new LoginViewModel();

            string username = login.Username;
            string password = login.Password;

            var LoginContent = _contentService.GetLoginContent(Sitecore.Context.Item.ID.ToString());
            if (LoginContent != null)
            {
                viewModel = new LoginViewModel(LoginContent);
                viewModel.Username = username;
                viewModel.RememberMe = login.RememberMe;
            }

            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                SSOLogger.Logger.Info("LOGIN AUDIT: About to initiate login authentiation from RADPAC.");
                var loginResult = UserManager.CurrentUserContext.Authenticate(username, password);
                SSOLogger.Logger.Info("LOGIN AUDIT: Completed login authentication and logged in to RADPAC.");

                if (loginResult.Result)
                {
                    if (login.RememberMe)
                    {
                        AuthenticationUtil.WriteCustomerRememberMeCookie(System.Web.HttpContext.Current.Response, username, true);
                    }
                    else
                    {
                        AuthenticationUtil.DeleteCustomerRememberMeCookie(System.Web.HttpContext.Current.Response);
                    }

                    string redirectUrl = login.ReturnUrl; //Request.QueryString["returnUrl"];
                    if (string.IsNullOrWhiteSpace(redirectUrl))
                    {
                        redirectUrl = Request.Url.Scheme + "://" + Request.Url.Host;
                    }
                    if (redirectUrl.StartsWith("/"))
                    {
                        redirectUrl = Request.Url.Scheme + "://" + Request.Url.Host + redirectUrl;
                    }
                    UserManager.CurrentUserContext.Login(username, password, redirectUrl);
                    return null;
                }
                else
                {
                    viewModel.LoginError = true;
                    return View(viewModel);
                }
            }
            else
            {
                viewModel.LoginError = true;
                return View(viewModel);
            }
        } 
    }
}
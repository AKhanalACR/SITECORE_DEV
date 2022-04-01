using System;
using ACR.Library.Reference;
using System.Web;
using ACR.controls.Radpac;
using ACR.Foundation.SSO.Users;
using ACR.Foundation.SSO.Utils;
using ACR.controls.Overrides;

namespace ACR.layouts.Radpac
{
  
	/// <summary>
	/// Summary description for SltloginSublayout
	/// </summary>
  public partial class sltLogin : System.Web.UI.UserControl 
	{
      private string redirectUrl = "";
        

        protected void Page_Load(object sender, EventArgs e)
      {
          if (!IsPostBack)
          {
              //string loginFormText = "<h4 class='header-forth icon-user'></h4><panel id='loginPanel' runat='server'><p class='descr'>Please login below to continue to your requested Page.</p>";
            // string frameUrl = "http://";
            // frameUrl = redirectUrl + Request.Url.Host;
           
              //loginIframe.("~/html/Radpac/LoginForm.htm");
          }
          if (Request.QueryString["logout"] != null && Request.QueryString ["logout"]=="true")
          {
              LoginResult.Text = "You have logged out Successfully </br>  </br>";
              LoginResult.Style.Add("color", "green");
              LoginResult.Visible = true;
              loginPanel.Visible = false;
             UserManager.CurrentUserContext.Logout();            
              return;
          }

            //handle international users
          if (UserManager.CurrentUserContext.CurrentCustomerToken != null)
          {                          
              if (UserManager.CurrentUserContext.CurrentUser.IsInternationalUser)
              {
                  LoginResult.Text = "You have not logged in Successfully </br> Note:Users from United States/Canada can only access the content of this site</br>";
                  LoginResult.Style.Add("color", "red");
                  LoginResult.Visible = true;
                  loginPanel.Visible = false;
                  UserManager.CurrentUserContext.Logout();
                  return;
              }

          }

            //if user logged in successfully
          if (UserManager.CurrentUserContext.CurrentUser.IsAuthenticated || (Request.QueryString["ct"] != null))
          {
              if (UserManager.CurrentUserContext.CurrentUser.IsAuthenticated)
              {
                  SuccessfulLogin();
                  return;
              }
              else
              {
                  if (AcrSsoUtil.IsAuthorized(HttpContext.Current, Sitecore.Context.Item))
                  {
                      SuccessfulLogin();
                      return;
                  }
                  else
                  {
                      LoginResult.Text = "You have not logged in Successfully </br> Note:Users from United States/Canada can only access the content of this site</br>";
                      LoginResult.Style.Add("color", "red");
                      LoginResult.Visible = true;
                      loginPanel.Visible = false;
                      UserManager.CurrentUserContext.Logout();
                      return;
                  }
              }
          }
    
                         
                loginPanel.Visible = true;

      lnkForgot.NavigateUrl = "https://login.acr.org/ForgotPassword.aspx";// ACRSettings.AcrLoginForgotPassword;

                string customerRememberMeCookie = AuthenticationUtil.ReadCustomerRememberMeCookie(HttpContext.Current.Request);
                if (!String.IsNullOrEmpty(customerRememberMeCookie))
                {
                    txtUserName.Text = customerRememberMeCookie;
                    chkRemember.Checked = true;
                }
           
                }

        private void SuccessfulLogin()
        {
            LoginResult.Text = "You have logged in Successfully </br> Please click on the Page you wish to navigate</br>";
            LoginResult.Style.Add("color", "Green");
            LoginResult.Visible = true;
            loginPanel.Visible = false;
        }
           
       

        private void GenerateRedirectUrl()
        {
            string redirectPage = Request.QueryString["RedirectPage"];
            string redirectDocument = Request.QueryString["documentPath"];
            redirectUrl = "http://";
            redirectUrl = redirectUrl + Request.Url.Host;
           
            if (redirectDocument != null)
            {
                if (redirectDocument != "")
                    redirectUrl += redirectDocument;
            }
            if (redirectPage != null)
            {
                if (redirectPage != "")
                    redirectUrl += redirectPage;
            }
            hdnUrlReferrer.Value = redirectUrl;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            
            if (!Page.IsValid)
            {
                return;
            }
            // Redirect the user if he's authenticated already
            if (UserManager.CurrentUserContext.CurrentUser.IsAuthenticated)
            {
                Response.Redirect(Request .UrlReferrer .ToString (), true);
            }
            
            //check for valid username and password
            var loginResult = UserManager.CurrentUserContext.Authenticate(txtUserName.Text, txtPassword.Text);
            if (loginResult.Result)
            {
               
               string redirectUrl = string.IsNullOrEmpty(hdnUrlReferrer.Value) ? ItemReference.Radpac.Url : hdnUrlReferrer.Value;

                // Set the remember me cookie
                if (chkRemember.Checked)
                    AuthenticationUtil.WriteCustomerRememberMeCookie(HttpContext.Current.Response, txtUserName.Text, true);
                else
                    AuthenticationUtil.DeleteCustomerRememberMeCookie(HttpContext.Current.Response);

                // Login and redirect
                UserManager.CurrentUserContext.Login("", "", Request.UrlReferrer.ToString());
                //if (Request.QueryString["documentPath"] != null)
                   // UserManager.CurrentUserContext.Login(txtUserName.Text, txtPassword.Text, Request.UrlReferrer.ToString());
                //else
                //{
                //    GenerateRedirectUrl();
                //    UserManager.CurrentUserContext.Login(txtUserName.Text, txtPassword.Text, hdnUrlReferrer.Value);
                //}
            }
            else
            {
                if (loginResult.Errors != null)
                {
                    foreach (string error in loginResult.Errors)
                    {
                        Page.Validators.Add(new CustomError(error));
                    }
                }
                else
                {
                    Page.Validators.Add(new CustomError("Authentication failed."));
                }
                Page.Validate();
            }
        }

        //private string GetReferringPageUrl()
        //{
        //    Uri redirectUri;
        //    // Check the session value
        //    if (Session[AcrConstants.SSOParams.LoginRedirectUrlKey] != null)
        //    {
        //        string referrer = (string)Session[AcrConstants.SSOParams.LoginRedirectUrlKey];
        //        // Clear this value after we read it
        //        Session[AcrConstants.SSOParams.LoginRedirectUrlKey] = null;
        //        if (Uri.TryCreate(referrer, UriKind.Absolute, out redirectUri))
        //        {
        //            if (redirectUri.Host == Request.Url.Host)
        //            {
        //                return redirectUri.ToString();
        //            }
        //        }
        //    }

        //    // Check the referrer
        //    if (Request.UrlReferrer != null && Request.UrlReferrer.Host == Request.Url.Host)
        //    {
        //        return Request.UrlReferrer.ToString();
        //    }

        //    return string.Empty;
        //}
  }
}
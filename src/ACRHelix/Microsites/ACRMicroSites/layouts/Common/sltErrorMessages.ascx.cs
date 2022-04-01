using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.Common.CustomItems.AcrCommon;
using ACR.Library.Utils;
using Sitecore.Data.Items;
using Velir.SitecorePlugins.ExpressURL;

namespace ACR.layouts.Common
{
    public partial class sltErrorMessages : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorPageItem item = Sitecore.Context.Item;
            ltlErrorMsg.Text = item.ErrorMessage.Rendered;

            List<String> keys = new List<string>(HttpContext.Current.Request.Params.AllKeys);

            if (keys.Contains("item"))
            {
              Velir.SitecorePlugins.ExpressURL.ExpressUrlResolver resolver = new ExpressUrlResolver();
              try
              {
                resolver.PerformRedirect(HttpContext.Current);
              }
              catch(Exception){}
              //Then we have a 404 - Item Not Found.
                litErrorBanner.Text = "404 - Page Not Found";
								litErrorItem.Text = HttpUtils.StripHTMLTags(HttpContext.Current.Request.Params["item"]);
                Response.StatusCode = 404;
            }
            else if (keys.Contains("code"))
            {
                //Then we have a CODE Error
                switch (HttpContext.Current.Request.Params["code"])
                {
                    case "500":
                        //Application Error
                        litErrorBanner.Text = "500 - Application Error";
                        Response.StatusCode = 500;
                        break;
                    case "404":
                        //Page Not Found
                        litErrorBanner.Text = "404 - Page Not Found";
                        Response.StatusCode = 404;
                        break;
                    default:
                        //Generic Message, show code.
												litErrorBanner.Text = HttpUtils.StripHTMLTags(Request.Params["code"]) + " - Server Returned an Error ";
                        Response.StatusCode = Convert.ToInt16(Request.Params["code"]);
                        break;
                }
            }
            else
            {
                String redirectUrl = null;

                string badUrl = HttpContext.Current.Request.Headers["Referer"] ?? "http://" + Sitecore.Context.Site.HostName + HttpContext.Current.Request.RawUrl;

                if (_findRedirectPage(badUrl, item, out redirectUrl))
                {
                    HttpContext.Current.Response.Redirect(redirectUrl);
                }
                else
                {
                    //Really Generic, Message.
                    litErrorBanner.Text = "404 - Page Not Found";
                    litErrorItem.Text = badUrl;
                    Response.StatusCode = 404;
                }
            }
        }

        private bool _findRedirectPage(string url, ErrorPageItem item, out string redirectUrl)
        {
            try
            {
                foreach (Item redirectItem in item.InnerItem.Children)
                {
                    if (redirectItem["Original Url"] != null && redirectItem["Original Url"].Equals(url))
                    {
                        redirectUrl = redirectItem["New Url"];
                        return true;
                    }
                }
                redirectUrl = String.Empty;
                return false;
            }
            catch (Exception)
            {
                redirectUrl = String.Empty;
                return false;
            }
        }
    }
}
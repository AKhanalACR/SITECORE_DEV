using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace ACRHelix.Feature.ImageWiselyContent.Helpers
{
    public static class GoogleCaptchaHelper
    {
        public static IHtmlString GoogleCaptcha(this HtmlHelper helper)
        {
            //var publicSiteKey = WebConfigurationManager.AppSettings["GoogleRecaptchaSiteKey"];
            var publicSiteKey = Sitecore.Configuration.Settings.GetSetting("GoogleRecaptchaSiteKey");

            var mvcHtmlString = new TagBuilder("div")
            {
                Attributes =
                {
                    new KeyValuePair<string, string>("class", "g-recaptcha"),
                    new KeyValuePair<string, string>("data-sitekey", publicSiteKey)
                }
            };

            var googleCaptchaScript = "<script src='https://www.google.com/recaptcha/api.js'></script>";
            var renderedCaptcha = mvcHtmlString.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(string.Format("{0}{1}", googleCaptchaScript, renderedCaptcha));
        }
    }
}
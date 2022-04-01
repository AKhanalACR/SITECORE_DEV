using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.ImageWiselyContent.Helpers
{
    public static class InvalidGoogleCaptchaHelper
    {
        public static IHtmlString InvalidGoogleCaptchaLabel(this HtmlHelper helper, string errorText = "Captcha is not valid! Please, try it again.")
    {
        var invalidCaptchaObj = helper.ViewContext.Controller.TempData["InvalidCaptcha"];

        var invalidCaptcha =  invalidCaptchaObj != null ? invalidCaptchaObj.ToString() : null;

        if (string.IsNullOrWhiteSpace(invalidCaptcha)) return MvcHtmlString.Create("");

        var buttonTag = new TagBuilder("span")
        {
            Attributes =
            {
                new KeyValuePair<string, string>("class", "field-validation-error")
            },
            InnerHtml = errorText ?? invalidCaptcha
        };

        return MvcHtmlString.Create(buttonTag.ToString(TagRenderMode.Normal));
    }

    }
}
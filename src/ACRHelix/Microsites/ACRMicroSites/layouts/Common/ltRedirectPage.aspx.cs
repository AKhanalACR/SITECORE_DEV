using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.AcrCommon;

namespace ACR.layouts.Common
{
	public partial class ltRedirectPage : System.Web.UI.Page
	{
		protected void Page_PreInit(object sender, EventArgs e)
		{
			if (Sitecore.Context.Item == null 
				|| Sitecore.Context.Item.TemplateID.ToString() != RedirectPageItem.TemplateId)
			{
				Response.Redirect("/", true);
				return;
			}

			RedirectPageItem redirect = Sitecore.Context.Item;
			if (redirect.RedirectUrl == null 
				|| string.IsNullOrEmpty(redirect.RedirectUrl.Url) 
				|| !Uri.IsWellFormedUriString(redirect.RedirectUrl.Url, UriKind.RelativeOrAbsolute))
			{
				Response.Redirect("/", true);
				return;
			}

			Response.Redirect(redirect.RedirectUrl.Url);
		}
	}
}
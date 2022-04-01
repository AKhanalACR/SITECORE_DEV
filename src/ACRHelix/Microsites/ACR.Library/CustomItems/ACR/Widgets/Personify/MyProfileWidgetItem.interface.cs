using System;
using ACR.Library.UserServices;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.Widgets.Personify
{
public partial class MyProfileWidgetItem 
{
	/// <summary>
	/// Will return if this widget has any content to display.
	/// </summary>
	/// <returns>Flag determining if this widget has content.</returns>
	public bool HasContent()
	{
		if (!UserManager.CurrentUserContext.CurrentUser.IsAnonymous && UserManager.CurrentUserContext.CurrentUser.IsAuthenticated)
			return true;

		return false;
	}
}
}
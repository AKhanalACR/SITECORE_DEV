using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.Widgets.Personify
{
public partial class FeaturedUpcomingCourseWidgetItem 
{
	/// <summary>
	/// Will return if this widget has any content to display.
	/// </summary>
	/// <returns>Flag determining if this widget has content.</returns>
	public bool HasContent()
	{
		if (!String.IsNullOrEmpty(HeaderText.Raw) || !String.IsNullOrEmpty(Title.Raw) || !String.IsNullOrEmpty(Description.Raw))
			return true;

		return false;
	}
}
}
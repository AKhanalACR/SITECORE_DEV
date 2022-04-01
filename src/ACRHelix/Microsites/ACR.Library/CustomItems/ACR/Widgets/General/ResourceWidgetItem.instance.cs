using System;
using System.Linq;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.Widgets.General
{
	public partial class ResourceWidgetItem
	{
		/// <summary>
		/// Will return if this widget has any content to display.
		/// </summary>
		/// <returns>Flag determining if this widget has content.</returns>
		public bool HasContent()
		{
			//if any of our fields are populated then we have content
			if (!string.IsNullOrEmpty(Title.Text))
			{
				return true;
			}

			if (Resources.ListItems != null && Resources.ListItems.Any())
			{
				return true;
			}

			if (Link != null && !string.IsNullOrEmpty(Link.Url))
			{
				return true;
			}

			//else return false
			return false;
		}
	}
}
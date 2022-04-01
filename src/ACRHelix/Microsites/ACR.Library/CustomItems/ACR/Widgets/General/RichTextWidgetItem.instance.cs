using System;
using ACR.Library.Utils;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.Widgets.General
{
	public partial class RichTextWidgetItem
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

			string imageUrl = ImageUtil.GetScaledImageUrl(Image, 100, 100);
			if (!string.IsNullOrEmpty(imageUrl))
			{
				return true;
			}

			if (!string.IsNullOrEmpty(BodyText.Text))
			{
				return true;
			}

			if (!string.IsNullOrEmpty(Link.Url))
			{
				return true;
			}

			//else return false
			return false;
		}
	}
}
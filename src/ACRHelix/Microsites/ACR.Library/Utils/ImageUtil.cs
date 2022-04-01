using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomItemGenerator.Fields.SimpleTypes;
using Velir.Utilities;

namespace ACR.Library.Utils
{
	public static class ImageUtil
	{
		/// <summary>
		/// Returns a url path to the image handler with query parameters to 
		/// specify the max width and height of the scaled image.
		/// Checks the height and width properties of the field as well, and uses those
		/// if they are less than the provided parameters.
		/// </summary>
		/// <param name="imageField"></param>
		/// <param name="maxWidth">0 for no limit.</param>
		/// <param name="maxHeight">0 for no limit.</param>
		/// <returns></returns>
		public static string GetScaledImageUrl(CustomImageField imageField, int maxWidth, int maxHeight)
		{
			if (imageField == null || imageField.Field == null || imageField.MediaItem == null) return string.Empty;

			string url = Sitecore.Resources.Media.MediaManager.GetMediaUrl(imageField.MediaItem);

			int fieldHeight = 0;
			int fieldWidth = 0;

			if (Int32.TryParse(imageField.Field.Height, out fieldHeight))
			{
				maxHeight = fieldHeight < maxHeight ? fieldHeight : maxHeight;
			}

			if (Int32.TryParse(imageField.Field.Width, out fieldWidth))
			{
				maxWidth = fieldWidth < maxWidth ? fieldWidth : maxWidth;
			}

			Hashtable options = new Hashtable();
			if (maxWidth > 0) options.Add("mw", maxWidth);
			if (maxHeight > 0) options.Add("mh", maxHeight);

			url = UrlUtil.CreateUrl(url, options);

			return url;
		}

	}
}

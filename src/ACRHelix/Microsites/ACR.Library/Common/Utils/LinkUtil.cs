using System;
using ACR.Library.Common.CustomItems;
using ACR.Library.Utils;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;
using Velir.SitecoreLibrary.CustomItems.MediaLibrary;

namespace ACR.Library.Common.Utils
{
	public static class LinkUtil
	{

		public static string GetLinkFieldUrl(LinkField linkField)
		{
			if (linkField == null)
				return String.Empty;

			if (linkField.IsInternal)
				return CustomItemUtils.GetItemUrl((GenericItem)linkField.TargetItem);

			if (linkField.IsMediaLink)
			{
				MediaItem mediaItem = linkField.TargetItem;
				return GetMediaUrl(mediaItem);
			}

			return GetExternalUrl(linkField.Url);
		}

		public static string GetLinkFieldTarget(LinkField linkField)
		{
			if (linkField == null)
				return "_self";

			if (linkField.IsInternal)
				return "_self";

			return linkField.Target;
		}

		public static string GetExternalUrl(string url)
		{
			return (url.StartsWith("http://") || url.StartsWith("https://"))
														? url
														: "http://" + url;
		}

		public static string GetImageUrl(ImageField field)
		{
			if (field == null || field.MediaItem == null)
				return string.Empty;
			else
				return GetMediaUrl(field.MediaItem);
		}

		public static string GetImageUrl(ImageItem item)
		{
			return GetMediaUrl(item);
		}

		public static string GetMediaUrl(MediaItem item)
		{
			if (item == null) return String.Empty;
			MediaUrlOptions options = new MediaUrlOptions();
			options.AbsolutePath = true;
			return MediaManager.GetMediaUrl(item, options);
		}
        
	}
}

using System;
using ACR.Library.Common.CustomItems;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Resources.Media;
using Sitecore.Web;
using Velir.SitecoreLibrary.CustomItems.MediaLibrary;

namespace ACR.Library.Utils
{
	public static class LinkUtils
	{
		public static string GetItemUrl(Item item)
		{
            if (item == null)
                return String.Empty;

			return LinkManager.GetItemUrl(item).ToLower();
		}

		public static string GetItemFullUrl(Item item)
		{
			return item != null ? (WebUtil.GetFullUrl(GetItemUrl(item))).ToLower() : string.Empty;
		}

		public static string GetItemFullUrl(string url)
		{
			return !String.IsNullOrEmpty(url) ? WebUtil.GetFullUrl(url).ToLower() : string.Empty;
		}

		public static string GetMediaFullUrl(MediaItem mediaItem)
		{
			if (mediaItem == null)
			{
				return string.Empty;
			}
			return WebUtil.GetFullUrl(MediaManager.GetMediaUrl(mediaItem,
			                                                   new MediaUrlOptions() {AbsolutePath = true,}));
		}

		public static string GetLinkFieldUrl(LinkField linkField)
		{
			if (linkField == null)
				return String.Empty;

			if (linkField.IsInternal )
            {
                if (linkField.TargetItem == null)
                    return String.Empty;
				return GetItemUrl(linkField.TargetItem);
            }

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

			return "_blank";
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

		public static Boolean IsPdfLink(LinkField linkField)
		{
			if (linkField.IsMediaLink && linkField.TargetItem != null)
			{
				MediaItem mediaItem = linkField.TargetItem;
				return IsPdf(mediaItem);
			}
			return false;
		}

		public static Boolean IsPdf(MediaItem mediaItem)
		{
			if (mediaItem.MimeType == "application/pdf")
				return true;

			//Word documents will count too for now
			if (mediaItem.MimeType == "application/msword")
				return true;
			return false;
		}

		public static string GetBreadcrumbLinkHtml(string link, string text)
		{
			return "<span itemscope itemtype='http://data-vocabulary.org/Breadcrumb'>" +
			       "<a href=\"" + link + "\" itemprop='url'><span itemprop='title'>" + text + "</span></a></span>";
		}

		public static string GetBreadcrumbFinalHtml(string text)
		{
			return "<span itemscope itemtype='http://data-vocabulary.org/Breadcrumb'>" +
			       "<span itemprop='title'><strong>" + text + "</strong></span></span>";
		}
	}
}
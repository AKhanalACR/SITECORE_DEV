using System;
using Common.Logging;
using Sitecore.Data.Items;
using Sitecore.Links;


namespace ACR.Library.Utils
{
    public enum CustomItemType
    {
        Shared,
        ImageWisely,
        Undefined
    }

    public static class CustomItemUtils
    {
        private static ILog _logger;

        private static ILog Logger
        {
            get
            {
                _logger = _logger ?? LogManager.GetLogger(typeof(CustomItemUtils));
                return _logger;
            }
        }

        public static string GetItemUrl(CustomItem customItem)
        {
					if (customItem == null)
					{
						Logger.Warn(String.Format("CustomItemUtils.GetItemUrl() received a null item."));
						return String.Empty;
					}

					UrlOptions urlOptions = new UrlOptions();
					urlOptions.AlwaysIncludeServerUrl = true;
					urlOptions.EncodeNames = true;
					urlOptions.LanguageEmbedding = LanguageEmbedding.Never;
					return LinkManager.GetItemUrl(customItem.InnerItem, urlOptions);
        }
    }
}

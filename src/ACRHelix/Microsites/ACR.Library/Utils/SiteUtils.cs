using System;
using Common.Logging;
using Sitecore.Configuration;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;


namespace ACR.Library.Utils
{
    public static class SiteUtils
    {
        private static ILog _logger;
        public static ILog Logger
        {
            get
            {
                if (_logger == null)
                {
                    _logger = LogManager.GetLogger(typeof(SiteUtils));
                }
                return _logger;
            }
        }
        public static SiteNames GetSiteByContext()
        {
            Assert.ArgumentNotNull(Sitecore.Context.Site, "Site Context is Null.");

            try
            {
                if (String.IsNullOrEmpty(Sitecore.Context.Site.Name))
                    return SiteNames.Undefined;

                if (Sitecore.Context.Site.Name.Equals("shell") || Sitecore.Context.Site.Name.Equals("website"))
                    return SiteNames.Undefined;

                var siteName = (SiteNames)AcrGlobals.SiteTypes[Sitecore.Context.Site.Name];
                return siteName;
            }
            catch (NullReferenceException nullEx)
            {
                Logger.Debug(String.Format("SiteUtils.GetSiteByContext() handled Null Reference Exception on Site {0}.", Sitecore.Context.Site.Name), nullEx);
                return SiteNames.Undefined;
            }
            catch (Exception ex)
            {
                Logger.Warn(String.Format("SiteUtils.GetSiteByContext() handled error."), ex);
                return SiteNames.Undefined;
            }
        }

        		/// <summary>
		/// Compares the known paths to the site names
		/// and determines if that's where we're at.
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public static SiteNames GetSiteByItem(Item item)
		{
			if (item == null)
			{
				Logger.Error(String.Format("SiteUtils.GetSiteByItem() recieved null item."));
				return SiteNames.Undefined;
			}

			try
			{
				string itemPath = item.Paths.FullPath.ToLower();

                if (itemPath.Contains(AcrGlobals.IMAGEWISELY_PATH.ToLower())) return SiteNames.ImageWisely;
                if (itemPath.Contains(AcrGlobals.HOME_PATH.ToLower())) return SiteNames.Shared;
			}
			catch (Exception ex)
			{
				Logger.Warn(String.Format("SiteUtils.GetSiteByItem() handled error on item {0}", item.Paths.FullPath), ex);
			}
			return SiteNames.Undefined;
		}

		public static string GetSiteNameByType(SiteNames type)
		{
            return AcrGlobals.SiteName[type].ToString();
        }

        public static string GetSiteTitleByType(SiteNames type)
        {
            switch (type)
            {
                case SiteNames.ImageWisely:
                    return AcrGlobals.IMAGEWISELY_SITE_TITLE;
                default:
                    return GetSiteNameByType(type);
            }
        }

        public static Item GetHomeItemBySite(SiteNames siteName)
        {
          if (siteName == SiteNames.ImageWisely)
          {
            return GetItem(AcrGlobals.IMAGEWISELY_PATH);
          }


          return null;
        }

		public static string GetSiteNameByItem(Item item)
		{
			if (item == null)
			{
				Logger.Error(String.Format("SiteUtils.GetSiteNameByItem() received null item."));
				return "website";
			}

			try
			{
				string itemPath = item.Paths.FullPath.ToLower();

				//KHN
				if (itemPath.Contains(AcrGlobals.IMAGEWISELY_PATH.ToLower()))
				{
					return AcrGlobals.SiteName[SiteNames.ImageWisely].ToString();
				}

			}
			catch (Exception ex)
			{
				Logger.Error(String.Format("SiteUtils.GetSiteNameByItem() handled error on item {0}", item.Paths.FullPath), ex);
			}
			return "website";
		}

        private static Item GetItem(string itemPath)
        {
            try
            {
                var database = Sitecore.Context.Database;

                if (database == null)
                    database = Factory.GetDatabase("web");

                var item = database.GetItem(itemPath);

                return item;

            }
            catch (Exception)
            {

                return null;
            }
        }
        
	}
}

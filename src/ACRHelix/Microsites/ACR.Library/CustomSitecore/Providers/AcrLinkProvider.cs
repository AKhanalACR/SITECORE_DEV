using Sitecore;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using Sitecore.Diagnostics;
using Sitecore.Globalization;
using Sitecore.IO;
using Sitecore.Links;
using Sitecore.Resources.Media;
using Sitecore.SecurityModel;
using Sitecore.Sites;
using Sitecore.StringExtensions;
using Sitecore.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Specialized;
using System.Configuration.Provider;
using System.Text;
using System.Web;

namespace ACR.Library.CustomSitecore.Providers
{
	public class AcrLinkProvider : LinkProvider
	{
		/// <summary>
		/// Override to allow links to media to be site specific.
		/// Example: http://www.acr.org/~/media/ACR/Documents/PGTS/guidelines/Skeletal_Scintigraphy.pdf
		/// on the Image Wisely site would render as
		/// http://www.acr.org/http://imagewisely.org/~/media/ACR/Documents/PGTS/guidelines/Skeletal_Scintigraphy.pdf
		/// because the default behavior would be to convert ~/media to http://imagewisely.org/~/media
		/// </summary>
		public override string ExpandDynamicLinks(string text, bool resolveSites)
		{
			string baseExpands = base.ExpandDynamicLinks(text, resolveSites);
			List<SiteInfo> sites = Factory.GetSiteInfoList().Where(s => !s.HostName.IsNullOrEmpty()).ToList();
			List<string> hostNames = new List<string>();

			foreach (SiteInfo site in sites)
			{
				hostNames.Add(site.HostName.Replace("*", ""));
				hostNames.Add(string.Format("www.{0}", site.HostName.Replace("*", "")));
			}

			foreach (string hostName in hostNames)
			{
				string host = string.Format("http://{0}", hostName);

				foreach (string siteName in hostNames)
				{
					string contextHost = string.Format("http://{0}", siteName);
					string expandedHost = string.Format("{0}/{1}", host, contextHost);
					baseExpands = baseExpands.Replace(expandedHost, host);
				}
			}

			return baseExpands;
		}
	}
}

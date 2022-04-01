using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Services;
using ACR.Library.Reference;
using ACR.Library.Utils;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Jobs;

namespace ACR.services
{
	/// <summary>
	/// Summary description for SmartPublishHandler
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class SmartPublishHandler : System.Web.Services.WebService
	{

		[WebMethod]
		public void SmartPublishSite(string securityGuid)
		{
			smartPublishSite(securityGuid);
		}

		private void smartPublishSite(string securityGuid)
		{
			Sitecore.Diagnostics.Log.Info("Starting full site smart publish", this);
			//TODO: Set this GUID to be configurable somewhere.  Hardcoded for now.);
			if (securityGuid.ToUpper() != "{D5E22DF7-2CC0-4682-88F2-6F877CF64769}")
			{
				Sitecore.Diagnostics.Log.Error("Error smart publishing site - Invalid Security GUID", this);
				return;
			}

			//Templates
			PublishUtil.SmartPublishFromRoot("{3C1715FE-6A13-4FCF-845F-DE308BA9741D}");

			//System
			PublishUtil.SmartPublishFromRoot("{13D6D6C6-C50B-4BBD-B331-2B04F1A58F21}");

			//Layout
			PublishUtil.SmartPublishFromRoot("{EB2E4FFD-2761-4653-B052-26A64D385227}");
		}

		[WebMethod]
		public void SmartPublishContent(string securityGuid)
		{
			smartPublishContent(securityGuid);
		}

		private void smartPublishContent(string securityGuid)
		{
			Sitecore.Diagnostics.Log.Info("Starting ACR content smart publish", this);
			//TODO: Set this GUID to be configurable somewhere.  Hardcoded for now.);
			if (securityGuid.ToUpper() != "{D5E22DF7-2CC0-4682-88F2-6F877CF64769}")
			{
				Sitecore.Diagnostics.Log.Error("Error smart publishing site - Invalid Security GUID", this);
				return;
			}

			// Content Home
			PublishUtil.SmartPublishFromRoot("{0DE95AE4-41AB-4D01-9EB0-67441B7C2450}");

		}

	}
}

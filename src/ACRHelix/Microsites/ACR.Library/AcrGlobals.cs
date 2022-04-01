using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using ACR.Library.Cache;
using ACR.Library.Reference;
using Sitecore.Data.Items;
using System.Text;
using System.Net.Mail;
using Velir.Net.Mail;
using Common.Logging;

namespace ACR.Library
{
	public enum SiteNames
	{
		ImageWisely = 1,
		Airp = 2,
		Shared = 3,
		ACR = 4,
		Radpac= 5,
		Undefined = 0
	}

	public enum SITECORE_DEVICES
	{
		ImageWiselyShared,
		AirpShared
	}

	public class AcrGlobals
	{
		private static ILog _globalsLogger;

		private static ILog Logger
		{
			get
			{
				_globalsLogger = _globalsLogger ?? LogManager.GetLogger(typeof(AcrGlobals));
				return _globalsLogger;
			}
		}

		/* Sites */

		public static string HOME_PATH
		{
			get
			{
				if (ItemReference.Home.InnerItem != null)
					return ItemReference.Home.Path;

				string errMsg =
					"Could not get sitecoreHome item from Item Reference. ItemReference.Home.InnerItem = null";
				_globalsLogger.Error(errMsg);
				//Temporary: Send Emails to Pete and Diane
				SendEmails(errMsg);
				return "/sitecore/content/home";
			}
		}

		public static string IMAGEWISELY_PATH
		{
			get
			{
				if (ItemReference.ImageWisely.InnerItem != null)
					return ItemReference.ImageWisely.Path;

				string errMsg =
					"Could not get sitecore ImageWisely item from Item Reference. ItemReference.ImageWisely.InnerItem = null";
				_globalsLogger.Error(errMsg);
				return "/sitecore/content/home";
			}
		}

		public static string AIRP_PATH
		{
			get
			{
				if (ItemReference.Airp.InnerItem != null)
					return ItemReference.Airp.Path;

				string errMsg =
					"Could not get sitecore AIRP item from Item Reference. ItemReference.Airp.InnerItem = null";
				_globalsLogger.Error(errMsg);
				return "/sitecore/content/home";
			}
		}

		public static string ACR_PATH
		{
			get
			{
				if (ItemReference.ACR_Home.InnerItem != null)
					return ItemReference.ACR_Home.Path;

				string errMsg =
					"Could not get sitecore ACR item from Item Reference. ItemReference.ACR_Home.InnerItem = null";
				_globalsLogger.Error(errMsg);
				return "/sitecore/content/home";
			}
		}

		public static string RADPAC_PATH
		{
			get
			{
				if (ItemReference.Radpac.InnerItem != null)
					return ItemReference.Radpac.Path;

				string errMsg =
								"Could not get sitecore RADPAC item from Item Reference. ItemReference.RADPAC.InnerItem = null";
				_globalsLogger.Error(errMsg);
				return "/sitecore/content/home";
			}
		}

		public const string IMAGEWISELY_SITE_TITLE = "Image Wisely";
		public const string AIRP_SITE_TITLE = "American Institute for Radiologic Pathology";
		public const string ACR_SITE_TITLE = "American College of Radiology";
		public const string RADPAC_SITE_TITLE = "RADPAC";
		public const string RLI_SITE_TITLE = "RLI";

		private static Hashtable siteTypes = new Hashtable();

		public static Hashtable SiteTypes
		{
			get
			{
				if (siteTypes.Count == 0)
				{
					siteTypes.Add("ImageWisely", SiteNames.ImageWisely);
					siteTypes.Add("AIRP", SiteNames.Airp);
					siteTypes.Add("ACR", SiteNames.ACR);
					siteTypes.Add("RADPAC", SiteNames.Radpac);
				}
				return siteTypes;
			}
		}

		private static Hashtable siteName = new Hashtable();

		public static Hashtable SiteName
		{
			get
			{
				if (siteName.Count == 0)
				{
					siteName.Add(SiteNames.ImageWisely, "ImageWisely");
					siteName.Add(SiteNames.Airp, "AIRP");
					siteName.Add(SiteNames.ACR, "ACR");
					siteName.Add(SiteNames.Radpac, "RADPAC");
				}
				return siteName;
			}
		}

		private static Hashtable siteRoots = new Hashtable();

		public static Hashtable SiteRoots
		{
			get
			{
				if (siteRoots.Count == 0)
				{
					siteRoots.Add(SiteNames.ImageWisely, IMAGEWISELY_PATH);
					siteRoots.Add(SiteNames.Airp, AIRP_PATH);
					siteRoots.Add(SiteNames.ACR, ACR_PATH);
					siteRoots.Add(SiteNames.Radpac, RADPAC_PATH);
					siteRoots.Add(SiteNames.Shared, HOME_PATH);
				}
				return siteRoots;
			}
		}

		//private static Hashtable customDevices = new Hashtable();

		//public static Hashtable CustomDevices
		//{
		//  get
		//  {
		//    if (customDevices.Count == 0)
		//    {
		//      customDevices.Add(SITECORE_DEVICES.ImageWiselyShared, "{5751A731-EFD9-4FF1-9543-CA017CD1A9AC}");
		//      customDevices.Add(SITECORE_DEVICES.AirpShared, "{7C0B504D-0DE3-44A4-A82B-95E326E31C77}");
		//    }
		//    return customDevices;
		//  }
		//}

		//private const string StaffMemberTypesCacheKey = "acrStaffMemberTypes";
		//private static List<EnumerationItem> _staffMemberTypes;

		///// <summary>
		///// All the possible staff member types.
		///// </summary>
		//public static List<EnumerationItem> StaffMemberTypes
		//{
		//	get
		//	{
		//			//get our staff member types enumeration parent item
		//			Item parent = ItemReference.ACR_Global_Enumerations_StaffMemberTypes.InnerItem;

		//			//if we have a parent then get our staff member types
		//			if (parent != null)
		//			{
		//				_staffMemberTypes = ACRCache.GetFromCache(StaffMemberTypesCacheKey,
		//				                                          () =>
		//				                                          parent.GetChildrenByTemplate(EnumerationItem.TemplateId)
		//				                                                .Select(i => (EnumerationItem) i)
		//				                                                .ToList());
		//			}
		//			else
		//			{
		//				//we need a staff member type parent, log an error
		//				string errMsg = "Could not get sitecore ACR item from Item Reference. ItemReference.ACR_Global_Enumerations_StaffMemberTypes.InnerItem = null";
		//				_globalsLogger.Error(errMsg);

		//				//set an empty list for our staff member types
		//				_staffMemberTypes = new List<EnumerationItem>(0);
		//			}

		//		//return our staff member types
		//		return _staffMemberTypes;
		//	}
		//}

		//private const string CpiCategoriesCacheKey = "acrCpiCategories";
		//private static List<EnumerationItem> _cpiCategories;

		///// <summary>
		///// All the possible CPI Categories.
		///// </summary>
		//public static List<EnumerationItem> CPICategories
		//{
		//	get
		//	{
		//		//get our CPI categories enumeration parent item
		//		Item parent = ItemReference.ACR_Global_Enumerations_CPICategories.InnerItem;

		//		//if we have a parent then get our CPI categories
		//		if (parent != null)
		//		{
		//			_cpiCategories = ACRCache.GetFromCache(CpiCategoriesCacheKey,
		//			                                       () =>
		//			                                       parent.GetChildrenByTemplate(EnumerationItem.TemplateId)
		//			                                             .Select(i => (EnumerationItem) i)
		//			                                             .ToList());
		//		}
		//		else
		//		{
		//			//we need a CPI categories parent, log an error
		//			string errMsg =
		//				"Could not get sitecore ACR item from Item Reference.ACR_Global_Enumerations_CPICategories.InnerItem = null";
		//			_globalsLogger.Error(errMsg);

		//			//set an empty list for our CPI categories
		//			_cpiCategories = new List<EnumerationItem>(0);
		//		}

		//		//return our CPI categories
		//		return _cpiCategories;
		//	}
		//}

		//private const string CpiSpliceCategoriesCacheKey = "acrCpiSpliceCategories";
		//private static List<EnumerationItem> _cpiSpliceCategories;

		///// <summary>
		///// All the possible CPI Splice Categories.
		///// </summary>
		//public static List<EnumerationItem> CPISpliceCategories
		//{
		//	get
		//	{
		//		//get our CPI splice categories enumeration parent item
		//		Item parent = ItemReference.ACR_Global_Enumerations_CPISpliceCategories.InnerItem;

		//		//if we have a parent then get our CPI splice categories
		//		if (parent != null)
		//		{
		//			_cpiSpliceCategories = ACRCache.GetFromCache(CpiSpliceCategoriesCacheKey,
		//			                                             () =>
		//			                                             parent.GetChildrenByTemplate(EnumerationItem.TemplateId)
		//			                                                   .Select(i => (EnumerationItem) i)
		//			                                                   .ToList());
		//		}
		//		else
		//		{
		//			//we need a CPI splice categories parent, log an error
		//			string errMsg =
		//				"Could not get sitecore ACR item from Item Reference.ACR_Global_Enumerations_CPISpliceCategories.InnerItem = null";
		//			_globalsLogger.Error(errMsg);

		//			//set an empty list for our CPI splice categories
		//			_cpiCategories = new List<EnumerationItem>(0);
		//		}

		//		//return our CPI splice categories
		//		return _cpiSpliceCategories;
		//	}
		//}

		#region Query Parameter Constants

		public const string ReferrerParam = "referrer";
		public const string SearchReferrerValue = "search";

		#endregion

		#region Meeting Sublayout Property Constants

		public const string SublayoutDisplayDates = "DisplayDates";
		public const string SublayoutDisplayLocationDetails = "DisplayLocationDetails";
		public const string SublayoutDisplayContactDetails = "DisplayContactDetails";
		public const string SublayoutDisplayAdditionalDetails = "DisplayAdditionalDetails";
		public const string SublayoutDisplayDescriptionTitle = "DisplayDescriptionTitle";
		public const string SublayoutDisplayDocuments = "DisplayDocuments";
		public const string SublayoutDisplayRegisterLink = "DisplayRegisterLink";

		#endregion

		/* Miscellaneous */
		public static string EmailRegex = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
		public static string PledgeFormSuccessMessage = "Your message has been sent.";

		public static string PledgeFormFailureMessage =
			"Email server error. The form has not been submitted. Please try again later.";

		public static string PledgeFormDefaultSubject = "A form has been submitted from the Image Wisely website.";

		public static int SEARCH_PAGINATION_PAGESIZE
		{
			get
			{
				try
				{
					return Convert.ToInt32(GSASettings["ResultsPerPage"]);
				}
				catch (Exception ex)
				{
					Logger.Warn(
						"Pagination: \"ResultsPerPage\" (integer) could not be loaded from GSASettings Configuration file. A default value has been assigned",
						ex);
					return 10;
				}
			}
		}

		//web services security key
		public static string WebServicesSecurityKey
		{
			get
			{
				try
				{
					return ConfigurationManager.AppSettings["WebServicesSecurityKey"];
				}
				catch (Exception ex)
				{
					Logger.Error(
						"Web Services: \"WebServicesSecurityKey\" could not be loaded from AppSettings. The \"Pledges Made\" field on the Image Wisely home node was not updated",
						ex);
					return "";
				}
			}
		}

		private static NameValueCollection _GSASettings;

		public static NameValueCollection GSASettings
		{
			get
			{
				if (_GSASettings == null)
				{
					_GSASettings = (NameValueCollection)System.Configuration.ConfigurationManager.GetSection("GSASettings");
				}

				return _GSASettings;
			}
		}

		//These are the words/phrases to remove from the beginning of the title for alphabetical sorting purposes
		private static List<string> _badFirstWords = new List<string>();

		public static List<String> BadFirstWords
		{
			get
			{
				if (_badFirstWords.Count == 0)
				{
					lock (_badFirstWords)
					{
						if (_badFirstWords.Count == 0)
						{
							_badFirstWords.Add("The");
							_badFirstWords.Add("A");
						}
					}
				}
				return _badFirstWords;
			}
		}


		private static void SendEmails(string errMsg)
		{
			try
			{
				//build the message
				StringBuilder messageBody = new StringBuilder();

				string subject = "ACR website not functioning correctly.";

				messageBody.Append(
					@"<br/>This automated email is being sent because ACR Imagewisely site is having an issue. Error Message:<br/>" +
					errMsg +
					@"<br/><br/>Check both live site, http://www.imagewisely.org and preview site, http://206.137.102.49/ and logs.<br/>");

				EmailSender emailSender = new EmailSender();
				MailMessage message = new MailMessage
										{
											From = new MailAddress("support@velir.com"),
											Subject = subject,
											IsBodyHtml = true,
											Body = messageBody.ToString()
										};

				//send the email!
				message.To.Clear();
				message.To.Add("pete.kemble@velir.com,diane.oconnell@velir.com,acr-svn-commit@velir.com");
				if (!emailSender.SendEmail(message))
				{
					Logger.Warn("AcrGlobals.cs: Failed to send site error notification to Pete Kemble and Diane");
					return;
				}
			}
			catch (Exception ex)
			{
				Logger.Warn("AcrGlobals.cs: Failed to send site error notification to Pete Kemble and Diane", ex);
			}

			return;
		}
	}
}
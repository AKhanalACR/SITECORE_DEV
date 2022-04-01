using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ACR.Library;
using ACR.Library.MSL.CustomItems.MammographySavesLives.ContentItems;
using ACR.Library.Reference;
using ACR.Library.Utils;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace ACR.services
{
	/// <summary>
	/// Summary description for AnnualReminderService
	/// </summary>
	[WebService(Namespace = "http://www.mammographysaveslives.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class AnnualReminderService : System.Web.Services.WebService
	{
		/// <summary>
		/// Adds a new Annual Reminder item to the master database
		/// </summary>
		/// <param name="skey"></param>
		/// <param name="month"></param>
		/// <param name="name"></param>
		/// <param name="email"></param>
		/// <param name="zip"></param>
		/// <returns>empty string, or error string if unsuccessful</returns>
		[WebMethod]
		public string AddAnnualReminder(string skey, string month, string name, string email, string zip)
		{
			if (skey == AcrGlobals.WebServicesSecurityKey)
			{
				//Get Access to the Specific Sitecore Database	
				Sitecore.Data.Database masterDb = Sitecore.Configuration.Factory.GetDatabase("master");
				if (masterDb == null)
					return "AnnualReminderService: Could not get master database.";

				//Get the Annual Reminders folder
				Item annualRemindersFolder = masterDb.GetItem(ItemReference.MSL_AnnualRemindersFolder.Guid);
				if (annualRemindersFolder == null)
					return "AnnualReminderService: Could not get Annual Reminders folder.";
				
				
				//Add new Sitecore Item to the parent item
				string newItemName = month + " " + DateTime.Now.Year + " " + name + " " + "Reminder";
				Item newItem = SitecoreUtils.CreateItem(annualRemindersFolder, newItemName, new ID(AnnualReminderItem.TemplateId));
				if (newItem != null)
				{
					using (new Sitecore.SecurityModel.SecurityDisabler())
					{
						newItem.Editing.BeginEdit();
						newItem["Full Name"] = name;
						newItem["Email"] = email;
						newItem["Zip Code"] = zip;
						newItem["Month"] = month;
						newItem.Editing.EndEdit();
					}
				}
				else
				{
					return "AnnualReminderService: Could not create new item. Item name: " + newItemName;
				}
			}
			else
			{
				return "AnnualReminderService: Security key is incorrect.";
			}
			return String.Empty;
				
		}
	}
}

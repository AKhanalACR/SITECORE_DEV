using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ACR.Library.Reference;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Jobs;
using Sitecore.Publishing;

namespace ACR.Library.Utils
{
	public class PublishUtil
	{
		public static void SmartPublishFromRoot(string id)
		{
			try
			{
				List<Database> targetDatabases = new List<Database>();
				if (DatabaseReference.Preview != null)
				{
					targetDatabases.Add(DatabaseReference.Preview);
				}
				if (DatabaseReference.Production != null)
				{
					targetDatabases.Add(DatabaseReference.Production);
				}
				Sitecore.Globalization.Language[] languages = DatabaseReference.Master.Languages;
				Item home = DatabaseReference.Master.GetItem(id);
				Handle h = PublishManager.PublishItem(home, targetDatabases.ToArray(), languages, true, true);

				while (!PublishManager.GetStatus(h).IsDone)
				{
					Thread.Sleep(1000);
					//Wait for this to finish up
				}
			}
			catch (Exception ex)
			{
				Sitecore.Diagnostics.Log.Error("Error smart publishing site - " + ex.Message, ex);
			}
		}
	}
}

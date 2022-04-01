using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ACR.Library.Reference;
using Common.Logging;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Globalization;
using Sitecore.Publishing;
using Sitecore.SecurityModel;
using Sitecore.Foundation.SitecoreExtensions.Extensions;

namespace ACR.Library.Utils
{
    public class SitecoreUtils
    {
        private static ILog _logger;

        private static ILog UtilLogger
        {
            get
            {
                _logger = _logger ?? LogManager.GetLogger(typeof(SitecoreUtils));
                return _logger;
            }
        }

				public const string ITEMNAMEFILTER_REGEX = @"[\/:\\?'<>|\[\]\-&@#\.%,\+\=;\{\}]";

				/// <summary>
				/// Cleans the Item Name - Changes & to "And", and removes disallowed characters
				/// </summary>
				/// <param name="itemName">The proposed item name</param>
				/// <returns>Cleaned Item name</returns>
				public static string ItemNameCleaner(string itemName)
				{
					string newName = itemName.Trim();

					newName = newName.Replace("&", "And");
					newName = newName.Replace("\"", " ");

					var regex = new Regex(ITEMNAMEFILTER_REGEX);
					var m = regex.Match(newName);
					if (m.Success)
					{
						// Do name replacement here
						newName = regex.Replace(newName, " ");
					}

					return newName.Trim();
				}

				/// <summary>
				/// Creates a new item. Returns newly created Item or null.
				/// </summary>
				/// <param name="parentItemPath">The Parent Item Path of the new Item</param>
				/// <param name="newItemName">Proposed Item Name - it will be cleaned</param>
				/// <param name="templateId">The Sitecore ID of the Template that the Item should use</param>
				/// <returns>The Item (may be null if Item could not be created)</returns>
				public static Item CreateItem(string parentItemPath, string newItemName, ID templateId)
				{
					//Get the parent item from the master database
					Database masterDb = Sitecore.Configuration.Factory.GetDatabase("master");
					Item parentItem = masterDb.GetItem(parentItemPath);
					return CreateItem(parentItem, newItemName, templateId);
				}

				/// <summary>
				/// Creates a new item. Returns newly created Item or null.
				/// </summary>
				/// <param name="parentItem">The Parent Item of the new Item</param>
				/// <param name="newItemName">Proposed Item Name - it will be cleaned</param>
				/// <param name="templateId">The Sitecore ID of the Template that the Item should use</param>
				/// <returns>The Item (may be null if Item could not be created</returns>
				public static Item CreateItem(Item parentItem, string newItemName, ID templateId)
				{
					if (parentItem == null || String.IsNullOrEmpty(newItemName) || templateId == (ID)null)
						return null;

					string itemName = ItemNameCleaner(newItemName); ;

					Database masterDb = Sitecore.Configuration.Factory.GetDatabase("master");
					if(masterDb == null)
					{
						UtilLogger.Error("Could not get the Master DB to create item. Item name:" + itemName + ", Template ID: " + templateId);
						return null;
					}

					//Get the template from which the item is created
					TemplateItem template = masterDb.GetTemplate(templateId);
					if (template == null)
					{
						UtilLogger.Error("Could not get Template to create item. Item name:" + itemName + ", Template ID: " + templateId);
						return null;
					}

					Item newItem = null;
					using (new SecurityDisabler())
					{
						//Add the new item as a child to the parent
						UtilLogger.Info("Begin Creating Item - Name: " + itemName);
						newItem = parentItem.Add(itemName, template);
						UtilLogger.Info("End Creating Item - Name: " + itemName);
					}

					// Update the History table with the new item info
					if (newItem != null)
					{
						masterDb.Engines.HistoryEngine.RegisterItemCreated(newItem);
					}

					return newItem;
				}

        /// <summary>
        /// Returns true or false if the child Item is decendant of Parent Item
        /// </summary>
        /// <param name="childItem">Child Item to Start at</param>
        /// <param name="parentItem">Parent Item to Check for</param>
        /// <returns>bool</returns>
        public static bool IsChildOfItem(Item childItem, Item parentItem)
        {
            return childItem.Axes.IsDescendantOf(parentItem);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="childItem">Child item to start at</param>
        /// <param name="parentPath">Path of Item to Look for</param>
        /// <returns>bool</returns>
        public static bool IsChildOfItem(Item childItem, string parentPath)
        {
            Item parentItem = childItem.Database.GetItem(parentPath);
            return IsChildOfItem(childItem, parentItem);
        }

        /// <summary>
        /// Checks to see if the Template is part of the Shared Template Path
        /// </summary>
        /// <param name="templateItem">Template Item to Look For</param>
        /// <returns>bool</returns>
        public static bool IsSharedTemplate(TemplateItem templateItem)
        {
            return IsChildOfItem(templateItem.InnerItem, ItemReference.Templates_AcrCommon.Guid);
        }


        /// <summary>
        /// This is the default value of a Sitecore Date form field when no value has been set.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static Boolean IsDefaultDate(DateTime date)
        {
            return (date.ToString().Trim().Equals("1/1/0001 12:00:00 AM")) ? true : false;
        }

        public static bool IsValid(string templateId, Item item)
        {
            return IsValid(templateId, item, Sitecore.Context.Database);
        }

        public static bool IsValid(string templateId, Item item, Database db)
        {
						if (String.IsNullOrEmpty(templateId))
							return false;

            if (item == null)
                return false;

						//If the item is of the current template type of has a base template of the current type
						//return true.
            if (item.TemplateID.ToString().Equals(templateId) || item.IsDerived(templateId))               
            {
                return true;
            }

            return false;
        }

        public static bool IsViewable(Item item)
        {
            return (item.Visualization.Layout != null);
        }

        public static void PublishItem(Item item, bool deep)
        {
            DateTime publishDate = DateTime.Now;
            Database master = Sitecore.Configuration.Factory.GetDatabase("master");
            Item targets = master.GetItem("/sitecore/system/publishing targets");
            ItemChanges changes = new ItemChanges(item);
            foreach (Item target in targets.Children)
            {
                Database targetDb;
                string targetDbName = target["target database"];
                try
                {
                    targetDb = Sitecore.Configuration.Factory.GetDatabase(targetDbName);
                }
                catch(Exception ex)
                {
                    UtilLogger.Warn("Publishing target db could not be found. targetDbName: " + target["target database"], ex);
                    return;
                }
                foreach (Language language in master.Languages)
                {
                    PublishOptions publishOptions = new PublishOptions(master, targetDb, PublishMode.SingleItem, language, publishDate)
                    {
                        RootItem = item,
                        Deep = deep
                    };

                    Publisher publisher = new Publisher(publishOptions);
                    publisher.Publish();
                }
                // Register the item change in the history engine
                targetDb.Engines.HistoryEngine.RegisterItemSaved(item, changes);

                
            }
        }

        public static void PublishItem(Item item)
        {
            PublishItem(item, false);
        }

			public static void RecycleItem (Item item)
			{
				if (item == null)
				{
					return;
				}
				using (new SecurityDisabler())
				{
					UtilLogger.Info("Recycling item " + item.ID + ", " + item.Paths.FullPath);
					item.Editing.BeginEdit();
					item.Recycle();
					item.Editing.EndEdit();
				}
			}
    }
}

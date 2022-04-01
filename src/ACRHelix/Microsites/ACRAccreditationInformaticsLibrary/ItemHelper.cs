using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Publishing;
using Sitecore.Links;
using ACR.Constants;

namespace ACRAccreditationInformaticsLibrary
{
    public class ItemHelper
    {
        /// <summary>
        /// Publish item to web
        /// </summary>
        /// <param name="i">item</param>
        /// <param name="children">publish children</param>
        public static void Publish(Item item, bool children)
        {
            PublishOptions opt = new PublishOptions(item.Database, Factory.GetDatabase("web"), PublishMode.Full, item.Language, DateTime.Now);
            opt.RootItem = item;
            opt.Deep = children;

            new Publisher(opt).Publish();
        }

        public static string getStringFieldWithFallback(string targetFieldName, string fallbackFieldName, Item item)
        {
            try
            {
                return string.IsNullOrWhiteSpace(targetFieldName) ? fallbackFieldName : targetFieldName;
            }
            catch (Exception ex)
            {
                Log.Error("Error getting fallback field", ex, new ItemHelper());
            }

            return "";
        }

        public static bool isFieldChecked(CheckboxField checkBoxField)
        {

            if (checkBoxField != null)
            {
                if (checkBoxField.Checked)
                    return true;

            }

            return false;
        }

        public static DateTime getDateField(Item item, string fieldName)
        {
            var sitecoreDate = (DateField)item.Fields[fieldName];

            if (sitecoreDate != null)
            {
                if (!string.IsNullOrEmpty(sitecoreDate.ToString()))
                {
                    return sitecoreDate.DateTime;
                }

            }

            return DateTime.MinValue;
        }


        public static Item getReferenceItem(Item item, string fieldName)
        {
            if (item.Fields[fieldName] != null)
            {
                return ((ReferenceField)item.Fields[fieldName]).TargetItem;
            }

            return null;

        }

        public static string GetFieldValue(Item contentItem, string fieldName)
        {
            return Utilities.NotNullOrEmpty(contentItem, fieldName)
                       ? contentItem.Fields[fieldName].Value
                       : "";
        }


        public static string GetFieldValueOrDefault(Item contentItem, string fieldName, string defaultValue)
        {
            return Utilities.NotNullOrEmpty(contentItem, fieldName)
                       ? contentItem.Fields[fieldName].Value
                       : defaultValue;
        }

        public static string GetFieldValueOrItemName(Item contentItem, string fieldName)
        {
            if (contentItem != null)
                return Utilities.NotNullOrEmpty(contentItem, fieldName)
                           ? contentItem.Fields[fieldName].Value
                           : contentItem.Name;
            return "";
        }

        public static string GetExtensionlessUrl(Item contentItem)
        {
            var url = string.Empty;

            if (contentItem != null)
            {
                url = LinkManager.GetItemUrl(contentItem).Trim();
                if (url.EndsWith(".aspx"))
                    url = url.Substring(0, (url.Length - 5));
            }
            return url.ToLower();
        }

        public static string GetIndexAnchorUrl(Item contentItem, int listItemIndex)
        {
            var url = string.Empty;

            if (contentItem.Parent != null)
            {
                url = LinkManager.GetItemUrl(contentItem.Parent).Trim();
                if (url.EndsWith(".aspx"))
                    url = url.Substring(0, (url.Length - 5));

                url = url + "#s" + listItemIndex;
            }
            return url.ToLower();
        }
    }
}

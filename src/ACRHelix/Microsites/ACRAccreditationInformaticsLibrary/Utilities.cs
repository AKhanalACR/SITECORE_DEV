using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;



namespace ACRAccreditationInformaticsLibrary
{
    public class Utilities
    {

        public static Item GetItemByGuid(string guid)
        {
           return Sitecore.Context.Database.GetItem(guid);
        }

        public static bool NotNullOrEmpty(Item contentItem, string fieldName)
        {
            if (contentItem == null)
                return false;

            if (fieldName.Length == 0)
                return false;

            if (contentItem.Fields[fieldName] != null)
            {
                if (contentItem.Fields[fieldName].Value.Trim().Length == 0)
                    return false;

                if (contentItem.Fields[fieldName].ContainsStandardValue)
                    return true;

                if (contentItem.Fields[fieldName].HasValue)
                    return true;

                return false;
            }
            return false;
        }
    }
}

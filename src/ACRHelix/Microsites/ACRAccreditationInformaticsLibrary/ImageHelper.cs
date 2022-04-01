using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Diagnostics;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace ACRAccreditationInformaticsLibrary
{
    public class ImageHelper
    {
        public static string getImageURLFromField(Item item, string fieldName)
        {
            try
            {
                ImageField imgField = item.Fields[fieldName];
                return Sitecore.Resources.Media.MediaManager.GetMediaUrl(imgField.MediaItem);
            }
            catch (Exception ex)
            {
                Log.Error("Error getting media src", ex, new ItemHelper());
            }

            return "";
        }

        public static ImageField getSitecoreImageFromField(Item item, string fieldName)
        {
            try
            {
                ImageField imgField = item.Fields[fieldName];
                return imgField;
            }
            catch (Exception ex)
            {
                Log.Error("Error getting media src", ex, new ItemHelper());
            }

            return item.Fields[fieldName];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using CustomItemGenerator.Fields.SimpleTypes;
using Sitecore.Data.Items;

namespace ACR.Library.Utils
{
    public static class MetaUtils
    {

        /// <summary>
        /// Certain characters interfere with searches in meta tags, so strip them out.
        /// </summary>
        /// <param name="s">the string to sanitize</param>
        /// <returns>a string with all problematic characters removed</returns>
        public static string StripBadGSACharacters(string s)
        {
            //Periods, apostrophes, ampersands need to be removed completely.
            //There may be other characters that cause problems, but these are the only
            //three that have been run into thus far.
            s = Regex.Replace(s, @"[&'\.]", "");

            return s;
        }

        public static string GetDate(Item item)
        {
            return FormatDate(item.Statistics.Updated);
        }

        public static string FormatDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");

        }

    	//public static string GetMetaKeywordsForCoveo(string metaKeywords)
    	//{
    	//	return metaKeywords.Replace("\n", CoveoField.ValueSeparator);
    	//}
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace ACR.Library.Utils
{
	public class UtilStripHtml
	{
		const string HTML_TAG_PATTERN = "<.*?>";

		public static string GetRawText(string richText)
		{
			// first remove all html tags
			string rawText = Regex.Replace(richText, HTML_TAG_PATTERN, string.Empty);
			// then replace line breaks with spaces.
			rawText = rawText.Replace(Environment.NewLine, " ");
			return rawText;
		}




		public static int GetWordCount(string richText)
		{
			string cleanedText = GetRawText(richText);
			string[] result;
			try
			{
				result = cleanedText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			}
			catch (Exception ex)
			{
				return 0;
			}
			return result.Length;
		}


	}
}

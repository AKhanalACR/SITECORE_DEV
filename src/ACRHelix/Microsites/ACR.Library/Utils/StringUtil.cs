using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace ACR.Library.Utils
{
	public class StringUtil
	{
		public static string GetNonEmptyString(string primary, params string[] fallbacks)
		{
			if (!string.IsNullOrEmpty(primary))
			{
				return primary;
			}
			foreach (var fallback in fallbacks)
			{
				if (!string.IsNullOrEmpty(fallback))
				{
					return fallback;
				}
			}
			return string.Empty;
		}

		public static string GetShortenString(string text)
		{
			return GetShortenString(text, 300);
		}

		public static string GetShortenString(string text, int length)
		{
			if (length < 1) length = 300;

			return (text.Length > length ? text.Substring(0, length).Trim() + "..." : text);
		}

		public static string ReplacePTagsWithBrTags(string input)
		{
			Regex backToBackPTags = new Regex(@"<\s*[/]\s*[pP]\s*>\s*<\s*[pP]\s*>");
			//replace back to back p tags with 2 <br/> tags
			input = backToBackPTags.Replace(input, "<br/><br/>");

			//now get rid of the other p tags
			Regex allPTags = new Regex(@"<\s*[/]?\s*[pP]\s*>");
			input = allPTags.Replace(input, "");
			return input;
		}
		public static string GetWholeShortenString(string text, int length)
		{
			if(length < text.Length && text.IndexOf(' ', length) > 0)
			{
			return GetShortenString(text, text.IndexOf(' ', length));
			}
			return text;
		}

		//Substring the inner text of Html nodes, preserving tags.
		public static string GetHtmlSubstring(string input, int maxLength)
		{
			if (string.IsNullOrEmpty(input) || maxLength <= 0)
			{
				return string.Empty;
			}
			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(input);

			// Get text nodes with the appropriate running total
			int acc = 0;
			var nodes = doc.DocumentNode
				.Descendants()
				.Where(n => n.NodeType == HtmlNodeType.Text && n.InnerText.Trim().Length > 0)
				.Select(n =>
				{
					int length = n.InnerText.Trim().Length;
					acc += length;
					return new { Node = n, TotalLength = acc, NodeLength = length };
				})
				.TakeWhile(n => (n.TotalLength - n.NodeLength) < maxLength)
				.ToList();

			// Select element nodes we intend to keep
			IEnumerable<HtmlNode> nodesToKeep = nodes
				.SelectMany(n => n.Node.AncestorsAndSelf()
					.Where(m => m.NodeType == HtmlNodeType.Element || m == n.Node));

			// Select and remove element nodes we don't need
			List<HtmlNode> nodesToDrop = doc.DocumentNode
				.Descendants()
				.Except(nodesToKeep)
				.ToList();

			foreach (HtmlNode r in nodesToDrop)
				r.Remove();

			// Shorten the last node as required
			var lastNode = nodes.Last();
			HtmlNode lastNodeText = lastNode.Node;
			string text = lastNodeText.InnerText.Trim();
			if (lastNode.NodeLength - lastNode.TotalLength + maxLength < text.Length && text.IndexOf(' ', lastNode.NodeLength - lastNode.TotalLength + maxLength) >= 0)
			{
				text = text.Substring(0, text.IndexOf(' ', lastNode.NodeLength - lastNode.TotalLength + maxLength)).Trim() + "...";
			}
			HtmlNode newLast = HtmlNode.CreateNode(text);
			lastNodeText
				.ParentNode
				.ReplaceChild(newLast, lastNodeText);


			return doc.DocumentNode.OuterHtml;

		}

		/// <summary>
		/// Determines whether [is null or whitespace] [the specified input].
		/// </summary>
		/// <param name="input">The input.</param>
		/// <returns></returns>
		public static bool IsNullOrWhiteSpace(string input)
		{
			if (input == null)
			{
				return true;
			}

			input = input.Trim();
			return string.IsNullOrEmpty(input);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace ACR.Library.Utils
{
	public static class HtmlAgilityExtender
	{
		public static IEnumerable<HtmlNode> DescendantNodes(this HtmlNode node)
		{
			foreach (HtmlNode iteratorVariable0 in node.ChildNodes.OfType<HtmlNode>())
			{
				yield return iteratorVariable0;
				foreach (HtmlNode iteratorVariable1 in DescendantNodes(iteratorVariable0))
				{
					yield return iteratorVariable1;
				}
			}
		}
	public static IEnumerable<HtmlNode> Descendants(this HtmlNode node)
{
    foreach (HtmlNode iteratorVariable0 in node.DescendantNodes())
    {
        yield return iteratorVariable0;
    }
}
	public static IEnumerable<HtmlNode> AncestorsAndSelf(this HtmlNode node)
	{
		HtmlNode parentNode = node;
		while (true)
		{
			if (parentNode == null)
			{
				yield break;
			}
			yield return parentNode;
			parentNode = parentNode.ParentNode;
		}
	}
	public static void Remove(this HtmlNode node)
	{
		if (node.ParentNode != null)
		{
			node.ParentNode.RemoveChild(node);
		}
	}




	}

}

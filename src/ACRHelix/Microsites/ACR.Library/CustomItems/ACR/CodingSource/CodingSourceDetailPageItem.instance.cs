using System;
using System.Linq;
using Sitecore.Data.Items;
using System.Collections.Generic;

namespace ACR.Library.ACR.CodingSource
{
	public partial class CodingSourceDetailPageItem
	{
		public List<CodingSourceDetailPageItem> GetChildPages()
		{
			if(InnerItem.HasChildren)
			{
				return InnerItem.GetChildren().Select(i => new CodingSourceDetailPageItem(i)).ToList();
			}
			return new List<CodingSourceDetailPageItem>();
		}

		public CodingSourceDetailPageItem GetNextPage()
		{
			// First, check if this is a parent of a child, and if we can move to the child.
			if (InnerItem.HasChildren)
			{
				return InnerItem.Children.First();
			}

			Item nextSibling = InnerItem.Axes.GetNextSibling();

			if (nextSibling == null) // Check if this has a parent Detail page, and then check if it has a sibling
			{
				if (IsChildDetailPage())
				{
					return InnerItem.Parent.Axes.GetNextSibling();
				}
				return null;
			}
			// Just return the item since its not null
			return nextSibling;
		}

		private bool IsCodingSourceDetail(Item item)
		{
			string templateId = item.TemplateID.ToString();
			return templateId == CodingSourceDetailPageItem.TemplateId ||
						 templateId == CodingSourceWideDetailPageItem.TemplateId;
		}

		private bool IsCodingSourceIndex(Item item)
		{
			return item.TemplateID.ToString() == CodingSourceIndexItem.TemplateId;
		}

		private bool IsChildDetailPage()
		{
			return IsCodingSourceDetail(InnerItem.Parent);
		}

		public bool HasNextPage()
		{
			return GetNextPage() != null;
		}

		public CodingSourceDetailPageItem GetPreviousPage()
		{
			if (IsChildDetailPage())
			{
				Item previousChildSibling = InnerItem.Axes.GetPreviousSibling();

				// If we're a child, try to get the previous sibling.
				if (previousChildSibling != null)
				{
					return previousChildSibling;
				}
				// If it doesn't exist, get the parent page
				return InnerItem.Parent;
			}

			Item previousSibling = InnerItem.Axes.GetPreviousSibling();

			if (previousSibling != null)
			{
				// If we're a parent, try to get the last child of our previous sibling.
				if (previousSibling.HasChildren)
				{
					return previousSibling.Children.Last();
				}
				// If it doesn't exist, get the previous sibling.
				return previousSibling;
			}
			else
			{
				return null;
			}
		}

		public bool HasPreviousPage()
		{
			return GetPreviousPage() != null;
		}

		public CodingSourceIndexItem GetIndexPage()
		{
			if (IsCodingSourceIndex(InnerItem.Parent))
			{
				return InnerItem.Parent;
			}
			CodingSourceDetailPageItem parent = InnerItem.Parent; // If its parents isn't an index, its a child. Get the parent.
			return parent.GetIndexPage();
		}
	}
}
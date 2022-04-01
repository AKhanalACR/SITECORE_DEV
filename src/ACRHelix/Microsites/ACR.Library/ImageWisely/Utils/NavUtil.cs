using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.Common.Interfaces;
using ACR.Library.Common.Interfaces.Factory;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Base;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Components;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Pages;
using ACR.Library.Reference;
using ACR.Library.Utils;
using Common.Logging;
using Sitecore.Data.Items;

namespace ACR.Library.ImageWisely.Utils
{
	public static class NavUtil
	{
		private static ILog _logger;

		private static ILog Logger
		{
			get
			{
				_logger = _logger ?? LogManager.GetLogger(typeof (NavUtil));
				return _logger;
			}
		}

		public static Item GetCurrentSection()
		{
			return GetFirstLevelSection(Sitecore.Context.Item);
		}

		public static Item GetFirstLevelSection(Item item)
		{
			if (item.ID.ToString() == ItemReference.ImageWisely.Guid)
			{
				return ItemReference.ImageWisely.InnerItem;
			}
			else
			{
				return CrawlToFirstLevel(item);
			}
		}

		private static Item CrawlToFirstLevel(Item item)
		{
			//If for some reason we started at or above the home page node, return the home page node
			if (item.Parent == null)
			{
				return ItemReference.ImageWisely.InnerItem;
			}
			if (item.Parent.ID.ToString() == ItemReference.ImageWisely.Guid)
			{
				return item;
			}
			else
			{
				return CrawlToFirstLevel(item.Parent);
			}
		}

		private static Item CrawlToLevel(int level, Item item)
		{
			int levelCount = GetLevelCount(item);
			if (levelCount == 0)
			{
				return ItemReference.Home.InnerItem;
			}
			if (levelCount == level)
			{
				return item;
			}
			else
			{
				return CrawlToLevel(level, item.Parent);
			}
		}

		public static int GetLevelCount(Item item)
		{
			int count = 0;
			for (count = 0; item != null && item.ID.ToString() != ItemReference.Home.Guid; count++)
			{
				item = item.Parent;
			}

			return count;
		}

		public static List<Item> GetViewableChildren(Item root)
		{
			List<Item> children = new List<Item>();
			foreach (Item child in root.Children)
			{
				if (child.Visualization.Layout != null)
				{
					children.Add(child);
				}
			}
			return children;
		}

		public static List<Item> GetItemsAtLevel(int level, Item currentItem)
		{
			int currentLevel = GetLevelCount(currentItem);
			Item root = currentItem.Parent;
			if (currentLevel == 1)
			{
				root = currentItem;
			}
			else
			{
				for (int i = currentLevel - level; i > 0; i--)
				{
					root = root.Parent;
				}
			}

			return GetViewableChildren(root);
		}

		public static List<Item> GetStandardBreadcrumb(Item root)
		{
			List<Item> crumb = new List<Item>();
			if (root.ID.ToString() != ItemReference.Home.Guid)
			{
				crumb.AddRange(GetStandardBreadcrumb(root.Parent));
			}
			if (SitecoreUtils.IsViewable(root))
			{
				crumb.Add(root);
			}
			return crumb;
		}

		public static bool IsParentOf(Item parent, Item child)
		{
			for (Item item = child; item != null && item.ID.ToString() != ItemReference.Home.Guid; item = item.Parent)
			{
				if (item.ID.ToString() == parent.ID.ToString())
				{
					return true;
				}
			}
			return false;
		}

		public static List<PageSettingsItem> GetMainNavItems(Item parentItem)
		{
			if (parentItem == null)
			{
				return null;
			}

			IEnumerable<Item> items =
				parentItem.Children.Where(
					i => i != null
					     && SitecoreUtils.IsValid(PageSettingsItem.TemplateId, i)
					     && ((PageSettingsItem) i).DisplayinMainNav.Checked);

			return items.Select(i => (PageSettingsItem) i).ToList();
		}

		public static List<IPageItem> GetMainSubNavItems(Item parentItem)
		{
			if (parentItem == null)
			{
				return null;
			}

			try
			{
				//Do check for exceptions first
				if (parentItem.TemplateID.ToString() == PledgeLandingItem.TemplateId)
				{
					//Special handling for Pledge item - first add the Pledge Landing Item itself
					List<IPageItem> items = new List<IPageItem>();
					items.Add(ItemInterfaceFactory.GetItem<IPageItem>(parentItem));
					var subitems = parentItem.Children.Where(
						i => i != null
						     && SitecoreUtils.IsValid(HonorRollItem.TemplateId, i));
					var pageItems = subitems.Select(i => ItemInterfaceFactory.GetItem<IPageItem>(i));
					items.AddRange(pageItems);
					return items;
				}
				else
				{
					//Get viewable children
					IEnumerable<Item> items =
						parentItem.Children.Where(
							i => i != null
							     && SitecoreUtils.IsValid(PageSettingsItem.TemplateId, i));
					return items.Select(i => ItemInterfaceFactory.GetItem<IPageItem>(i)).ToList();
				}
			}
			catch (Exception exc)
			{
				Logger.Error(exc);
				return null;
			}


		}

		public static List<VendorItem> GetVendorItems(Item parentItem)
		{
			//Get viewable children
			IEnumerable<Item> items =
				parentItem.Axes.GetDescendants().Where(
					i => i != null
					     && SitecoreUtils.IsValid(VendorItem.TemplateId, i));

			return items.Select(i => ((VendorItem) i)).ToList();
		}

		public static List<IPageItem> GetAuxNavItems(Item parentItem)
		{
			IEnumerable<Item> items =
				parentItem.Children.Where(
					i => i != null
					     && SitecoreUtils.IsValid(PageSettingsItem.TemplateId, i)
					     && ((PageSettingsItem) i).DisplayinAuxiliaryNav.Checked);

			return items.Select(i => ItemInterfaceFactory.GetItem<IPageItem>(i)).ToList();
		}

		public static List<SocialMediaLinkItem> GetSocialMediaItems(Item parentItem)
		{
			string templateId =
				ImageWisely.CustomItems.ImageWisely.Components.SocialMediaLinkItem.TemplateId;
			IEnumerable<Item> items =
				parentItem.Axes.GetDescendants().Where(
					i => i != null
					     && SitecoreUtils.IsValid(templateId, i)
					);

			return items.Select(i => (SocialMediaLinkItem) i).ToList();
		}

		public static List<IPageItem> GetFooterNavItems(Item parentItem)
		{
			IEnumerable<Item> items =
				parentItem.Children.Where(
					i => i != null
					     && SitecoreUtils.IsValid(PageSettingsItem.TemplateId, i)
					     && ((PageSettingsItem) i).DisplayinFooterNav.Checked);

			return items.Select(i => ItemInterfaceFactory.GetItem<IPageItem>(i)).ToList();
		}

		public static Item GetFirstLevelAncestor(Item descendantItem)
		{
			Item ancestorItem = descendantItem;
			for (Item item = descendantItem; item != null && item.ID.ToString() != ItemReference.Home.Guid; item = item.Parent)
			{
				ancestorItem = item;
			}

			return ancestorItem;
		}
	}
}

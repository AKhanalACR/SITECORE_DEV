using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.Common.Interfaces;
using ACR.Library.Common.Interfaces.Factory;
using ACR.Library.Reference;
using Sitecore.Data.Items;
using Sitecore.Links;

namespace ACR.Library.CustomSitecore.Extensions
{
	public static class ItemExtensions
	{
		/// <summary>
		/// Gets a list of all child items that have a particular template
		/// </summary>
		/// <param name="parent">The parent item whose children will be searched on.</param>
		/// <param name="templateId">Child items of the parent with this template id will be returned.</param>
		/// <returns>All children that have the specified template id.</returns>
		public static List<Item> GetChildrenByTemplate(this Item parent, string templateId)
		{
			List<Item> items = new List<Item>();
			foreach (Item item in parent.Children)
			{
				if (item.TemplateID.ToString() == templateId)
				{
					items.Add(item);
				}
			}
			return items;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <param name="templateId"></param>
		/// <returns>True if the item is of the current template type or has a base template of the current type</returns>
		public static bool IsValidTemplate(this Item item, string templateId)
		{
			return BaseTemplateReference.IsValidTemplate(item, templateId);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="item"></param>
		/// <returns>Returns an instance of the Interface object given, or null if it does not implement</returns>
		public static T GetInterfaceItem<T>(this Item item)
		{
			return ItemInterfaceFactory.GetItem<T>(item);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="item"></param>
		/// <returns></returns>
		public static string GetItemUrl(this Item item)
		{
			if (item == null) return "";
			return LinkManager.GetItemUrl(item);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="item"></param>
		/// <returns></returns>
		public static bool ImplementsInterface<T>(this Item item)
		{
			return ItemInterfaceFactory.GetItem<T>(item) != null;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <param name="templateId"></param>
		/// <returns>Returns a list representing the breadcrumb.  This includes all Navigation Items including ones with 'Hide Breadcrumb' selected.</returns>
		//public static IEnumerable<INavigationItem> GetBreadCrumb(this INavigationItem item)
		//{
		//	Item itemAccumulator = ((CustomItemBase)item).InnerItem;
		//	Stack<INavigationItem> itemNav = new Stack<INavigationItem>();

		//	INavigationItem iNav = ItemInterfaceFactory.GetItem<INavigationItem>(itemAccumulator);
		//	while (itemAccumulator != null && itemAccumulator.ID != ItemReference.ACR_Home.InnerItem.ID)
		//	{
		//		if (iNav != null)
		//		{
		//			itemNav.Push(iNav);
		//		}
		//		itemAccumulator = itemAccumulator.Parent;
		//		iNav = itemAccumulator.GetInterfaceItem<INavigationItem>();
		//	}
		//	return itemNav;
		//}


		
	}
}

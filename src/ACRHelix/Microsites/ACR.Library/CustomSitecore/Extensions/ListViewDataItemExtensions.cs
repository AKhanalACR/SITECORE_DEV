using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ACR.Library.CustomSitecore.Extensions
{
	public static class ListViewDataItemExtensions
	{
		/// <summary>
		/// Will try to determine the group index of a ListViewDataItem bound to a ListView
		/// using groups.
		/// </summary>
		/// <param name="dataItem">The ListViewDataItem to get the group index of.</param>
		/// <returns></returns>
		public static int GetGroupIndex(this ListViewDataItem dataItem)
		{
			//if our data item is null then return -1
			if (dataItem == null)
			{
				return -1;
			}

			//get the index of our data item
			int itemIndex = dataItem.DataItemIndex;

			//if our item index isn't valid then return -1
			if (itemIndex < 0)
			{
				return -1;
			}

			//get the list view control from our data item
			ListView listView = null;
			Control parent = dataItem.NamingContainer;
			while (parent != null)
			{
				//see if the current parent is our list view
				if (parent is ListView)
				{
					//set our list view
					listView = (ListView)parent;

					//break out of loop
					break;
				}

				//we must not have found our list view yet.
				//check our parent.
				parent = parent.NamingContainer;
			}

			//if we never found our list view then return -1
			if (listView == null)
			{
				return -1;
			}

			//get our group count from our list view
			int groupCount = listView.GroupItemCount;

			//our group count should be at least 1
			if (groupCount <= 0)
			{
				groupCount = 1;
			}

			//calculate our row number
			int rowNum = (int)Math.Floor((double)itemIndex / groupCount);

			//calculate our group index.
			int groupIndex = itemIndex - (rowNum * groupCount);

			//return our group index
			return groupIndex;
		}
	}
}

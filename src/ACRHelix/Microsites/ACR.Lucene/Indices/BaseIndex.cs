using System;
using System.Collections.Generic;
using ACR.Lucene.Options;
using ACR.Lucene.Parameters;
using ACR.Lucene.Util;
using Sitecore.Collections;
using Sitecore.Data.Items;

namespace ACR.Lucene.Indices
{
	public class BaseIndex : IDisposable
	{
		public string IndexName { get; private set; }

		public BaseIndex() : this(string.Empty)
		{
		}

		public BaseIndex(string indexName)
		{
			IndexName = indexName;
		}

		public List<LightweightItem> GetLightweightItemsUnder(string itemGuid)
		{
			//If there is no index specified return and empty list
			if (string.IsNullOrEmpty(IndexName)) return new List<LightweightItem>();
			if (string.IsNullOrEmpty(itemGuid)) return new List<LightweightItem>();

			//return Searcher.GetLightweightItems(IndexName, itemGuid);
      return null;
		}

        /*
		public List<LightweightItem> GetLightweightItems(SafeDictionary<string> filters,DateRangeSearchParam dateRange, SearchOptions searchOptions)
		{
			//If there is no index specified return and empty list
			if (string.IsNullOrEmpty(IndexName)) return new List<LightweightItem>();

            /
            var searchIndex = Sitecore.ContentSearch.ContentSearchManager.GetIndex(IndexName);
            using (var context = searchIndex.CreateSearchContext())
            {
                
            }




                return Searcher.GetLightweightItems(IndexName, filters, dateRange, searchOptions);
		}

		public List<LightweightItem> GetLightweightItems(SafeDictionary<string> filters, SearchOptions searchOptions)
		{
			return GetLightweightItems(filters, null, searchOptions);
		}

		public List<LightweightItem> GetLightweightItems(string fieldName, string fieldValue, SearchOptions searchOptions)
		{
			return GetLightweightItems(fieldName, fieldValue, null, searchOptions);
		}

		public List<LightweightItem> GetLightweightItems(string fieldName, string fieldValue, DateRangeSearchParam dateRange, SearchOptions searchOptions)
		{
			SafeDictionary<string> filters = new SafeDictionary<string>();
			if (!string.IsNullOrEmpty(fieldName))
			{
				filters.Add(fieldName, fieldValue);
			}
			return GetLightweightItems(filters, dateRange, searchOptions);
		}

		public List<LightweightItem> GetLightweightItems(string fieldName, string fieldValue, string templateFilter, string locationFilter)
		{
			SafeDictionary<string> filters = new SafeDictionary<string>();
			if (!string.IsNullOrEmpty(fieldName))
			{
				filters.Add(fieldName, fieldValue);
			}
			return Searcher.GetLightweightItems(IndexName, filters, locationFilter, templateFilter);
		}
    */
		public void Dispose()
		{
			IndexName = null;
		}
        /*

		public List<T> GetContentItems<T>()
		{
			return GetContentItems<T>(null);
		}

		public List<T> GetContentItems<T>(SearchOptions searchOptions)
		{
			return GetContentItems<T>(new SafeDictionary<string>(),null, searchOptions);
		}

		public List<T> GetFilteredItems<T>(string fieldName, string fieldValue, SearchOptions searchOptions)
		{
			return GetFilteredItems<T>(fieldName, fieldValue, null, searchOptions);
		}

		public List<T> GetFilteredItems<T>(string fieldName, string fieldValue, DateRangeSearchParam dateRange, SearchOptions searchOptions)
		{
			SafeDictionary<string> filters = new SafeDictionary<string>();

			if (!string.IsNullOrEmpty(fieldName))
			{
				filters.Add(fieldName, fieldValue);
			}

			return GetContentItems<T>(filters, dateRange,searchOptions);
		}
        
		public List<T> GetContentItems<T>(SafeDictionary<string> filters, DateRangeSearchParam dateRange, SearchOptions searchOptions)
		{
			List<LightweightItem> lightweightItems = GetLightweightItems(filters,dateRange, searchOptions);

			//Convert items
			List<T> content = new List<T>();
			foreach (LightweightItem lightweightItem in lightweightItems)
			{
				Item item = Sitecore.Context.Database.GetItem(lightweightItem.ItemID);
				T converted = (T)Convert.ChangeType(item, typeof(T));
				if (converted == null) continue;
				content.Add(converted);
			}

			return content;
		}*/
	}
}

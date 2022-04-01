using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.Cache;
using ACR.Library.RLI.Base;
using ACR.Library.RLI.Pages;
using ACR.Lucene.Indices;
using ACR.Lucene.Options;
using ACR.Lucene.Parameters;
using ACR.Lucene.Util;
using Sitecore.Collections;
using Sitecore.Data.Items;

namespace ACR.Library.RLI.RLILucene.Indices.PressReleases
{
	public class RLIPressReleasesIndex:BaseIndex
	{
		public RLIPressReleasesIndex()
			:base(RLISiteIndexes.RLIPressReleases)
		{
			
		}

		public static DateRangeSearchParam GetDefaultDateParam()
		{
			return GetDateParam(DateTime.Now.AddYears(-1), DateTime.Now);
		}

		private static DateRangeSearchParam GetDateParam(DateTime startDate, DateTime endDate)
		{
			DateRangeSearchParam dateRangeSearchParam = new DateRangeSearchParam();
			dateRangeSearchParam.Ranges = new List<DateRangeSearchParam.DateRangeField>();
			dateRangeSearchParam.Ranges.Add(new DateRangeSearchParam.DateRangeField(PressReleaseItem.FieldName_Date, startDate, endDate));
			return dateRangeSearchParam;
		}

		public static SearchOptions GetDefaultSort(int maxItems)
		{
            return new SearchOptions(new SortOptions(PressReleaseItem.FieldName_Date, SortDirection.Reverse), new PaginationOptions(1, maxItems));
		}

		/// <summary>
		/// Returns the latest Press Releases ordered by Date.
		/// </summary>
		/// <returns></returns>
		public IList<PressReleaseItem> GetLatestPressReleases(int maxItems)
		{
			return GetPressReleases(new SafeDictionary<string>(), GetDefaultDateParam(), GetDefaultSort(maxItems));
		}

		/// <summary>
		/// Returns the Press Releases for the year specified.
		/// </summary>
		/// <param name="year">The year to get Press Releases for.</param>
		/// <returns>The RLI Press Releases for the year specified.</returns>
		public IList<PressReleaseItem> GetPressReleasesForYear(int year)
		{
			//get our data param to search on
			DateRangeSearchParam dateParam = GetDateParam(new DateTime(year, 1, 1, 0, 0, 0),
														  new DateTime(year, 12, 31, 23, 59, 59));

			//create our search options to sort our results by date
			SearchOptions searchOptions = new SearchOptions(new SortOptions(PressReleaseItem.FieldName_Date, SortDirection.Reverse));

			return GetPressReleases(new SafeDictionary<string>(), dateParam, searchOptions);
		}


		/// <summary>
		/// Gets Press Release Items from the events index.
		/// </summary>
		/// <param name="filters"></param>
		/// <param name="dateRange"></param>
		/// <param name="searchOptions"></param>
		/// <returns></returns>
		public IList<PressReleaseItem> GetPressReleases(SafeDictionary<string> filters, DateRangeSearchParam dateRange, SearchOptions searchOptions)
		{
			if (searchOptions == null) searchOptions = new SearchOptions();

			//Setting time on end date to 11:59:59 to include all items from the date, regardless of time.
			DateTime endDate = dateRange.Ranges[0].EndDate;
			DateTime newEndDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59);
			dateRange.Ranges[0].EndDate = newEndDate;

      //Get the wrappers
      List<LightweightItem> lightweightItems = new List<LightweightItem>(); // GetLightweightItems(filters, dateRange, searchOptions);

			//Convert items
			List<PressReleaseItem> pressReleases = new List<PressReleaseItem>();
			foreach (LightweightItem lightweightItem in lightweightItems)
			{
				Item item = searchOptions.Database.GetItem(lightweightItem.ItemID);
				pressReleases.Add(item);
			}

			return pressReleases;
		}

		public List<int> GetPressReleaseYears()
		{
			return ACRCache.GetFromCache("RLIPressReleaseYears", new DateTime(DateTime.Now.Year , 12, 31,23,59,59), GetDistinctYears);
		}

		private List<int> RecalculatePressReleaseYears()
		{
			List<PressReleaseItem> pressReleases = GetPressReleases(new SafeDictionary<string>(), GetDateParam(DateTime.MinValue, DateTime.MaxValue), new SearchOptions(new SortOptions(PressReleaseItem.FieldName_Date, SortDirection.Normal))).ToList();
			HashSet<int> years = new HashSet<int>();
			foreach (PressReleaseItem item in pressReleases)
			{
				years.Add(item.Date.DateTime.Year);
			}
			return years.ToList();
		}

		/// <summary>
		/// Will pull out the distinct years for our press releases.
		/// This will only retrieve the last 10 years.
		/// </summary>
		/// <returns>Distinct years for our press releases.</returns>
		public List<int> GetDistinctYears()
		{
			//lets retrieve all our press releases within the last 10 years
			IList<PressReleaseItem> pressReleases = GetPressReleases(new SafeDictionary<string>(),
																	 GetDateParam(DateTime.Now.AddYears(-10), DateTime.Now), null);

			//using our press releases, lets pull out our distinct years
			List<int> distinctYears = pressReleases.Select(i => i.Date.DateTime.Year).Distinct().ToList();

			//sort or years desc
			distinctYears.Sort();
			distinctYears.Reverse();

			//return our distinct years
			return distinctYears;
		}

	}
}

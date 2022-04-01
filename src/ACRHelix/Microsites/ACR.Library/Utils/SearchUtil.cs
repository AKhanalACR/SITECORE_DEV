using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using ACR.Library.Common;
using Velir.GoogleSearch;

namespace ACR.Library.Utils
{
	public static class SearchUtil
	{
		public const int START_PAGE = 1;

		public const string PARAM_COLLECTION = "search_collection";
		public const string PARAM_QUERY = "q";
		public const string PARAM_PAGE = "search_page";
		public const string PARAM_SORTING = "search_sort";
		public const string PARAM_COUNT = "search_count"; // How many results per page?

		public const string PARAM_ADVANCED_EXACT = "search_exact";
		public const string PARAM_ADVANCED_ALL = "search_all";
		public const string PARAM_ADVANCED_ANY = "search_any";
		public const string PARAM_ADVANCED_WITHOUT = "search_without";
		public const string PARAM_START_DATE = "start";
		public const string PARAM_END_DATE = "end";

		#region Page request helpers.

		public static GoogleSearch BuildSearchFromRequest(HttpRequest request)
		{
			return BuildSearchFromRequest(request, null, null);
		}

		public static GoogleSearch BuildSearchFromRequest(HttpRequest request, string defaultCollection, SearchMode? defaultSorting)
		{
			return BuildSearchFromRequest(request, defaultCollection, defaultSorting, PARAM_PAGE);
		}

		public static GoogleSearch BuildSearchFromRequest(HttpRequest request, string defaultCollection, SearchMode? defaultSorting, string customPageParam)
		{
			var resultPage = GetPageFromRequest(request, customPageParam);
			var querystring = GetQueryFromRequest(request);
			var collection = GetCollectionFromRequest(request, defaultCollection);

			var search = new GoogleSearch(querystring) { ResultPage = resultPage, Collection = collection };
			search.AddSearchTerm(GetAdvancedExactFromRequest(request), SearchModifier.ExactPhrase);
			search.AddSearchTerm(GetAdvancedAllFromRequest(request), SearchModifier.AllWords);
			search.AddSearchTerm(GetAdvancedAnyFromRequest(request), SearchModifier.AnyWords);
			search.AddSearchTerm(GetAdvancedWithoutFromRequest(request), SearchModifier.WithoutWords);

			var resultsPerPage = GetCountFromRequest(request);
			if (resultsPerPage != null) search.ResultsPerPage = (int)resultsPerPage;


			var startDate = GetStartDateFromRequest(request);
			if (startDate.HasValue) { search.StartDate = startDate.Value; }

			var endDate = GetEndDateFromRequest(request);
			if (endDate.HasValue) { search.EndDate = endDate.Value; }

			var sorting = GetSortingFromRequest(request, defaultSorting);
			if (sorting != null) search.SortMode = (SearchMode)sorting;

			return search;
		}

		public static string BuildPaginationUrlFormat(HttpRequest request)
		{
			string beginning = BuildSearchUrlParameters(request, PARAM_PAGE);
			string partPage = PARAM_PAGE + "={0}";

			return beginning + "&" + partPage;
		}


		public static string BuildSortingUrlFormat(HttpRequest request)
		{
			string beginning = BuildSearchUrlParameters(request, PARAM_PAGE, PARAM_SORTING);
			string partSorting = PARAM_SORTING + "={0}";

			return beginning + "&" + partSorting;
		}


		/// <summary>
		/// Build the string of search-specific URL parameters from a request, optionally omitting certain parameters.
		/// </summary>
		/// <param name="request"></param>
		/// <param name="omitParameters"></param>
		/// <returns></returns>
		private static string BuildSearchUrlParameters(HttpRequest request, params string[] omitParameters)
		{
			// Make a lookup dictionary to decide what to omit.
			Dictionary<string, bool> omit = new Dictionary<string, bool>();
			foreach (var omission in omitParameters)
			{
				omit.Add(omission, true);
			}

			var collection = GetCollectionFromRequest(request);
			if (omit.ContainsKey(PARAM_COLLECTION)) collection = null;

			var query = GetQueryFromRequest(request);
			if (omit.ContainsKey(PARAM_QUERY)) query = null;

			int? page = GetPageFromRequest(request);
			if (omit.ContainsKey(PARAM_PAGE)) page = null;

			int? count = GetCountFromRequest(request);
			if (omit.ContainsKey(PARAM_COUNT)) count = null;

			var sorting = GetSortingFromRequest(request);
			if (omit.ContainsKey(PARAM_SORTING)) sorting = null;

			var advExact = GetAdvancedExactFromRequest(request);
			if (omit.ContainsKey(PARAM_ADVANCED_EXACT)) advExact = null;

			var advAll = GetAdvancedAllFromRequest(request);
			if (omit.ContainsKey(PARAM_ADVANCED_ALL)) advAll = null;

			var advAny = GetAdvancedAnyFromRequest(request);
			if (omit.ContainsKey(PARAM_ADVANCED_ANY)) advAny = null;

			var advWithout = GetAdvancedWithoutFromRequest(request);
			if (omit.ContainsKey(PARAM_ADVANCED_WITHOUT)) advWithout = null;


			var startDate = GetStartDateFromRequest(request);
			if (omit.ContainsKey(PARAM_START_DATE)) startDate = null;

			var endDate = GetEndDateFromRequest(request);
			if (omit.ContainsKey(PARAM_END_DATE)) endDate = null;


			return BuildSearchUrlParameters(collection, query, page, count, sorting,
				advExact, advAll, advAny, advWithout, startDate, endDate);
		}


		public static string BuildSearchUrlParameters(string collection, string query, int? page)
		{
			return BuildSearchUrlParameters(collection, query, page, null, null, null, null, null, null, null, null);
		}

		public static string BuildSearchUrlParameters(string collection, string query, int? page, SearchMode? sorting)
		{
			return BuildSearchUrlParameters(collection, query, page, null, sorting, null, null, null, null, null, null);
		}

		public static string BuildSearchUrlParameters(string collection, string query, int? page, DateTime? startDate, DateTime? endDate)
		{
			return BuildSearchUrlParameters(collection, query, page, null, null, null, null, null, null, startDate, endDate);
		}

		public static string BuildSearchUrlParameters(string collection, string query, int? page,
			int? resultsPerPage, SearchMode? sorting, string advancedExact, string advancedAll, string advancedAny, string advancedWithout, DateTime? startDate, DateTime? endDate)
		{
			NameValueCollection urlParams = new NameValueCollection();

			// Basic search parameters:
			if (!string.IsNullOrEmpty(query)) urlParams.Add(PARAM_QUERY, query);
			if (!string.IsNullOrEmpty(collection)) urlParams.Add(PARAM_COLLECTION, collection);
			if (page != null) urlParams.Add(PARAM_PAGE, page.ToString());

			// Advanced search parameters:
			if (resultsPerPage != null) urlParams.Add(PARAM_COUNT, resultsPerPage.ToString());
			if (sorting != null) urlParams.Add(PARAM_SORTING, sorting.ToString());
			if (!string.IsNullOrEmpty(advancedExact)) urlParams.Add(PARAM_ADVANCED_EXACT, advancedExact);
			if (!string.IsNullOrEmpty(advancedAll)) urlParams.Add(PARAM_ADVANCED_ALL, advancedAll);
			if (!string.IsNullOrEmpty(advancedAny)) urlParams.Add(PARAM_ADVANCED_ANY, advancedAny);
			if (!string.IsNullOrEmpty(advancedWithout)) urlParams.Add(PARAM_ADVANCED_WITHOUT, advancedWithout);

			if (startDate != null) urlParams.Add(PARAM_START_DATE, startDate.Value.ToString("MM/dd/yyyy"));
			if (endDate != null) urlParams.Add(PARAM_END_DATE, endDate.Value.ToString("MM/dd/yyyy"));

			return "?" + HttpUtils.ConstructQueryString(urlParams);
		}


		public static string GetQueryFromRequest(HttpRequest request)
		{
			return HttpUtils.GetParameterValue(PARAM_QUERY, request);
		}

		public static int GetPageFromRequest(HttpRequest request)
		{
			return GetPageFromRequest(request, PARAM_PAGE);
		}

		public static int GetPageFromRequest(HttpRequest request, string customPageParam)
		{
			var resultPage = START_PAGE;
			if (!string.IsNullOrEmpty(request[customPageParam]))
			{
				int.TryParse(request[customPageParam], out resultPage);
			}

			return resultPage;
		}


		public static string GetCollectionFromRequest(HttpRequest request)
		{
			return GetCollectionFromRequest(request, null);
		}


		public static string GetCollectionFromRequest(HttpRequest request, string defaultCollection)
		{
			string collection = HttpUtils.GetParameterValue(PARAM_COLLECTION, request);
			if (string.IsNullOrEmpty(collection))
			{
				return defaultCollection ?? string.Empty;
			}
			return collection;
		}


		public static int? GetCountFromRequest(HttpRequest request)
		{
			try
			{
				var resultsPerPage = int.Parse(request[PARAM_COUNT]);
				return resultsPerPage;
			}
			catch (Exception)
			{
				return null;
			}
		}


		public static SearchMode? GetSortingFromRequest(HttpRequest request)
		{
			return GetSortingFromRequest(request, null);
		}


		public static SearchMode? GetSortingFromRequest(HttpRequest request, SearchMode? defaultSorting)
		{
			string sortingValue = HttpUtils.GetParameterValue(PARAM_SORTING, request);

			try
			{
				SearchMode sorting = (SearchMode)Enum.Parse(typeof(SearchMode), sortingValue, true);
				return sorting;
			}
			catch (Exception)
			{
				return defaultSorting;
			}
		}


		public static string GetAdvancedExactFromRequest(HttpRequest request)
		{
			return HttpUtils.GetParameterValue(PARAM_ADVANCED_EXACT, request);
		}


		public static string GetAdvancedAllFromRequest(HttpRequest request)
		{
			return HttpUtils.GetParameterValue(PARAM_ADVANCED_ALL, request);
		}


		public static string GetAdvancedAnyFromRequest(HttpRequest request)
		{
			return HttpUtils.GetParameterValue(PARAM_ADVANCED_ANY, request);
		}


		public static string GetAdvancedWithoutFromRequest(HttpRequest request)
		{
			return HttpUtils.GetParameterValue(PARAM_ADVANCED_WITHOUT, request);
		}

		public static DateTime? GetStartDateFromRequest(HttpRequest request)
		{
			DateTime date;
			var result = DateTime.TryParse(HttpUtils.GetParameterValue(PARAM_START_DATE, request), out date);
			if (result)
			{
				return date;
			}
			else
			{
				return null;
			}

		}

		public static DateTime? GetEndDateFromRequest(HttpRequest request)
		{
			DateTime date;
			var result = DateTime.TryParse(HttpUtils.GetParameterValue(PARAM_END_DATE, request), out date);
			if (result)
			{
				return date;
			}
			else
			{
				return null;
			}
		}

		public static int GetResultsPerPageFromRequest(HttpRequest request)
		{
			int result;
			Int32.TryParse(HttpUtils.GetParameterValue(PARAM_COUNT, request), out result);
			return result;
		}
		#endregion

		#region General search helpers.

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


		public static string GetSummaryText(GoogleSearch googleSearch)
		{
			if (googleSearch.GetTotalResultCount() < 1)
			{
				return "No results found.";
			}

			var rawresults = googleSearch.GetRawResults();

			var firstresult = rawresults.StartItemIndex;
			var lastresult = rawresults.EndItemIndex;
			var total = googleSearch.GetTotalResultCount();

			var totaltext = "<b>" + total.ToString() + "</b>";
			if (total > googleSearch.ResultsPerPage)
			{
				totaltext = "about <b>" + totaltext + "</b>";
			}

			var sb = new StringBuilder();
			sb.AppendFormat("Results <b>{0}</b> - <b>{1}</b> of {2}.", firstresult, lastresult, totaltext);
			return sb.ToString();
		}


		public static string FormatResultDate(DateTime datetime)
		{
			if (datetime.Year < 1900) return "";

			return datetime.ToShortDateString();
		}

		public static int GetCurrentPage(int startResult, int resultsPerPage)
		{
			if (startResult == 0 || resultsPerPage == 0)
			{
				return 0;
			}
			if (startResult % resultsPerPage == 0)
			{
				return startResult / resultsPerPage;
			}
			else
			{
				return (startResult / resultsPerPage) + 1;
			}
		}

		public static int GetFirstResult(int currentPage, int resultsPerPage)
		{
			if (currentPage == 0 || resultsPerPage == 0)
			{
				return 0;
			}
			return ((currentPage - 1) * resultsPerPage) + 1;
		}

		public static int GetTotalPages(int totalResults, int resultsPerPage)
		{
			if (totalResults == 0 || resultsPerPage == 0)
			{
				return 0;
			}
			if (totalResults % resultsPerPage == 0)
			{
				return totalResults / resultsPerPage;
			}
			else
			{
				return (totalResults / resultsPerPage) + 1;
			}
		}

		public static int GetEndResult(int startResult, int resultsPerPage, int totalResults)
		{
			if (startResult == 0 || totalResults == 0 || resultsPerPage == 0)
			{
				return 0;
			}
			int end = (startResult + resultsPerPage - 1);
			if (end > totalResults)
			{
				return totalResults;
			}
			return end;
		}

		public static int GetStartItemFromPage(int page, int itemsPerPage)
		{
			return ((page - 1) * itemsPerPage) + 1;
		}

		//public static object GetCoveoResultFieldValue(QueryResult queryResult, CoveoField field)
		//{
		//	ResultField rField = queryResult.Fields.FirstOrDefault(f => f.Name == field.CoveoFormattedFieldName);
		//	if (rField != null)
		//	{
		//		return rField.Value;
		//	}
		//	return null;
		//}

		#endregion

	}
}

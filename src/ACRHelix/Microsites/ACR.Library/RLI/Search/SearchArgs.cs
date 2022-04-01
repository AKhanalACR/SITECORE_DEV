using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACR.Library.RLI.Search
{
	public class SearchArgs
	{
		private int _pageNumber = 1;
		private int _resultsPerPage = 10;

		/// <summary>
		/// Id of the search page
		/// </summary>
		public string CurrentItemId { get; set; }

		/// <summary>
		/// Text Search Term
		/// </summary>
		public string SearchText { get; set; }

		/// <summary>
		/// Number of overall Pages
		/// </summary>
		public int Pages { get; set; }

		/// <summary>
		/// Current Page Number
		/// </summary>
		public int PageNumber
		{
			get { return _pageNumber; }
			set { _pageNumber = value; }
		}

		/// <summary>
		/// Results per page
		/// </summary>
		public int ResultsPerPage
		{
			get { return _resultsPerPage; }
			set { _resultsPerPage = value; }
		}

		/// <summary>
		/// Number or results returned from query
		/// </summary>
		public Int32 NumberOfResults { get; set; }

		/// <summary>
		/// Result items
		/// </summary>
		public List<ResultItem> Results { get; set; }
	}
}

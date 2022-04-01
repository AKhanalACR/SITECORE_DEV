using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ACR.Library.Reference;
using ACR.Library.RLI.Search;

namespace ACR.services
{
	/// <summary>
	/// Summary description for RLISearch
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	[System.Web.Script.Services.ScriptService]
	public class RLISearch : System.Web.Services.WebService
	{
		/// <summary>
		/// Perform a search for the RLI search functionality
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
		[WebMethod]
		public SearchArgs PerformSearch(SearchArgs args)
		{
			//set current search page (rli)
			args.CurrentItemId = ItemReference.RLI_Search.Guid;

            //create search context
            //SearchContext context = SearchContext.Get(args);

            //set new data back to args to be return to client
            args.NumberOfResults = 0;// context.Results.TotalCount;
            args.SearchText = "";// context.Results.BasicQuery;
			//args.Results = //GetResultItems(context.Results.Results);
			//args.Pages = //GetNumberOfPages(context.Results.TotalCount);
			
			return args;
		}

		/// <summary>
		/// returns the number of pages
		/// </summary>
		/// <param name="count"></param>
		/// <returns></returns>
		private int GetNumberOfPages(double count)
		{
			double totalNumberOfPages = count / 10;
			return (int)Math.Ceiling(totalNumberOfPages); 
		}

		/// <summary>
		/// converts coveo results to result items to be processed on the frontend
		/// </summary>
		/// <param name="results"></param>
		/// <returns></returns>
		//private List<ResultItem> GetResultItems(IEnumerable<QueryResult> results)
		//{
		//	return (from result in results where result != null select new ResultItem(result)).ToList();
		//}

		/// <summary>
		/// Temporary test results
		/// </summary>
		private List<ResultItem> Results
		{
			get
			{
				List<ResultItem> results = new List<ResultItem>();
				for(int i = 0; i <= 35; i++)
				{
					results.Add(GetResult(i));
				}

				return results;
			}
		}

		/// <summary>
		/// returns a test result
		/// </summary>
		/// <param name="i"></param>
		/// <returns></returns>
		private ResultItem GetResult(int i)
		{
			ResultItem resultItem = new ResultItem();
			resultItem.Name = i + " - Page or document title";
			resultItem.Description = i + " - One line short description goes here.";
			resultItem.Href = "http://www.google.com";

			return resultItem;
		}
	}
}

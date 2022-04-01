using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using ACR.Library;
using ACR.Library.Utils;
using Sitecore.Data.Items;
using System.Linq;
using Common.Logging;

namespace ACR.controls.Common
{
    public class SearchPage : System.Web.UI.UserControl
    {
        protected readonly Item _currentItem = Sitecore.Context.Item;
        private static ILog _logger;

        private static ILog Logger
        {
            get
            {
                _logger = _logger ?? LogManager.GetLogger(typeof(SearchPage));
                return _logger;
            }
        }

        protected bool _showAllItems = false;
        protected readonly string _defaultSearchText = "Enter Keywords Here";
        protected static readonly string _searchQS = "search";
        protected readonly string _sortQS = "sort";
        public static readonly string PageQS = "pageno";

        protected List<T> GetPagedItems<T>(
            List<T> totalItems,
            int startItem,
            int pageSize)
        {
            return totalItems.Skip(startItem).Take(pageSize).ToList();
        }

        protected void SetupPage<T>(string searchTerm,
            string itemsPerPage, List<T> totalItems,
            Pagination paginationUpper, Pagination paginationLower, Literal paginationDescription,
            PlaceHolder ph, Repeater rpt, TextBox txt)
        {
            txt.Text = String.IsNullOrEmpty(Request.QueryString[_searchQS]) ? _defaultSearchText : Request.QueryString[_searchQS];
            this.SetupPage<T>(searchTerm, itemsPerPage, totalItems, paginationUpper, paginationLower, paginationDescription, ph, rpt);
        }

        protected void SetupPage<T>(string searchTerm,
            string itemsPerPage, List<T> totalItems,
            Pagination paginationUpper, Pagination paginationLower, Literal paginationDescription,
            PlaceHolder ph, Repeater rpt)
        {
            var totalItemCount = totalItems.Count();
            this.SetupPage<T>(searchTerm, itemsPerPage, totalItems, paginationUpper, paginationLower, paginationDescription, ph, rpt, totalItemCount, false);
        }

        protected void SetupPage<T>(string searchTerm,
            string itemsPerPage, List<T> totalItems,
            Pagination paginationUpper, Pagination paginationLower, Literal paginationDescription,
            PlaceHolder ph, Repeater rpt, int totalItemCount, bool isTotalItemsPartial)
        {
            var windowSize = 5;
            
            int pageSize = itemsPerPage != null ? Int32.Parse(itemsPerPage) : AcrGlobals.SEARCH_PAGINATION_PAGESIZE;
            String pageNum = Request.QueryString[PageQS];
            short currentPageNumber;
            try
            {
                currentPageNumber = Convert.ToInt16(pageNum);
            }
            catch(Exception)
            {
                currentPageNumber = 1;
            }
            if (currentPageNumber == 0) currentPageNumber = 1;
            int firstRecord = ((currentPageNumber - 1) * pageSize) +1;

            _showAllItems = !String.IsNullOrEmpty(Request.QueryString["showAll"]);

            List<T> itemsToDisplay;
            if (_showAllItems && !isTotalItemsPartial)
            {
                itemsToDisplay = totalItems;
            }
            else
            {
                if (isTotalItemsPartial)
                {
                    itemsToDisplay = totalItems;
                }
                else
                {
                    itemsToDisplay = GetPagedItems<T>(
                        totalItems,
                        firstRecord,
                        pageSize);
                }


                var formattedUrl = HttpUtils.AddParameterToUrl(Request, PageQS, "{0}");
                formattedUrl = HttpUtility.UrlDecode(formattedUrl);

                if (paginationUpper != null)
                    paginationUpper.SetData(totalItemCount, pageSize, currentPageNumber, windowSize, formattedUrl);
                if (paginationLower != null)
                    paginationLower.SetData(totalItemCount, pageSize, currentPageNumber, windowSize, formattedUrl);
            }

						int endNum = ((firstRecord + pageSize - 1) > totalItemCount) ? totalItemCount : (firstRecord + pageSize - 1);
        		string paginationTextPrefix = string.Format("Results {0} - {1} of {2}", firstRecord, endNum, totalItemCount);

            if (totalItemCount > 0)
            {
                ph.Visible = false;
                rpt.Visible = true;
                rpt.DataSource = itemsToDisplay;
                rpt.DataBind();
            }
            else
            {
								paginationTextPrefix = "No results";
                ph.Visible = true;
                rpt.Visible = false;
            }
            
            paginationDescription.Text = String.Format("{0} for keyword, \"{1}\"", paginationTextPrefix, searchTerm);
        }
    }
}
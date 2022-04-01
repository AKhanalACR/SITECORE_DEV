using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using Common.Logging;
using Velir.GoogleSearch;

namespace ACR.Library.Common
{
    public class GoogleSearch
    {
        protected GSAConfig _config;
        protected GSASortOptions _sortOptions;
        protected GSASearchParams _searchParams;
        protected GoogleSearchTool _searchTool;
        private int _resultPage;

        protected bool _cacheResults = true;
        private Dictionary<int, SearchResults> _cachedResultsForPage;
        private static ILog _logger;

        



        #region Protected/private properties.
        private static ILog Logger
        {
            get
            {
                _logger = _logger ?? LogManager.GetLogger(typeof(GoogleSearch));
                return _logger;
            }
        }

        protected internal GSAConfig Config
        {
            get
            {
                if (_config == null) _config = new GSAConfig();
                return _config;
            }
        }


        protected internal GSASortOptions SortOptions
        {
            get
            {
                if (_sortOptions == null) _sortOptions = new GSASortOptions();
                return _sortOptions;
            }
        }


        protected internal GSASearchParams SearchParams
        {
            get
            {
                if (_searchParams == null) _searchParams = new GSASearchParams { SortOptions = SortOptions };
                return _searchParams;
            }
        }


        protected internal GoogleSearchTool SearchTool
        {
            get
            {
                if (_searchTool == null) _searchTool = new GoogleSearchTool(Config);
                return _searchTool;
            }
        }


        protected internal Dictionary<int, SearchResults> CachedResultsForPage
        {
            get
            {
                if (_cachedResultsForPage == null)
                {
                    _cachedResultsForPage = new Dictionary<int, SearchResults>();
                }
                return _cachedResultsForPage;
            }
            set { _cachedResultsForPage = value; }
        }
        #endregion



        #region Public properties.
        public int ResultsPerPage
        {
            get
            {
                return Config.ResultsPerPage;
            }
            set
            {
                if (ResultsPerPage != value)
                {
                    Config.ResultsPerPage = value;
                    CacheClear();
                }
            }
        }

        public int ResultPage
        {
            get { return _resultPage; }
            set { _resultPage = value; }
        }

        public string Collection
        {
            get { return Config.SiteId; }
            set { Config.SiteId = value; }
        }

        public SearchDirection SortDirection
        {
            get
            {
                return SortOptions.SortDirection;
            }
            set
            {
                if (SortDirection != value)
                {
                    SortOptions.SortDirection = value;
                    CacheClear();
                }
            }
        }

        public SearchMode SortMode
        {
            get
            {
                return SortOptions.SortMode;
            }
            set
            {
                if (SortMode != value)
                {
                    SortOptions.SortMode = value;
                    CacheClear();
                }
            }
        }

        public bool CacheResults
        {
            get { return _cacheResults; }
            set
            {
                if (CacheResults != value)
                {
                    _cacheResults = value;
                    if (!value) CacheClear();
                }
            }
        }

        public DateTime StartDate
        {
            get { return SearchParams.SearchFrom; }
            set
            {
                SearchParams.SearchFrom = value;
            }
        }

        public DateTime EndDate
        {
            get { return SearchParams.SearchTo; }
            set
            {
                SearchParams.SearchTo = value;
            }
        }

        public string GetLastUsedSearchUrl
        {
            get
            {
                return SearchTool.GetUrlUsed;
            }
        }
        #endregion



        #region Constructors.

        public GoogleSearch()
            : this(null)
        {
        }

        public GoogleSearch(string searchText)
        {
            // Basic GSA configuration.
            Config.BaseURL = AcrGlobals.GSASettings["BaseUrl"];
            Config.ClientId = AcrGlobals.GSASettings["ClientId"];
            Config.SiteId = AcrGlobals.GSASettings["Collection.Default"]; // May be overridden with the Collection property.
            Config.Filter = 0;

            // Set some default values.
            ResultsPerPage = StringToInteger(AcrGlobals.GSASettings["ResultsPerPage"], 10);
            SortDirection = SearchDirection.Descending;
            SortMode = SearchMode.Relevance;
            ResultPage = 1;

            if (!string.IsNullOrEmpty(searchText))
            {
                SetSearchText(searchText);
            }
        }

        #endregion


        #region Configuration methods.

        /// <summary>
        /// Enter a non-advanced search query.  (This will override any previous calls to AddSearchTerm()).
        /// </summary>
        /// <param name="searchText"></param>
        public void SetSearchText(string searchText)
        {
            SearchParams.SearchTerms = ParseSearchTerms(searchText);
            CacheClear();
        }

        public void SetBaseURL(string url)
        {
            Config.BaseURL = url;
        }

        public void AddMetaSearchTerm(string key, string value)
        {
            SearchParams.AddMetaSeachTerm(key, value);
        }

        public void SetMetaSearchType(MetaSearchTermModifier modifier)
        {
            SearchParams.MetaTermsModifier = modifier;
        }

        public void AddSearchTerm(string searchText, SearchModifier searchModifier)
        {
            if (string.IsNullOrEmpty(searchText)) return;

            if (searchModifier == SearchModifier.AnyWords) // Since this project uses a really outdated copy of the Velir.Library this has to be done here. It has since been fixed in the Velir.Library though. 
            {
                searchText = InsertStringBetweenWords(searchText, " OR ");
            }

            SearchParams.AddSearchTerm(searchText, searchModifier);
            CacheClear();
        }


        #endregion


        #region Search methods.

        public SearchResults GetRawResults()
        {
            return GetRawResults(ResultPage);
        }


        /// <summary>
        /// Get a raw Velir.GoogleSearch.SearchResults object from the GoogleSearchTool.
        /// </summary>
        /// <param name="page">Result page to retrieve; page numbers start with 1</param>
        /// <returns></returns>
        protected SearchResults GetRawResults(int page)
        {
            SearchResults results;

            lock (this)
            {
                results = RetryGetRawResults(page, 10, 500);
            }





            return results;
        }


        /// <summary>
        /// Get a raw Velir.GoogleSearch.SearchResults object from the GoogleSearchTool, retrying with
        /// increasing delays upon failure.
        /// </summary>
        /// <param name="page">Result page to retrieve; page numbers start with 1</param>
        /// <param name="attempts">How many attempts should be made before giving up?</param>
        /// <param name="waitAfterAttempt">How many milliseconds should we wait after failing?  (This value will automatically increase for subsequent attempts.)</param>
        /// <returns></returns>
        protected SearchResults RetryGetRawResults(int page, int attempts, double waitAfterAttempt)
        {
            SearchResults results = CacheGet(page);
            if (results != null) // Results are already cached, so just return them.
            {
                return results;
            }

            if (attempts < 1)
            {
                return null; // TODO: should this return an empty result set?
            }
            int rpp = Config.ResultsPerPage;

            // Perform the actual search attempt.
            Config.CurrentRecord = (page - 1) * rpp;

            SearchParams.ExcludeFileExtensions.Add("aspx");
            SearchParams.ExcludeFileExtensions.Add("pdf");



            results = SearchTool.ExecuteSearch(SearchParams);


        


            if (results.SearchException == null) // Success; cache and return the results.
            {
                CacheSet(page, results);
                return results;
            }
            else // Failure with an exception; log and retry.
            {
                string errorMessage = string.Format("GoogleSearch failure (remaining attempts = {0}) using GSA URL:\n\n{1}\n", attempts - 1, SearchTool.GetUrlUsed);
                Logger.Error(errorMessage, results.SearchException);

                // Retry after waiting the requested time, and increase the wait for subsequent calls.
                Thread.Sleep((int)waitAfterAttempt);
                return RetryGetRawResults(page, attempts - 1, waitAfterAttempt * 1.5);
            }
        }


        /// <summary>
        /// Get a list of result items for the current ResultPage.
        /// </summary>
        /// <returns></returns>
        public List<SearchResultItem> GetRawResultItems()
        {
            List<SearchResultItem> result = GetRawResultItems(ResultPage);

            return result;
        }


        /// <summary>
        /// Get a list of result items for a particular page.
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public List<SearchResultItem> GetRawResultItems(int page) // Assume "page" starts at 1.
        {
            var results = GetRawResults(page);
            return results.ActualResultItems;
        }


        /// <summary>
        /// Get the total number of matches for the current query.
        /// </summary>
        /// <returns></returns>
        public int GetTotalResultCount()
        {
            SearchResults results = GetRawResults();
            return results.TotalItemsAvailable; // TODO make sure this is right.
        }



        #endregion


        #region Result cache methods.

        protected void CacheClear()
        {
            CachedResultsForPage.Clear();
        }


        protected void CacheSet(int page, SearchResults results)
        {
            if (CacheResults)
            {
                CachedResultsForPage[page] = results;
            }
        }


        protected SearchResults CacheGet(int page)
        {
            if (CacheResults && CachedResultsForPage.ContainsKey(page))
            {

                return CachedResultsForPage[page];
            }

            return null;
        }

        #endregion


        #region Helpers.

        protected List<SearchTerm> ParseSearchTerms(string searchText)
        {
            List<SearchTerm> searchTerms = new List<SearchTerm>();

            Regex quoteMatch = new Regex("[\"].*?[\"]");
            MatchCollection matches = quoteMatch.Matches(searchText);

            string singleWords = quoteMatch.Replace(searchText, "");
            singleWords.Trim();
            if (!string.IsNullOrEmpty(singleWords))
            {
                var term = new SearchTerm(singleWords, SearchModifier.AllWords);
                searchTerms.Add(term);
            }
            foreach (Match match in matches)
            {
                string phrase = match.Value.Replace("\"", "");
                var term = new SearchTerm(phrase, SearchModifier.ExactPhrase);
                searchTerms.Add(term);
            }

            return searchTerms;

        }

        protected int StringToInteger(string str, int defaultVal)
        {
            try
            {
                return Convert.ToInt32(str);
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }

        protected string InsertStringBetweenWords(string text, string word)
        {
            return text.Replace(" ", " " + word + " ");
        }

        #endregion

    }
}

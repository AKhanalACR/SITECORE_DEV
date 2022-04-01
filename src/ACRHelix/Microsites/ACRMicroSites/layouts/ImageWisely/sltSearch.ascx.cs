using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.controls.Common;
using ACR.Library;
using ACR.Library.Common;
using ACR.Library.Utils;
using Common.Logging;

// Addis
using WebSearch = ACRAccreditationInformaticsLibrary.Search;
using ACRAccreditationInformaticsLibrary;
using Sitecore.Data.Items;
using ACR.Constants;
using Sitecore.Web;
using System.Text;
using System.Text.RegularExpressions;

namespace ACR.layouts.ImageWisely
{
    public partial class sltSearch : SearchPage
    {
        private static ILog _logger;

        private static ILog Logger
        {
            get
            {
                _logger = _logger ?? LogManager.GetLogger(typeof(SearchPage));
                return _logger;
            }
        }

        #region
        WebSearch.SearchManager _searchMgr;
        string _searchTerm = string.Empty;
        int _currentPage = 1;
        int _startCount;
        int _endCount;

        int _pageSize = 10;
        int _truncateCount = 200;
        string _noResults = "<span>Sorry No Results found.</span>";
        private string _indexName = "rli_search_index_web";
        string _searchOverView = "<span>Results {0} to {1} of {2} for <em>\"{3}\"</em></span>";
        string _noCriteria = "<span>No search terms supplied!</span>";
        public bool Result404;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //Addis 4/27/2017
            PageTop.Text = string.Empty;
            PageBottom.Text = string.Empty;

            if (!IsPostBack)
            {
                InitializeSearch();
                Search(int.Parse(WebUtil.GetQueryString("page", "1")));
            }

            #region Addis 4/27/2017
            //GoogleSearch googleSearch;
            //List<SearchResultItem> results;
            //string allTerm;
            //try
            //{
            //    googleSearch = SearchUtil.BuildSearchFromRequest(Request, AcrGlobals.GSASettings["Collection.ImageWisely.EntireSite"], SearchMode.Date, PageQS);
            //    allTerm = SearchUtil.GetAdvancedAllFromRequest(Request);
            //    Logger.Info(this.ToString() + ": 'All' search string: " + allTerm);

            //    results = googleSearch.GetRawResultItems();

            //}
            //catch (Exception ex)
            //{
            //    Logger.Error("GoogleSearch object: \n" +
            //        "BaseUrl = " + AcrGlobals.GSASettings["BaseUrl"] + "\n" +
            //        "Collection.ImageWisely.EntireSite = " + AcrGlobals.GSASettings["Collection.ImageWisely.EntireSite"] + "\n" +
            //        "ClientId = " + AcrGlobals.GSASettings["ClientId"], ex);
            //    return;
            //}

            //if (IsPostBack) { return; }
            //was commented out before 4/26 by addis
            // Sorting code left here for possible future dev.
            //SearchMode? searchMode = SearchUtil.GetSortingFromRequest(Request);
            //switch (searchMode)
            //{
            //    case SearchMode.Relevance:
            //        liRelevance.Attributes.Add("class", "active");
            //        lkbRelevance.Enabled = false;
            //        break;
            //    case SearchMode.Date:
            //        liDate.Attributes.Add("class", "active");
            //        lkbDate.Enabled = false;
            //        break;
            //    default:
            //        Debug.Assert(searchMode == null, "Unrecognized search mode, defaulting to relevance.");
            //        _logger.Warn("KaiserEDU Search: Unrecognized search mode, defaulting to relevance.");
            //        liRelevance.Attributes.Add("class", "active");
            //        lkbRelevance.Enabled = false;
            //        break;

            //}

            //commented out on 4/26 by addis
            //int count = googleSearch.GetTotalResultCount();
            //int resultsPerPage = SearchUtil.GetResultsPerPageFromRequest(Request);
            //Logger.Info(this.ToString() + ": Total result count: " + count);

            //if (resultsPerPage < 1)
            //{ resultsPerPage = 10; }

            //SetupPage<SearchResultItem>(allTerm, resultsPerPage.ToString(), results, PaginationUpper, PaginationLower, ltlResults, phNoSearchedItems, rptResults, count, true);
            #endregion
        }

        protected void InitializeSearch()
        {
            Item setting = Sitecore.Context.Database.GetItem(Types.Items.ItemsPerPage);
            int.TryParse(ItemHelper.GetFieldValueOrDefault(setting, Types.Fields.SettingValue, "10"), out _pageSize);

            setting = Sitecore.Context.Database.GetItem(Types.Items.SnippetsMaxLength);
            int.TryParse(ItemHelper.GetFieldValueOrDefault(setting, Types.Fields.SettingValue, "200"), out _truncateCount);

            setting = Sitecore.Context.Database.GetItem(Types.Items.NoResultsMessage);
            _noResults = ItemHelper.GetFieldValueOrDefault(setting, Types.Fields.SettingValue,
                                                          "<span>Sorry No Results found.</span>");

            setting = Sitecore.Context.Database.GetItem(Types.Items.SearchResultsOverview);
            _searchOverView = ItemHelper.GetFieldValueOrDefault(setting, Types.Fields.SettingValue,
                                                               "<span>Results {0} to {1} of {2} for \"<em>{3}</em>\"</span>");

            setting = Sitecore.Context.Database.GetItem(Types.Items.NoSearchTermsWarning);
            _noCriteria = ItemHelper.GetFieldValueOrDefault(setting, Types.Fields.SettingValue,
                                                           "<span>No search terms supplied!</span>");

            setting = Sitecore.Context.Database.GetItem(Types.Items.SearchIndex);
            _indexName = "imagewisely_index_web"; //"rli_search_index_web"; // 
        }

        #region Added on 4/27/2017 Addis
        protected void Search(int startPage)
        {
            if (!string.IsNullOrEmpty(_indexName))
            {
                _searchMgr = new WebSearch.SearchManager(_indexName);

                _currentPage = startPage;

                ErrorResults.Visible = bool.Parse(WebUtil.GetQueryString("err", "false"));

                _searchTerm = GetSearchTerm() ?? string.Empty;

                if (_searchTerm == string.Empty)
                    SearchString.Text = _noCriteria;
                else
                {
                    _searchMgr.MSLSearch(_searchTerm); // Perform the actual search
                    searchResults.DataSource = DisplayResults(_searchMgr.SearchResults);
                    searchResults.DataBind();
                }
            }
            else
            {
                var noIndexName = new LiteralControl("No index has been setup.");
                ResultsMessage.Controls.Add(noIndexName);
            }
        }

        protected List<ACRAccreditationInformaticsLibrary.SearchResult> DisplayResults(IEnumerable<ACRAccreditationInformaticsLibrary.SearchResult> results)
        {
            ResultsMessage.Controls.Clear();

            if (results.Count() == 0) // No Results
            {
                var noResultsMsg = _noResults;
                var noResults = new LiteralControl(noResultsMsg);
                ResultsMessage.Controls.Add(noResults);
            }
            else
            {
                _startCount = _currentPage == 1 ? 1 : (_pageSize * (_currentPage - 1)) + 1;
                GetEndCount(results.Count());

                SearchString.Text = string.Format(_searchOverView, _startCount, _endCount, results.Count(), _searchTerm);

                BuildPaging(results, PageTop, _currentPage);
                BuildPaging(results, PageBottom, _currentPage);
                if (_currentPage > 1)
                    return results.Skip((_currentPage - 1) * _pageSize).Take(_pageSize).ToList();
            }
            return results.Take(_pageSize).ToList();
        }

        protected void BuildPaging(IEnumerable<ACRAccreditationInformaticsLibrary.SearchResult> items, Literal pagingLabel, int currentPage)
        {
            var label = new StringBuilder("<ul id=\"searchTopPagination\" class=\"array across\">");
            if (pagingLabel.ID == PageBottom.ID)
            {
                label = new StringBuilder("<ul id=\"searchBottomPagination\" class=\"array across\">");
            }
            const string linkFormat = "<li><a href='?page={0}&q={1}' class='{2}'>{3}</a></li>";
            int pageCount = 1;

            if (items.Count() > _pageSize)
                pageCount = (items.Count() + _pageSize - 1) / _pageSize;

            for (int i = 1; i <= pageCount; i++)
            {
                string css = ""; // string.Empty;

                if (i == currentPage)
                    css = "current";

                label.Append(string.Format(linkFormat, i, _searchTerm, css, i));
            }

            label.Append("</ul>");

            pagingLabel.Text = "<span>Page</span> " + label;
        }

        public string GetFieldValue(Item item, string fieldName)
        {
            return item[fieldName] ?? String.Empty;
        }

        public string BuildTeaser(Item item)
        {
            string teaser = TruncateString(Server.HtmlDecode(GetFieldValue(item, "Body")));

            if (string.IsNullOrEmpty(teaser))
                teaser = TruncateString(GetFieldValue(item, "Short Description"));


            if (string.IsNullOrEmpty(teaser))
                teaser = TruncateString(GetFieldValue(item, "Metadata Description"));

            //Addis 4/27/2017
            if (string.IsNullOrEmpty(teaser))
                teaser = TruncateString(GetFieldValue(item, "Body Text"));

            if (string.IsNullOrEmpty(teaser))
                teaser = TruncateString(GetFieldValue(item, "Meta Description"));

            if (string.IsNullOrEmpty(teaser))
                teaser = TruncateString(GetFieldValue(item, "Organization Description"));

            if (string.IsNullOrEmpty(teaser))
                teaser = TruncateString(GetFieldValue(item, "Details"));
            //---

            if (string.IsNullOrEmpty(teaser))
                teaser = TruncateString(GetFieldValue(item, Types.Fields.ModalityStepDetail));

            if (!string.IsNullOrEmpty(teaser))
                if (teaser[0] != '<')
                    teaser = "<p>" + teaser + "</p>";

            return teaser;
        }

        public string GetValidUrl(Item item)
        {
            if (item.TemplateID.ToString() == Types.Templates.ModalityStep)
                return BuildModalityStepUrl(item);

            if (item.TemplateID.ToString() == "{601994CB-252E-460D-9A7A-DFCEB3D5E047}") 
            {
                item = item.Parent;
            }

            if (item.TemplateID.ToString() == "{A836B93F-5642-406E-82BA-40888B098E2B}") 
            {
                item = item.Parent.Parent;
            }
            return ItemHelper.GetExtensionlessUrl(item);
        }

        private string BuildModalityStepUrl(Item item)
        {
            int stepIndex = 1;
            Item iterator = item.Axes.GetPreviousSibling();
            if (iterator != null)
            {
                if (iterator.TemplateID.ToString() != Types.Templates.ModalityStep)
                    iterator = null;

                while (iterator != null)
                {
                    stepIndex++;
                    iterator = item.Axes.GetPreviousSibling();
                    if (iterator.TemplateID.ToString() != Types.Templates.ModalityStep)
                        iterator = null;
                    break;
                }
            }

            return ItemHelper.GetExtensionlessUrl(item.Parent) + "#s" + stepIndex;
        }

        public string GetFriendlyName(ACRAccreditationInformaticsLibrary.SearchResult item)
        {
            return item.MSLFiendlyName;
        }

        public string GetFriendlyTeaser(ACRAccreditationInformaticsLibrary.SearchResult item)
        {
            if (item.ResultItem.TemplateID.ToString() == Types.Templates.ModalityStep)
                return BuildTeaser(item.ResultItem.Parent);

            return BuildTeaser(item.ResultItem);
        }

        protected string TruncateString(string s)
        {
            const string pattern = @"<(.|\n)*?>";
            if (!string.IsNullOrEmpty(s))
            {
                string cleanString = Regex.Replace(s, pattern, string.Empty);
                return cleanString.Length > _truncateCount ? cleanString.Substring(0, _truncateCount) + "..." : cleanString;
            }
            return string.Empty;
        }

        protected string GetSearchTerm()
        {
            string searchTerm = "";// SearchInput.Text;

            if (_searchMgr != null)
                _searchMgr.SearchType = WebSearch.SearchType.Any;

            if (string.IsNullOrEmpty(searchTerm))
                searchTerm = Server.UrlDecode(WebUtil.GetQueryString("q"));

            return searchTerm;
        }

        protected void GetEndCount(int totalCount)
        {
            if ((_currentPage * _pageSize) < totalCount)
            {
                if (_currentPage == 1)
                    _endCount = _pageSize;
                else if ((_currentPage * _pageSize) > totalCount)
                    _endCount = totalCount;
                else
                    _endCount = (_currentPage * _pageSize);
            }
            else
                _endCount = totalCount;
        }

        #endregion

        #region Addis 4/27/2017
        //public void rptResults_OnItemDataBound(Object Sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        var resultItem = (SearchResultItem)e.Item.DataItem;

        //        var hlPageTitle = (HyperLink)e.Item.FindControl("hlPageTitle");
        //        var ltlPageDescription = (Literal)e.Item.FindControl("ltlPageDescription");

        //        //First add the query param for incrementing the search counter
        //        string itemUrl = HttpUtils.AddParameterToUrl(resultItem.ItemUrl.ToString(), AcrGlobals.ReferrerParam, AcrGlobals.SearchReferrerValue);

        //        hlPageTitle.NavigateUrl = itemUrl;

        //        // Set the title text.
        //        if (string.IsNullOrEmpty(resultItem.MetaTags["title"]))
        //        {
        //            hlPageTitle.Text = resultItem.Title;
        //        }
        //        else
        //        {
        //            hlPageTitle.Text = resultItem.MetaTags["title"];
        //        }

        //        // Set the summary text.
        //        if (string.IsNullOrEmpty(resultItem.MetaTags["description"]))
        //        {
        //            ltlPageDescription.Text = resultItem.Summary;
        //        }
        //        else
        //        {
        //            ltlPageDescription.Text = resultItem.MetaTags["description"];
        //        }
        //    }
        //}
        #endregion
    }
}
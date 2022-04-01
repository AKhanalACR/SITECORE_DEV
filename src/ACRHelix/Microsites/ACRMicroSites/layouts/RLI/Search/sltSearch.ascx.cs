using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Text.RegularExpressions;
using Sitecore.Data.Items;
using Sitecore.Search;
using Sitecore.Web;
using WebSearch = ACRAccreditationInformaticsLibrary.Search;
using ACR.Constants;
using ACR.Library;
using ACRAccreditationInformaticsLibrary;

namespace ACR.layouts.RLI.Search
{
	public partial class sltSearch : System.Web.UI.UserControl
    {
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
            PageTop.Text = string.Empty;
            PageBottom.Text = string.Empty;

            if (!IsPostBack)
            {
                InitializeSearch();
                Search(int.Parse(WebUtil.GetQueryString("page", "1")));
                //SearchInput.Text = _searchTerm;
            }
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
            _indexName = "rli_search_index_web"; // ItemHelper.GetFieldValueOrDefault(setting, Types.Fields.SettingValue,"rli_search_index_web");
        }

        protected void SearchClick(object sender, EventArgs e)
        {
            Response.Redirect(Types.ItemUrls.SearchResults +
                              System.Web.HttpUtility.UrlEncode(GetSearchTerm() ?? string.Empty));
        }

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

            if (item.TemplateID.ToString() == "{78AE2533-A95E-4891-95F8-D6D433CA63E9}")
            {
                item = item.Parent;
            }
            if (item.TemplateID.ToString() == "{62BEEA1D-6B79-4E0C-A98F-E337E321DBBE}")
            {
                var url = item.Fields["Meeting Registration Form Url"] != null ? item.Fields["Meeting Registration Form Url"].Value : "";

                if (string.IsNullOrEmpty(url))
                    url = item.Fields["Product Url"] != null ? item.Fields["Product Url"].Value : "";

                if (string.IsNullOrEmpty(url))
                    url = ItemHelper.GetExtensionlessUrl(item.Database.GetItem("{0D6B627F-529D-4325-B616-FF0788617266}"));
                
                return url;
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
    }
}
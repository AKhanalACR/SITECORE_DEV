using System.Text;
using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Search;
using System.Linq;
using System.Collections.Generic;

namespace ACRAccreditationInformaticsLibrary.Search
{
    public enum SearchType
    {
        All,
        Any,
        Exact
    }

    public class SearchManager
    {
        public IEnumerable<SearchResult> Results { get; set; }

        public const string OtherCategory = "Other";
        private readonly Item _siteRoot;                     // The item associated with the site root
        private readonly string _searchIndexName;            // The search index for the current database (assumed to be the master DB)

        private IEnumerable<SearchResult> _searchResults;

        public IEnumerable<SearchResult> SearchResults
        {
            get { return _searchResults; }
        }

        public SearchType SearchType { get; set; }

        public SearchManager(string indexName)
        {
            _searchIndexName = indexName;
            Sitecore.Sites.SiteContext contextSite = Context.Site;
            _siteRoot = contextSite.Database.GetItem(Context.Site.RootPath);
        }

        private string GetCategoryName(Item item)
        {
            Item workItem = item;

            if (!_siteRoot.Axes.IsAncestorOf(workItem))
            {
                return string.Empty;
            }

            if (workItem == _siteRoot)
            {
                return OtherCategory;
            }

            while (workItem.ParentID != _siteRoot.ID && workItem.Parent != null)
            {
                workItem = workItem.Parent;
            }

            return workItem.Name;
        }

        public IEnumerable<SearchResult> Search(string searchString)
        {
            //Getting index from the web.config
            var searchIndex = Sitecore.ContentSearch.ContentSearchManager.GetIndex(_searchIndexName);
            using (var context = searchIndex.CreateSearchContext())
            {
                searchString = PrepareSearchTerm(searchString);

                var results = context.GetQueryable<SearchResult>()
                    .Where(x => x.ContentTitle.Contains(searchString) ||
                        x.Description.Contains(searchString) ||
                        x.Keywords.Contains(searchString) ||
                        x.IndexDefaultContent.Contains(searchString) ||
                        x.NameOverride.Contains(searchString) ||
                        x.Content.Contains(searchString)).ToList();

              

             

                return _searchResults = results;
            }
        }

        public IEnumerable<SearchResult> MSLSearch(string searchString)
        {
            var searchIndex = Sitecore.ContentSearch.ContentSearchManager.GetIndex(_searchIndexName);
            using (var context = searchIndex.CreateSearchContext())
            {
                searchString = PrepareSearchTerm(searchString);

                var queryable = context.GetQueryable<SearchResult>();

                /*var results = context.GetQueryable<SearchResult>()
                    .Where(x => x.Title.Contains(searchString) ||
                        x.ShortDescription.Contains(searchString) ||
                        x.Keywords.Contains(searchString) ||
                        x.IndexDefaultContent.Contains(searchString) ||
                        x.MSLFiendlyName.Contains(searchString) ||
                        x.Body.Contains(searchString)).ToList();*/

                var resultsTitleMatch = queryable.Where(x => x.Title.Contains(searchString) || x.MSLFiendlyName.Contains(searchString)).ToList();
                var noTitleMatch = queryable.Where(x => (x.ShortDescription.Contains(searchString) ||
                                                    x.Keywords.Contains(searchString) ||
                                                    x.IndexDefaultContent.Contains(searchString) ||
                                                    x.Body.Contains(searchString)
                                                )).ToList();

                var results = new List<SearchResult>();

                if (resultsTitleMatch.Count == 0)
                {
                    results = noTitleMatch;
                }
                else
                if (noTitleMatch.Count == 0)
                {
                    results = resultsTitleMatch;
                }
                else
                {
                    results = resultsTitleMatch;
                    foreach (var m in noTitleMatch)
                    {
                        var exist = resultsTitleMatch.FirstOrDefault(x => x.Id == m.Id);
                        if (exist == null)
                        {
                            results.Add(m);
                        }
                    }
                }

                

                return _searchResults = results;
            }
        }

        protected string PrepareSearchTerm(string term)
        {
            switch (SearchType)
            {
                case SearchType.All: // all words in the phrase must be in the text
                    string[] terms = term.Split(' ');
                    var sb = new StringBuilder();
                    foreach (string t in terms)
                    {
                        sb.Append("\"*" + t + "*\" AND ");
                    }
                    term = sb.ToString().Remove(sb.ToString().Length - 5, 5);
                    break;

                case SearchType.Exact: // Quote the full search phrase
                    term = "\"" + term + "\"";
                    break;
            }
            return term;
        }

        
    }
}
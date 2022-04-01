using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ACRHelix.Foundation.Repository.Search
{
    public interface ISearchRepository
    {
        IEnumerable<T> Search<T>(Expression<Func<T, bool>> query) where T : SearchResultItem;
        IEnumerable<SearchIndexTerm> GetTermsByFieldName(string fieldName, string searchTerm);

     
    }
}
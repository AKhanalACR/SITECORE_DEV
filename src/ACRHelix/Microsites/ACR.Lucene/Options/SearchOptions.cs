using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Data;

namespace ACR.Lucene.Options
{
	public class SearchOptions
	{
		public static int DefaultItemsPerPage = 10; 

		public SearchOptions() : this(null,null)
		{

		}

		public SearchOptions(string sortFieldName)
			: this(new SortOptions(sortFieldName))
		{
		}

		public SearchOptions(string sortFieldName, int currentPage, int numItemsPerPage)
			: this(new SortOptions(sortFieldName), new PaginationOptions(currentPage,numItemsPerPage))
		{
		}

		public SearchOptions(SortOptions sorting) : this(sorting,null)
		{
		}


		public SearchOptions(PaginationOptions pagination)
			: this(null, pagination)
		{

		}

		public SearchOptions(SortOptions sorting, PaginationOptions pagination)
		{
			Sorting = sorting;
			Pagination = pagination;
		}

		public SortOptions Sorting { get; private set; }
		public PaginationOptions Pagination { get; private set; }

		private Database _retrivalDatabase = null;
		public Database Database
		{
			get
			{
				if (_retrivalDatabase == null)
				{
					_retrivalDatabase = Sitecore.Context.Database;
				}
				return _retrivalDatabase;
			}
			set { _retrivalDatabase = value; }
		}
	}
}

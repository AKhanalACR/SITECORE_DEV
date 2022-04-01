namespace ACR.Lucene.Options
{
	public class PaginationOptions
	{

		public PaginationOptions() : this(1,SearchOptions.DefaultItemsPerPage)
		{
		}

		public PaginationOptions(int currentPage)
			: this(currentPage, SearchOptions.DefaultItemsPerPage)
		{
		}

		public PaginationOptions(int currentPage, int numberOfItemsPerPage)
		{
			CurrentPage = currentPage;
			NumberOfItemsPerPage = numberOfItemsPerPage;
		}

		public int CurrentPage { get; private set; }
		public int NumberOfItemsPerPage { get; private set; }
	}
}

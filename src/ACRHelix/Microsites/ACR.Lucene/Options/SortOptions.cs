namespace ACR.Lucene.Options
{
	public enum SortDirection
	{
		Normal,
		Reverse
	}

	public class SortOptions
	{
		public SortOptions(string sortFieldName, SortDirection sortDirection)
		{
			SortFieldName = sortFieldName.ToLowerInvariant();
			SortDirection = sortDirection;
		}

		public SortOptions(string sortFieldName) : this(sortFieldName,Options.SortDirection.Normal)
		{
		}
		
		public string SortFieldName { get; private set; }
		public SortDirection SortDirection { get; private set; }
	}
}

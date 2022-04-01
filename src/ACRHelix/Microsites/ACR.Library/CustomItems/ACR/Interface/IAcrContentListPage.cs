using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using ACR.Library.Common.Interfaces.Factory;
using ACR.Lucene.Indices;

namespace ACR.Library.CustomItems.ACR.Interface
{
	[FactoryInterface]
	public interface IAcrContentListPage
	{
		/// <summary>
		/// The content index that will be used to pull content items
		/// for display in the list.
		/// </summary>
		BaseIndex ContentIndex { get; }

		/// <summary>
		/// The header text that will be displayed above the list.
		/// </summary>
		string ListHeaderText { get; }

		/// <summary>
		/// The header text formatted to include the filtered year.
		/// Displayed above the filtered list.
		/// </summary>
		string ListHeaderTextYearFormat { get; }

		/// <summary>
		/// The date field name used for filtering list items by a date.
		/// </summary>
		string ListDateFieldName { get; }

		/// <summary>
		/// The Filter Name for secondary Filtering
		/// </summary>
		string ListFilterFieldName { get; }

		/// <summary>
		/// The List for the options for secondary Filtering
		/// </summary>
		List<ListItem> ListFilterValues { get; }
	}
}

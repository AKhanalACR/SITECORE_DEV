using System;
using System.Web.UI.WebControls;
using ACR.Library.CustomItems.ACR.Interface;
using ACR.Library.Search.Indices.PositionStatements;
using ACR.Lucene.Indices;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.MediaCenter
{
	public partial class PositionStatementsLandingPageItem : IAcrContentListPage
	{
		#region IAcrContentListPage

		public BaseIndex ContentIndex
		{
			get { return new PositionStatementsIndex(); }
		}

		public string ListHeaderText
		{
			get { return "Position Statements"; }
		}

		public string ListHeaderTextYearFormat
		{
			get { return "{0} " + ListHeaderText; }
		}

		public string ListDateFieldName
		{
			get { return PositionStatementItem.FieldName_Date; }
		}

		public string ListFilterFieldName
		{
			get { return string.Empty; }
		}

		public List<ListItem> ListFilterValues
		{
			get { return new List<ListItem>(); }
		}

		#endregion
	}
}
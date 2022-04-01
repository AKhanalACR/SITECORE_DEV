using System;
using System.Linq;
using ACR.Library.ACR.Content;
using ACR.Library.Search.Indices.Content;
using Sitecore.Collections;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.Widgets.Specific
{
public partial class CurrentBillsWidgetItem 
{
	private List<Item> _currentBills;

	/// <summary>
	/// Will return if this widget has any content to display.
	/// </summary>
	/// <returns>Flag determining if this widget has content.</returns>
	public bool HasContent()
	{
		//if any of our fields are populated then we have content
		if (!string.IsNullOrEmpty(HeaderText.Text))
		{
			return true;
		}

		if(ReturnCurrentBills().Any())
		{
			return true;
		}

		//else return false
		return false;
	}

	public List<Item> ReturnCurrentBills()
	{
		if (_currentBills == null)
			FetchCurrentBills();

		return _currentBills;
	}

	private void FetchCurrentBills()
	{
		// Calculate the Taxonomy of the current page
		// Set the _relatedCourses that have the same taxonomy

		CurrentBillsIndex index = new CurrentBillsIndex();

		SafeDictionary<string> safeDictionary = new SafeDictionary<string>();


		_currentBills = new List<Item>();

		foreach (CurrentBillItem p in index.GetLatestBills())
		{
			Item i = p;
			_currentBills.Add(i);
		}

	}

}
}
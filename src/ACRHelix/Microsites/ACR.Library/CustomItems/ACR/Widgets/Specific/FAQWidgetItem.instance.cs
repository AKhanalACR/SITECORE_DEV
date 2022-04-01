using System;
using System.Linq;
using ACR.Library.ACR.FAQ;
using ACR.Library.Search.Indices.Content;
using Sitecore.Collections;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.Widgets.Specific
{
public partial class FAQWidgetItem
{
	private List<Item> _FAQs;

	/// <summary>
	/// Will return if this widget has any content to display.
	/// </summary>
	/// <returns>Flag determining if this widget has content.</returns>
	public bool HasContent()
	{
		if (ReturnFAQs().Any())
		{
			return true;
		}

		//else return false
		return false;
	}

	public List<Item> ReturnFAQs()
	{
		if (_FAQs == null)
			FetchFAQs();

		return _FAQs;
	}

	private void FetchFAQs()
	{
		// Calculate the Taxonomy of the current page
		// Set the _relatedCourses that have the same taxonomy

		FAQsIndex index = new FAQsIndex();

		_FAQs = new List<Item>();

		foreach (FAQItem p in index.GetFAQsByType(FAQsType.Raw, 5))
		{
			Item i = p;
			_FAQs.Add(i);
		}

	}
}
}
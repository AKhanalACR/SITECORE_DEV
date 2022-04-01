using System;
using System.Linq;
using ACR.Library.ACR.Membership;
using ACR.Library.Search.Indices.Membership;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.Widgets.Specific
{
public partial class ResidentNewsandMeetingsWidgetItem 
{
	private List<Item> _relatedNews;
	private List<Item> _relatedMeetings;

	/// <summary>
	/// Will return if this widget has any content to display.
	/// </summary>
	/// <returns>Flag determining if this widget has content.</returns>
	public bool HasContent()
	{
		if (ReturnRelatedMeetings().Any())
			return true;

		if (ReturnRelatedNews().Any())
			return true;

		return false;
	}



	public List<Item> ReturnRelatedNews()
	{
		if (_relatedNews == null)
			FetchRelatedNews();

		return _relatedNews;
	}

	private void FetchRelatedNews()
	{
		ResidentNewsIndex index = new ResidentNewsIndex();

		_relatedNews = new List<Item>();

		foreach(ResidentFellowsNewsItem r in index.GetLatestNewsArticles(25))
		{
			Item i = r;
			_relatedNews.Add(i);
		}
	}


	public List<Item> ReturnRelatedMeetings()
	{
		if (_relatedMeetings == null)
			FetchRelatedMeetings();

		return _relatedMeetings;
	}

	private void FetchRelatedMeetings()
	{
		ResidentMeetingsIndex index = new ResidentMeetingsIndex();

		_relatedMeetings = new List<Item>();

		foreach(ResidentFellowsMeetingItem r in index.GetLatestMeetings(25))
		{
			Item i = r;
			_relatedMeetings.Add(i);
		}
	}
}
}
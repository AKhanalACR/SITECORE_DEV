using Sitecore.Data.Items;
using System.Collections.Generic;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Xml;
using System.Globalization;


namespace ACR.Library.ACR.Widgets.Specific
{
public partial class RssFeedssWidgetItem : CustomItem
{

    public static readonly string TemplateId = "{F8ABB06B-1021-437D-B78F-5876BC4B65CD}";

#region Inherited Base Templates

private readonly WidgetBaseItem _WidgetBaseItem;
public WidgetBaseItem WidgetBase { get { return _WidgetBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public RssFeedssWidgetItem(Item innerItem)
    : base(innerItem)
{
	_WidgetBaseItem = new WidgetBaseItem(innerItem);

}

public static implicit operator RssFeedssWidgetItem(Item innerItem)
{
    return innerItem != null ? new RssFeedssWidgetItem(innerItem) : null;
}

public static implicit operator Item(RssFeedssWidgetItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Title
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Title"]);
	}
}

public static string FieldName_Title 
{
	get
	{
		return "Title";
	}
} 


public CustomTextField LinkTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Link Title"]);
	}
}

public static string FieldName_LinkTitle 
{
	get
	{
		return "Link Title";
	}
}

public CustomGeneralLinkField RSSFeedLink
{
    get
    {
        return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["RSS Feed Link"]);
    }
}

public static string FieldName_RSSFeedLink
{
    get
    {
        return "RSS Feed Link";
    }
} 
public CustomGeneralLinkField DetailLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Detail Link"]);
	}
}

public static string FieldName_DetailLink 
{
	get
	{
		return "Detail Link";
	}
} 


#endregion //Field Instance Methods

#region Impl
private List<FeedItemModel> _rssFeedItem;

public List<FeedItemModel> ReturnRelatedNews(string url)
{
    if (_rssFeedItem == null)
     FetchRelatedNews(url);

    return _rssFeedItem;
}

private void FetchRelatedNews(string url)
{    
    _rssFeedItem = new List<FeedItemModel>();
    if (Sitecore.Context.Item == null)
    {
        return ;
    }

    XmlReader reader = XmlReader.Create(url);
    SyndicationFeed feed = SyndicationFeed.Load(reader);
    foreach (SyndicationItem item in feed.Items)
    {
        FeedItemModel feedItem = new FeedItemModel();
        {
            feedItem.Title = string.IsNullOrEmpty(item.Title.Text.ToString()) ? "" : item.Title.Text.ToString();
            if (string.IsNullOrEmpty(item.LastUpdatedTime.ToString()) || item.LastUpdatedTime.Date.ToString() == "1/1/0001 12:00:00 AM")
           // {
                //if (item.LastUpdatedTime.Date.ToString() == "1/1/0001 12:00:00 AM")
                feedItem.DatePublished = string.IsNullOrEmpty(item.PublishDate.DateTime.ToString("MMMM dd, yyyy")) ? "" : item.PublishDate.DateTime.ToString("MMMM dd, yyyy");
                else
                feedItem.DatePublished = string.IsNullOrEmpty(item.LastUpdatedTime.DateTime.ToString("MMMM dd, yyyy")) ? "" : item.LastUpdatedTime.DateTime.ToString("MMMM dd, yyyy");
           // }
            //feedItem.DatePublished = string.IsNullOrEmpty(item.LastUpdatedTime.ToString()) ? item.PublishDate.DateTime.ToString("MMMM dd, yyyy") : item.LastUpdatedTime.DateTime.ToString("MMMM dd, yyyy");

            if (item.Links.Count > 0)
                feedItem.Url = string.IsNullOrEmpty(item.Links[0].Uri.ToString()) ? "" : item.Links[0].Uri.ToString();
            else
                feedItem.Url = "";
            if (item.Summary != null)
                feedItem.Desc = string.IsNullOrEmpty(item.Summary.ToString()) ? "" : item.Summary.Text.ToString();
            else
                feedItem.Desc = "";
        }        
        _rssFeedItem.Add(feedItem);
    }
       
}
#endregion
}

public partial class FeedItemModel
{
    string _title;
    string  _datePublished;
    string _url;
    string _desc;
    
#region methods
   public string  Title
{
	get
	{
		return _title;
	}
    set
    {
        _title = value;
    }
}

   public string DatePublished
   {
       get
       {
           return _datePublished;
       }
       set
       {
           _datePublished = value;
       }
   }

   public string Url
   {
       get
       {
           return _url;
       }
       set
       {
           _url = value;
       }
   }

   public string Desc
   {
       get
       {
           return _desc;
       }
       set
       {
           _desc = value;
       }
   } 
#endregion


}

}
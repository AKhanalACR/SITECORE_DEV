using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.RLI.Base;

namespace ACR.Library.RLI.Pages
{
public partial class EventListPageItem : CustomItem
{

public static readonly string TemplateId = "{DDE807D6-3DD0-4667-AD93-913966A48542}";

#region Inherited Base Templates

private readonly NavigationBaseItem _NavigationBaseItem;
public NavigationBaseItem NavigationBase { get { return _NavigationBaseItem; } }
private readonly PageBaseItem _PageBaseItem;
public PageBaseItem PageBase { get { return _PageBaseItem; } }
private readonly BackgroundBaseItem _BackgroundBaseItem;
public BackgroundBaseItem BackgroundBase { get { return _BackgroundBaseItem; } }
private readonly WidgetPageBaseItem _WidgetPageBaseItem;
public WidgetPageBaseItem WidgetPageBase { get { return _WidgetPageBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public EventListPageItem(Item innerItem) : base(innerItem)
{
	_NavigationBaseItem = new NavigationBaseItem(innerItem);
	_PageBaseItem = new PageBaseItem(innerItem);
	_BackgroundBaseItem = new BackgroundBaseItem(innerItem);
	_WidgetPageBaseItem = new WidgetPageBaseItem(innerItem);

}

public static implicit operator EventListPageItem(Item innerItem)
{
	return innerItem != null ? new EventListPageItem(innerItem) : null;
}

public static implicit operator Item(EventListPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomMultiListField EventTypesIncluded
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Event Types Included"]);
	}
}

public static string FieldName_EventTypesIncluded 
{
	get
	{
		return "Event Types Included";
	}
} 


public CustomMultiListField TagsIncluded
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Tags Included"]);
	}
}

public static string FieldName_TagsIncluded 
{
	get
	{
		return "Tags Included";
	}
} 

	public CustomCheckboxField DisplayTags
	{
		get
		{
			return new CustomCheckboxField(InnerItem, InnerItem.Fields["Display Tags"]);
		}
	}

#endregion //Field Instance Methods
}
}
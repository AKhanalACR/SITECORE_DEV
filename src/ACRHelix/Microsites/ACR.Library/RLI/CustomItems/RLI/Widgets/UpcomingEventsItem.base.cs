using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.RLI.Base;

namespace ACR.Library.RLI.Widgets
{
public partial class UpcomingEventsItem : CustomItem
{

public static readonly string TemplateId = "{59928765-98A3-4F82-BEE2-D62CF46C30DE}";

#region Inherited Base Templates

private readonly WidgetBaseItem _WidgetBaseItem;
public WidgetBaseItem WidgetBase { get { return _WidgetBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public UpcomingEventsItem(Item innerItem) : base(innerItem)
{
	_WidgetBaseItem = new WidgetBaseItem(innerItem);

}

public static implicit operator UpcomingEventsItem(Item innerItem)
{
	return innerItem != null ? new UpcomingEventsItem(innerItem) : null;
}

public static implicit operator Item(UpcomingEventsItem customItem)
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


public CustomImageField Icon
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Icon"]);
	}
}

public static string FieldName_Icon 
{
	get
	{
		return "Icon";
	}
} 


public CustomIntegerField NumberofEvents
{
	get
	{
		return new CustomIntegerField(InnerItem, InnerItem.Fields["Number of Events"]);
	}
}

public static string FieldName_NumberofEvents 
{
	get
	{
		return "Number of Events";
	}
} 


public CustomMultiListField EventTypes
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Event Types"]);
	}
}

public static string FieldName_EventTypes 
{
	get
	{
		return "Event Types";
	}
} 


public CustomMultiListField EventTags
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Event Tags"]);
	}
}

public static string FieldName_EventTags 
{
	get
	{
		return "Event Tags";
	}
} 


#endregion //Field Instance Methods
}
}
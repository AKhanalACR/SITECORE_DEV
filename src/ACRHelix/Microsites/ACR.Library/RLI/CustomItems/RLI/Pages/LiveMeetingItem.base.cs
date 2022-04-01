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
public partial class LiveMeetingItem : CustomItem
{

public static readonly string TemplateId = "{1BB91691-F73D-4C17-8ED0-9B28159C1F69}";

#region Inherited Base Templates

private readonly EventBaseItem _EventBaseItem;
public EventBaseItem EventBase { get { return _EventBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public LiveMeetingItem(Item innerItem) : base(innerItem)
{
	_EventBaseItem = new EventBaseItem(innerItem);

}

public static implicit operator LiveMeetingItem(Item innerItem)
{
	return innerItem != null ? new LiveMeetingItem(innerItem) : null;
}

public static implicit operator Item(LiveMeetingItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomDateField EndDate
{
	get
	{
		return new CustomDateField(InnerItem, InnerItem.Fields["End Date"]);
	}
}

public static string FieldName_EndDate 
{
	get
	{
		return "End Date";
	}
} 


public CustomTextField Duration
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Duration"]);
	}
}

public static string FieldName_Duration 
{
	get
	{
		return "Duration";
	}
} 


public CustomTextField Location
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Location"]);
	}
}

public static string FieldName_Location 
{
	get
	{
		return "Location";
	}
} 


#endregion //Field Instance Methods
}
}
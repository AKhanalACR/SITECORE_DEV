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
public partial class ExternalMeetingItem : CustomItem
{

public static readonly string TemplateId = "{78AE2533-A95E-4891-95F8-D6D433CA63E9}";

#region Inherited Base Templates

private readonly EventBaseItem _EventBaseItem;
public EventBaseItem EventBase { get { return _EventBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public ExternalMeetingItem(Item innerItem) : base(innerItem)
{
	_EventBaseItem = new EventBaseItem(innerItem);

}

public static implicit operator ExternalMeetingItem(Item innerItem)
{
	return innerItem != null ? new ExternalMeetingItem(innerItem) : null;
}

public static implicit operator Item(ExternalMeetingItem customItem)
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
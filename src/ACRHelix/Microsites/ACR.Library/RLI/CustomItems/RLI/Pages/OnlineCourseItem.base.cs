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
public partial class OnlineCourseItem : CustomItem
{

public static readonly string TemplateId = "{2F8D268E-BA70-4762-AA22-A7F0ACE28DDA}";

#region Inherited Base Templates

private readonly EventBaseItem _EventBaseItem;
public EventBaseItem EventBase { get { return _EventBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public OnlineCourseItem(Item innerItem) : base(innerItem)
{
	_EventBaseItem = new EventBaseItem(innerItem);

}

public static implicit operator OnlineCourseItem(Item innerItem)
{
	return innerItem != null ? new OnlineCourseItem(innerItem) : null;
}

public static implicit operator Item(OnlineCourseItem customItem)
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


public CustomMultiListField LectureDaysofWeek
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Lecture Days of Week"]);
	}
}

public static string FieldName_LectureDaysofWeek 
{
	get
	{
		return "Lecture Days of Week";
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


public CustomLookupField Timezone
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Timezone"]);
	}
}

public static string FieldName_Timezone 
{
	get
	{
		return "Timezone";
	}
} 


#endregion //Field Instance Methods
}
}
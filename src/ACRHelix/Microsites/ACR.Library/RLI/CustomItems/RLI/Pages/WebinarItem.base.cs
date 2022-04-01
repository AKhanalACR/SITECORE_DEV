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
public partial class WebinarItem : CustomItem
{

public static readonly string TemplateId = "{207A95C3-1E65-4FF8-AE36-3B8E2383DE5B}";

#region Inherited Base Templates

private readonly EventBaseItem _EventBaseItem;
public EventBaseItem EventBase { get { return _EventBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public WebinarItem(Item innerItem) : base(innerItem)
{
	_EventBaseItem = new EventBaseItem(innerItem);

}

public static implicit operator WebinarItem(Item innerItem)
{
	return innerItem != null ? new WebinarItem(innerItem) : null;
}

public static implicit operator Item(WebinarItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


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


#endregion //Field Instance Methods
}
}
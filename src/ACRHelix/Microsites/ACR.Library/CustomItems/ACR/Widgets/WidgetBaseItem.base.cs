using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.ACR.Widgets
{
public partial class WidgetBaseItem : CustomItem
{

public static readonly string TemplateId = "{35E2AC5A-C5F8-4557-9074-039FED6991F6}";


#region Boilerplate CustomItem Code

public WidgetBaseItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator WidgetBaseItem(Item innerItem)
{
	return innerItem != null ? new WidgetBaseItem(innerItem) : null;
}

public static implicit operator Item(WidgetBaseItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomLookupField AssociatedSublayout
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Associated Sublayout"]);
	}
}

public static string FieldName_AssociatedSublayout 
{
	get
	{
		return "Associated Sublayout";
	}
} 


public CustomLookupField DisplayWhen
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Display When"]);
	}
}

public static string FieldName_DisplayWhen 
{
	get
	{
		return "Display When";
	}
} 


#endregion //Field Instance Methods
}
}
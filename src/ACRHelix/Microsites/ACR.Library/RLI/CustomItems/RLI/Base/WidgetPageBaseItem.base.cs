using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.RLI.Base
{
public partial class WidgetPageBaseItem : CustomItem
{

public static readonly string TemplateId = "{A0EED37E-0AD5-4E99-955A-06F5149E3D78}";


#region Boilerplate CustomItem Code

public WidgetPageBaseItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator WidgetPageBaseItem(Item innerItem)
{
	return innerItem != null ? new WidgetPageBaseItem(innerItem) : null;
}

public static implicit operator Item(WidgetPageBaseItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTreeListField RightRailWidgets
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Right Rail Widgets"]);
	}
}

public static string FieldName_RightRailWidgets 
{
	get
	{
		return "Right Rail Widgets";
	}
} 


#endregion //Field Instance Methods
}
}
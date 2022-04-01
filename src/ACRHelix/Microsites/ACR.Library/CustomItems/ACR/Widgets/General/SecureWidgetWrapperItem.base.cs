using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.ACR.Widgets;

namespace ACR.Library.ACR.Widgets.General
{
public partial class SecureWidgetWrapperItem : CustomItem
{

public static readonly string TemplateId = "{6E194B4C-5A74-485E-879D-7ABA8061F32B}";

#region Inherited Base Templates

private readonly WidgetBaseItem _WidgetBaseItem;
public WidgetBaseItem WidgetBase { get { return _WidgetBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public SecureWidgetWrapperItem(Item innerItem) : base(innerItem)
{
	_WidgetBaseItem = new WidgetBaseItem(innerItem);

}

public static implicit operator SecureWidgetWrapperItem(Item innerItem)
{
	return innerItem != null ? new SecureWidgetWrapperItem(innerItem) : null;
}

public static implicit operator Item(SecureWidgetWrapperItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomLookupField Widget
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Widget"]);
	}
}

public static string FieldName_Widget 
{
	get
	{
		return "Widget";
	}
} 

#endregion //Field Instance Methods
}
}
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
public partial class WidgetBaseItem : CustomItem
{

public static readonly string TemplateId = "{6B041EE2-07CB-406D-919D-39FC0A2C53F3}";


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


#endregion //Field Instance Methods
}
}
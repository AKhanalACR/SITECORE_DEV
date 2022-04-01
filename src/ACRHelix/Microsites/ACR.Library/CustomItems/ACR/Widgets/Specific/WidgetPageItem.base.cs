using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.ACR.Base
{
public partial class WidgetPageItem : CustomItem
{

public static readonly string TemplateId = "{A6D30386-2CA5-49DD-BDFD-61E249F52A45}";


#region Boilerplate CustomItem Code

public WidgetPageItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator WidgetPageItem(Item innerItem)
{
	return innerItem != null ? new WidgetPageItem(innerItem) : null;
}

public static implicit operator Item(WidgetPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomMultiListField Widgets
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Widgets"]);
	}
}


#endregion //Field Instance Methods
}
}